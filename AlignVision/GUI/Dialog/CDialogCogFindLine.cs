using Cognex.VisionPro.Caliper;
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
    public partial class CDialogCogFindLine : Form
    {

        private CogFindLineTool m_objFindLineTool;
        public CDialogCogFindLine(CogFindLineTool objFindLineTool)
        {
            m_objFindLineTool = objFindLineTool;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CDialogCogFindLine_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void CDialogCogFindLine_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInitialize();
        }

        private void DeInitialize()
        {
            cogFindLineEditV21.Dispose();
        }

        private void Initialize()
        {
            this.DialogResult = DialogResult.None;
            cogFindLineEditV21.Subject = m_objFindLineTool;
            SetControlColor();
        }
        private void SetControlColor()
        {
            var pFormCommon = CFormCommon.GetFormCommon;
            pFormCommon.SetButtonColor(this.btnClose, Color.White, Color.FromArgb(50, 50, 50));
        }

    }
}
