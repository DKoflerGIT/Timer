
namespace TimerTool
{
    partial class FormAddTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddTimer));
            this.label7 = new System.Windows.Forms.Label();
            this.TbAddTimerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NudAddTimerSeconds = new System.Windows.Forms.NumericUpDown();
            this.NudAddTimerMinutes = new System.Windows.Forms.NumericUpDown();
            this.NudAddTimerHours = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAddTimerConfirm = new System.Windows.Forms.Button();
            this.BtnAddTimerCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CbTimerColor = new System.Windows.Forms.ComboBox();
            this.LblTimerColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NudAddTimerSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAddTimerMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAddTimerHours)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Color:";
            // 
            // TbAddTimerName
            // 
            this.TbAddTimerName.Location = new System.Drawing.Point(94, 12);
            this.TbAddTimerName.Name = "TbAddTimerName";
            this.TbAddTimerName.Size = new System.Drawing.Size(246, 23);
            this.TbAddTimerName.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "h";
            // 
            // NudAddTimerSeconds
            // 
            this.NudAddTimerSeconds.Location = new System.Drawing.Point(260, 57);
            this.NudAddTimerSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NudAddTimerSeconds.Name = "NudAddTimerSeconds";
            this.NudAddTimerSeconds.Size = new System.Drawing.Size(50, 23);
            this.NudAddTimerSeconds.TabIndex = 16;
            // 
            // NudAddTimerMinutes
            // 
            this.NudAddTimerMinutes.Location = new System.Drawing.Point(170, 56);
            this.NudAddTimerMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NudAddTimerMinutes.Name = "NudAddTimerMinutes";
            this.NudAddTimerMinutes.Size = new System.Drawing.Size(50, 23);
            this.NudAddTimerMinutes.TabIndex = 15;
            this.NudAddTimerMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NudAddTimerHours
            // 
            this.NudAddTimerHours.Location = new System.Drawing.Point(94, 56);
            this.NudAddTimerHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.NudAddTimerHours.Name = "NudAddTimerHours";
            this.NudAddTimerHours.Size = new System.Drawing.Size(50, 23);
            this.NudAddTimerHours.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Timer name:";
            // 
            // BtnAddTimerConfirm
            // 
            this.BtnAddTimerConfirm.Location = new System.Drawing.Point(265, 142);
            this.BtnAddTimerConfirm.Name = "BtnAddTimerConfirm";
            this.BtnAddTimerConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnAddTimerConfirm.TabIndex = 22;
            this.BtnAddTimerConfirm.Text = "OK";
            this.BtnAddTimerConfirm.UseVisualStyleBackColor = true;
            this.BtnAddTimerConfirm.Click += new System.EventHandler(this.BtnAddTimerConfirm_Click);
            this.BtnAddTimerConfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnAddTimerConfirm_Click);
            // 
            // BtnAddTimerCancel
            // 
            this.BtnAddTimerCancel.Location = new System.Drawing.Point(179, 142);
            this.BtnAddTimerCancel.Name = "BtnAddTimerCancel";
            this.BtnAddTimerCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnAddTimerCancel.TabIndex = 22;
            this.BtnAddTimerCancel.Text = "Cancel";
            this.BtnAddTimerCancel.UseVisualStyleBackColor = true;
            this.BtnAddTimerCancel.Click += new System.EventHandler(this.BtnAddTimerCancel_Click);
            // 
            // CbTimerColor
            // 
            this.CbTimerColor.FormattingEnabled = true;
            this.CbTimerColor.Location = new System.Drawing.Point(94, 97);
            this.CbTimerColor.Name = "CbTimerColor";
            this.CbTimerColor.Size = new System.Drawing.Size(121, 23);
            this.CbTimerColor.TabIndex = 23;
            this.CbTimerColor.SelectedIndexChanged += new System.EventHandler(this.CbTimerColor_SelectedIndexChanged);
            // 
            // LblTimerColor
            // 
            this.LblTimerColor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblTimerColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTimerColor.Location = new System.Drawing.Point(221, 95);
            this.LblTimerColor.Name = "LblTimerColor";
            this.LblTimerColor.Size = new System.Drawing.Size(25, 25);
            this.LblTimerColor.TabIndex = 24;
            // 
            // FormAddTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 181);
            this.Controls.Add(this.LblTimerColor);
            this.Controls.Add(this.CbTimerColor);
            this.Controls.Add(this.BtnAddTimerCancel);
            this.Controls.Add(this.BtnAddTimerConfirm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbAddTimerName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NudAddTimerSeconds);
            this.Controls.Add(this.NudAddTimerMinutes);
            this.Controls.Add(this.NudAddTimerHours);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddTimer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Timer";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.NudAddTimerSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAddTimerMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAddTimerHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TbAddTimerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudAddTimerSeconds;
        private System.Windows.Forms.NumericUpDown NudAddTimerMinutes;
        private System.Windows.Forms.NumericUpDown NudAddTimerHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAddTimerConfirm;
        private System.Windows.Forms.Button BtnAddTimerCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox CbTimerColor;
        private System.Windows.Forms.Label LblTimerColor;
    }
}