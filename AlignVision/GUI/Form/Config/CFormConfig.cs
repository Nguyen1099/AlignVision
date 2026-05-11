using AlignVision.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CFormConfig : CFormCommon, CFormInterface
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
        private Button[] m_btnMenu;
        private CDefine.FormViewConfig m_eCurrentForm = CDefine.FormViewConfig.FORM_VIEW_CONFIG_FINAL;

        public CFormConfig(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }

        private void CFormConfig_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void CFormConfig_FormClosed(object sender, FormClosedEventArgs e)
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
        private bool InitializeForm()
        {
            bool result = false;
            int iMenuCount = (int)CDefine.FormViewConfig.FORM_VIEW_CONFIG_FINAL;

            // Button margin & width settings
            int iWhiteSpace = 2;
            int iButtonWidth = (this.panelFormMenu.Width / iMenuCount);

            //If the number of buttons is small and the width is larger than the base button, it is fixed to the base button width.
            if (iButtonWidth > this.btnBase.Width)
            {
                iButtonWidth = this.btnBase.Width;
            }
            string[] strButtonName = new string[iMenuCount];
            m_btnMenu = new Button[iMenuCount];
            for (int iLoopButton = 0; iLoopButton < strButtonName.Length; iLoopButton++)
            {
                strButtonName[iLoopButton] = ((CDefine.FormViewConfig)iLoopButton).ToString();
            }

            // Dynamically create buttons
            SetDynamicMenuButton(m_btnMenu, this.panelFormMenu, strButtonName, iButtonWidth, iWhiteSpace, new EventHandler(ButtonMenu_Click));
            // Set button name
            for (int iLoopMenu = 0; iLoopMenu < m_btnMenu.Length; iLoopMenu++)
            {
                m_btnMenu[iLoopMenu].Name = string.Format("BtnMainMenu[{0}]", iLoopMenu);
            }
            m_stForm = new structureForm[iMenuCount];
            SetChangeForm(CDefine.FormViewConfig.FORM_VIEW_CONFIG_OPTION);

            result = true;
            return result;
        }
        
        public void DeInitialize()
        {
        }

        /// <summary>
        /// Thay đổi giao diện hiển thị dựa trên tham số eForm.
        /// </summary>
        /// <param name="eForm"></param>
        public void SetChangeForm(CDefine.FormViewConfig eForm)
        {
            if (m_eCurrentForm == eForm)
            {
                return;
            }
            if (CDefine.FormViewConfig.FORM_VIEW_CONFIG_FINAL != m_eCurrentForm)
            {
                m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(false);
                m_stForm[(int)m_eCurrentForm].m_IForm.SetTimer(false);
            }
            if (null == m_stForm[(int)eForm].m_IForm)
            {
                switch (eForm)
                {
                    case CDefine.FormViewConfig.FORM_VIEW_CONFIG_OPTION:
                        {
                            m_stForm[(int)eForm] = new structureForm(new CFormConfigOption(m_objDocument) as CFormInterface);
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

        /// <summary>
        /// Cấu hình Form
        /// </summary>
        /// <param name="objForm"></param>
        /// <param name="objPanel"></param>
        public void SetFormDockStyle(Form objForm, Panel objPanel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
            objForm.Dock = DockStyle.Fill;
            objPanel.Controls.Add(objForm);
        }

        /// <summary>
        /// Hàm này xử lý sự kiện khi người dùng nhấn vào một nút (Button) trong giao diện. 
        /// Dựa trên tên của nút, nó xác định loại form cần chuyển sang và thực hiện việc chuyển đổi giao diện.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonMenu_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            try
            {
                // Tạo một biểu thức chính quy để tìm chuỗi nằm trong dấu ngoặc vuông [...] trong tên của nút.
                Regex regex = new Regex("\\[(.+)\\]");
                if (regex.IsMatch(button.Name))
                {
                    string value = regex.Match(button.Name).Groups[1].Value;
                    CDefine.FormViewConfig formViewConfig = (CDefine.FormViewConfig)Convert.ToInt32(value);
                    string strButton = string.Format("[{0}] [Form Change : {1} -> {2}]", "ButtonMenu_Click", m_eCurrentForm.ToString(), formViewConfig.ToString());
                    //m_objDocument.SetUpdateButtonLog(this, strButton);
                    SetChangeForm(formViewConfig);
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có ngoại lệ xảy ra trong quá trình xử lý sự kiện.
                Trace.WriteLine(ex.Message);
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
            this.Visible = bVisible;
            if (bVisible)
            {
                //m_objDocument.GetMainFrame().SetCurrentForm(this);
                m_stForm[(int)m_eCurrentForm].m_IForm.SetVisible(bVisible);
            }

        }
    }
}
