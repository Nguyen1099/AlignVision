namespace AlignVision
{
    partial class CFormSetup
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
            this.panelFormManu = new System.Windows.Forms.Panel();
            this.panelFormView = new System.Windows.Forms.Panel();
            this.btnBase = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelFormManu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormManu
            // 
            this.panelFormManu.Controls.Add(this.btnBase);
            this.panelFormManu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormManu.Location = new System.Drawing.Point(0, 0);
            this.panelFormManu.Name = "panelFormManu";
            this.panelFormManu.Size = new System.Drawing.Size(1656, 40);
            this.panelFormManu.TabIndex = 0;
            // 
            // panelFormView
            // 
            this.panelFormView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormView.Location = new System.Drawing.Point(0, 40);
            this.panelFormView.Name = "panelFormView";
            this.panelFormView.Size = new System.Drawing.Size(1656, 983);
            this.panelFormView.TabIndex = 1;
            // 
            // btnBase
            // 
            this.btnBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBase.Location = new System.Drawing.Point(12, 6);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(70, 28);
            this.btnBase.TabIndex = 0;
            this.btnBase.Text = "Base";
            this.btnBase.UseVisualStyleBackColor = true;
            // 
            // CFormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1656, 1023);
            this.Controls.Add(this.panelFormView);
            this.Controls.Add(this.panelFormManu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CFormConfig";
            this.panelFormManu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormManu;
        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.Panel panelFormView;
        private System.Windows.Forms.Timer timer;
    }
}