using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CFormMainTwoCam : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;

        private CogImage8Grey[] m_objImage8Gray;
        public CFormMainTwoCam(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }


        private void CFormMainTwoCam_Load(object sender, EventArgs e)
        {
            Initialize();

        }
        public bool Initialize()
        {
            bool result = false;

            // Khởi tạo mảng hình ảnh
            m_objImage8Gray = new CogImage8Grey[Enum.GetNames(typeof(CDefine.enumCamera)).Length];

            if (InitializeForm() == false)
            {
                throw new Exception("Failed to initialize CFormMainTwoCam.");
            }
            result = true;
            return result;
        }

        private void CFormMainTwoCam_FormClosed(object sender, FormClosedEventArgs e)
        {

            DeInitialize();
        }
        public void DeInitialize()
        {
        }
        private bool InitializeForm()
        {
            bool result = false;
            timer.Interval = 100;
            timer.Enabled = false;

            Panel[] panels = { pnlCam1, pnlCam2 };
            foreach (CDefine.enumCamera iCamera in Enum.GetValues(typeof(CDefine.enumCamera)))
            {
                m_objDocument.m_objFormDisplay[iCamera].Initialize(iCamera, m_objDocument);
                SetFormDockStyle(m_objDocument.m_objFormDisplay[iCamera], panels[(int)iCamera]);
            }
            result = true;
            return result;
        }
        private void btnExpand1_Click(object sender, EventArgs e)
        {
            CFormViewCameraExpand objFormViewCameraExpand = new CFormViewCameraExpand(m_objDocument, CDefine.enumCamera.CAMERA_ALIGN_1, m_objImage8Gray[(int)CDefine.enumCamera.CAMERA_ALIGN_1]);
            objFormViewCameraExpand.ShowDialog();

        }
        private void btnExpand2_Click(object sender, EventArgs e)
        {
            CFormViewCameraExpand objFormViewCameraExpand = new CFormViewCameraExpand(m_objDocument, CDefine.enumCamera.CAMERA_ALIGN_2, m_objImage8Gray[(int)CDefine.enumCamera.CAMERA_ALIGN_2]);
            objFormViewCameraExpand.ShowDialog();
        }

        private void btnTrigger1_Click(object sender, EventArgs e)
        {

        }

        private void btnTrigger2_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadImage1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            CogImageFile image = new CogImageFile();

            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFile.RestoreDirectory = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image.Open(openFile.FileName, CogImageFileModeConstants.Read);
                CogImage8Grey m_objCogImageInput = (CogImage8Grey)image[0];
                m_objImage8Gray[(int)CDefine.enumCamera.CAMERA_ALIGN_1] = m_objCogImageInput;
                m_objDocument.m_objFormDisplay[CDefine.enumCamera.CAMERA_ALIGN_1].getCogDisplay().Image = m_objCogImageInput;
            }
        }

        private void btnLoadImage2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            CogImageFile image = new CogImageFile();

            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFile.RestoreDirectory = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                image.Open(openFile.FileName, CogImageFileModeConstants.Read);
                CogImage8Grey m_objCogImageInput = (CogImage8Grey)image[0];
                m_objImage8Gray[(int)CDefine.enumCamera.CAMERA_ALIGN_2] = m_objCogImageInput;
                m_objDocument.m_objFormDisplay[CDefine.enumCamera.CAMERA_ALIGN_2].getCogDisplay().Image = m_objCogImageInput;
            }
        }

        public void SetFormDockStyle(Form objForm, Panel objPanel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
            objForm.Visible = true;
            objForm.Dock = DockStyle.Fill;
            objPanel.Controls.Add(objForm);
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

    }
}
