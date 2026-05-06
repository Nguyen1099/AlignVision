using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlignVision
{
    public partial class FormKeyPad : Form
    {
        public double m_dValue { get; set; }

        public double m_dOriginValue { get; set; }

        public string m_strInputData { get; set; }

        public double m_dResultValue { get; set; }

        private enumCalulation m_eCalulation;

        private enum enumCalulation
        {
            CAL_NONE,
            CAL_PLUS,
            CAL_MINUS,
            CAL_DEVISION,
            CAL_MULTIPLY
        }


        public FormKeyPad(double dOriginValue)
        {
            InitializeComponent();
            m_dOriginValue = dOriginValue;
            Initialize();
        }

        public bool Initialize()
        {
            bool flag = false;
            string text = $"{m_dOriginValue:F3}";
            if (0.0 != m_dOriginValue)
            {
                m_strInputData = $"{m_dOriginValue:F3}";
            }
            else
            {
                m_strInputData = "0";
            }
            m_eCalulation = enumCalulation.CAL_NONE;
            Reload();
            BtnDisplayOriginValue.Text = text;
            BtnKeyPadTitle.BackColor = Color.Gray;
            flag = true;
            return flag;
        }

        private void Reload(bool bCalMode = false)
        {
            if (bCalMode)
            {
                BtnKeyPadChar0.Enabled = true;
                BtnKeyPadChar1.Enabled = true;
                BtnKeyPadChar2.Enabled = true;
                BtnKeyPadChar3.Enabled = true;
                BtnKeyPadChar4.Enabled = true;
                BtnKeyPadChar5.Enabled = true;
                BtnKeyPadChar6.Enabled = true;
                BtnKeyPadChar7.Enabled = true;
                BtnKeyPadChar8.Enabled = true;
                BtnKeyPadChar9.Enabled = true;
                BtnKeyPadMinusDotOne.Enabled = false;
                BtnKeyPadPlusDotOne.Enabled = false;
                BtnKeyPadMinusDotFive.Enabled = false;
                BtnKeyPadPlusDotFive.Enabled = false;
                BtnKeyPadMinusOne.Enabled = false;
                BtnKeyPadPlusOne.Enabled = false;
                BtnKeyPadDivision.Enabled = true;
                BtnKeyPadMutiply.Enabled = true;
                BtnKeyPadHyphen.Enabled = true;
                BtnKeyPadPlus.Enabled = true;
                BtnKeyPadEquals.Enabled = true;
                BtnKeyPadPoint.Enabled = true;
            }
            BtnDisPlayKeyValue.Text = m_strInputData;
        }

        private void BtnKeyPadClear_Click(object sender, EventArgs e)
        {
            m_strInputData = "0";
            m_dValue = 0.0;
            m_eCalulation = enumCalulation.CAL_NONE;
            Reload();
        }

        private void BtnKeyPadBackSpace_Click(object sender, EventArgs e)
        {
            if (0 != m_strInputData.Length)
            {
                if (1 == m_strInputData.Length)
                {
                    m_strInputData = "0";
                }
                if (1 < m_strInputData.Length)
                {
                    string text = "";
                    text = m_strInputData.Substring(0, m_strInputData.Length - 1);
                    m_strInputData = text;
                }
                Reload();
            }
        }

        private void BtnKeyPadDivision_Click(object sender, EventArgs e)
        {
            if (!("0" == m_strInputData) || 0.0 != m_dValue)
            {
                m_dValue = Convert.ToDouble(m_strInputData);
                m_eCalulation = enumCalulation.CAL_DEVISION;
                m_strInputData = "0";
            }
        }

        private void BtnKeyPadMutiply_Click(object sender, EventArgs e)
        {
            if (!("0" == m_strInputData) || 0.0 != m_dValue)
            {
                m_dValue = Convert.ToDouble(m_strInputData);
                m_eCalulation = enumCalulation.CAL_MULTIPLY;
                m_strInputData = "0";
            }
        }

        private void BtnKeyPadHyphen_Click(object sender, EventArgs e)
        {
            if ("0" == m_strInputData && 0.0 == m_dValue)
            {
                m_strInputData = "-";
                Reload();
            }
            else
            {
                m_dValue = Convert.ToDouble(m_strInputData);
                m_eCalulation = enumCalulation.CAL_MINUS;
                m_strInputData = "0";
            }
        }

        private void BtnKeyPadPlus_Click(object sender, EventArgs e)
        {
            if (!("0" == m_strInputData) || 0.0 != m_dValue)
            {
                m_dValue = Convert.ToDouble(m_strInputData);
                m_eCalulation = enumCalulation.CAL_PLUS;
                m_strInputData = "0";
            }
        }

        private void BtnKeyPadEquals_Click(object sender, EventArgs e)
        {
            double num = 0.0;
            m_dValue = Convert.ToDouble(m_strInputData);
            switch (m_eCalulation)
            {
                case enumCalulation.CAL_PLUS:
                    m_dValue += num;
                    break;
                case enumCalulation.CAL_MINUS:
                    m_dValue -= num;
                    break;
                case enumCalulation.CAL_MULTIPLY:
                    m_dValue *= num;
                    break;
                case enumCalulation.CAL_DEVISION:
                    m_dValue /= num;
                    break;
            }
            m_eCalulation = enumCalulation.CAL_NONE;
            string text = $"{m_dValue:F3}";
            m_dValue = Convert.ToDouble(m_strInputData);
            Reload();
        }

        private void BtnKeyPadOK_Click(object sender, EventArgs e)
        {
            double num = 0.0;
            m_dValue = Convert.ToDouble(m_strInputData);
            switch (m_eCalulation)
            {
                case enumCalulation.CAL_PLUS:
                    m_dValue += num;
                    break;
                case enumCalulation.CAL_MINUS:
                    m_dValue -= num;
                    break;
                case enumCalulation.CAL_MULTIPLY:
                    m_dValue *= num;
                    break;
                case enumCalulation.CAL_DEVISION:
                    m_dValue /= num;
                    break;
                case enumCalulation.CAL_NONE:
                    m_dValue = num;
                    break;
            }
            m_eCalulation = enumCalulation.CAL_NONE;
            string text = $"{m_dValue:F3}";
            m_dValue = Convert.ToDouble(m_strInputData);
            Reload();
            m_dResultValue = m_dValue;
            base.DialogResult = DialogResult.OK;
            Form.ActiveForm.Close();
        }

        private void BtnKeyPadPoint_Click(object sender, EventArgs e)
        {
            int num = 0;
            num = m_strInputData.IndexOf(".");
            if (-1 == num)
            {
                m_strInputData += ".";
                Reload();
            }
        }

        private void BtnKeyPadChar0_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (!m_strInputData.Equals("0"))
            {
                if (m_strInputData == $"{m_dOriginValue:F3}")
                {
                    m_strInputData = "";
                }
                m_strInputData += "0";
                Reload();
            }
        }

        private void BtnKeyPadChar1_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "1";
            Reload();
        }

        private void BtnKeyPadChar2_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "2";
            Reload();
        }

        private void BtnKeyPadChar3_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "3";
            Reload();
        }

        private void BtnKeyPadChar4_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "4";
            Reload();
        }

        private void BtnKeyPadChar5_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "5";
            Reload();
        }

        private void BtnKeyPadChar6_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "6";
            Reload();
        }

        private void BtnKeyPadChar7_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "7";
            Reload();
        }

        private void BtnKeyPadChar8_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "8";
            Reload();
        }

        private void BtnKeyPadChar9_Click(object sender, EventArgs e)
        {
            if (m_strInputData.Equals("0") || m_strInputData == $"{m_dOriginValue:F3}")
            {
                m_strInputData = "";
            }
            m_strInputData += "9";
            Reload();
        }

        private void BtnKeyPadMinusDotOne_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) - 0.1:F3}";
            Reload();
        }

        private void BtnKeyPadPlusDotOne_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) + 0.1:F3}";
            Reload();
        }

        private void BtnKeyPadMinusDotFive_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) - 0.5:F3}";
            Reload();
        }

        private void BtnKeyPadPlusDotFive_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) + 0.5:F3}";
            Reload();
        }

        private void BtnKeyPadMinusOne_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) - 1.0:F3}";
            Reload();
        }

        private void BtnKeyPadPlusOne_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) + 1.0:F3}";
            Reload();
        }

        private void BtnKeyPadMinusTen_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) - 10.0:F3}";
            Reload();
        }

        private void BtnKeyPadPlusTen_Click(object sender, EventArgs e)
        {
            m_strInputData = $"{double.Parse(m_strInputData) + 10.0:F3}";
            Reload();
        }

        private void BtnKeyPadCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            Form.ActiveForm.Close();
        }

        private void BtnKeyPad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.IsInputKey = true;
            }
        }
    }
}
