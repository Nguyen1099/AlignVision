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
    public partial class CFormView : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;
        /// <summary>
        ///  Current form
        /// </summary>
        private CDefine.FormView m_eCurrentForm = CDefine.FormView.FORM_VIEW_FINAL;

        /// <summary>
        /// Cấu trúc lưu trữ Form và CFormCommon
        /// </summary>
        private struct structureForm
        {
            private CFormCommon objForm;
            private CFormInterface Iform;

            public CFormCommon m_objForm => objForm;
            public CFormInterface m_IForm => Iform;
            public structureForm(CFormInterface form)
            {
                Iform = form;
                objForm = form as CFormCommon;
            }
        }

        private structureForm[] m_stForm;

        public CFormView(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }
        private void CFormView_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        public bool Initialize()
        {
            bool result = false;
            if (InitializeForm() == true)
            {
                result = true;
            }
            return result;

        }
        public bool InitializeForm()
        {
            bool result = false;
            m_stForm = new structureForm[(int)CDefine.FormView.FORM_VIEW_FINAL];
            SetChangeForm(CDefine.FormView.FORM_VIEW_MAIN);

            result = true;
            return result;
        }
        /// <summary>
        /// Change form
        /// </summary>
        /// <param name="eForm"></param>
        public void SetChangeForm(CDefine.FormView eForm)
        {
            if (m_eCurrentForm == eForm)
            {
                return;
            }
            if (CDefine.FormView.FORM_VIEW_FINAL != m_eCurrentForm)
            {
                m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(false);
                m_stForm[(int)m_eCurrentForm].m_IForm.SetTimer(false);
            }
            // Check form is null, if null create new form else show form
            if (null == m_stForm[(int)eForm].m_IForm)
            {
                switch (eForm)
                {
                    case CDefine.FormView.FORM_VIEW_MAIN:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormMain(m_objDocument) as CFormInterface);
                            break;
                        }
                    case CDefine.FormView.FORM_VIEW_SETUP:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormSetup(m_objDocument) as CFormInterface);
                            break;
                        }
                    case CDefine.FormView.FORM_VIEW_CONFIG:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormConfig(m_objDocument) as CFormInterface);
                            break;
                        }
                }
                SetFormDockStyle(m_stForm[(int)eForm].m_objForm, panelView);

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
        public void SetFormDockStyle(Form objForm, Panel panel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
            objForm.FormBorderStyle = FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            panel.Controls.Add(objForm);
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

        private void CFormView_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }
        public void DeInitialize()
        {
        }

    }
}
