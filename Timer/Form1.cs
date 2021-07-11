using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TimerTool
{
    public partial class FormTimerMenu : Form
    {
        private delegate void SafeCallDelegate(Label l, string s); //Used for the TimerLoop Thread (https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8)
        public readonly List<Timer> addedTimers = new List<Timer> { };
        private FormAddTimer f = null;
        private int maxTimerCount = 10;

        public readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            ["Blue"] = new Color(149, 170, 255),
            ["Green"] = new Color(149, 255, 163),
            ["Yellow"] = new Color(255, 250, 149),
            ["Purple"] = new Color(205, 149, 255),
            ["Red"] = new Color(255, 149, 152)
        };

        public FormTimerMenu()
        {
            InitializeComponent();

            //Set some control elements
            LblVersion.Text = string.Format("Version {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            PanAddedTimers.Width = this.Width - 20;
            PanAddedTimers.Height = this.Height - 50 - 20;
            this.Text = "Timer";

            BtnNewTimer.Text = "";
            BtnNewTimer.BackgroundImage = Image.FromFile(Program.resourcePath + "add.png");
            BtnNewTimer.BackgroundImageLayout = ImageLayout.Stretch;
            BtnNewTimer.FlatStyle = FlatStyle.Flat;
            BtnNewTimer.FlatAppearance.BorderSize = 0;

            //Default timers, testcases:
            addedTimers.Add(new Timer("Pause kurz", 0, 5, 0, Colors["Red"]));
            addedTimers.Add(new Timer("Pause mittel", 0, 10, 0, Colors["Blue"]));
            addedTimers.Add(new Timer("Pause lang", 0, 15, 0, Colors["Green"]));
            addedTimers.Add(new Timer("TestTimer", 0, 0, 5, Colors["Purple"]));
            //addedTimers.Add(new Timer("Timer5", 1, 2, 35, Colors["Red"]));

            AddedTimersRefresh();
        }

        private void BtnNewTimerClick(object sender, EventArgs e)
        {
            if (addedTimers.Count >= maxTimerCount)
            {
                MessageBox.Show("Maximum number of timers reached.\nDelete one or more timers before adding more.", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                f = new FormAddTimer(this);
                f.Show();
            }
        }

        private void BtnTimerStartClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string currentTimerName = btn.Name.Substring(13);
            var currentTimerObject = addedTimers.FirstOrDefault(Timer => Timer.Name == currentTimerName);

            if (!currentTimerObject.running)
            {
                currentTimerObject.reset = false;
                currentTimerObject.pause = false;
                currentTimerObject.running = true;
                
                currentTimerObject.TimerButtons.FirstOrDefault(BtnTimerStart => BtnTimerStart.Name == "BtnTimerStart" + currentTimerName).Visible = false;
                currentTimerObject.TimerButtons.FirstOrDefault(BtnTimerPause => BtnTimerPause.Name == "BtnTimerPause" + currentTimerName).Visible = true;
                currentTimerObject.TimerButtons.FirstOrDefault(BtnTimerReset => BtnTimerReset.Name == "BtnTimerReset" + currentTimerName).Enabled = false;

                new Thread(() => { TimerLoop(currentTimerObject); }).Start();
            }
        }

        private void TimerLoop(Timer t) //runs a loop that counts down a timer, currently in same thread. Looped can not yet be paused. Needs multithreading to work.
        {
            uint totalSeconds = (uint)(t.Hours * 3600 + t.Minutes * 60 + t.Seconds);

            do
            {
                System.Threading.Thread.Sleep(1000);
                if (!t.pause)
                {
                    if (t.Seconds > 0)
                    {
                        t.Seconds--;
                    }
                    else if (t.Minutes > 0)
                    {
                        t.Minutes--;
                        t.Seconds = 59;
                    }
                    else if (t.Hours > 0)
                    {
                        t.Hours--;
                        t.Minutes = 59;
                        t.Seconds = 59;
                    }

                    var timerLabel = t.TimerLabels.FirstOrDefault(Label => Label.Name == "LblTimer" + t.Name);
                    var labelText = (t.Hours > 0 ? t.Hours.ToString("D2") + ":" : "") + t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2");
                    TimerLabelRefresh(timerLabel, labelText);
                    totalSeconds--;
                }
            } while (totalSeconds > 0 && !t.pause && !t.reset);

            t.running = false;

            if (totalSeconds == 0)
            {
                Ring();
            }
        }

        private void Ring() //Creates a ringing sound
        {
            string wav = "..\\..\\..\\Timer\\ring.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(wav);

            try
            {
                player.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("ring-ring! (could not play soundfile)");
            }
        }

        private void TimerLabelRefresh(Label timerLabel, string labelText) //refreshes the displayed time label
        {
            if (timerLabel.InvokeRequired) //invoke method required when multithreading
            {
                timerLabel.Invoke(new SafeCallDelegate(TimerLabelRefresh), new object[] { timerLabel, labelText });
            }
            else
            {
                timerLabel.Text = labelText;
            }
        }

        private void BtnTimerPauseClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string currentTimerName = btn.Name.Substring(13);

            var currentTimerObject = addedTimers.FirstOrDefault(Timer => Timer.Name == currentTimerName);

            currentTimerObject.TimerButtons.FirstOrDefault(BtnTimerStart => BtnTimerStart.Name == "BtnTimerStart" + currentTimerName).Visible = true;
            currentTimerObject.TimerButtons.FirstOrDefault(BtnTimerPause => BtnTimerPause.Name == "BtnTimerPause" + currentTimerName).Visible = false;
            currentTimerObject.TimerButtons.FirstOrDefault(BtnTimerReset => BtnTimerReset.Name == "BtnTimerReset" + currentTimerName).Enabled = true;

            currentTimerObject.pause = true;
        }

        private void BtnTimerDeleteClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string currenTimerName = btn.Name.Substring(14);

            addedTimers.Remove(addedTimers.FirstOrDefault(Timer => Timer.Name == currenTimerName));
            AddedTimersRefresh();
        }

        private void BtnTimerResetClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string currenTimerName = btn.Name.Substring(13);

            var currentTimerObject = addedTimers.FirstOrDefault(Timer => Timer.Name == currenTimerName);

            currentTimerObject.reset = true;

            currentTimerObject.Hours = currentTimerObject.HoursInit;
            currentTimerObject.Minutes = currentTimerObject.MinutesInit;
            currentTimerObject.Seconds = currentTimerObject.SecondsInit;

            AddedTimersRefresh();
        }

        private void BtnTimerEditClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string currenTimerName = btn.Name.Substring(12);

            new FormAddTimer(addedTimers.FirstOrDefault(Timer => Timer.Name == currenTimerName), this).Show();
        }

        public void AddedTimersRefresh() //Clears the main panel and refills it with timer object panels
        {
            int posX = 10, posXDefault = 10, posY = 10, posYDefault = 10, sizeX = 256, sizeY = 256, c = 1;

            PanAddedTimers.Controls.Clear();

            foreach (var timer in addedTimers)
            {
                if (posX + 256 + 10 > PanAddedTimers.Width && c > 1)
                {
                    posX = posXDefault;
                    posY += sizeY + posYDefault;
                }

                CreateTimerVisual(posX, posY, sizeX, sizeY, timer);
                posX += sizeX + posXDefault;
                c++;
            }
        }

        private void CreateTimerVisual(int x, int y, int sx, int sy, Timer t) //Creates a panel filled with elemets for a timer-object
        {
            t.TimerButtons.Clear();
            t.TimerLabels.Clear();

            PanTimer = new Panel();
            PanAddedTimers.Controls.Add(PanTimer);
            PanTimer.Location = new System.Drawing.Point(x, y);
            PanTimer.Name = "PanTimer" + t.Name;
            PanTimer.Size = new Size(sx, sy);
            PanTimer.TabIndex = 10;
            PanTimer.TabStop = false;
            PanTimer.Text = "";
            PanTimer.BorderStyle = BorderStyle.None;
            t.TimerPanel = PanTimer;
            PanTimer.BackColor = System.Drawing.Color.FromArgb(50, t.Color.R, t.Color.G, t.Color.B);

            #region Label Time

            LblTimerTime = new Label();
            LblTimerTime.Font = new Font("Calibri", 36F, FontStyle.Bold, GraphicsUnit.Point);
            LblTimerTime.Size = new Size(sx - 20, 50);
            LblTimerTime.Location = new Point(PanTimer.Size.Width / 2 - LblTimerTime.Size.Width / 2, PanTimer.Size.Height / 3 - LblTimerTime.Size.Height / 2);
            LblTimerTime.Name = "LblTimer" + t.Name; ;
            LblTimerTime.TabIndex = 10;
            LblTimerTime.Text = (t.Hours > 0 ? t.Hours.ToString("D2") + ":" : "") + t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2");
            LblTimerTime.TextAlign = ContentAlignment.MiddleCenter;
            LblTimerTime.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
            PanTimer.Controls.Add(LblTimerTime);
            t.TimerLabels.Add(LblTimerTime);

            #endregion

            #region Button Start

            BtnTimerStart = new Button();
            BtnTimerStart.Font = new Font("Calibri", 20F);
            BtnTimerStart.TextAlign = ContentAlignment.MiddleCenter;
            BtnTimerStart.Name = "BtnTimerStart" + t.Name; ;
            BtnTimerStart.Size = new Size(50, 50);
            BtnTimerStart.Location = new Point(PanTimer.Size.Width / 3 - BtnTimerStart.Size.Width / 2, PanTimer.Size.Height / 3 * 2 - BtnTimerStart.Size.Height / 2);
            BtnTimerStart.TabIndex = 1;

            BtnTimerStart.Text = "";
            BtnTimerStart.BackgroundImage = Image.FromFile(Program.resourcePath + "play.png");
            BtnTimerStart.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTimerStart.FlatStyle = FlatStyle.Flat;
            BtnTimerStart.FlatAppearance.BorderSize = 0;
            BtnTimerStart.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);

            BtnTimerStart.Click += new EventHandler(BtnTimerStartClick);
            PanTimer.Controls.Add(BtnTimerStart);
            t.TimerButtons.Add(BtnTimerStart);

            if (t.running) BtnTimerStart.Visible = false;
            else BtnTimerStart.Visible = true;

            #endregion

            #region Button Pause

            BtnTimerPause = new Button();
            BtnTimerPause.Font = new Font("Calibri", 20F);
            BtnTimerPause.TextAlign = ContentAlignment.MiddleCenter;
            BtnTimerPause.Name = "BtnTimerPause" + t.Name; ;
            BtnTimerPause.Size = new Size(50, 50);
            BtnTimerPause.Location = new Point(PanTimer.Size.Width / 3 - BtnTimerPause.Size.Width / 2, PanTimer.Size.Height / 3 * 2 - BtnTimerPause.Size.Height / 2);
            BtnTimerPause.TabIndex = 1;

            BtnTimerPause.Text = "";
            BtnTimerPause.BackgroundImage = Image.FromFile(Program.resourcePath + "pause.png");
            BtnTimerPause.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTimerPause.FlatStyle = FlatStyle.Flat;
            BtnTimerPause.FlatAppearance.BorderSize = 0;
            BtnTimerPause.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);

            BtnTimerPause.Click += new EventHandler(BtnTimerPauseClick);
            PanTimer.Controls.Add(BtnTimerPause);
            t.TimerButtons.Add(BtnTimerPause);

            if (t.running) BtnTimerPause.Visible = true;
            else BtnTimerPause.Visible = false;

            #endregion

            #region Button Reset

            BtnTimerReset = new Button();
            BtnTimerReset.Font = new Font("Calibri", 20F);
            BtnTimerReset.TextAlign = ContentAlignment.MiddleCenter;
            BtnTimerReset.Name = "BtnTimerReset" + t.Name; ;
            BtnTimerReset.Size = new Size(50, 50);
            BtnTimerReset.Location = new Point(PanTimer.Size.Width / 3 * 2 - BtnTimerReset.Size.Width / 2, PanTimer.Size.Height / 3 * 2 - BtnTimerReset.Size.Height / 2);
            BtnTimerReset.TabIndex = 1;

            BtnTimerReset.Text = "";
            BtnTimerReset.BackgroundImage = Image.FromFile(Program.resourcePath + "reset.png");
            BtnTimerReset.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTimerReset.FlatStyle = FlatStyle.Flat;
            BtnTimerReset.FlatAppearance.BorderSize = 0;
            BtnTimerReset.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);

            BtnTimerReset.Click += new EventHandler(BtnTimerResetClick);
            PanTimer.Controls.Add(BtnTimerReset);
            t.TimerButtons.Add(BtnTimerReset);

            #endregion

            #region Button Delete

            BtnTimerDelete = new Button();
            BtnTimerDelete.Font = new Font("Calibri", 10F);
            BtnTimerDelete.TextAlign = ContentAlignment.MiddleCenter;
            BtnTimerDelete.Name = "BtnTimerDelete" + t.Name; ;
            BtnTimerDelete.Size = new Size(25, 25);
            BtnTimerDelete.Location = new Point(PanTimer.Size.Width - BtnTimerDelete.Size.Width - 10, 15);
            BtnTimerDelete.TabIndex = 1;

            BtnTimerDelete.Text = "";
            BtnTimerDelete.BackgroundImage = Image.FromFile(Program.resourcePath + "delete.png");
            BtnTimerDelete.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTimerDelete.FlatStyle = FlatStyle.Flat;
            BtnTimerDelete.FlatAppearance.BorderSize = 0;
            BtnTimerDelete.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);

            BtnTimerDelete.Click += new EventHandler(BtnTimerDeleteClick);
            PanTimer.Controls.Add(BtnTimerDelete);
            t.TimerButtons.Add(BtnTimerDelete);

            #endregion

            #region Button Edit

            BtnTimerEdit = new Button();
            BtnTimerEdit.Font = new Font("Calibri", 10F);
            BtnTimerEdit.TextAlign = ContentAlignment.MiddleCenter;
            BtnTimerEdit.Name = "BtnTimerEdit" + t.Name; ;
            BtnTimerEdit.Size = new Size(25, 25);
            BtnTimerEdit.Location = new Point(PanTimer.Size.Width - BtnTimerDelete.Size.Width - BtnTimerDelete.Size.Width - 20, 15);
            BtnTimerEdit.TabIndex = 1;

            BtnTimerEdit.Text = "";
            BtnTimerEdit.BackgroundImage = Image.FromFile(Program.resourcePath + "edit.png");
            BtnTimerEdit.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTimerEdit.FlatStyle = FlatStyle.Flat;
            BtnTimerEdit.FlatAppearance.BorderSize = 0;
            BtnTimerEdit.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);

            BtnTimerEdit.Click += new EventHandler(BtnTimerEditClick);
            PanTimer.Controls.Add(BtnTimerEdit);
            t.TimerButtons.Add(BtnTimerEdit);

            #endregion

            #region Label Color

            LblTimerColor = new Label();
            LblTimerColor.Size = new Size(BtnTimerEdit.Location.X - 20, 25);
            LblTimerColor.Font = new Font("Calibri", 16F, FontStyle.Bold, GraphicsUnit.Point);
            LblTimerColor.TextAlign = ContentAlignment.MiddleLeft;
            LblTimerColor.Location = new Point(10, 15);
            LblTimerColor.Name = "LblTimerColor" + t.Name; ;
            LblTimerColor.Text = t.Name;
            LblTimerColor.BackColor = System.Drawing.Color.FromArgb(t.Color.R, t.Color.G, t.Color.B);
            PanTimer.Controls.Add(LblTimerColor);
            t.TimerLabels.Add(LblTimerColor);

            #endregion
        }

        private void FormTimerMenu_SizeChanged(object sender, EventArgs e)
        {
            PanAddedTimers.Width = this.Width - 40;
            PanAddedTimers.Height = this.Height - 100;
            AddedTimersRefresh();
        }
    }
}