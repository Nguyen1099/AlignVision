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
    public partial class CFormMainTwoCam : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;
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
            if (InitializeForm())
            {
                result = true;
            }
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
            return result;
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
        }
        public void SetVisible(bool bVisible)
        {
            this.Visible = bVisible;
        }


    }
}
