using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private COptionParameter m_objOptionParameter;


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

            m_objOptionParameter = m_objDocument.m_objConfig.GetOptionParameter();

            // 중심선 색상 콤보 박스 추가
            this.comboBoxCenterLineColor.Items.Clear();
            foreach (CogColorConstants eItem in Enum.GetValues(typeof(CogColorConstants)))
            {
                if ("None" == eItem.ToString())
                {
                    continue;
                }
                this.comboBoxCenterLineColor.Items.Add(eItem.ToString());
            }
            this.comboBoxCenterLineColor.SelectedIndex = m_objOptionParameter.iCenterLineColorIndex;

            SetDisplayHardWareInfor();

            //SetDisplayAlignOption();

            SetDisplaySaveImage();




            SetChangeLanguage();
            timer.Interval = 100;
            timer.Enabled = false;

            bReturn = true;
            return bReturn;
        }

        public void DeInitialize()
        {
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveRcp_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadRrp_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRcp_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateRcp_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateIndex_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateName_Click(object sender, EventArgs e)
        {

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
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            {
                if (checkBoxUseSaveAll.Checked == true)
                {
                    checkBoxUseSaveNG.Checked = false;
                    checkBoxUseSaveOK.Checked = false;

                }
                else if (checkBoxUseSaveNG.Checked == true)
                {
                    checkBoxUseSaveAll.Checked = false;
                    checkBoxUseSaveOK.Checked = false;
                }
                else if (checkBoxUseSaveOK.Checked == true)
                {
                    checkBoxUseSaveAll.Checked = false;
                    checkBoxUseSaveNG.Checked = false;
                }
            }
        }

        /// <summary>
        /// Thong tin luu hinh anh duoc hien thi tren form
        /// </summary>
        private void SetDisplaySaveImage()
        {
            checkBoxUseImageSave.Checked = m_objDocument.m_objConfig.GetOptionParameter().bImageSave;
            checkBoxUseGraphicSave.Checked = m_objDocument.m_objConfig.GetOptionParameter().bImageGraphicSave;
            numericImageSavePeriod.Value = (decimal)m_objDocument.m_objConfig.GetOptionParameter().iPeriodImage;

            switch (m_objDocument.m_objConfig.GetOptionParameter().eImageSaveType)
            {
                case CDefine.enumImageSaveType.TYPE_SAVE_ALL:
                    checkBoxUseSaveAll.Checked = true;
                    checkBoxUseSaveNG.Checked = false;
                    checkBoxUseSaveOK.Checked = false;
                    break;
                case CDefine.enumImageSaveType.TYPE_SAVE_NG:
                    checkBoxUseSaveNG.Checked = true;      
                    checkBoxUseSaveAll.Checked = false;
                    checkBoxUseSaveOK.Checked = false;
                    break;
                case CDefine.enumImageSaveType.TYPE_SAVE_OK:
                    checkBoxUseSaveOK.Checked = true;
                    checkBoxUseSaveAll.Checked = false;
                    checkBoxUseSaveNG.Checked = false;
                    break;
                default:
                    break;
            }

            // Kieu luu hinh anh
            switch (m_objDocument.m_objConfig.GetOptionParameter().eImageFormatType)
            {
                case CDefine.enumImageFormatType.TYPE_BMP:
                    checkBoxUseImageTypeBMP.Checked = true;
                    checkBoxUseImageTypeJPG.Checked = false;
                    break;
                case CDefine.enumImageFormatType.TYPE_JPG:
                    checkBoxUseImageTypeBMP.Checked = false;
                    checkBoxUseImageTypeJPG.Checked = true;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Thoong tin phan cung thiet bi duoc hien thi tren form
        /// </summary>
        private void SetDisplayHardWareInfor()
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
                    //case CDefine.enumCamera.CAMERA_ALIGN_3:
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

        private void SetDisplayAlignOption()
        {
           
        }
    }
}
