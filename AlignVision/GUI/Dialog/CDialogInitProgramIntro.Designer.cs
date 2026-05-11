namespace AlignVision
{
    partial class CDialogInitProgramIntro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDialogInitProgramIntro));
            this.uiProcessBar = new Sunny.UI.UIProcessBar();
            this.lblProgress = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiProcessBar
            // 
            this.uiProcessBar.BackColor = System.Drawing.Color.Black;
            this.uiProcessBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiProcessBar.FillColor = System.Drawing.SystemColors.Control;
            this.uiProcessBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiProcessBar.ForeColor = System.Drawing.Color.Black;
            this.uiProcessBar.Location = new System.Drawing.Point(0, 416);
            this.uiProcessBar.MinimumSize = new System.Drawing.Size(3, 3);
            this.uiProcessBar.Name = "uiProcessBar";
            this.uiProcessBar.RectColor = System.Drawing.Color.LimeGreen;
            this.uiProcessBar.Size = new System.Drawing.Size(600, 34);
            this.uiProcessBar.TabIndex = 0;
            this.uiProcessBar.Text = "aaaaa";
            this.uiProcessBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblProgress.Location = new System.Drawing.Point(12, 390);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(115, 23);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "uiLabel1";
            // 
            // CDialogInitProgramIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.uiProcessBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CDialogInitProgramIntro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intro";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIProcessBar uiProcessBar;
        private Sunny.UI.UILabel lblProgress;
    }
}