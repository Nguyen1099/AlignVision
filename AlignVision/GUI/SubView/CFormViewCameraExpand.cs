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
    public partial class CFormViewCameraExpand : Form
    {
        private CFormDisplay m_objFormDisplay;
        private CDocument m_objDocument;
        private CDefine.enumCamera m_eCamera;

        public CFormViewCameraExpand(CDocument objDocument, CDefine.enumCamera eCamera)
        {
            InitializeComponent();
            m_objDocument = objDocument;
            m_eCamera = eCamera;
        }

        private void CFormViewCameraExpand_Load(object sender, EventArgs e)
        {
            m_objFormDisplay = new CFormDisplay();
            Initialize(m_eCamera);
        }

        public void Initialize(CDefine.enumCamera eCamera)
        {
            m_objFormDisplay.Initialize(eCamera, m_objDocument);
            btnTitleMain.Text = string.Format("Camera {0}", (int)eCamera + 1);
            SetFormDockStyle(m_objFormDisplay, pnlDisplay);
        }

        private void btnShrink_Click(object sender, EventArgs e)
        {
           Form.ActiveForm.Close();
        }

        public void SetFormDockStyle(Form objForm, Panel objPanel)
        {
            objForm.Owner = this;
            objForm.TopLevel = false;
            objForm.Visible = true;
            objForm.Dock = DockStyle.Fill;
            objPanel.Controls.Add(objForm);
        }

    }
}
