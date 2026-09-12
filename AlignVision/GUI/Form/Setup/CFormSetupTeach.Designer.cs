namespace AlignVision
{
    partial class CFormSetupTeach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSetupTeach));
            this.panelSetting = new System.Windows.Forms.Panel();
            this.btnChooseTool = new System.Windows.Forms.Button();
            this.btnCamera2 = new System.Windows.Forms.Button();
            this.btnTitleAlignToolType = new System.Windows.Forms.Button();
            this.btnTitleCamera = new System.Windows.Forms.Button();
            this.btnCamera1 = new System.Windows.Forms.Button();
            this.btnPatternAdd = new System.Windows.Forms.Button();
            this.btnPatternDelete = new System.Windows.Forms.Button();
            this.btnToolPaste = new System.Windows.Forms.Button();
            this.btnToolCopy = new System.Windows.Forms.Button();
            this.btnTitleToolList = new System.Windows.Forms.Button();
            this.dataGridViewToolList = new System.Windows.Forms.DataGridView();
            this.cogDisplayCamera = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayResult = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayStatusBar_Camera = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.btnTitleCam = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.BtnMasterPositionDisplay = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.BtnSetMasterPosition = new System.Windows.Forms.Button();
            this.BtnGrabCamera = new System.Windows.Forms.Button();
            this.BtnGrabImage = new System.Windows.Forms.Button();
            this.BtnLoadImage = new System.Windows.Forms.Button();
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.btnToolSetting = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.cogDisplayStatusBar_Result = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.btnOpenToolBlock = new System.Windows.Forms.Button();
            this.groupAlignSetting = new System.Windows.Forms.GroupBox();
            this.btnAlignSetting = new System.Windows.Forms.Button();
            this.comboBoxAlignToolType = new Sunny.UI.UIComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStage1 = new System.Windows.Forms.Button();
            this.btnStage2 = new System.Windows.Forms.Button();
            this.panelSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToolList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayResult)).BeginInit();
            this.groupBoxOperation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupAlignSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.btnChooseTool);
            this.panelSetting.Controls.Add(this.btnCamera2);
            this.panelSetting.Controls.Add(this.btnTitleAlignToolType);
            this.panelSetting.Controls.Add(this.btnTitleCamera);
            this.panelSetting.Controls.Add(this.btnCamera1);
            this.panelSetting.Location = new System.Drawing.Point(4, 733);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(215, 244);
            this.panelSetting.TabIndex = 58;
            // 
            // btnChooseTool
            // 
            this.btnChooseTool.BackColor = System.Drawing.Color.White;
            this.btnChooseTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChooseTool.Location = new System.Drawing.Point(0, 186);
            this.btnChooseTool.Name = "btnChooseTool";
            this.btnChooseTool.Size = new System.Drawing.Size(117, 46);
            this.btnChooseTool.TabIndex = 2231;
            this.btnChooseTool.Text = "CHOOSE";
            this.btnChooseTool.UseVisualStyleBackColor = true;
            this.btnChooseTool.Click += new System.EventHandler(this.btnChooseTool_Click);
            // 
            // btnCamera2
            // 
            this.btnCamera2.BackColor = System.Drawing.Color.White;
            this.btnCamera2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCamera2.Location = new System.Drawing.Point(110, 32);
            this.btnCamera2.Name = "btnCamera2";
            this.btnCamera2.Size = new System.Drawing.Size(105, 46);
            this.btnCamera2.TabIndex = 74;
            this.btnCamera2.Text = "CAMERA 2";
            this.btnCamera2.UseVisualStyleBackColor = true;
            this.btnCamera2.Click += new System.EventHandler(this.btnCamera2_Click);
            // 
            // btnTitleAlignToolType
            // 
            this.btnTitleAlignToolType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitleAlignToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTitleAlignToolType.Location = new System.Drawing.Point(0, 110);
            this.btnTitleAlignToolType.Name = "btnTitleAlignToolType";
            this.btnTitleAlignToolType.Size = new System.Drawing.Size(215, 28);
            this.btnTitleAlignToolType.TabIndex = 63;
            this.btnTitleAlignToolType.Text = "ALIGN TOOL TYPE";
            this.btnTitleAlignToolType.UseVisualStyleBackColor = true;
            // 
            // btnTitleCamera
            // 
            this.btnTitleCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitleCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTitleCamera.Location = new System.Drawing.Point(0, 0);
            this.btnTitleCamera.Name = "btnTitleCamera";
            this.btnTitleCamera.Size = new System.Drawing.Size(215, 28);
            this.btnTitleCamera.TabIndex = 54;
            this.btnTitleCamera.Text = "CAMERA";
            this.btnTitleCamera.UseVisualStyleBackColor = true;
            // 
            // btnCamera1
            // 
            this.btnCamera1.BackColor = System.Drawing.Color.White;
            this.btnCamera1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCamera1.Location = new System.Drawing.Point(0, 32);
            this.btnCamera1.Name = "btnCamera1";
            this.btnCamera1.Size = new System.Drawing.Size(105, 46);
            this.btnCamera1.TabIndex = 58;
            this.btnCamera1.Text = "CAMERA 1";
            this.btnCamera1.UseVisualStyleBackColor = true;
            this.btnCamera1.Click += new System.EventHandler(this.btnCamera1_Click);
            // 
            // btnPatternAdd
            // 
            this.btnPatternAdd.BackColor = System.Drawing.Color.White;
            this.btnPatternAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPatternAdd.Location = new System.Drawing.Point(322, 39);
            this.btnPatternAdd.Name = "btnPatternAdd";
            this.btnPatternAdd.Size = new System.Drawing.Size(107, 46);
            this.btnPatternAdd.TabIndex = 167;
            this.btnPatternAdd.Text = "ADD (PATTERN)";
            this.btnPatternAdd.UseVisualStyleBackColor = true;
            this.btnPatternAdd.Click += new System.EventHandler(this.btnPatternAdd_Click);
            // 
            // btnPatternDelete
            // 
            this.btnPatternDelete.BackColor = System.Drawing.Color.White;
            this.btnPatternDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPatternDelete.Location = new System.Drawing.Point(322, 91);
            this.btnPatternDelete.Name = "btnPatternDelete";
            this.btnPatternDelete.Size = new System.Drawing.Size(105, 46);
            this.btnPatternDelete.TabIndex = 168;
            this.btnPatternDelete.Text = "DELETE (PATTERN)";
            this.btnPatternDelete.UseVisualStyleBackColor = true;
            this.btnPatternDelete.Click += new System.EventHandler(this.btnPatternDelete_Click);
            // 
            // btnToolPaste
            // 
            this.btnToolPaste.BackColor = System.Drawing.Color.White;
            this.btnToolPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnToolPaste.Location = new System.Drawing.Point(324, 143);
            this.btnToolPaste.Name = "btnToolPaste";
            this.btnToolPaste.Size = new System.Drawing.Size(105, 46);
            this.btnToolPaste.TabIndex = 170;
            this.btnToolPaste.Text = "TOOL PASTE";
            this.btnToolPaste.UseVisualStyleBackColor = true;
            this.btnToolPaste.Click += new System.EventHandler(this.btnToolPaste_Click);
            // 
            // btnToolCopy
            // 
            this.btnToolCopy.BackColor = System.Drawing.Color.White;
            this.btnToolCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnToolCopy.Location = new System.Drawing.Point(322, 195);
            this.btnToolCopy.Name = "btnToolCopy";
            this.btnToolCopy.Size = new System.Drawing.Size(105, 46);
            this.btnToolCopy.TabIndex = 169;
            this.btnToolCopy.Text = "TOOL COPY";
            this.btnToolCopy.UseVisualStyleBackColor = true;
            this.btnToolCopy.Click += new System.EventHandler(this.btnToolCopy_Click);
            // 
            // btnTitleToolList
            // 
            this.btnTitleToolList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitleToolList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTitleToolList.Location = new System.Drawing.Point(3, 6);
            this.btnTitleToolList.Name = "btnTitleToolList";
            this.btnTitleToolList.Size = new System.Drawing.Size(424, 28);
            this.btnTitleToolList.TabIndex = 54;
            this.btnTitleToolList.Text = "TOOL LIST";
            this.btnTitleToolList.UseVisualStyleBackColor = true;
            // 
            // dataGridViewToolList
            // 
            this.dataGridViewToolList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToolList.Location = new System.Drawing.Point(3, 39);
            this.dataGridViewToolList.Name = "dataGridViewToolList";
            this.dataGridViewToolList.RowTemplate.Height = 23;
            this.dataGridViewToolList.Size = new System.Drawing.Size(313, 202);
            this.dataGridViewToolList.TabIndex = 55;
            // 
            // cogDisplayCamera
            // 
            this.cogDisplayCamera.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayCamera.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayCamera.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayCamera.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayCamera.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayCamera.DoubleTapZoomCycleLength = 2;
            this.cogDisplayCamera.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayCamera.Location = new System.Drawing.Point(4, 134);
            this.cogDisplayCamera.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayCamera.MouseWheelSensitivity = 1D;
            this.cogDisplayCamera.Name = "cogDisplayCamera";
            this.cogDisplayCamera.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayCamera.OcxState")));
            this.cogDisplayCamera.Size = new System.Drawing.Size(815, 560);
            this.cogDisplayCamera.TabIndex = 81;
            this.cogDisplayCamera.TabStop = false;
            // 
            // cogDisplayResult
            // 
            this.cogDisplayResult.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayResult.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayResult.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayResult.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayResult.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayResult.DoubleTapZoomCycleLength = 2;
            this.cogDisplayResult.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayResult.Location = new System.Drawing.Point(838, 134);
            this.cogDisplayResult.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayResult.MouseWheelSensitivity = 1D;
            this.cogDisplayResult.Name = "cogDisplayResult";
            this.cogDisplayResult.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayResult.OcxState")));
            this.cogDisplayResult.Size = new System.Drawing.Size(815, 560);
            this.cogDisplayResult.TabIndex = 81;
            this.cogDisplayResult.TabStop = false;
            // 
            // cogDisplayStatusBar_Camera
            // 
            this.cogDisplayStatusBar_Camera.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBar_Camera.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBar_Camera.Location = new System.Drawing.Point(2, 699);
            this.cogDisplayStatusBar_Camera.Name = "cogDisplayStatusBar_Camera";
            this.cogDisplayStatusBar_Camera.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBar_Camera.Size = new System.Drawing.Size(817, 25);
            this.cogDisplayStatusBar_Camera.TabIndex = 82;
            this.cogDisplayStatusBar_Camera.Use3DCoordinateSpaceTree = false;
            // 
            // btnTitleCam
            // 
            this.btnTitleCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTitleCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTitleCam.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitleCam.Location = new System.Drawing.Point(4, 88);
            this.btnTitleCam.Name = "btnTitleCam";
            this.btnTitleCam.Size = new System.Drawing.Size(815, 40);
            this.btnTitleCam.TabIndex = 122;
            this.btnTitleCam.Text = "CAMERA 1";
            this.btnTitleCam.UseVisualStyleBackColor = true;
            // 
            // btnResult
            // 
            this.btnResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResult.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.Location = new System.Drawing.Point(838, 88);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(815, 40);
            this.btnResult.TabIndex = 123;
            this.btnResult.Text = "RESULT";
            this.btnResult.UseVisualStyleBackColor = true;
            // 
            // BtnMasterPositionDisplay
            // 
            this.BtnMasterPositionDisplay.BackColor = System.Drawing.Color.White;
            this.BtnMasterPositionDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnMasterPositionDisplay.Location = new System.Drawing.Point(988, 727);
            this.BtnMasterPositionDisplay.Name = "BtnMasterPositionDisplay";
            this.BtnMasterPositionDisplay.Size = new System.Drawing.Size(665, 65);
            this.BtnMasterPositionDisplay.TabIndex = 164;
            this.BtnMasterPositionDisplay.Text = "[ MASTER ]";
            this.BtnMasterPositionDisplay.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BtnSetMasterPosition
            // 
            this.BtnSetMasterPosition.BackColor = System.Drawing.Color.White;
            this.BtnSetMasterPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSetMasterPosition.Location = new System.Drawing.Point(1498, 797);
            this.BtnSetMasterPosition.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetMasterPosition.Name = "BtnSetMasterPosition";
            this.BtnSetMasterPosition.Size = new System.Drawing.Size(155, 94);
            this.BtnSetMasterPosition.TabIndex = 168;
            this.BtnSetMasterPosition.Text = "SET MASTER";
            this.BtnSetMasterPosition.UseVisualStyleBackColor = true;
            // 
            // BtnGrabCamera
            // 
            this.BtnGrabCamera.BackColor = System.Drawing.Color.White;
            this.BtnGrabCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnGrabCamera.Location = new System.Drawing.Point(424, 30);
            this.BtnGrabCamera.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGrabCamera.Name = "BtnGrabCamera";
            this.BtnGrabCamera.Size = new System.Drawing.Size(207, 50);
            this.BtnGrabCamera.TabIndex = 166;
            this.BtnGrabCamera.Text = "GRAB CAMERA";
            this.BtnGrabCamera.UseVisualStyleBackColor = true;
            this.BtnGrabCamera.Click += new System.EventHandler(this.BtnGrabCamera_Click);
            // 
            // BtnGrabImage
            // 
            this.BtnGrabImage.BackColor = System.Drawing.Color.White;
            this.BtnGrabImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnGrabImage.Location = new System.Drawing.Point(2, 30);
            this.BtnGrabImage.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGrabImage.Name = "BtnGrabImage";
            this.BtnGrabImage.Size = new System.Drawing.Size(207, 50);
            this.BtnGrabImage.TabIndex = 167;
            this.BtnGrabImage.Text = "GRAB IMAGE";
            this.BtnGrabImage.UseVisualStyleBackColor = true;
            this.BtnGrabImage.Click += new System.EventHandler(this.BtnGrabImage_Click);
            // 
            // BtnLoadImage
            // 
            this.BtnLoadImage.BackColor = System.Drawing.Color.White;
            this.BtnLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnLoadImage.Location = new System.Drawing.Point(213, 30);
            this.BtnLoadImage.Margin = new System.Windows.Forms.Padding(2);
            this.BtnLoadImage.Name = "BtnLoadImage";
            this.BtnLoadImage.Size = new System.Drawing.Size(207, 50);
            this.BtnLoadImage.TabIndex = 165;
            this.BtnLoadImage.Text = "LOAD IMAGE";
            this.BtnLoadImage.UseVisualStyleBackColor = true;
            this.BtnLoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.BtnGrabImage);
            this.groupBoxOperation.Controls.Add(this.BtnGrabCamera);
            this.groupBoxOperation.Controls.Add(this.BtnLoadImage);
            this.groupBoxOperation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOperation.Location = new System.Drawing.Point(838, 0);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(634, 86);
            this.groupBoxOperation.TabIndex = 2224;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "OPERATION";
            // 
            // btnToolSetting
            // 
            this.btnToolSetting.BackColor = System.Drawing.Color.White;
            this.btnToolSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnToolSetting.Location = new System.Drawing.Point(664, 727);
            this.btnToolSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnToolSetting.Name = "btnToolSetting";
            this.btnToolSetting.Size = new System.Drawing.Size(319, 68);
            this.btnToolSetting.TabIndex = 168;
            this.btnToolSetting.Text = "TOOL SETTING";
            this.btnToolSetting.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(1334, 797);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 94);
            this.button2.TabIndex = 168;
            this.button2.Text = "RUN ALGORITHM";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTitleToolList);
            this.panel1.Controls.Add(this.btnPatternAdd);
            this.panel1.Controls.Add(this.dataGridViewToolList);
            this.panel1.Controls.Add(this.btnToolCopy);
            this.panel1.Controls.Add(this.btnPatternDelete);
            this.panel1.Controls.Add(this.btnToolPaste);
            this.panel1.Location = new System.Drawing.Point(225, 727);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 250);
            this.panel1.TabIndex = 2225;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uiSymbolButton1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiSymbolButton2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1334, 897);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(322, 85);
            this.tableLayoutPanel2.TabIndex = 2226;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton1.FillColor = System.Drawing.SystemColors.Control;
            this.uiSymbolButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiSymbolButton1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.uiSymbolButton1.Location = new System.Drawing.Point(3, 3);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Radius = 0;
            this.uiSymbolButton1.RectSize = 2;
            this.uiSymbolButton1.Size = new System.Drawing.Size(155, 79);
            this.uiSymbolButton1.Symbol = 361587;
            this.uiSymbolButton1.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.uiSymbolButton1.SymbolSize = 50;
            this.uiSymbolButton1.TabIndex = 1;
            this.uiSymbolButton1.Text = "LOAD";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton2.FillColor = System.Drawing.SystemColors.Control;
            this.uiSymbolButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiSymbolButton2.ForeColor = System.Drawing.Color.DarkGreen;
            this.uiSymbolButton2.Location = new System.Drawing.Point(164, 3);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Radius = 0;
            this.uiSymbolButton2.RectSize = 2;
            this.uiSymbolButton2.Size = new System.Drawing.Size(155, 79);
            this.uiSymbolButton2.Symbol = 361465;
            this.uiSymbolButton2.SymbolColor = System.Drawing.Color.DarkGreen;
            this.uiSymbolButton2.SymbolSize = 50;
            this.uiSymbolButton2.TabIndex = 1;
            this.uiSymbolButton2.Text = "SAVE";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // cogDisplayStatusBar_Result
            // 
            this.cogDisplayStatusBar_Result.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBar_Result.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBar_Result.Location = new System.Drawing.Point(839, 699);
            this.cogDisplayStatusBar_Result.Name = "cogDisplayStatusBar_Result";
            this.cogDisplayStatusBar_Result.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBar_Result.Size = new System.Drawing.Size(817, 25);
            this.cogDisplayStatusBar_Result.TabIndex = 2227;
            this.cogDisplayStatusBar_Result.Use3DCoordinateSpaceTree = false;
            // 
            // btnOpenToolBlock
            // 
            this.btnOpenToolBlock.BackColor = System.Drawing.Color.White;
            this.btnOpenToolBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOpenToolBlock.Location = new System.Drawing.Point(664, 799);
            this.btnOpenToolBlock.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenToolBlock.Name = "btnOpenToolBlock";
            this.btnOpenToolBlock.Size = new System.Drawing.Size(319, 68);
            this.btnOpenToolBlock.TabIndex = 2228;
            this.btnOpenToolBlock.Text = "OPEN TOOLBLOCK";
            this.btnOpenToolBlock.UseVisualStyleBackColor = true;
            // 
            // groupAlignSetting
            // 
            this.groupAlignSetting.Controls.Add(this.btnAlignSetting);
            this.groupAlignSetting.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAlignSetting.Location = new System.Drawing.Point(665, 872);
            this.groupAlignSetting.Name = "groupAlignSetting";
            this.groupAlignSetting.Size = new System.Drawing.Size(318, 105);
            this.groupAlignSetting.TabIndex = 2229;
            this.groupAlignSetting.TabStop = false;
            this.groupAlignSetting.Text = "ALIGN SETTING";
            // 
            // btnAlignSetting
            // 
            this.btnAlignSetting.BackColor = System.Drawing.Color.White;
            this.btnAlignSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlignSetting.Location = new System.Drawing.Point(6, 22);
            this.btnAlignSetting.Name = "btnAlignSetting";
            this.btnAlignSetting.Size = new System.Drawing.Size(312, 46);
            this.btnAlignSetting.TabIndex = 80;
            this.btnAlignSetting.Text = "ALIGN PARAM SETTING";
            this.btnAlignSetting.UseVisualStyleBackColor = true;
            // 
            // comboBoxAlignToolType
            // 
            this.comboBoxAlignToolType.DataSource = null;
            this.comboBoxAlignToolType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboBoxAlignToolType.FillColor = System.Drawing.Color.White;
            this.comboBoxAlignToolType.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAlignToolType.ForeColor = System.Drawing.Color.Black;
            this.comboBoxAlignToolType.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comboBoxAlignToolType.Items.AddRange(new object[] {
            "Pattern Only",
            "FindLine Only"});
            this.comboBoxAlignToolType.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboBoxAlignToolType.Location = new System.Drawing.Point(4, 874);
            this.comboBoxAlignToolType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAlignToolType.MaxDropDownItems = 3;
            this.comboBoxAlignToolType.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBoxAlignToolType.Name = "comboBoxAlignToolType";
            this.comboBoxAlignToolType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBoxAlignToolType.RectColor = System.Drawing.Color.Black;
            this.comboBoxAlignToolType.Size = new System.Drawing.Size(215, 42);
            this.comboBoxAlignToolType.SymbolSize = 24;
            this.comboBoxAlignToolType.TabIndex = 2230;
            this.comboBoxAlignToolType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBoxAlignToolType.Watermark = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStage1);
            this.groupBox1.Controls.Add(this.btnStage2);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 86);
            this.groupBox1.TabIndex = 2225;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STAGE INDEX";
            // 
            // btnStage1
            // 
            this.btnStage1.BackColor = System.Drawing.Color.White;
            this.btnStage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStage1.Location = new System.Drawing.Point(2, 30);
            this.btnStage1.Margin = new System.Windows.Forms.Padding(2);
            this.btnStage1.Name = "btnStage1";
            this.btnStage1.Size = new System.Drawing.Size(207, 50);
            this.btnStage1.TabIndex = 167;
            this.btnStage1.Text = "STAGE 1";
            this.btnStage1.UseVisualStyleBackColor = true;
            this.btnStage1.Click += new System.EventHandler(this.btnStage1_Click);
            // 
            // btnStage2
            // 
            this.btnStage2.BackColor = System.Drawing.Color.White;
            this.btnStage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStage2.Location = new System.Drawing.Point(213, 30);
            this.btnStage2.Margin = new System.Windows.Forms.Padding(2);
            this.btnStage2.Name = "btnStage2";
            this.btnStage2.Size = new System.Drawing.Size(207, 50);
            this.btnStage2.TabIndex = 165;
            this.btnStage2.Text = "STAGE 2";
            this.btnStage2.UseVisualStyleBackColor = true;
            this.btnStage2.Click += new System.EventHandler(this.btnStage2_Click);
            // 
            // CFormSetupTeach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 983);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxAlignToolType);
            this.Controls.Add(this.groupAlignSetting);
            this.Controls.Add(this.btnOpenToolBlock);
            this.Controls.Add(this.cogDisplayStatusBar_Result);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxOperation);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnToolSetting);
            this.Controls.Add(this.BtnSetMasterPosition);
            this.Controls.Add(this.BtnMasterPositionDisplay);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnTitleCam);
            this.Controls.Add(this.cogDisplayStatusBar_Camera);
            this.Controls.Add(this.cogDisplayResult);
            this.Controls.Add(this.cogDisplayCamera);
            this.Controls.Add(this.panelSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormSetupTeach";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CFormSetupTeach";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CFormSetupTeach_FormClosed);
            this.Load += new System.EventHandler(this.CFormSetupTeach_Load);
            this.panelSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToolList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayResult)).EndInit();
            this.groupBoxOperation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupAlignSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button btnPatternAdd;
        private System.Windows.Forms.Button btnPatternDelete;
        private System.Windows.Forms.Button btnToolPaste;
        private System.Windows.Forms.Button btnToolCopy;
        private System.Windows.Forms.Button btnCamera2;
        private System.Windows.Forms.Button btnTitleAlignToolType;
        private System.Windows.Forms.Button btnTitleToolList;
        private System.Windows.Forms.DataGridView dataGridViewToolList;
        private System.Windows.Forms.Button btnTitleCamera;
        private System.Windows.Forms.Button btnCamera1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayCamera;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayResult;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBar_Camera;
        private System.Windows.Forms.Button btnTitleCam;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button BtnMasterPositionDisplay;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button BtnSetMasterPosition;
        private System.Windows.Forms.Button BtnGrabCamera;
        private System.Windows.Forms.Button BtnGrabImage;
        private System.Windows.Forms.Button BtnLoadImage;
        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.Button btnToolSetting;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBar_Result;
        private System.Windows.Forms.Button btnOpenToolBlock;
        private System.Windows.Forms.GroupBox groupAlignSetting;
        private System.Windows.Forms.Button btnAlignSetting;
        private Sunny.UI.UIComboBox comboBoxAlignToolType;
        private System.Windows.Forms.Button btnChooseTool;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStage1;
        private System.Windows.Forms.Button btnStage2;
    }
}