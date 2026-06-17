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
            this.uiRichTextBox = new Sunny.UI.UIRichTextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            this.uiProcessBar.RectColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uiProcessBar.Size = new System.Drawing.Size(600, 34);
            this.uiProcessBar.TabIndex = 0;
            this.uiProcessBar.Text = "aaaaa";
            this.uiProcessBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblProgress.Location = new System.Drawing.Point(12, 390);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(320, 23);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "uiLabel1";
            // 
            // uiRichTextBox
            // 
            this.uiRichTextBox.FillColor = System.Drawing.SystemColors.Control;
            this.uiRichTextBox.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.uiRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox.Name = "uiRichTextBox";
            this.uiRichTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox.RectColor = System.Drawing.Color.Black;
            this.uiRichTextBox.ShowText = false;
            this.uiRichTextBox.Size = new System.Drawing.Size(332, 385);
            this.uiRichTextBox.TabIndex = 3;
            this.uiRichTextBox.Text = "uiRichTextBox1";
            this.uiRichTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Image = global::AlignVision.Properties.Resources.vision;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(329, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(271, 385);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // CDialogInitProgramIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.uiRichTextBox);
            this.Controls.Add(this.uiProcessBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CDialogInitProgramIntro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CDialogInitProgramIntro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIProcessBar uiProcessBar;
        private Sunny.UI.UILabel lblProgress;
        private Sunny.UI.UIRichTextBox uiRichTextBox;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}