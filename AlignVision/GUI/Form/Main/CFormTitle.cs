using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CFormTitle : CFormCommon, CFormInterface
    {
        private CDocument m_objDocument;
        public CFormTitle(CDocument objDocument)
        {
            m_objDocument = objDocument;
            InitializeComponent();
        }

        private void CFormTitle_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void CFormTitle_FormClosed(object sender, FormClosedEventArgs e)
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

            timer.Interval = 1000;
            timer.Start();
            result = true;
            return result;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            var mainFrame = m_objDocument.GetMainFrame();
            if (mainFrame == null)
            {
                return;
            }
            mainFrame.WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SetUpdateTime();
        }

        private void SetUpdateTime()
        {
            DateTime now = DateTime.Now;
            lblTimeDate.Text = $"{now:dd - MM - yyyy}";
            lblTimeHour.Text = $"{now:HH:mm:ss}";
        }
    }
}
