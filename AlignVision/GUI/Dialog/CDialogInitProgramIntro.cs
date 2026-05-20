using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AlignVision
{
    public partial class CDialogInitProgramIntro : Form
    {
        public CDialogInitProgramIntro()
        {
            InitializeComponent();
        }

        public void setStatus(string strText, int nProgress)
        {
            uiProcessBar.Value = nProgress;

            lblProgress.Text = strText;
            this.Refresh();
            //Application.DoEvents();
            Thread.Sleep(200);
        }
    }
}
