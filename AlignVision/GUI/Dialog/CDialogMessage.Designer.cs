namespace AlignVision
{
    partial class CDialogMessage
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
            this.btnNo = new Sunny.UI.UISymbolButton();
            this.btnYes = new Sunny.UI.UISymbolButton();
            this.TextBoxAlarmCode = new System.Windows.Forms.TextBox();
            this.TextBoxTitleAlarmType = new System.Windows.Forms.TextBox();
            this.TextBoxAlarmTime = new System.Windows.Forms.TextBox();
            this.TextBoxTitleAlarmTime = new System.Windows.Forms.TextBox();
            this.TextBoxTitleAlarmCode = new System.Windows.Forms.TextBox();
            this.TextBoxTitleAlarmDescription = new System.Windows.Forms.TextBox();
            this.RichTextBoxAlarmDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FillColor = System.Drawing.Color.OrangeRed;
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNo.Location = new System.Drawing.Point(694, 541);
            this.btnNo.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNo.Name = "btnNo";
            this.btnNo.RectPressColor = System.Drawing.Color.Red;
            this.btnNo.Size = new System.Drawing.Size(131, 50);
            this.btnNo.Symbol = 61453;
            this.btnNo.SymbolSize = 40;
            this.btnNo.TabIndex = 15;
            this.btnNo.Text = "CANCEL";
            this.btnNo.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.FillColor = System.Drawing.Color.Blue;
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(557, 541);
            this.btnYes.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(131, 50);
            this.btnYes.Symbol = 61452;
            this.btnYes.SymbolSize = 40;
            this.btnYes.TabIndex = 14;
            this.btnYes.Text = "OK";
            this.btnYes.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // TextBoxAlarmCode
            // 
            this.TextBoxAlarmCode.BackColor = System.Drawing.Color.White;
            this.TextBoxAlarmCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxAlarmCode.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxAlarmCode.Location = new System.Drawing.Point(215, 164);
            this.TextBoxAlarmCode.Name = "TextBoxAlarmCode";
            this.TextBoxAlarmCode.ReadOnly = true;
            this.TextBoxAlarmCode.Size = new System.Drawing.Size(621, 35);
            this.TextBoxAlarmCode.TabIndex = 16;
            this.TextBoxAlarmCode.TabStop = false;
            this.TextBoxAlarmCode.Text = "ALARM CODE";
            // 
            // TextBoxTitleAlarmType
            // 
            this.TextBoxTitleAlarmType.BackColor = System.Drawing.Color.DodgerBlue;
            this.TextBoxTitleAlarmType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxTitleAlarmType.Font = new System.Drawing.Font("Malgun Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxTitleAlarmType.ForeColor = System.Drawing.SystemColors.Info;
            this.TextBoxTitleAlarmType.Location = new System.Drawing.Point(12, 12);
            this.TextBoxTitleAlarmType.Name = "TextBoxTitleAlarmType";
            this.TextBoxTitleAlarmType.ReadOnly = true;
            this.TextBoxTitleAlarmType.Size = new System.Drawing.Size(822, 93);
            this.TextBoxTitleAlarmType.TabIndex = 17;
            this.TextBoxTitleAlarmType.TabStop = false;
            this.TextBoxTitleAlarmType.Text = "TYPE";
            this.TextBoxTitleAlarmType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxAlarmTime
            // 
            this.TextBoxAlarmTime.BackColor = System.Drawing.Color.White;
            this.TextBoxAlarmTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxAlarmTime.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxAlarmTime.Location = new System.Drawing.Point(215, 123);
            this.TextBoxAlarmTime.Name = "TextBoxAlarmTime";
            this.TextBoxAlarmTime.ReadOnly = true;
            this.TextBoxAlarmTime.Size = new System.Drawing.Size(621, 35);
            this.TextBoxAlarmTime.TabIndex = 18;
            this.TextBoxAlarmTime.TabStop = false;
            this.TextBoxAlarmTime.Text = "ALARM TIME";
            // 
            // TextBoxTitleAlarmTime
            // 
            this.TextBoxTitleAlarmTime.BackColor = System.Drawing.Color.White;
            this.TextBoxTitleAlarmTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxTitleAlarmTime.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxTitleAlarmTime.Location = new System.Drawing.Point(12, 123);
            this.TextBoxTitleAlarmTime.Name = "TextBoxTitleAlarmTime";
            this.TextBoxTitleAlarmTime.ReadOnly = true;
            this.TextBoxTitleAlarmTime.Size = new System.Drawing.Size(197, 35);
            this.TextBoxTitleAlarmTime.TabIndex = 19;
            this.TextBoxTitleAlarmTime.TabStop = false;
            this.TextBoxTitleAlarmTime.Text = "TIME";
            // 
            // TextBoxTitleAlarmCode
            // 
            this.TextBoxTitleAlarmCode.BackColor = System.Drawing.Color.White;
            this.TextBoxTitleAlarmCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxTitleAlarmCode.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxTitleAlarmCode.Location = new System.Drawing.Point(12, 164);
            this.TextBoxTitleAlarmCode.Name = "TextBoxTitleAlarmCode";
            this.TextBoxTitleAlarmCode.ReadOnly = true;
            this.TextBoxTitleAlarmCode.Size = new System.Drawing.Size(197, 35);
            this.TextBoxTitleAlarmCode.TabIndex = 20;
            this.TextBoxTitleAlarmCode.TabStop = false;
            this.TextBoxTitleAlarmCode.Text = "CODE";
            // 
            // TextBoxTitleAlarmDescription
            // 
            this.TextBoxTitleAlarmDescription.BackColor = System.Drawing.Color.White;
            this.TextBoxTitleAlarmDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxTitleAlarmDescription.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxTitleAlarmDescription.Location = new System.Drawing.Point(13, 205);
            this.TextBoxTitleAlarmDescription.Name = "TextBoxTitleAlarmDescription";
            this.TextBoxTitleAlarmDescription.ReadOnly = true;
            this.TextBoxTitleAlarmDescription.Size = new System.Drawing.Size(823, 35);
            this.TextBoxTitleAlarmDescription.TabIndex = 21;
            this.TextBoxTitleAlarmDescription.TabStop = false;
            this.TextBoxTitleAlarmDescription.Text = "ALARM DESCRIPTION";
            this.TextBoxTitleAlarmDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RichTextBoxAlarmDescription
            // 
            this.RichTextBoxAlarmDescription.BackColor = System.Drawing.Color.White;
            this.RichTextBoxAlarmDescription.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxAlarmDescription.Location = new System.Drawing.Point(13, 246);
            this.RichTextBoxAlarmDescription.Name = "RichTextBoxAlarmDescription";
            this.RichTextBoxAlarmDescription.ReadOnly = true;
            this.RichTextBoxAlarmDescription.Size = new System.Drawing.Size(823, 273);
            this.RichTextBoxAlarmDescription.TabIndex = 22;
            this.RichTextBoxAlarmDescription.TabStop = false;
            this.RichTextBoxAlarmDescription.Text = "";
            // 
            // CDialogMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 603);
            this.ControlBox = false;
            this.Controls.Add(this.TextBoxAlarmCode);
            this.Controls.Add(this.TextBoxTitleAlarmType);
            this.Controls.Add(this.TextBoxAlarmTime);
            this.Controls.Add(this.TextBoxTitleAlarmTime);
            this.Controls.Add(this.TextBoxTitleAlarmCode);
            this.Controls.Add(this.TextBoxTitleAlarmDescription);
            this.Controls.Add(this.RichTextBoxAlarmDescription);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CDialogMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDialogMessage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CDialogMessage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CDialogMessage_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UISymbolButton btnNo;
        private Sunny.UI.UISymbolButton btnYes;
        private System.Windows.Forms.TextBox TextBoxAlarmCode;
        private System.Windows.Forms.TextBox TextBoxTitleAlarmType;
        private System.Windows.Forms.TextBox TextBoxAlarmTime;
        private System.Windows.Forms.TextBox TextBoxTitleAlarmTime;
        private System.Windows.Forms.TextBox TextBoxTitleAlarmCode;
        private System.Windows.Forms.TextBox TextBoxTitleAlarmDescription;
        private System.Windows.Forms.RichTextBox RichTextBoxAlarmDescription;
    }
}