namespace AlignVision
{
    partial class CFormViewCameraExpand
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTitleMain = new System.Windows.Forms.Button();
            this.btnExpand = new Sunny.UI.UISymbolButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.382436F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 656F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 714);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.74258F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.257426F));
            this.tableLayoutPanel2.Controls.Add(this.btnTitleMain, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExpand, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1058, 52);
            this.tableLayoutPanel2.TabIndex = 124;
            // 
            // btnTitleMain
            // 
            this.btnTitleMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTitleMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitleMain.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitleMain.Location = new System.Drawing.Point(3, 3);
            this.btnTitleMain.Name = "btnTitleMain";
            this.btnTitleMain.Size = new System.Drawing.Size(1006, 46);
            this.btnTitleMain.TabIndex = 121;
            this.btnTitleMain.Text = "IN 1";
            this.btnTitleMain.UseVisualStyleBackColor = true;
            // 
            // btnExpand
            // 
            this.btnExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExpand.FillColor = System.Drawing.SystemColors.Control;
            this.btnExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExpand.ForeColor = System.Drawing.Color.Black;
            this.btnExpand.ForeHoverColor = System.Drawing.Color.Black;
            this.btnExpand.ForePressColor = System.Drawing.SystemColors.Window;
            this.btnExpand.Location = new System.Drawing.Point(1015, 3);
            this.btnExpand.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.RectColor = System.Drawing.Color.Black;
            this.btnExpand.RectPressColor = System.Drawing.Color.Black;
            this.btnExpand.RectSelectedColor = System.Drawing.Color.Black;
            this.btnExpand.Size = new System.Drawing.Size(40, 46);
            this.btnExpand.Symbol = 47;
            this.btnExpand.SymbolColor = System.Drawing.Color.Black;
            this.btnExpand.SymbolSize = 45;
            this.btnExpand.TabIndex = 122;
            this.btnExpand.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // CFormViewCameraExpand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1064, 714);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CFormViewCameraExpand";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFormViewCameraExpand";
            this.Load += new System.EventHandler(this.CFormViewCameraExpand_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnTitleMain;
        private Sunny.UI.UISymbolButton btnExpand;
        private System.Windows.Forms.Timer timer1;
    }
}