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
    public partial class CFormMenu : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;
        private CFormView m_objView;

        private string m_ButtonActive = string.Empty;

        public CFormMenu(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }

        private void CFormMenu_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        private bool Initialize()
        {
            bool result = false;
            if (InitializeForm())
            {
                result = true;
            }
            return result;
        }
        public bool InitializeForm()
        {
            bool result = false;

            CMainFrame cMainFrame = Owner as CMainFrame;
            m_objView = cMainFrame.GetFormView() as CFormView;
            m_ButtonActive = "btnMain";
            SetFormDockStyle(new FormStatusPC(), panelResourceInfo);

            timer.Interval = 100;
            timer.Start();

            result = true;
            return result;
        }
        public void SetFormDockStyle(Form objForm, Panel panel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
            objForm.Visible = true;
            objForm.FormBorderStyle = FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            panel.Controls.Add(objForm);
        }


        private void btnMain_Click(object sender, EventArgs e)
        {
            m_ButtonActive = "btnMain";
            m_objView.SetChangeForm(CDefine.FormView.FORM_VIEW_MAIN);
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            m_ButtonActive = "btnSetup"; 
            m_objView.SetChangeForm(CDefine.FormView.FORM_VIEW_SETUP);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            m_ButtonActive = "btnConfig";
            m_objView.SetChangeForm(CDefine.FormView.FORM_VIEW_CONFIG);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            m_ButtonActive = "btnReport";
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {

        }

        private void btnIOTest_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
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
             switch (m_ButtonActive)
            {
                case "btnMain":
                    btnMain.FillColor = m_colorOn;
                    btnSetup.FillColor = m_colorControl;
                    btnConfig.FillColor = m_colorControl;
                    btnReport.FillColor = m_colorControl;
                    break;
                case "btnSetup":
                    btnMain.FillColor = m_colorControl;
                    btnSetup.FillColor = m_colorOn;
                    btnConfig.FillColor = m_colorControl;
                    btnReport.FillColor = m_colorControl;
                    break;
                case "btnConfig":
                    btnMain.FillColor = m_colorControl;
                    btnSetup.FillColor = m_colorControl;
                    btnConfig.FillColor = m_colorOn;
                    btnReport.FillColor = m_colorControl;
                    break;
                case "btnReport":
                    btnMain.FillColor = m_colorControl;
                    btnSetup.FillColor = m_colorControl;
                    btnConfig.FillColor = m_colorControl;
                    btnReport.FillColor = m_colorOn;
                    break;
                default:
                    break;
            }
        }
    }
}
