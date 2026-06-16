using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AlignVision.CConfig;

namespace AlignVision
{
    public partial class CFormConfigOption : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;

        private List<CConfig.CRecipeInformation> m_objModelParameterList;

        private int m_iSelectedRow;

        public CFormConfigOption(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }

        private void CFormConfigOption_Load(object sender, EventArgs e)
        {
            Initialize();

        }

        private void CFormConfigOption_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();

        }

        public bool Initialize()
        {
            bool bReturn = false;

            // Tên bảng
            string[] strColumnName = { "Index", "Name" };
            if (false == InitializeGridView(GridViewRecipeList, strColumnName))
            {
                return bReturn;
            }

            this.comboBoxCenterLineColor.Items.Clear();
            foreach (CogColorConstants eItem in Enum.GetValues(typeof(CogColorConstants)))
            {
                if ("None" == eItem.ToString())
                {
                    continue;
                }
                this.comboBoxCenterLineColor.Items.Add(eItem.ToString());
            }
            this.comboBoxCenterLineColor.SelectedIndex = m_objDocument.m_objConfig.GetOptionParameter().iCenterLineColorIndex;

            // Hiện thị thông tin camera, light, controll pc trên form
            GetDisplayHardWareInfor();

            //GetDisplayAlignOption();

            GetOptionData();
            SetChangeLanguage();
            timer.Interval = 100;
            timer.Enabled = false;

            bReturn = true;
            return bReturn;
        }

        public void DeInitialize()
        {
        }

        /// <summary>
        /// Khởi tạo bảng dữ liệu recipe
        /// </summary>
        /// <param name="objGridView"></param>
        /// <param name="strColumnName"></param>
        /// <returns></returns>
        private bool InitializeGridView(DataGridView objGridView, string[] strColumnName)
        {
            bool result = false;
            if (InitializeGridView(objGridView) == true)
            {
                objGridView.ReadOnly = true;
                objGridView.MultiSelect = false;
                objGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                for (int i = 0; i < strColumnName.Length; i++)
                {
                    objGridView.Columns.Add($"{i}", strColumnName[i]);
                    objGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                objGridView.Columns[0].Width = 100;
                SetGridViewFont(objGridView, 12.0);
                result = true;
            }
            return result;

        }
        private void GridViewRecipeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    return;
                }
                m_iSelectedRow = dataGridView.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Đồng bộ danh sách recipe với bảng hiện thị
        /// </summary>
        /// <param name="objModelList"></param>
        private void SetRecipeListGridView(List<CConfig.CRecipeInformation> objModelList)
        {
            bool flag = true;
            DataGridView gridviewRecipeList = GridViewRecipeList;
            try
            {
                //Kiểm tra số lượng reciepe có thay đổi không, nếu không thay đổi thì kiểm tra tiếp tên recipe có thay đổi không,
                //nếu không thay đổi thì không cần cập nhật lại bảng
                if (objModelList.Count == gridviewRecipeList.RowCount)
                {
                    for (int i = 0; i < objModelList.Count; i++)
                    {
                        if (objModelList[i].strBootRecipe != gridviewRecipeList[1, i].Value.ToString())
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace);
            }

            // Nếu không có sự thay đổi nào về số lượng recipe và tên recipe thì không cần cập nhật lại bảng
            if (flag)
            {
                return;
            }
            lock (gridviewRecipeList)   // khóa thread để tránh xung đột
            {
                gridviewRecipeList.Rows.Clear();
                for (int i = 0; i < objModelList.Count; i++)
                {
                    string[] values = { objModelList[i].strIndex, objModelList[i].strBootRecipe };
                    gridviewRecipeList.Rows.Add(values);
                    if (objModelList[i].strBootRecipe == m_objDocument.m_objConfig.GetSystemParameter().strBootRecipe)
                    {
                        m_iSelectedRow = i;
                    }
                }
                try
                {
                    if (m_iSelectedRow >= objModelList.Count)
                    {
                        m_iSelectedRow = 0;
                    }
                    gridviewRecipeList[0, m_iSelectedRow].Selected = true;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.StackTrace);
                }
            }

        }


        private void SetRecipeListData(int iRow)
        {
            if (m_objModelParameterList[iRow].strBootRecipe == m_objDocument.m_objConfig.GetSystemParameter().strBootRecipe)
            {
                btnDeleteRcp.Enabled = false;
                btnSaveRcp.Enabled = true;
            }
            else
            {
                btnDeleteRcp.Enabled = true;
                btnSaveRcp.Enabled = false;
            }
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage("Do you wanna Load ?"))
            {
                return;
            }
            m_objDocument.m_objConfig.LoadOptionParameter();
            GetOptionData();
            m_objDocument.SetMessage("Load Complete");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage("Do you want to save the changes?"))
            {
                return;
            }

            COptionParameter m_objOptionParameter = new COptionParameter();
            SetDisplaySaveImage(m_objOptionParameter);
            m_objDocument.m_objConfig.SaveOptionParameter(m_objOptionParameter);

            //SetDisplayAlignOption();
            m_objDocument.SetMessage("Save Complete");
        }


        private void btnSaveRcp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage("Do you want to save?"))
            {
                return;
            }
            CConfig.CRecipeInformation objRecipeParameter = m_objModelParameterList[m_iSelectedRow];
            m_objDocument.m_objConfig.SaveRecipeParameter(objRecipeParameter);
            m_objModelParameterList = m_objDocument.m_objRecipeManagement.GetModelParameterList();
        }

        private void btnLoadRrp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage("Do you want to load?"))
            {
                return;
            }
            CConfig.CSystemParameter systemParameter = m_objDocument.m_objConfig.GetSystemParameter();

            systemParameter.strBootRecipe = m_objModelParameterList[m_iSelectedRow].strBootRecipe;
            m_objDocument.m_objConfig.SaveSystemParameter(systemParameter);
            m_objDocument.m_objConfig.LoadRecipeParameter();
            m_objModelParameterList = m_objDocument.m_objRecipeManagement.GetModelParameterList();
            m_objDocument.m_objConfig.LoadLightControllerParameter();
            //m_objDocument.m_objConfig.LoadVisionParameter();
            m_objDocument.m_objConfig.LoadCameraParameter();
            //m_objDocument.m_objProcessMain.LoadRecipe();
            //m_objDocument.m_objProcessMain.SetCameraConfig();
        }

        private void btnDeleteRcp_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage(" Do you want delete?"))
            {
                return;
            }
            string strBootRecipe = m_objModelParameterList[m_iSelectedRow].strBootRecipe;
            string directoryDelete = $@"{CDefine.DEF_ALIGN_RECIPE_PATH}\{strBootRecipe}";

            m_objDocument.m_objRecipeManagement.SetDirectoryDelete(directoryDelete);
            m_objModelParameterList = m_objDocument.m_objRecipeManagement.GetModelParameterList();

            //string strButton = string.Format("[{0}] [Delete PPID : {1}]", "BtnDelete_Click", strPPID);
            //m_objDocument.SetUpdateButtonLog(this, strButton);
        }

        private void btnCreateRcp_Click(object sender, EventArgs e)
        {
            CRecipeManagement objModel = m_objDocument.m_objRecipeManagement;
            CConfig objConfig = m_objDocument.m_objConfig;

            if (DialogResult.Yes != m_objDocument.SetMessage(" Do you want creat?"))
            {
                return;
            }
            if (btnCreateName.Text == "" || btnCreateIndex.Text == "")
            {
                m_objDocument.SetMessage("PPID or Index is EMPTY!");
                return;
            }
            if (true == m_objDocument.m_objRecipeManagement.GetPPIDDuplicate(btnCreateName.Text))
            {
                m_objDocument.SetMessage("PPID Name is DUPLICATE!");
                return;
            }
            if (true == m_objDocument.m_objRecipeManagement.GetIndexDuplicate(btnCreateIndex.Text))
            {
                m_objDocument.SetMessage("Index is DUPLICATE!");
                return;
            }
            string strExistFilePath = $@"{CDefine.DEF_ALIGN_RECIPE_PATH}\{objConfig.GetSystemParameter().strBootRecipe}";
            string strNewFilePath = $@"{CDefine.DEF_ALIGN_RECIPE_PATH}\{btnCreateName.Text}";


            objModel.SetDirectoryCopy(strExistFilePath, strNewFilePath);
            objModel.SetPPIDMatch(btnCreateName.Text, btnCreateIndex.Text);
            m_objModelParameterList = objModel.GetModelParameterList();
            btnCreateIndex.Text = "";
            btnCreateName.Text = "";

            //string strButton = string.Format("[{0}] [Create PPID : {1}]", "BtnCreate_Click", btnCreateName.Text);
            //m_objDocument.SetUpdateButtonLog(this, strButton);
        }

        private void btnCreateIndex_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            FormKeyPad formKeyPad = new FormKeyPad(1);
            if (DialogResult.OK == formKeyPad.ShowDialog())
            {
                button.Text = formKeyPad.m_dResultValue.ToString();
            }
        }

        private void btnCreateName_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            FormKeyBoard formKeyBoard = new FormKeyBoard();
            if (DialogResult.OK == formKeyBoard.ShowDialog())
            {
                button.Text = formKeyBoard.m_strReturnValue.ToUpper();
            }
        }
        public bool SetChangeLanguage()
        {
            return true;
        }
        public void SetTimer(bool bTimer)
        {
            timer.Enabled = bTimer;
        }
        public void SetVisible(bool bVisible)
        {
            this.Visible = bVisible;
            if (bVisible)
            {
                //Sửa lỗi ngăn không cho cập nhật xảy ra khi quay lại tab khác sau khi thực hiện thay đổi.
                m_objModelParameterList = m_objDocument.m_objRecipeManagement.GetModelParameterList();

                m_objDocument.GetMainFrame().SetCurrentForm(this);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            btnSelectedPPID.Text = m_objDocument.m_objConfig.GetSystemParameter().strBootRecipe;
            SetRecipeListGridView(m_objModelParameterList);
            SetRecipeListData(m_iSelectedRow);
            if (m_objModelParameterList.Count < 2)
            {
                btnDeleteRcp.Enabled = false;
            }

            if (m_objDocument.GetRunMode() == CDefine.enumRunMode.RUN_MODE_START)
            {
                btnSave.Enabled = false;
            }
        }

        /// <summary>
        /// Thong tin luu hinh anh duoc hien thi tren form
        /// </summary>
        private void GetOptionData()
        {
            checkBoxOriginImage.Checked = m_objDocument.m_objConfig.GetOptionParameter().bImageSave;
            checkBoxResultImage.Checked = m_objDocument.m_objConfig.GetOptionParameter().bImageGraphicSave;
            numericImageSavePeriod.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().iPeriodImage;

            switch (m_objDocument.m_objConfig.GetOptionParameter().eImageSaveType)
            {
                case CDefine.enumImageSaveType.TYPE_SAVE_ALL:
                    checkBoxUseSaveALL.Checked = true;
                    break;
                case CDefine.enumImageSaveType.TYPE_SAVE_NG:
                    checkBoxUseSaveNG.Checked = true;
                    break;
                case CDefine.enumImageSaveType.TYPE_SAVE_OK:
                    checkBoxUseSaveOK.Checked = true;
                    break;
                default:
                    break;
            }

            numericImageSaveDriveVolume.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().dImageSaveDriveVolume;
            numericAutoBackupDay.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().iBackupDay;
            numericAutoBackupCount.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().iBackupCount;
            numericReportSavePeriod.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().iPeriodDatabase;
            checkBoxUseLinkPLCRecipe.Checked = m_objDocument.m_objConfig.GetOptionParameter().bLinkPlcRecipe;
            checkBoxUseCenterLine.Checked = m_objDocument.m_objConfig.GetOptionParameter().bUseCenterLine;
            comboBoxCenterLineColor.SelectedIndex = m_objDocument.m_objConfig.GetOptionParameter().iCenterLineColorIndex;
        }

        /// <summary>
        /// Thong tin phan cung thiet bi duoc hien thi tren form
        /// </summary>
        private void GetDisplayHardWareInfor()
        {
            // Controller IP
            lblIPControl.Text = $"Controller: {m_objDocument.m_objConfig.GetDeviceParameter().strControllerIP}";
            lblPortControl.Text = $"Port: {m_objDocument.m_objConfig.GetDeviceParameter().strControllerPort}";

            // Camera IP
            foreach (CDefine.enumCamera eItem in Enum.GetValues(typeof(CDefine.enumCamera)))
            {
                string strCameraInfo = $"Camera {(int)eItem + 1}: {m_objDocument.m_objConfig.GetCameraParameter(eItem).strCameraIP}";

                switch (eItem)
                {
                    case CDefine.enumCamera.CAMERA_ALIGN_1:
                        lblCamera1.Text = strCameraInfo;
                        break;
                    case CDefine.enumCamera.CAMERA_ALIGN_2:
                        lblCamera2.Text = strCameraInfo;
                        break;
                    //case CDefine.enumCamera.CAMERA_ALIGN_3:          // Camera 3,4 khong su dung nen khong hien thi thong tin
                    //    lblCamera3.Text = strCameraInfo;
                    //    break;
                    //case CDefine.enumCamera.CAMERA_ALIGN_4:
                    //    lblCamera4.Text = strCameraInfo;
                    //    break;
                    default:
                        break;
                }
            }
            lblCamera3.Text = "";
            lblCamera4.Text = "";

            // Light Controller IP
            if (m_objDocument.m_objConfig.GetLightControllerParameter().eType == CLightControllerParameter.enumType.TYPE_SOCKET)
            {
                lblPortLight1.Text = $"Light Controller IP: {m_objDocument.m_objConfig.GetLightControllerParameter().strSocketIPAddress}";
                lblBaudrateLight1.Text = $"Port: {m_objDocument.m_objConfig.GetLightControllerParameter().iSocketPortNumber}";
            }
            else
            {
                lblPortLight1.Text = $"COM: {m_objDocument.m_objConfig.GetLightControllerParameter().strSerialPortName}";
                lblBaudrateLight1.Text = $"Baudrate: {m_objDocument.m_objConfig.GetLightControllerParameter().iSerialPortBaudrate}";
            }
            lblBaudrateLight2.Text = "";
            lblPortLight2.Text = "";
            lblBaudrateLight2.Text = "";

            // Save path 
            lblRecipePath.Text = $"Recipe Path: {CDefine.DEF_ALIGN_RECIPE_PATH}";
            lblImagePath.Text = $"Image Path: {CDefine.DEF_ALIGN_REPORT_IMAGE_PATH}";

            // Drive Volume
            numericImageSaveDriveVolume.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().dImageSaveDriveVolume;
        }

        /// <summary>
        /// Lấy thông tin từ form và lưu vào cấu hình liên quan đến việc lưu hình ảnh
        /// </summary>
        private void SetDisplaySaveImage(COptionParameter m_objOptionParameter)
        {
            m_objOptionParameter.bImageSave = checkBoxOriginImage.Checked;
            m_objOptionParameter.bImageGraphicSave = checkBoxResultImage.Checked;
            m_objOptionParameter.iPeriodImage = (int)numericImageSavePeriod.Value;

            if (checkBoxUseSaveALL.Checked)
            {
                m_objOptionParameter.eImageSaveType = CDefine.enumImageSaveType.TYPE_SAVE_ALL;
            }
            else if (checkBoxUseSaveNG.Checked)
            {
                m_objOptionParameter.eImageSaveType = CDefine.enumImageSaveType.TYPE_SAVE_NG;
            }
            else if (checkBoxUseSaveOK.Checked)
            {
                m_objOptionParameter.eImageSaveType = CDefine.enumImageSaveType.TYPE_SAVE_OK;
            }

            m_objOptionParameter.dImageSaveDriveVolume = (int)numericImageSaveDriveVolume.Value;
            m_objOptionParameter.iBackupDay = (int)numericAutoBackupDay.Value;
            m_objOptionParameter.iBackupCount = (int)numericAutoBackupCount.Value;
            m_objOptionParameter.iPeriodDatabase = (int)numericReportSavePeriod.Value;
            m_objOptionParameter.bLinkPlcRecipe = checkBoxUseLinkPLCRecipe.Checked;
            m_objOptionParameter.bUseCenterLine = checkBoxUseCenterLine.Checked;
            m_objOptionParameter.iCenterLineColorIndex = comboBoxCenterLineColor.SelectedIndex;
        }

    }
}
