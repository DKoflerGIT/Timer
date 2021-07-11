
using System.Drawing;
using System.Windows.Forms;

namespace TimerTool
{
    partial class FormTimerMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTimerMenu));
            this.BtnNewTimer = new System.Windows.Forms.Button();
            this.LblVersion = new System.Windows.Forms.Label();
            this.PanAddedTimers = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BtnNewTimer
            // 
            this.BtnNewTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNewTimer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnNewTimer.Location = new System.Drawing.Point(12, 12);
            this.BtnNewTimer.Name = "BtnNewTimer";
            this.BtnNewTimer.Size = new System.Drawing.Size(30, 30);
            this.BtnNewTimer.TabIndex = 0;
            this.BtnNewTimer.UseVisualStyleBackColor = true;
            this.BtnNewTimer.Click += new System.EventHandler(this.BtnNewTimerClick);
            // 
            // LblVersion
            // 
            this.LblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblVersion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblVersion.Location = new System.Drawing.Point(848, 12);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(124, 18);
            this.LblVersion.TabIndex = 2;
            this.LblVersion.Text = "label1";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanAddedTimers
            // 
            this.PanAddedTimers.Location = new System.Drawing.Point(12, 48);
            this.PanAddedTimers.Name = "PanAddedTimers";
            this.PanAddedTimers.Size = new System.Drawing.Size(960, 901);
            this.PanAddedTimers.TabIndex = 3;
            // 
            // FormTimerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.PanAddedTimers);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnNewTimer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTimerMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer";
            this.SizeChanged += new System.EventHandler(this.FormTimerMenu_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNewTimer;
        private System.Windows.Forms.GroupBox GbTimer;
        private System.Windows.Forms.Label LblTimerTime;
        private System.Windows.Forms.Label LblTimerColor;
        private System.Windows.Forms.Button BtnTimerDelete;
        private System.Windows.Forms.Button BtnTimerEdit;
        private System.Windows.Forms.Button BtnTimerStart;
        private System.Windows.Forms.Button BtnTimerPause;
        private System.Windows.Forms.Button BtnTimerReset;
        private Label LblVersion;
        private Panel PanAddedTimers;
        private Panel PanTimer;
    }
}

