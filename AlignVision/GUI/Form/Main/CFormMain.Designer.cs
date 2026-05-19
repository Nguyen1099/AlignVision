namespace AlignVision
{
    partial class CFormMain
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelFormView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelFormView
            // 
            this.panelFormView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormView.Location = new System.Drawing.Point(0, 0);
            this.panelFormView.Name = "panelFormView";
            this.panelFormView.Size = new System.Drawing.Size(1656, 1023);
            this.panelFormView.TabIndex = 1;
            // 
            // CFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1656, 1023);
            this.Controls.Add(this.panelFormView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CFormConfig";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CFormMain_FormClosed);
            this.Load += new System.EventHandler(this.CFormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelFormView;
        private System.Windows.Forms.Timer timer;
    }
}