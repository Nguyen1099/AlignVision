using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CFormSetupSettingCamera : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;

        private enum enumCameraIndex
        {
            CAMERA_1 = 0,
            CAMERA_2 = 1,
            CAMERA_FINAL
        }

        private enumCameraIndex m_eCameraIndex;

        /// <summary>
        /// Quản lý form hiện thị hình ảnh
        /// </summary>
        private Dictionary<CDefine.enumCamera, CFormDisplay> m_objFormDisplay;

        /// <summary>
        /// Quản lý thông số camera
        /// </summary>
        private Dictionary<CDefine.enumCamera, CConfig.CCameraParameter> m_objCameraParameters;

        /// <summary>
        /// Quản lý thông số Light Controller
        /// </summary>
        private CConfig.CLightControllerParameter m_objLightControllerParameters;


        public CFormSetupSettingCamera(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }

        private void CFormSetupSettingCamera_Load(object sender, EventArgs e)
        {
            Initialize();

        }
        public bool Initialize()
        {
            bool result = false;

            m_eCameraIndex = enumCameraIndex.CAMERA_1;
            // Khởi tạo form hiển thị hình ảnh
            {
                m_objFormDisplay = new Dictionary<CDefine.enumCamera, CFormDisplay>();
                foreach (CDefine.enumCamera index in Enum.GetValues(typeof(CDefine.enumCamera)))
                {
                    m_objFormDisplay[index] = new CFormDisplay();
                }
            }

            GetParameterRecipe();

            // Lấy dữ liệu từ các parameter để hiển thị lên form
            GetParameterData(enumCameraIndex.CAMERA_1);

            if (InitializeForm() == false)
            {
                throw new Exception("Failed to initialize CFormSetupSettingCamera.");
            }
            result = true;
            return result;
        }


        private bool InitializeForm()
        {
            bool result = false;
            timer.Interval = 100;
            timer.Start();

            Panel[] panels = { pnlCam1, pnlCam2 };
            foreach (CDefine.enumCamera iCamera in Enum.GetValues(typeof(CDefine.enumCamera)))
            {
                m_objFormDisplay[iCamera].Initialize(iCamera, m_objDocument);
                SetFormDockStyle(m_objFormDisplay[iCamera], panels[(int)iCamera]);
            }

            result = true;
            return result;
        }

        private void CFormSetupSettingCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }

        public void DeInitialize()
        {
        }

        public void SetFormDockStyle(Form objForm, Panel objPanel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
            objForm.Visible = true;
            objForm.Dock = DockStyle.Fill;
            objPanel.Controls.Add(objForm);
        }

        private void btnExpand1_Click(object sender, EventArgs e)
        {
            CFormViewCameraExpand objFormViewCameraExpand = new CFormViewCameraExpand(m_objDocument, CDefine.enumCamera.CAMERA_ALIGN_1);
            objFormViewCameraExpand.ShowDialog();
        }

        private void btnExpand2_Click(object sender, EventArgs e)
        {
            CFormViewCameraExpand objFormViewCameraExpand = new CFormViewCameraExpand(m_objDocument, CDefine.enumCamera.CAMERA_ALIGN_2);
            objFormViewCameraExpand.ShowDialog();
        }

        private void btnLoadImageCamera1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            CogImageFile image = new CogImageFile();

            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFile.RestoreDirectory = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image.Open(openFile.FileName, CogImageFileModeConstants.Read);
                CogImage8Grey m_objCogImageInput = (CogImage8Grey)image[0];

                m_objFormDisplay[CDefine.enumCamera.CAMERA_ALIGN_1].getCogDisplay().Image = m_objCogImageInput;
            }
        }

        private void btnLoadImageCamera2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            CogImageFile image = new CogImageFile();

            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFile.RestoreDirectory = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image.Open(openFile.FileName, CogImageFileModeConstants.Read);
                CogImage8Grey m_objCogImageInput = (CogImage8Grey)image[0];

                m_objFormDisplay[CDefine.enumCamera.CAMERA_ALIGN_2].getCogDisplay().Image = m_objCogImageInput;
            }
        }

        private void btnGrabCamera1_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabCamera2_Click(object sender, EventArgs e)
        {

        }

        private void btnLiveCamera1_Click(object sender, EventArgs e)
        {

        }

        private void btnLiveCamera2_Click(object sender, EventArgs e)
        {

        }

        private void BtnRotation270_Click(object sender, EventArgs e)
        {

        }

        private void BtnRotation90_Click(object sender, EventArgs e)
        {

        }

        private void BtnReverseX_Click(object sender, EventArgs e)
        {

        }

        private void BtnReverseY_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage("Do you wanna Save ?"))
            {
                return;
            }
            SetParameterData(m_eCameraIndex);
            m_objDocument.m_objConfig.SaveLightControllerParameter(m_objLightControllerParameters);
            foreach (CDefine.enumCamera i in Enum.GetValues(typeof(CDefine.enumCamera)))
            {
                m_objDocument.m_objConfig.SaveCameraParameter(i, m_objCameraParameters[i]);
            }
            m_objDocument.SetMessage("Save Complete");

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != m_objDocument.SetMessage("Do you wanna Load ?"))
            {
                return;
            }
            GetParameterData(m_eCameraIndex);
            m_objDocument.SetMessage("Load Complete");

        }

        private void btnCamera1_Click(object sender, EventArgs e)
        {
            m_eCameraIndex = enumCameraIndex.CAMERA_1;
            GetParameterData(enumCameraIndex.CAMERA_1);
        }

        private void btnCamera2_Click(object sender, EventArgs e)
        {
            m_eCameraIndex = enumCameraIndex.CAMERA_2;
            GetParameterData(enumCameraIndex.CAMERA_2);
        }

        /// <summary>
        /// Lay du lieu khi doi Recipe
        /// </summary>
        private void GetParameterRecipe()
        {
            m_objCameraParameters = new Dictionary<CDefine.enumCamera, CConfig.CCameraParameter>();
            foreach (CDefine.enumCamera i in Enum.GetValues(typeof(CDefine.enumCamera)))
            {
                m_objCameraParameters[i] = m_objDocument.m_objConfig.GetCameraParameter(i).Clone() as CConfig.CCameraParameter;
            }

            m_objLightControllerParameters = m_objDocument.m_objConfig.GetLightControllerParameter().Clone() as CConfig.CLightControllerParameter;
        }
        /// <summary>
        /// Lấy dữ liệu từ các parameter để hiển thị lên form
        /// </summary>
        /// <param name="eCamera"></param>
        /// <exception cref="Exception"></exception>
        private void GetParameterData(enumCameraIndex eCamera)
        {
            // Camera Parameter
            numericExposureTime.Value = (decimal)m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dExposureTime;
            numericGain.Value = (decimal)m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dGain;
            numericGamma.Value = (decimal)m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dGamma;
            numericDigitalShift.Value = (decimal)m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dDigitalShift;

            // Light Controller Parameter
            numericLightChannel1.Value = (decimal)m_objLightControllerParameters.iIntensity[(int)CDefine.enumLightChannel.LIGHT_MAIN_ALIGN_1_1];
            numericLightChannel2.Value = (decimal)m_objLightControllerParameters.iIntensity[(int)CDefine.enumLightChannel.LIGHT_MAIN_ALIGN_1_2];
        }

        /// <summary>
        ///  Thiết lập dữ liệu cho các parameter từ các giá trị trên form
        /// </summary>
        /// <param name="eCamera"></param>
        /// <exception cref="Exception"></exception>
        private void SetParameterData(enumCameraIndex eCamera)
        {
            // Camera Parameter
            m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dExposureTime = (double)numericExposureTime.Value;
            m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dGain = (double)numericGain.Value;
            m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dGamma = (double)numericGamma.Value;
            m_objCameraParameters[(CDefine.enumCamera)eCamera].objCameraConfig.dDigitalShift = (double)numericDigitalShift.Value;
            // Light Controller Parameter
            m_objLightControllerParameters.iIntensity[(int)CDefine.enumLightChannel.LIGHT_MAIN_ALIGN_1_1] = (int)numericLightChannel1.Value;
            m_objLightControllerParameters.iIntensity[(int)CDefine.enumLightChannel.LIGHT_MAIN_ALIGN_1_2] = (int)numericLightChannel2.Value;
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            switch (m_eCameraIndex)
            {
                case enumCameraIndex.CAMERA_1:
                    btnCamera1.BackColor = m_colorOn;
                    btnCamera2.BackColor = Color.White;
                    break;
                case enumCameraIndex.CAMERA_2:
                    btnCamera1.BackColor = Color.White;
                    btnCamera2.BackColor = m_colorOn;
                    break;
                default:
                    break;
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
                m_objDocument.GetMainFrame().SetCurrentForm(this);

                // Cập nhật dữ liệu khi đổi recipe
                GetParameterRecipe();
                GetParameterData(m_eCameraIndex);
            }
        }

    }
}

