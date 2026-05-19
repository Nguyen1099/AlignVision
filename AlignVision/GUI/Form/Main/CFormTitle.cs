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
    public partial class CFormTitle : CFormCommon, CFormInterface
    {
        public CFormTitle(CDocument objDocument)
        {
            InitializeComponent();
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
    }
}
