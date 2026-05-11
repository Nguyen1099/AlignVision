using System;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class CDialogMessage : Form
    {
        private CDocument m_objDocument;

        private string strMessage;
        public CDialogMessage(CDocument objDocument, string strMessage)
        {
            InitializeComponent();
            m_objDocument = objDocument;
            this.strMessage = strMessage;
        }

        private void CDialogMessage_Load(object sender, EventArgs e)
        {
            RichTextBoxAlarmDescription.Text = strMessage;
            TextBoxAlarmTime.Text = DateTime.Now.ToString();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.DialogResult = DialogResult.Yes;
            Form.ActiveForm.Close();

        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            Form.ActiveForm.DialogResult = DialogResult.No;
            Form.ActiveForm.Close();
        }

        private void CDialogMessage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnYes_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Escape:
                    btnNo_Click(sender, EventArgs.Empty);
                    break;
            }
        }
    }
}
