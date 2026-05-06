using System.Windows.Forms;
using System.ComponentModel;


namespace AlignVision
{
    partial class FormKeyPad
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
            this.BtnKeyPadTitle = new System.Windows.Forms.Button();
            this.BtnKeyPadMinusDotOne = new System.Windows.Forms.Button();
            this.BtnKeyPadPlusDotOne = new System.Windows.Forms.Button();
            this.BtnKeyPadMinusDotFive = new System.Windows.Forms.Button();
            this.BtnKeyPadPlusDotFive = new System.Windows.Forms.Button();
            this.BtnKeyPadMinusOne = new System.Windows.Forms.Button();
            this.BtnKeyPadPlusOne = new System.Windows.Forms.Button();
            this.BtnDisPlayKeyValue = new System.Windows.Forms.Button();
            this.BtnKeyPadChar7 = new System.Windows.Forms.Button();
            this.BtnKeyPadChar8 = new System.Windows.Forms.Button();
            this.BtnKeyPadChar9 = new System.Windows.Forms.Button();
            this.BtnDisplayOriginValue = new System.Windows.Forms.Button();
            this.BtnKeyPadDivision = new System.Windows.Forms.Button();
            this.BtnKeyPadClear = new System.Windows.Forms.Button();
            this.BtnKeyPadBackSpace = new System.Windows.Forms.Button();
            this.BtnKeyPadChar4 = new System.Windows.Forms.Button();
            this.BtnKeyPadChar5 = new System.Windows.Forms.Button();
            this.BtnKeyPadChar6 = new System.Windows.Forms.Button();
            this.BtnKeyPadMutiply = new System.Windows.Forms.Button();
            this.BtnKeyPadChar1 = new System.Windows.Forms.Button();
            this.BtnKeyPadChar2 = new System.Windows.Forms.Button();
            this.BtnKeyPadChar3 = new System.Windows.Forms.Button();
            this.BtnKeyPadHyphen = new System.Windows.Forms.Button();
            this.BtnKeyPadChar0 = new System.Windows.Forms.Button();
            this.BtnKeyPadPoint = new System.Windows.Forms.Button();
            this.BtnKeyPadEquals = new System.Windows.Forms.Button();
            this.BtnKeyPadPlus = new System.Windows.Forms.Button();
            this.BtnKeyPadOK = new System.Windows.Forms.Button();
            this.BtnKeyPadCancel = new System.Windows.Forms.Button();
            this.BtnKeyPadPlusTen = new System.Windows.Forms.Button();
            this.BtnKeyPadMinusTen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnKeyPadTitle
            // 
            this.BtnKeyPadTitle.Location = new System.Drawing.Point(84, 2);
            this.BtnKeyPadTitle.Name = "BtnKeyPadTitle";
            this.BtnKeyPadTitle.Size = new System.Drawing.Size(322, 44);
            this.BtnKeyPadTitle.TabIndex = 0;
            this.BtnKeyPadTitle.Text = "KEY PAD";
            this.BtnKeyPadTitle.UseVisualStyleBackColor = true;
            this.BtnKeyPadTitle.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadMinusDotOne
            // 
            this.BtnKeyPadMinusDotOne.Location = new System.Drawing.Point(2, 2);
            this.BtnKeyPadMinusDotOne.Name = "BtnKeyPadMinusDotOne";
            this.BtnKeyPadMinusDotOne.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadMinusDotOne.TabIndex = 0;
            this.BtnKeyPadMinusDotOne.Text = "- 0.1";
            this.BtnKeyPadMinusDotOne.UseVisualStyleBackColor = true;
            this.BtnKeyPadMinusDotOne.Click += new System.EventHandler(this.BtnKeyPadMinusDotOne_Click);
            this.BtnKeyPadMinusDotOne.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadPlusDotOne
            // 
            this.BtnKeyPadPlusDotOne.Location = new System.Drawing.Point(2, 50);
            this.BtnKeyPadPlusDotOne.Name = "BtnKeyPadPlusDotOne";
            this.BtnKeyPadPlusDotOne.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadPlusDotOne.TabIndex = 0;
            this.BtnKeyPadPlusDotOne.Text = "+ 0.1";
            this.BtnKeyPadPlusDotOne.UseVisualStyleBackColor = true;
            this.BtnKeyPadPlusDotOne.Click += new System.EventHandler(this.BtnKeyPadPlusDotOne_Click);
            this.BtnKeyPadPlusDotOne.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadMinusDotFive
            // 
            this.BtnKeyPadMinusDotFive.Location = new System.Drawing.Point(2, 96);
            this.BtnKeyPadMinusDotFive.Name = "BtnKeyPadMinusDotFive";
            this.BtnKeyPadMinusDotFive.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadMinusDotFive.TabIndex = 0;
            this.BtnKeyPadMinusDotFive.Text = "- 0.5";
            this.BtnKeyPadMinusDotFive.UseVisualStyleBackColor = true;
            this.BtnKeyPadMinusDotFive.Click += new System.EventHandler(this.BtnKeyPadMinusDotFive_Click);
            this.BtnKeyPadMinusDotFive.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadPlusDotFive
            // 
            this.BtnKeyPadPlusDotFive.Location = new System.Drawing.Point(2, 143);
            this.BtnKeyPadPlusDotFive.Name = "BtnKeyPadPlusDotFive";
            this.BtnKeyPadPlusDotFive.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadPlusDotFive.TabIndex = 0;
            this.BtnKeyPadPlusDotFive.Text = "+ 0.5";
            this.BtnKeyPadPlusDotFive.UseVisualStyleBackColor = true;
            this.BtnKeyPadPlusDotFive.Click += new System.EventHandler(this.BtnKeyPadPlusDotFive_Click);
            this.BtnKeyPadPlusDotFive.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadMinusOne
            // 
            this.BtnKeyPadMinusOne.Location = new System.Drawing.Point(2, 191);
            this.BtnKeyPadMinusOne.Name = "BtnKeyPadMinusOne";
            this.BtnKeyPadMinusOne.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadMinusOne.TabIndex = 0;
            this.BtnKeyPadMinusOne.Text = "- 1";
            this.BtnKeyPadMinusOne.UseVisualStyleBackColor = true;
            this.BtnKeyPadMinusOne.Click += new System.EventHandler(this.BtnKeyPadMinusOne_Click);
            this.BtnKeyPadMinusOne.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadPlusOne
            // 
            this.BtnKeyPadPlusOne.Location = new System.Drawing.Point(2, 237);
            this.BtnKeyPadPlusOne.Name = "BtnKeyPadPlusOne";
            this.BtnKeyPadPlusOne.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadPlusOne.TabIndex = 0;
            this.BtnKeyPadPlusOne.Text = "+ 1";
            this.BtnKeyPadPlusOne.UseVisualStyleBackColor = true;
            this.BtnKeyPadPlusOne.Click += new System.EventHandler(this.BtnKeyPadPlusOne_Click);
            this.BtnKeyPadPlusOne.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnDisPlayKeyValue
            // 
            this.BtnDisPlayKeyValue.Location = new System.Drawing.Point(84, 50);
            this.BtnDisPlayKeyValue.Name = "BtnDisPlayKeyValue";
            this.BtnDisPlayKeyValue.Size = new System.Drawing.Size(322, 44);
            this.BtnDisPlayKeyValue.TabIndex = 0;
            this.BtnDisPlayKeyValue.Text = "0";
            this.BtnDisPlayKeyValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDisPlayKeyValue.UseVisualStyleBackColor = true;
            this.BtnDisPlayKeyValue.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar7
            // 
            this.BtnKeyPadChar7.Location = new System.Drawing.Point(84, 143);
            this.BtnKeyPadChar7.Name = "BtnKeyPadChar7";
            this.BtnKeyPadChar7.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar7.TabIndex = 0;
            this.BtnKeyPadChar7.Text = "7";
            this.BtnKeyPadChar7.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar7.Click += new System.EventHandler(this.BtnKeyPadChar7_Click);
            this.BtnKeyPadChar7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar8
            // 
            this.BtnKeyPadChar8.Location = new System.Drawing.Point(165, 143);
            this.BtnKeyPadChar8.Name = "BtnKeyPadChar8";
            this.BtnKeyPadChar8.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar8.TabIndex = 0;
            this.BtnKeyPadChar8.Text = "8";
            this.BtnKeyPadChar8.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar8.Click += new System.EventHandler(this.BtnKeyPadChar8_Click);
            this.BtnKeyPadChar8.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar9
            // 
            this.BtnKeyPadChar9.Location = new System.Drawing.Point(245, 143);
            this.BtnKeyPadChar9.Name = "BtnKeyPadChar9";
            this.BtnKeyPadChar9.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar9.TabIndex = 0;
            this.BtnKeyPadChar9.Text = "9";
            this.BtnKeyPadChar9.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar9.Click += new System.EventHandler(this.BtnKeyPadChar9_Click);
            this.BtnKeyPadChar9.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnDisplayOriginValue
            // 
            this.BtnDisplayOriginValue.Location = new System.Drawing.Point(84, 96);
            this.BtnDisplayOriginValue.Name = "BtnDisplayOriginValue";
            this.BtnDisplayOriginValue.Size = new System.Drawing.Size(160, 44);
            this.BtnDisplayOriginValue.TabIndex = 0;
            this.BtnDisplayOriginValue.UseVisualStyleBackColor = true;
            this.BtnDisplayOriginValue.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadDivision
            // 
            this.BtnKeyPadDivision.Location = new System.Drawing.Point(327, 143);
            this.BtnKeyPadDivision.Name = "BtnKeyPadDivision";
            this.BtnKeyPadDivision.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadDivision.TabIndex = 0;
            this.BtnKeyPadDivision.Text = "/";
            this.BtnKeyPadDivision.UseVisualStyleBackColor = true;
            this.BtnKeyPadDivision.Click += new System.EventHandler(this.BtnKeyPadDivision_Click);
            this.BtnKeyPadDivision.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadClear
            // 
            this.BtnKeyPadClear.Location = new System.Drawing.Point(245, 96);
            this.BtnKeyPadClear.Name = "BtnKeyPadClear";
            this.BtnKeyPadClear.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadClear.TabIndex = 0;
            this.BtnKeyPadClear.Text = "CLEAR";
            this.BtnKeyPadClear.UseVisualStyleBackColor = true;
            this.BtnKeyPadClear.Click += new System.EventHandler(this.BtnKeyPadClear_Click);
            this.BtnKeyPadClear.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadBackSpace
            // 
            this.BtnKeyPadBackSpace.Location = new System.Drawing.Point(327, 96);
            this.BtnKeyPadBackSpace.Name = "BtnKeyPadBackSpace";
            this.BtnKeyPadBackSpace.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadBackSpace.TabIndex = 0;
            this.BtnKeyPadBackSpace.Text = "←";
            this.BtnKeyPadBackSpace.UseVisualStyleBackColor = true;
            this.BtnKeyPadBackSpace.Click += new System.EventHandler(this.BtnKeyPadBackSpace_Click);
            this.BtnKeyPadBackSpace.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar4
            // 
            this.BtnKeyPadChar4.Location = new System.Drawing.Point(84, 191);
            this.BtnKeyPadChar4.Name = "BtnKeyPadChar4";
            this.BtnKeyPadChar4.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar4.TabIndex = 0;
            this.BtnKeyPadChar4.Text = "4";
            this.BtnKeyPadChar4.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar4.Click += new System.EventHandler(this.BtnKeyPadChar4_Click);
            this.BtnKeyPadChar4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar5
            // 
            this.BtnKeyPadChar5.Location = new System.Drawing.Point(165, 191);
            this.BtnKeyPadChar5.Name = "BtnKeyPadChar5";
            this.BtnKeyPadChar5.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar5.TabIndex = 0;
            this.BtnKeyPadChar5.Text = "5";
            this.BtnKeyPadChar5.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar5.Click += new System.EventHandler(this.BtnKeyPadChar5_Click);
            this.BtnKeyPadChar5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar6
            // 
            this.BtnKeyPadChar6.Location = new System.Drawing.Point(245, 191);
            this.BtnKeyPadChar6.Name = "BtnKeyPadChar6";
            this.BtnKeyPadChar6.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar6.TabIndex = 0;
            this.BtnKeyPadChar6.Text = "6";
            this.BtnKeyPadChar6.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar6.Click += new System.EventHandler(this.BtnKeyPadChar6_Click);
            this.BtnKeyPadChar6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadMutiply
            // 
            this.BtnKeyPadMutiply.Location = new System.Drawing.Point(327, 191);
            this.BtnKeyPadMutiply.Name = "BtnKeyPadMutiply";
            this.BtnKeyPadMutiply.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadMutiply.TabIndex = 0;
            this.BtnKeyPadMutiply.Text = "*";
            this.BtnKeyPadMutiply.UseVisualStyleBackColor = true;
            this.BtnKeyPadMutiply.Click += new System.EventHandler(this.BtnKeyPadMutiply_Click);
            this.BtnKeyPadMutiply.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar1
            // 
            this.BtnKeyPadChar1.Location = new System.Drawing.Point(84, 237);
            this.BtnKeyPadChar1.Name = "BtnKeyPadChar1";
            this.BtnKeyPadChar1.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar1.TabIndex = 0;
            this.BtnKeyPadChar1.Text = "1";
            this.BtnKeyPadChar1.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar1.Click += new System.EventHandler(this.BtnKeyPadChar1_Click);
            this.BtnKeyPadChar1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar2
            // 
            this.BtnKeyPadChar2.Location = new System.Drawing.Point(165, 237);
            this.BtnKeyPadChar2.Name = "BtnKeyPadChar2";
            this.BtnKeyPadChar2.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar2.TabIndex = 0;
            this.BtnKeyPadChar2.Text = "2";
            this.BtnKeyPadChar2.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar2.Click += new System.EventHandler(this.BtnKeyPadChar2_Click);
            this.BtnKeyPadChar2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar3
            // 
            this.BtnKeyPadChar3.Location = new System.Drawing.Point(245, 237);
            this.BtnKeyPadChar3.Name = "BtnKeyPadChar3";
            this.BtnKeyPadChar3.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar3.TabIndex = 0;
            this.BtnKeyPadChar3.Text = "3";
            this.BtnKeyPadChar3.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar3.Click += new System.EventHandler(this.BtnKeyPadChar3_Click);
            this.BtnKeyPadChar3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadHyphen
            // 
            this.BtnKeyPadHyphen.Location = new System.Drawing.Point(327, 237);
            this.BtnKeyPadHyphen.Name = "BtnKeyPadHyphen";
            this.BtnKeyPadHyphen.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadHyphen.TabIndex = 0;
            this.BtnKeyPadHyphen.Text = "-";
            this.BtnKeyPadHyphen.UseVisualStyleBackColor = true;
            this.BtnKeyPadHyphen.Click += new System.EventHandler(this.BtnKeyPadHyphen_Click);
            this.BtnKeyPadHyphen.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadChar0
            // 
            this.BtnKeyPadChar0.Location = new System.Drawing.Point(84, 285);
            this.BtnKeyPadChar0.Name = "BtnKeyPadChar0";
            this.BtnKeyPadChar0.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadChar0.TabIndex = 0;
            this.BtnKeyPadChar0.Text = "0";
            this.BtnKeyPadChar0.UseVisualStyleBackColor = true;
            this.BtnKeyPadChar0.Click += new System.EventHandler(this.BtnKeyPadChar0_Click);
            this.BtnKeyPadChar0.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadPoint
            // 
            this.BtnKeyPadPoint.Location = new System.Drawing.Point(165, 285);
            this.BtnKeyPadPoint.Name = "BtnKeyPadPoint";
            this.BtnKeyPadPoint.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadPoint.TabIndex = 0;
            this.BtnKeyPadPoint.Text = ".";
            this.BtnKeyPadPoint.UseVisualStyleBackColor = true;
            this.BtnKeyPadPoint.Click += new System.EventHandler(this.BtnKeyPadPoint_Click);
            this.BtnKeyPadPoint.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadEquals
            // 
            this.BtnKeyPadEquals.Location = new System.Drawing.Point(245, 285);
            this.BtnKeyPadEquals.Name = "BtnKeyPadEquals";
            this.BtnKeyPadEquals.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadEquals.TabIndex = 0;
            this.BtnKeyPadEquals.Text = "=";
            this.BtnKeyPadEquals.UseVisualStyleBackColor = true;
            this.BtnKeyPadEquals.Click += new System.EventHandler(this.BtnKeyPadEquals_Click);
            this.BtnKeyPadEquals.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadPlus
            // 
            this.BtnKeyPadPlus.Location = new System.Drawing.Point(327, 285);
            this.BtnKeyPadPlus.Name = "BtnKeyPadPlus";
            this.BtnKeyPadPlus.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadPlus.TabIndex = 0;
            this.BtnKeyPadPlus.Text = "+";
            this.BtnKeyPadPlus.UseVisualStyleBackColor = true;
            this.BtnKeyPadPlus.Click += new System.EventHandler(this.BtnKeyPadPlus_Click);
            this.BtnKeyPadPlus.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadOK
            // 
            this.BtnKeyPadOK.Location = new System.Drawing.Point(84, 333);
            this.BtnKeyPadOK.Name = "BtnKeyPadOK";
            this.BtnKeyPadOK.Size = new System.Drawing.Size(241, 44);
            this.BtnKeyPadOK.TabIndex = 0;
            this.BtnKeyPadOK.Text = "OK";
            this.BtnKeyPadOK.UseVisualStyleBackColor = true;
            this.BtnKeyPadOK.Click += new System.EventHandler(this.BtnKeyPadOK_Click);
            this.BtnKeyPadOK.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadCancel
            // 
            this.BtnKeyPadCancel.Location = new System.Drawing.Point(327, 333);
            this.BtnKeyPadCancel.Name = "BtnKeyPadCancel";
            this.BtnKeyPadCancel.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadCancel.TabIndex = 0;
            this.BtnKeyPadCancel.Text = "CANCEL";
            this.BtnKeyPadCancel.UseVisualStyleBackColor = true;
            this.BtnKeyPadCancel.Click += new System.EventHandler(this.BtnKeyPadCancel_Click);
            this.BtnKeyPadCancel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadPlusTen
            // 
            this.BtnKeyPadPlusTen.Location = new System.Drawing.Point(2, 333);
            this.BtnKeyPadPlusTen.Name = "BtnKeyPadPlusTen";
            this.BtnKeyPadPlusTen.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadPlusTen.TabIndex = 1;
            this.BtnKeyPadPlusTen.Text = "+ 10";
            this.BtnKeyPadPlusTen.Click += new System.EventHandler(this.BtnKeyPadPlusTen_Click);
            this.BtnKeyPadPlusTen.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // BtnKeyPadMinusTen
            // 
            this.BtnKeyPadMinusTen.Location = new System.Drawing.Point(2, 285);
            this.BtnKeyPadMinusTen.Name = "BtnKeyPadMinusTen";
            this.BtnKeyPadMinusTen.Size = new System.Drawing.Size(80, 44);
            this.BtnKeyPadMinusTen.TabIndex = 0;
            this.BtnKeyPadMinusTen.Text = "- 10";
            this.BtnKeyPadMinusTen.Click += new System.EventHandler(this.BtnKeyPadMinusTen_Click);
            this.BtnKeyPadMinusTen.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BtnKeyPad_PreviewKeyDown);
            // 
            // FormKeyPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(413, 381);
            this.ControlBox = false;
            this.Controls.Add(this.BtnKeyPadMinusTen);
            this.Controls.Add(this.BtnKeyPadPlusOne);
            this.Controls.Add(this.BtnKeyPadMinusOne);
            this.Controls.Add(this.BtnKeyPadPlusDotFive);
            this.Controls.Add(this.BtnKeyPadCancel);
            this.Controls.Add(this.BtnKeyPadBackSpace);
            this.Controls.Add(this.BtnKeyPadPlus);
            this.Controls.Add(this.BtnKeyPadHyphen);
            this.Controls.Add(this.BtnKeyPadMutiply);
            this.Controls.Add(this.BtnKeyPadDivision);
            this.Controls.Add(this.BtnKeyPadOK);
            this.Controls.Add(this.BtnKeyPadClear);
            this.Controls.Add(this.BtnKeyPadEquals);
            this.Controls.Add(this.BtnKeyPadChar3);
            this.Controls.Add(this.BtnKeyPadChar6);
            this.Controls.Add(this.BtnKeyPadChar9);
            this.Controls.Add(this.BtnKeyPadPoint);
            this.Controls.Add(this.BtnKeyPadChar2);
            this.Controls.Add(this.BtnKeyPadChar5);
            this.Controls.Add(this.BtnKeyPadPlusTen);
            this.Controls.Add(this.BtnKeyPadChar8);
            this.Controls.Add(this.BtnKeyPadChar0);
            this.Controls.Add(this.BtnKeyPadChar1);
            this.Controls.Add(this.BtnKeyPadChar4);
            this.Controls.Add(this.BtnKeyPadChar7);
            this.Controls.Add(this.BtnKeyPadMinusDotFive);
            this.Controls.Add(this.BtnDisplayOriginValue);
            this.Controls.Add(this.BtnKeyPadPlusDotOne);
            this.Controls.Add(this.BtnDisPlayKeyValue);
            this.Controls.Add(this.BtnKeyPadMinusDotOne);
            this.Controls.Add(this.BtnKeyPadTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormKeyPad";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KeyPad";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnKeyPadTitle;

        private Button BtnKeyPadMinusDotOne;

        private Button BtnKeyPadPlusDotOne;

        private Button BtnKeyPadMinusDotFive;

        private Button BtnKeyPadPlusDotFive;

        private Button BtnKeyPadMinusOne;

        private Button BtnKeyPadPlusOne;

        private Button BtnDisPlayKeyValue;

        private Button BtnKeyPadChar7;

        private Button BtnKeyPadChar8;

        private Button BtnKeyPadChar9;

        private Button BtnDisplayOriginValue;

        private Button BtnKeyPadDivision;

        private Button BtnKeyPadClear;

        private Button BtnKeyPadBackSpace;

        private Button BtnKeyPadChar4;

        private Button BtnKeyPadChar5;

        private Button BtnKeyPadChar6;

        private Button BtnKeyPadMutiply;

        private Button BtnKeyPadChar1;

        private Button BtnKeyPadChar2;

        private Button BtnKeyPadChar3;

        private Button BtnKeyPadHyphen;

        private Button BtnKeyPadChar0;

        private Button BtnKeyPadPoint;

        private Button BtnKeyPadEquals;

        private Button BtnKeyPadPlus;

        private Button BtnKeyPadOK;

        private Button BtnKeyPadCancel;

        private Button BtnKeyPadPlusTen;

        private Button BtnKeyPadMinusTen;

    }
}