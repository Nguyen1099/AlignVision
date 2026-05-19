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
    public partial class CFormMain : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;
        private struct structureForm
        {
            private CFormCommon _objForm;

            private CFormInterface _IForm;

            public CFormCommon m_objForm => _objForm;

            public CFormInterface m_IForm => _IForm;

            public structureForm(CFormInterface form)
            {
                _IForm = form;
                _objForm = _IForm as CFormCommon;
            }
        }

        private structureForm[] m_stForm;

        private CDefine.FormViewMain m_eCurrentForm = CDefine.FormViewMain.FORM_VIEW_MAIN_FINAL;

        public CFormMain(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }

        private void CFormMain_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        private void CFormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }
        public void DeInitialize()
        {
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

            m_stForm = new structureForm[(int)CDefine.FormViewMain.FORM_VIEW_MAIN_FINAL];
            SetChangeForm(CDefine.FormViewMain.FORM_VIEW_MAIN);
            result = true;
            return result;
        }
        public void SetChangeForm(CDefine.FormViewMain eForm)
        {
            if (m_eCurrentForm == eForm)
            {
                return;
            }
            if (CDefine.FormViewMain.FORM_VIEW_MAIN_FINAL != m_eCurrentForm)
            {
                m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(false);
                m_stForm[(int)m_eCurrentForm].m_IForm.SetTimer(false);
            }
            if (null == m_stForm[(int)eForm].m_IForm)
            {
                if (eForm == CDefine.FormViewMain.FORM_VIEW_MAIN)
                {
                    m_stForm[(int)eForm] = new structureForm(new CFormMainTwoCam(m_objDocument) as CFormInterface);
                }
                SetFormDockStyle(m_stForm[(int)eForm].m_objForm, panelFormView);
                m_stForm[(int)eForm].m_IForm.SetVisible(true);
                m_stForm[(int)eForm].m_IForm.SetTimer(true);
                m_stForm[(int)eForm].m_IForm.SetChangeLanguage();
            }
            else
            {
                m_stForm[(int)eForm].m_IForm.SetVisible(true);
                m_stForm[(int)eForm].m_IForm.SetTimer(true);
                m_stForm[(int)eForm].m_IForm.SetChangeLanguage();
            }
            m_eCurrentForm = eForm;
        }

        public void SetFormDockStyle(Form objForm, Panel objPanel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
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
            m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(bVisible);
        }
    }
}
