using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CFormSetupTeach : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;

        private Dictionary<CDefine.enumStage, CConfig.CStageParameter> m_objStageParameterList;

        private CDefine.enumCamera m_eCameraIndex;
        private CDefine.enumStage m_eStageIndex;

        private enum enumDataListColumnToolList
        {
            INDEX = 0,
            NAME,
            STATUS,
            LIST_FINAL
        }

        private string m_strCurrentModelID;
        private string m_strNewModelID;


        public CFormSetupTeach(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
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

        private void CFormSetupTeach_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            m_strCurrentModelID = "";
            m_strNewModelID = "";

            m_objStageParameterList = new Dictionary<CDefine.enumStage, CConfig.CStageParameter>();
            foreach (CDefine.enumStage eStage in Enum.GetValues(typeof(CDefine.enumStage)))
            {
                m_objStageParameterList[eStage] = m_objDocument.m_objConfig.GetStageParameter(eStage).Clone() as CConfig.CStageParameter;
            }

            m_eCameraIndex = CDefine.enumCamera.CAMERA_ALIGN_1;
            m_eStageIndex = CDefine.enumStage.STAGE_MAIN_ALIGN_1; 
            SetChangeStageIndex(m_eStageIndex);
            SetChangeCameraIndex(m_eCameraIndex);

            cogDisplayStatusBar_Camera.Display = cogDisplayCamera;
            cogDisplayStatusBar_Result.Display = cogDisplayResult;

            // Check License key
            isCheckLicenseKey();

            if (InitializeForm() == false)
            {
                throw new Exception("Failed to initialize CFormSetupSettingCamera.");
            }
        }

        private bool InitializeForm()
        {
            bool result = false;
            timer.Interval = 100;
            timer.Start();

            result = true;
            return result;
        }


        private void CFormSetupTeach_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }

        private void DeInitialize()
        {
            cogDisplayCamera.InteractiveGraphics.Dispose();
            cogDisplayCamera.Dispose();

            cogDisplayResult.InteractiveGraphics.Dispose();
            cogDisplayResult.Dispose();
        }

        /// <summary>
        /// Check if the license key is valid for the application.
        /// </summary>
        private void isCheckLicenseKey()
        {
            CogStringCollection objString = CogLicense.GetLicensedFeatures(false, false);
            CogLicenseResultConstants obj;
            try
            {
                obj = CogLicense.CheckLicenseState(CogLicenseConstants.PatMax);
            }
            catch (Exception ex)
            {
                obj = new CogLicenseResultConstants();
                obj = CogLicenseResultConstants.NotFound;
                CDocument.Exception(ex);
            }
            string strLicense = obj.ToString();
            if ("Valid" != strLicense)
            {
                string strError = string.Format("{0} {1} {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, "There is no vision license key.");
                m_objDocument.SetMessage(strError);
            }
        }

        /// <summary>
        /// Các tham số cần được load khi thay đổi camera
        /// </summary>
        private void SetChangeCameraIndex(CDefine.enumCamera enumCamera)
        {
            m_eCameraIndex = enumCamera;
        }

        /// <summary>
        /// Các tham số cần được load khi thay đổi stage
        /// </summary>
        /// <param name="enumStage"></param>
        private void SetChangeStageIndex(CDefine.enumStage enumStage)
        {
            m_eStageIndex = enumStage;
            comboBoxAlignToolType.SelectedIndex =(int)m_objStageParameterList[enumStage].eAlignToolType;
        }

        private void BtnGrabImage_Click(object sender, EventArgs e)
        {

        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            CogImageFile image = new CogImageFile();

            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFile.RestoreDirectory = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image.Open(openFile.FileName, CogImageFileModeConstants.Read);
                CogImage8Grey m_objCogImageInput = (CogImage8Grey)image[0];
                cogDisplayCamera.Image = m_objCogImageInput;
            }

        }

        private void btnStage1_Click(object sender, EventArgs e)
        {
            m_eStageIndex = CDefine.enumStage.STAGE_MAIN_ALIGN_1;

            SetChangeStageIndex(CDefine.enumStage.STAGE_MAIN_ALIGN_1);

        }

        private void btnStage2_Click(object sender, EventArgs e)
        {
            m_eStageIndex = CDefine.enumStage.STAGE_MAIN_ALIGN_2;

            SetChangeStageIndex(CDefine.enumStage.STAGE_MAIN_ALIGN_2);
        }

        private void BtnGrabCamera_Click(object sender, EventArgs e)
        {

        }

        private void btnCamera1_Click(object sender, EventArgs e)
        {
            if (m_eCameraIndex != CDefine.enumCamera.CAMERA_ALIGN_1)
            {
                m_eCameraIndex = CDefine.enumCamera.CAMERA_ALIGN_1;
            }

            btnTitleCam.Text = "CAMERA 1";
            // Thay đổi thông số khi chuyển camera.
            SetChangeCameraIndex(CDefine.enumCamera.CAMERA_ALIGN_1);
        }

        private void btnCamera2_Click(object sender, EventArgs e)
        {
            if (m_eCameraIndex != CDefine.enumCamera.CAMERA_ALIGN_2)
            {
                m_eCameraIndex = CDefine.enumCamera.CAMERA_ALIGN_2;
            }

            btnTitleCam.Text = "CAMERA 2";
            // Thay đổi thông số khi chuyển camera.
            SetChangeCameraIndex(CDefine.enumCamera.CAMERA_ALIGN_2);
        }

        private void btnPatternAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnPatternDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnToolPaste_Click(object sender, EventArgs e)
        {

        }

        private void btnToolCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseTool_Click(object sender, EventArgs e)
        {
            m_objStageParameterList[m_eStageIndex].eAlignToolType = (CDefine.enumAlignToolType)comboBoxAlignToolType.SelectedIndex;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch(m_eStageIndex)
            {
                case CDefine.enumStage.STAGE_MAIN_ALIGN_1:
                    btnStage1.BackColor = m_colorOn;
                    btnStage2.BackColor = Color.White;

                    btnCamera1.Visible = true;
                    btnCamera2.Visible = false;
                    break;
                case CDefine.enumStage.STAGE_MAIN_ALIGN_2:
                    btnStage1.BackColor = Color.White;
                    btnStage2.BackColor = m_colorOn;

                    btnCamera1.Visible = false;
                    btnCamera2.Visible = true;
                    break;
                default:
                    break;
            }
            switch (m_eCameraIndex)
            {
                case CDefine.enumCamera.CAMERA_ALIGN_1:
                    btnCamera1.BackColor = m_colorOn;
                    btnCamera2.BackColor = Color.White;
                    break;
                case CDefine.enumCamera.CAMERA_ALIGN_2:
                    btnCamera1.BackColor = Color.White;
                    btnCamera2.BackColor = m_colorOn;
                    break;
                default:
                    break;
            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_objDocument.m_objConfig.SaveStageParameter(m_eStageIndex, m_objStageParameterList[m_eStageIndex]);
        }
    }
}
