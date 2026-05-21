using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CFormSetup : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;

        /// <summary>
        /// lưu trữ thông tin form
        /// </summary>
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

        private CDefine.FormViewSetup m_eCurrentForm = CDefine.FormViewSetup.FORM_VIEW_SETUP_FINAL;
        private structureForm[] m_stForm;

        private Button[] m_btnMenu;

        public CFormSetup(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }


        private void CFormSetup_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        private void CFormSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
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
        public void DeInitialize()
        {
        }
        private bool InitializeForm()
        {
            bool result = false;
            int iMenuCount = (int)CDefine.FormViewSetup.FORM_VIEW_SETUP_FINAL;

            // Button margin & width settings
            int iWhiteSpace = 2;
            int iButtonWidth = (this.panelFormMenu.Width / iMenuCount);

            //If the number of buttons is small and the width is larger than the base button, it is fixed to the base button width.
            if (iButtonWidth > this.btnBase.Width)
            {
                iButtonWidth = this.btnBase.Width;
            }
            btnBase.Visible = false;

            string[] strButtonName = new string[iMenuCount];
            m_btnMenu = new Button[iMenuCount];
            for (int iLoopButton = 0; iLoopButton < strButtonName.Length; iLoopButton++)
            {
                strButtonName[iLoopButton] = ((CDefine.FormViewSetup)iLoopButton).ToString();
            }
            // Dynamically create buttons
            SetDynamicMenuButton(m_btnMenu, this.panelFormMenu, strButtonName, iButtonWidth, iWhiteSpace, new EventHandler(ButtonMenu_Click));
            // Set button name
            for (int iLoopMenu = 0; iLoopMenu < m_btnMenu.Length; iLoopMenu++)
            {
                m_btnMenu[iLoopMenu].Name = string.Format("BtnMainMenu[{0}]", iLoopMenu);
            }
            m_stForm = new structureForm[iMenuCount];
            SetChangeForm(CDefine.FormViewSetup.FORM_VIEW_SETUP_TEACH);

            timer.Interval = 100;
            timer.Enabled = true;

            result = true;
            return result;
        }
        public void SetChangeForm(CDefine.FormViewSetup eForm)
        {
            if (m_eCurrentForm == eForm)
            {
                return;
            }
            if (CDefine.FormViewSetup.FORM_VIEW_SETUP_FINAL != m_eCurrentForm)
            {
                m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(false);
                m_stForm[(int)m_eCurrentForm].m_IForm.SetTimer(false);
            }
            if (null == m_stForm[(int)eForm].m_IForm)
            {
                switch (eForm)
                {
                    case CDefine.FormViewSetup.FORM_VIEW_SETUP_CALIBRATION:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormSetupCalibration(m_objDocument) as CFormInterface);
                            break;
                        }
                    case CDefine.FormViewSetup.FORM_VIEW_SETUP_TEACH:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormSetupTeach(m_objDocument) as CFormInterface);
                            break;
                        }
                    case CDefine.FormViewSetup.FORM_VIEW_SETUP_SETTING_CAMERA:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormSetupSettingCamera(m_objDocument) as CFormInterface);
                            break;
                        }
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

        /// <summary>
        ///  Defining a button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonMenu_Click(object sender, EventArgs e)
        {
            Button objButton = sender as Button;
            try
            {
                var objRegex = new Regex(@"\[(.+)\]");
                if (true == objRegex.IsMatch(objButton.Name))
                {
                    string strText = objRegex.Match(objButton.Name).Groups[1].Value;
                    CDefine.FormViewSetup eFormView = (CDefine.FormViewSetup)Convert.ToInt32(strText);

                    // Add button log
                    string strLog = string.Format("[{0}] [Form Change : {1} -> {2}]", "ButtonMenu_Click", m_eCurrentForm.ToString(), eFormView.ToString());
                    //m_objDocument.SetUpdateButtonLog(this, strLog);

                    SetChangeForm(eFormView);
                }
            }
            catch (Exception ex)
            {
                //LogWrite.Exception(ex);
                MessageBox.Show(ex.Message);
            }
        }


        public bool SetChangeLanguage()
        {
            return true;
        }
        public void SetTimer(bool bTimer)
        {
            m_stForm[(int)m_eCurrentForm].m_IForm.SetTimer(bTimer);
        }
        public void SetVisible(bool bVisible)
        {
            this.Visible = bVisible;
            if (null != m_stForm[(int)m_eCurrentForm].m_IForm)
            {
                m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(bVisible);
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
              for (int iLoopMenu = 0; iLoopMenu < (int)CDefine.FormViewSetup.FORM_VIEW_SETUP_FINAL; iLoopMenu++)
              {
                if (iLoopMenu == (int)m_eCurrentForm)
                {
                    m_btnMenu[iLoopMenu].BackColor = Color.LightGreen;
                }
                else
                {
                    m_btnMenu[iLoopMenu].BackColor = Color.White;
                }
            }
        }
    }
}
