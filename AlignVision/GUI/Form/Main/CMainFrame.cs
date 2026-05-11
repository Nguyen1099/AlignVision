using AlignVision.Data;
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
    public partial class CMainFrame : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;
        private CFormCommon m_objTitle;
        private CFormCommon m_objView;
        private CFormCommon m_objMenu;
        private CFormCommon m_objCurrentForm;

        private CDialogInitProgramIntro View_Intro;

        public CMainFrame()
        {
            Size = new Size(1920, 1080);
            InitializeComponent();
            Initialize();
        }

        public bool Initialize()
        {
            bool result = false;
            //m_objDocument = new CDocument();
            //if (false == m_objDocument.Initialize())
            //{
            //    throw new ArgumentException("Fail to Initialize Document Class");
            //}


            if (true == InitializeForm())
            {
                result = true;
            }
            return result;
        }
        public bool InitializeForm()
        {
            bool result = false;

            m_objCurrentForm = this;
            m_objTitle = new CFormTitle(m_objDocument);
            m_objView = new CFormView(m_objDocument);
            m_objMenu = new CFormMenu(m_objDocument);

            SetFormDockStyle(m_objTitle, this.pnlTitle);
            SetFormDockStyle(m_objView, this.pnlView);
            SetFormDockStyle(m_objMenu, this.pnlMenu);

            result = true;
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
        public void SetCurrentForm(CFormCommon objForm)
        {
            if (m_objCurrentForm != objForm)
            {
                m_objCurrentForm = objForm;
            }
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
        }
        public Form GetFormView()
        {
            return m_objView;
        }


    }
}
