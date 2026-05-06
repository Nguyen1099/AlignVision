using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class FormKeyBoard : Form
    {
        private bool _bShift;

        private bool _bCtrl;

        private bool _bAlt;

        private bool _bCapsLock;

        private string _bQuotes;

        private string _strReturnValue;

        public bool m_bShift
        {
            get { return _bShift; }
            set { _bShift = value; }
        }

        public bool m_bCtrl
        {
            get { return _bCtrl; }
            set { _bCtrl = value; }
        }

        public bool m_bAlt
        {
            get { return _bAlt; }
            set { _bAlt = value; }
        }

        public bool m_bCapsLock
        {
            get { return _bCapsLock; }
            set { _bCapsLock = value;}
        }

        public string m_bQuotes
        {
            get { return _bQuotes;}
            set { _bQuotes = value;}
        }

        public string m_strReturnValue
        {
            get {return _strReturnValue;}
            set { _strReturnValue = value;}
        }

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public FormKeyBoard()
        {
            InitializeComponent();
        }

        public bool Initialize()
        {
            bool flag = false;
            InitializeButton();
            bool flag2 = (m_bAlt = false);
            flag2 = (m_bCtrl = flag2);
            flag2 = (m_bCapsLock = flag2);
            m_bShift = flag2;
            m_bCapsLock = true;
            m_bQuotes = BtnKeyBoardCharQuotes.Text;
            Reload();
            EditKeyBoardDisplay.Text = "";
            EditKeyBoardDisplay.Focus();
            flag = true;
            return flag;
        }

        public bool InitializeButton()
        {
            bool flag = false;
            BtnKeyBoardTitle.BackColor = SystemColors.Control;
            BtnKeyBoardRightShift.BackColor = SystemColors.Control;
            BtnKeyBoardLeftShift.BackColor = SystemColors.Control;
            BtnKeyBoardCharAccent.BackColor = SystemColors.Control;
            BtnKeyBoardChar0.BackColor = SystemColors.Control;
            BtnKeyBoardChar1.BackColor = SystemColors.Control;
            BtnKeyBoardChar2.BackColor = SystemColors.Control;
            BtnKeyBoardChar3.BackColor = SystemColors.Control;
            BtnKeyBoardChar4.BackColor = SystemColors.Control;
            BtnKeyBoardChar5.BackColor = SystemColors.Control;
            BtnKeyBoardChar6.BackColor = SystemColors.Control;
            BtnKeyBoardChar7.BackColor = SystemColors.Control;
            BtnKeyBoardChar8.BackColor = SystemColors.Control;
            BtnKeyBoardChar9.BackColor = SystemColors.Control;
            BtnKeyBoardCharQ.BackColor = SystemColors.Control;
            BtnKeyBoardCharW.BackColor = SystemColors.Control;
            BtnKeyBoardCharE.BackColor = SystemColors.Control;
            BtnKeyBoardCharR.BackColor = SystemColors.Control;
            BtnKeyBoardCharT.BackColor = SystemColors.Control;
            BtnKeyBoardCharY.BackColor = SystemColors.Control;
            BtnKeyBoardCharU.BackColor = SystemColors.Control;
            BtnKeyBoardCharI.BackColor = SystemColors.Control;
            BtnKeyBoardCharO.BackColor = SystemColors.Control;
            BtnKeyBoardCharP.BackColor = SystemColors.Control;
            BtnKeyBoardCharA.BackColor = SystemColors.Control;
            BtnKeyBoardCharS.BackColor = SystemColors.Control;
            BtnKeyBoardCharD.BackColor = SystemColors.Control;
            BtnKeyBoardCharF.BackColor = SystemColors.Control;
            BtnKeyBoardCharG.BackColor = SystemColors.Control;
            BtnKeyBoardCharH.BackColor = SystemColors.Control;
            BtnKeyBoardCharJ.BackColor = SystemColors.Control;
            BtnKeyBoardCharK.BackColor = SystemColors.Control;
            BtnKeyBoardCharL.BackColor = SystemColors.Control;
            BtnKeyBoardCharZ.BackColor = SystemColors.Control;
            BtnKeyBoardCharX.BackColor = SystemColors.Control;
            BtnKeyBoardCharC.BackColor = SystemColors.Control;
            BtnKeyBoardCharV.BackColor = SystemColors.Control;
            BtnKeyBoardCharB.BackColor = SystemColors.Control;
            BtnKeyBoardCharN.BackColor = SystemColors.Control;
            BtnKeyBoardCharM.BackColor = SystemColors.Control;
            BtnKeyBoardCharLeftBracket.BackColor = SystemColors.Control;
            BtnKeyBoardCharRightBracket.BackColor = SystemColors.Control;
            BtnKeyBoardCharSemicolon.BackColor = SystemColors.Control;
            BtnKeyBoardCharQuotes.BackColor = SystemColors.Control;
            BtnKeyBoardCharComma.BackColor = SystemColors.Control;
            BtnKeyBoardCharPoint.BackColor = SystemColors.Control;
            BtnKeyBoardCharSlash.BackColor = SystemColors.Control;
            BtnKeyBoardLeftShift.BackColor = SystemColors.Control;
            BtnKeyBoardRightShift.BackColor = SystemColors.Control;
            BtnKeyBoardTAB.BackColor = SystemColors.Control;
            BtnKeyBoardCapsLock.BackColor = SystemColors.Control;
            BtnKeyBoardEnter.BackColor = SystemColors.Control;
            BtnKeyBoardSpace.BackColor = SystemColors.Control;
            BtnKeyBoardBackSpace.BackColor = SystemColors.Control;
            BtnKeyBoardEsc.BackColor = SystemColors.Control;
            BtnKeyBoardEqual.BackColor = SystemColors.Control;
            BtnKeyBoardClear.BackColor = SystemColors.Control;
            BtnKeyBoardAlt.BackColor = SystemColors.Control;
            BtnKeyBoardCtrl.BackColor = SystemColors.Control;
            BtnKeyBoardCharBackSlash.BackColor = SystemColors.Control;
            BtnKeyBoardHyphen.BackColor = SystemColors.Control;
            flag = true;
            bool flag2 = false;
            return flag;
        }

        private void Reload()
        {
            if (m_bShift)
            {
                BtnKeyBoardRightShift.BackColor = Color.LimeGreen;
                BtnKeyBoardLeftShift.BackColor = Color.LimeGreen;
                BtnKeyBoardCharAccent.Text = "~";
                BtnKeyBoardChar0.Text = ")";
                BtnKeyBoardChar1.Text = "!";
                BtnKeyBoardChar2.Text = "@";
                BtnKeyBoardChar3.Text = "#";
                BtnKeyBoardChar4.Text = "$";
                BtnKeyBoardChar5.Text = "%";
                BtnKeyBoardChar6.Text = "^";
                BtnKeyBoardChar7.Text = "&&";
                BtnKeyBoardChar8.Text = "*";
                BtnKeyBoardChar9.Text = "(";
                BtnKeyBoardHyphen.Text = "_";
                BtnKeyBoardEqual.Text = "+";
                BtnKeyBoardCharQ.Text = BtnKeyBoardCharQ.Text.ToUpper();
                BtnKeyBoardCharW.Text = BtnKeyBoardCharW.Text.ToUpper();
                BtnKeyBoardCharE.Text = BtnKeyBoardCharE.Text.ToUpper();
                BtnKeyBoardCharR.Text = BtnKeyBoardCharR.Text.ToUpper();
                BtnKeyBoardCharT.Text = BtnKeyBoardCharT.Text.ToUpper();
                BtnKeyBoardCharY.Text = BtnKeyBoardCharY.Text.ToUpper();
                BtnKeyBoardCharU.Text = BtnKeyBoardCharU.Text.ToUpper();
                BtnKeyBoardCharI.Text = BtnKeyBoardCharI.Text.ToUpper();
                BtnKeyBoardCharO.Text = BtnKeyBoardCharO.Text.ToUpper();
                BtnKeyBoardCharP.Text = BtnKeyBoardCharP.Text.ToUpper();
                BtnKeyBoardCharA.Text = BtnKeyBoardCharA.Text.ToUpper();
                BtnKeyBoardCharS.Text = BtnKeyBoardCharS.Text.ToUpper();
                BtnKeyBoardCharD.Text = BtnKeyBoardCharD.Text.ToUpper();
                BtnKeyBoardCharF.Text = BtnKeyBoardCharF.Text.ToUpper();
                BtnKeyBoardCharG.Text = BtnKeyBoardCharG.Text.ToUpper();
                BtnKeyBoardCharH.Text = BtnKeyBoardCharH.Text.ToUpper();
                BtnKeyBoardCharJ.Text = BtnKeyBoardCharJ.Text.ToUpper();
                BtnKeyBoardCharK.Text = BtnKeyBoardCharK.Text.ToUpper();
                BtnKeyBoardCharL.Text = BtnKeyBoardCharL.Text.ToUpper();
                BtnKeyBoardCharZ.Text = BtnKeyBoardCharZ.Text.ToUpper();
                BtnKeyBoardCharX.Text = BtnKeyBoardCharX.Text.ToUpper();
                BtnKeyBoardCharC.Text = BtnKeyBoardCharC.Text.ToUpper();
                BtnKeyBoardCharV.Text = BtnKeyBoardCharV.Text.ToUpper();
                BtnKeyBoardCharB.Text = BtnKeyBoardCharB.Text.ToUpper();
                BtnKeyBoardCharN.Text = BtnKeyBoardCharN.Text.ToUpper();
                BtnKeyBoardCharM.Text = BtnKeyBoardCharM.Text.ToUpper();
                BtnKeyBoardCharLeftBracket.Text = "{";
                BtnKeyBoardCharRightBracket.Text = "}";
                BtnKeyBoardCharSemicolon.Text = ":";
                BtnKeyBoardCharQuotes.Text = m_bQuotes;
                BtnKeyBoardCharComma.Text = "<";
                BtnKeyBoardCharPoint.Text = ">";
                BtnKeyBoardCharSlash.Text = "?";
                BtnKeyBoardCharBackSlash.Text = "|";
            }
            else
            {
                BtnKeyBoardRightShift.BackColor = SystemColors.Control;
                BtnKeyBoardLeftShift.BackColor = SystemColors.Control;
                BtnKeyBoardCharAccent.Text = "`";
                BtnKeyBoardChar0.Text = "0";
                BtnKeyBoardChar1.Text = "1";
                BtnKeyBoardChar2.Text = "2";
                BtnKeyBoardChar3.Text = "3";
                BtnKeyBoardChar4.Text = "4";
                BtnKeyBoardChar5.Text = "5";
                BtnKeyBoardChar6.Text = "6";
                BtnKeyBoardChar7.Text = "7";
                BtnKeyBoardChar8.Text = "8";
                BtnKeyBoardChar9.Text = "9";
                BtnKeyBoardHyphen.Text = "-";
                BtnKeyBoardEqual.Text = "=";
                BtnKeyBoardCharQ.Text = BtnKeyBoardCharQ.Text.ToLower();
                BtnKeyBoardCharW.Text = BtnKeyBoardCharW.Text.ToLower();
                BtnKeyBoardCharE.Text = BtnKeyBoardCharE.Text.ToLower();
                BtnKeyBoardCharR.Text = BtnKeyBoardCharR.Text.ToLower();
                BtnKeyBoardCharT.Text = BtnKeyBoardCharT.Text.ToLower();
                BtnKeyBoardCharY.Text = BtnKeyBoardCharY.Text.ToLower();
                BtnKeyBoardCharU.Text = BtnKeyBoardCharU.Text.ToLower();
                BtnKeyBoardCharI.Text = BtnKeyBoardCharI.Text.ToLower();
                BtnKeyBoardCharO.Text = BtnKeyBoardCharO.Text.ToLower();
                BtnKeyBoardCharP.Text = BtnKeyBoardCharP.Text.ToLower();
                BtnKeyBoardCharA.Text = BtnKeyBoardCharA.Text.ToLower();
                BtnKeyBoardCharS.Text = BtnKeyBoardCharS.Text.ToLower();
                BtnKeyBoardCharD.Text = BtnKeyBoardCharD.Text.ToLower();
                BtnKeyBoardCharF.Text = BtnKeyBoardCharF.Text.ToLower();
                BtnKeyBoardCharG.Text = BtnKeyBoardCharG.Text.ToLower();
                BtnKeyBoardCharH.Text = BtnKeyBoardCharH.Text.ToLower();
                BtnKeyBoardCharJ.Text = BtnKeyBoardCharJ.Text.ToLower();
                BtnKeyBoardCharK.Text = BtnKeyBoardCharK.Text.ToLower();
                BtnKeyBoardCharL.Text = BtnKeyBoardCharL.Text.ToLower();
                BtnKeyBoardCharZ.Text = BtnKeyBoardCharZ.Text.ToLower();
                BtnKeyBoardCharX.Text = BtnKeyBoardCharX.Text.ToLower();
                BtnKeyBoardCharC.Text = BtnKeyBoardCharC.Text.ToLower();
                BtnKeyBoardCharV.Text = BtnKeyBoardCharV.Text.ToLower();
                BtnKeyBoardCharB.Text = BtnKeyBoardCharB.Text.ToLower();
                BtnKeyBoardCharN.Text = BtnKeyBoardCharN.Text.ToLower();
                BtnKeyBoardCharM.Text = BtnKeyBoardCharM.Text.ToLower();
                BtnKeyBoardCharLeftBracket.Text = "[";
                BtnKeyBoardCharRightBracket.Text = "]";
                BtnKeyBoardCharSemicolon.Text = ";";
                BtnKeyBoardCharQuotes.Text = "'";
                BtnKeyBoardCharComma.Text = ",";
                BtnKeyBoardCharPoint.Text = ".";
                BtnKeyBoardCharSlash.Text = "/";
                BtnKeyBoardCharBackSlash.Text = "\\";
            }
            if (m_bCapsLock)
            {
                BtnKeyBoardCapsLock.BackColor = Color.LimeGreen;
                BtnKeyBoardCharQ.Text = BtnKeyBoardCharQ.Text.ToUpper();
                BtnKeyBoardCharW.Text = BtnKeyBoardCharW.Text.ToUpper();
                BtnKeyBoardCharE.Text = BtnKeyBoardCharE.Text.ToUpper();
                BtnKeyBoardCharR.Text = BtnKeyBoardCharR.Text.ToUpper();
                BtnKeyBoardCharT.Text = BtnKeyBoardCharT.Text.ToUpper();
                BtnKeyBoardCharY.Text = BtnKeyBoardCharY.Text.ToUpper();
                BtnKeyBoardCharU.Text = BtnKeyBoardCharU.Text.ToUpper();
                BtnKeyBoardCharI.Text = BtnKeyBoardCharI.Text.ToUpper();
                BtnKeyBoardCharO.Text = BtnKeyBoardCharO.Text.ToUpper();
                BtnKeyBoardCharP.Text = BtnKeyBoardCharP.Text.ToUpper();
                BtnKeyBoardCharA.Text = BtnKeyBoardCharA.Text.ToUpper();
                BtnKeyBoardCharS.Text = BtnKeyBoardCharS.Text.ToUpper();
                BtnKeyBoardCharD.Text = BtnKeyBoardCharD.Text.ToUpper();
                BtnKeyBoardCharF.Text = BtnKeyBoardCharF.Text.ToUpper();
                BtnKeyBoardCharG.Text = BtnKeyBoardCharG.Text.ToUpper();
                BtnKeyBoardCharH.Text = BtnKeyBoardCharH.Text.ToUpper();
                BtnKeyBoardCharJ.Text = BtnKeyBoardCharJ.Text.ToUpper();
                BtnKeyBoardCharK.Text = BtnKeyBoardCharK.Text.ToUpper();
                BtnKeyBoardCharL.Text = BtnKeyBoardCharL.Text.ToUpper();
                BtnKeyBoardCharZ.Text = BtnKeyBoardCharZ.Text.ToUpper();
                BtnKeyBoardCharX.Text = BtnKeyBoardCharX.Text.ToUpper();
                BtnKeyBoardCharC.Text = BtnKeyBoardCharC.Text.ToUpper();
                BtnKeyBoardCharV.Text = BtnKeyBoardCharV.Text.ToUpper();
                BtnKeyBoardCharB.Text = BtnKeyBoardCharB.Text.ToUpper();
                BtnKeyBoardCharN.Text = BtnKeyBoardCharN.Text.ToUpper();
                BtnKeyBoardCharM.Text = BtnKeyBoardCharM.Text.ToUpper();
            }
            else if (m_bShift)
            {
                BtnKeyBoardCapsLock.BackColor = SystemColors.Control;
            }
            else
            {
                BtnKeyBoardCapsLock.BackColor = SystemColors.Control;
                BtnKeyBoardCharQ.Text = BtnKeyBoardCharQ.Text.ToLower();
                BtnKeyBoardCharW.Text = BtnKeyBoardCharW.Text.ToLower();
                BtnKeyBoardCharE.Text = BtnKeyBoardCharE.Text.ToLower();
                BtnKeyBoardCharR.Text = BtnKeyBoardCharR.Text.ToLower();
                BtnKeyBoardCharT.Text = BtnKeyBoardCharT.Text.ToLower();
                BtnKeyBoardCharY.Text = BtnKeyBoardCharY.Text.ToLower();
                BtnKeyBoardCharU.Text = BtnKeyBoardCharU.Text.ToLower();
                BtnKeyBoardCharI.Text = BtnKeyBoardCharI.Text.ToLower();
                BtnKeyBoardCharO.Text = BtnKeyBoardCharO.Text.ToLower();
                BtnKeyBoardCharP.Text = BtnKeyBoardCharP.Text.ToLower();
                BtnKeyBoardCharA.Text = BtnKeyBoardCharA.Text.ToLower();
                BtnKeyBoardCharS.Text = BtnKeyBoardCharS.Text.ToLower();
                BtnKeyBoardCharD.Text = BtnKeyBoardCharD.Text.ToLower();
                BtnKeyBoardCharF.Text = BtnKeyBoardCharF.Text.ToLower();
                BtnKeyBoardCharG.Text = BtnKeyBoardCharG.Text.ToLower();
                BtnKeyBoardCharH.Text = BtnKeyBoardCharH.Text.ToLower();
                BtnKeyBoardCharJ.Text = BtnKeyBoardCharJ.Text.ToLower();
                BtnKeyBoardCharK.Text = BtnKeyBoardCharK.Text.ToLower();
                BtnKeyBoardCharL.Text = BtnKeyBoardCharL.Text.ToLower();
                BtnKeyBoardCharZ.Text = BtnKeyBoardCharZ.Text.ToLower();
                BtnKeyBoardCharX.Text = BtnKeyBoardCharX.Text.ToLower();
                BtnKeyBoardCharC.Text = BtnKeyBoardCharC.Text.ToLower();
                BtnKeyBoardCharV.Text = BtnKeyBoardCharV.Text.ToLower();
                BtnKeyBoardCharB.Text = BtnKeyBoardCharB.Text.ToLower();
                BtnKeyBoardCharN.Text = BtnKeyBoardCharN.Text.ToLower();
                BtnKeyBoardCharM.Text = BtnKeyBoardCharM.Text.ToLower();
            }
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardEsc_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.DialogResult = DialogResult.Cancel;
            Form.ActiveForm.Close();
        }

        private void BtnKeyBoardTAB_Click(object sender, EventArgs e)
        {
            string arg = EditKeyBoardDisplay.Text;
            string text = string.Format("{0}{1}", arg, "    ");
            EditKeyBoardDisplay.Text = text;
            EditKeyBoardDisplay.Select(0, text.Length);
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCapsLock_Click(object sender, EventArgs e)
        {
            if (m_bCapsLock)
            {
                m_bCapsLock = false;
            }
            else
            {
                m_bCapsLock = true;
            }
            Reload();
        }

        private void BtnKeyBoardLeftShift_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_bShift = false;
                BtnKeyBoardLeftShift.BackColor = SystemColors.Control;
            }
            else
            {
                m_bShift = true;
                BtnKeyBoardLeftShift.BackColor = Color.LimeGreen;
            }
            Reload();
        }

        private void BtnKeyBoardCtrl_Click(object sender, EventArgs e)
        {
            if (m_bCtrl)
            {
                m_bCtrl = false;
                BtnKeyBoardCtrl.BackColor = SystemColors.Control;
            }
            else
            {
                m_bCtrl = true;
                BtnKeyBoardCtrl.BackColor = Color.LimeGreen;
            }
        }

        private void BtnKeyBoardAlt_Click(object sender, EventArgs e)
        {
            if (m_bAlt)
            {
                m_bAlt = false;
                BtnKeyBoardAlt.BackColor = SystemColors.Control;
            }
            else
            {
                m_bAlt = true;
                BtnKeyBoardAlt.BackColor = Color.LimeGreen;
            }
        }

        private void BtnKeyBoardSpace_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += " ";
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardClear_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text = "";
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardRightShift_Click(object sender, EventArgs e)
        {
            if (m_bShift)
            {
                m_bShift = false;
                BtnKeyBoardRightShift.BackColor = SystemColors.Control;
            }
            else
            {
                m_bShift = true;
                BtnKeyBoardRightShift.BackColor = Color.LimeGreen;
            }
            Reload();
        }

        private void BtnKeyBoardEnter_Click(object sender, EventArgs e)
        {
            m_strReturnValue = EditKeyBoardDisplay.Text;
            Form.ActiveForm.DialogResult = DialogResult.OK;
            Form.ActiveForm.Close();
        }

        private void BtnKeyBoardBackSpace_Click(object sender, EventArgs e)
        {
            string text = "";
            if (0 != EditKeyBoardDisplay.Text.Length && 1 <= EditKeyBoardDisplay.Text.Length)
            {
                text = EditKeyBoardDisplay.Text.Substring(0, EditKeyBoardDisplay.Text.Length - 1);
                EditKeyBoardDisplay.Text = text;
                EditKeyBoardDisplay.Focus();
            }
        }

        private void BtnKeyBoardCharAccent_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharAccent.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar1_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar1.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar2_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar2.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar3_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar3.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar4_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar4.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar5_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar5.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar6_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar6.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar7_Click(object sender, EventArgs e)
        {
            if (BtnKeyBoardChar7.Text.Length > 1)
            {
                EditKeyBoardDisplay.Text += BtnKeyBoardChar7.Text.Substring(1);
            }
            else
            {
                EditKeyBoardDisplay.Text += BtnKeyBoardChar7.Text;
            }
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar8_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar8.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar9_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar9.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardChar0_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardChar0.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardHyphen_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardHyphen.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardEqual_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardEqual.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharQ_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharQ.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharW_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharW.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharE_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharE.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharR_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharR.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharT_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharT.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharY_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharY.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharU_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharU.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharI_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharI.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharO_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharO.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharP_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharP.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharLeftBracket_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharLeftBracket.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharRightBracket_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharRightBracket.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharBackSlash_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharBackSlash.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharA_Click(object sender, EventArgs e)
        {
            if (m_bCtrl)
            {
                m_bCtrl = false;
                BtnKeyBoardCtrl.BackColor = SystemColors.Control;
                EditKeyBoardDisplay.Focus();
                EditKeyBoardDisplay.Select(0, EditKeyBoardDisplay.Text.Length);
            }
            else
            {
                EditKeyBoardDisplay.Text += BtnKeyBoardCharA.Text;
                EditKeyBoardDisplay.Focus();
            }
        }

        private void BtnKeyBoardCharS_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharS.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharD_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharD.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharF_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharF.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharG_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharG.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharH_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharH.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharJ_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharJ.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharK_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharK.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharL_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharL.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharSemicolon_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharSemicolon.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharQuotes_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharQuotes.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharZ_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharZ.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharX_Click(object sender, EventArgs e)
        {
            if (m_bCtrl)
            {
                m_bCtrl = false;
                BtnKeyBoardCtrl.BackColor = SystemColors.Control;
                EditKeyBoardDisplay.Focus();
                EditKeyBoardDisplay.Cut();
            }
            else
            {
                EditKeyBoardDisplay.Text += BtnKeyBoardCharX.Text;
                EditKeyBoardDisplay.Focus();
            }
        }

        private void BtnKeyBoardCharC_Click(object sender, EventArgs e)
        {
            if (m_bCtrl)
            {
                m_bCtrl = false;
                BtnKeyBoardCtrl.BackColor = SystemColors.Control;
                EditKeyBoardDisplay.Focus();
                EditKeyBoardDisplay.Copy();
            }
            else
            {
                EditKeyBoardDisplay.Text += BtnKeyBoardCharC.Text;
                EditKeyBoardDisplay.Focus();
            }
        }

        private void BtnKeyBoardCharV_Click(object sender, EventArgs e)
        {
            if (m_bCtrl)
            {
                m_bCtrl = false;
                BtnKeyBoardCtrl.BackColor = SystemColors.Control;
                EditKeyBoardDisplay.Focus();
                EditKeyBoardDisplay.Paste();
            }
            else
            {
                EditKeyBoardDisplay.Text += BtnKeyBoardCharV.Text;
                EditKeyBoardDisplay.Focus();
            }
        }

        private void BtnKeyBoardCharB_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharB.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharN_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharN.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharM_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharM.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharComma_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharComma.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharPoint_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharPoint.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void BtnKeyBoardCharSlash_Click(object sender, EventArgs e)
        {
            EditKeyBoardDisplay.Text += BtnKeyBoardCharSlash.Text;
            EditKeyBoardDisplay.Focus();
        }

        private void FormKeyBoard_Load(object sender, EventArgs e)
        {
            Initialize();
            EditKeyBoardDisplay.Text = "";
            EditKeyBoardDisplay.Focus();
        }

        private void EditKeyBoardDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                m_strReturnValue = EditKeyBoardDisplay.Text;
                Form.ActiveForm.DialogResult = DialogResult.OK;
                Form.ActiveForm.Close();
            }
        }

    }

}
