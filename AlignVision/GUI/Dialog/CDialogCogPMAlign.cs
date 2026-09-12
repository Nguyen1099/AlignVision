using Cognex.VisionPro.PMAlign;
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
    public partial class CDialogCogPMAlign : Form
    {
        private CogPMAlignTool m_objPMAlignTool;

        public CDialogCogPMAlign(CogPMAlignTool objPMAlignTool)
        {
            m_objPMAlignTool = objPMAlignTool;
            InitializeComponent();
        }

        private void CDialogCogPMAlign_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void CDialogCogPMAlign_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }

        private void DeInitialize()
        {
            cogPMAlignEdit.Dispose();
        }

        private void Initialize()
        {
            this.DialogResult = DialogResult.None;
            // PM Align Edit Subject
            cogPMAlignEdit.Subject = m_objPMAlignTool;

            SetControlColor();
        }

        /// <summary>
        /// Định nghĩa màu nút
        /// </summary>
		private void SetControlColor()
        {
            var pFormCommon = CFormCommon.GetFormCommon;
            pFormCommon.SetButtonColor(this.btnClose, Color.White, Color.FromArgb(50, 50, 50));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
