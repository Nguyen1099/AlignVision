using Cognex.VisionPro.Blob;
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
    public partial class CDialogCogBlob : Form
    {
        private CogBlobTool m_objBlobTool;
        public CDialogCogBlob(CogBlobTool objBlobTool)
        {
            m_objBlobTool = objBlobTool;
            InitializeComponent();
        }

        private void CDialogCogBlob_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.DialogResult = DialogResult.None;
            cogBlobEditV21.Subject = m_objBlobTool;
            SetControlColor();

        }

        private void CDialogCogBlob_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }

        private void DeInitialize()
        {
           cogBlobEditV21.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetControlColor()
        {
            var pFormCommon = CFormCommon.GetFormCommon;
            pFormCommon.SetButtonColor(this.btnClose, Color.White, Color.FromArgb(50, 50, 50));
        }

    }
}
