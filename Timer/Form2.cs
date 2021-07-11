using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimerTool
{
    public partial class FormAddTimer : Form
    {
        private FormTimerMenu f1 = null;
        private Timer t = null;
        private Color c = null;
        private bool editingMode = false;

        public FormAddTimer(FormTimerMenu f1)
        {
            InitializeComponent();
            this.f1 = f1;
            SetColors();
            CbTimerColor.SelectedItem = f1.Colors.FirstOrDefault().Key;
            TbAddTimerName.Text = string.Format("Timer{0}", f1.addedTimers.Count + 1);
        }

        public FormAddTimer(Timer t, FormTimerMenu f1)
        {
            InitializeComponent();
            this.t = t;
            this.f1 = f1;
            SetColors();
            TbAddTimerName.Text = t.Name;
            NudAddTimerHours.Value = t.Hours;
            NudAddTimerMinutes.Value = t.Minutes;
            NudAddTimerSeconds.Value = t.Seconds;
            CbTimerColor.SelectedItem = f1.Colors.FirstOrDefault(Color => Color.Value.R == t.Color.R && Color.Value.G == t.Color.G && Color.Value.B == t.Color.B).Key;

            this.Text = "Edit timer";
            editingMode = true;
        }

        private void SetColors()
        {
            foreach (var s in f1.Colors)
            {
                CbTimerColor.Items.Add(s.Key);
            }
        }

        private void BtnAddTimerConfirm_Click(object sender, EventArgs e)
        {
            if (NudAddTimerHours.Value == 0 || NudAddTimerMinutes.Value == 0 || NudAddTimerSeconds.Value == 0)
            {
                if (editingMode)
                {
                    if (TbAddTimerName.Text == t.Name)
                    {
                        t.Hours = (int)NudAddTimerHours.Value;
                        t.Minutes = (int)NudAddTimerMinutes.Value;
                        t.Seconds = (int)NudAddTimerSeconds.Value;
                        t.HoursInit = (int)NudAddTimerHours.Value;
                        t.MinutesInit = (int)NudAddTimerMinutes.Value;
                        t.SecondsInit = (int)NudAddTimerSeconds.Value;
                        t.Color = c;

                        this.Close();
                        f1.AddedTimersRefresh();

                        return;
                    }
                    else
                    {
                        f1.addedTimers.Remove(f1.addedTimers.Find(Timer => Timer.Name == t.Name));
                    }
                }

                if (f1.addedTimers.Find(Timer => Timer.Name == TbAddTimerName.Text) != null)
                {
                    MessageBox.Show("Timer using this name already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    f1.addedTimers.Add(new Timer(TbAddTimerName.Text, (int)NudAddTimerHours.Value, (int)NudAddTimerMinutes.Value, (int)NudAddTimerSeconds.Value, c));

                    this.Close();
                    f1.AddedTimersRefresh();
                }
            }
            else
            {
                MessageBox.Show("No countdown given!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAddTimerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            f1.AddedTimersRefresh();
        }

        private void CbTimerColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            c = new Color(f1.Colors[CbTimerColor.SelectedItem.ToString()].R,
                f1.Colors[CbTimerColor.SelectedItem.ToString()].G,
                f1.Colors[CbTimerColor.SelectedItem.ToString()].B);

            LblTimerColor.BackColor = System.Drawing.Color.FromArgb(
                c.R,
                c.G,
                c.B);
        }
    }
}
