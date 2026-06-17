using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Sunny.UI;

namespace AlignVision
{
    public partial class CFormCommon : Form
    {
        protected Color m_colorRed = Color.FromArgb(255, 192, 192);

        protected Color m_colorGreen = Color.FromArgb(192, 255, 192);

        protected Color m_colorYellow = Color.FromArgb(255, 255, 192);

        protected Color m_colorNormal = Color.FromArgb(230, 230, 230);

        protected Color m_colorClick = Color.FromArgb(180, 180, 180);

        protected Color m_colorLabel = Color.FromArgb(128, 128, 255);

        protected Color m_colorLabelSub = Color.FromArgb(192, 192, 255);

        protected Color m_colorLabelData = Color.FromArgb(255, 255, 255);

        protected Color m_colorOn = Color.FromArgb(192, 255, 192);

        protected Color m_colorOff = Color.FromArgb(255, 192, 192);

        protected Color m_colorControl = Color.FromArgb(240, 240, 240);

        protected Color m_objBlue = Color.Blue;

        /// <summary>
        /// Color the button (the Button class can be replaced with another class later)
        /// Description: If the color is the same, skip it.
        /// </summary>
        /// <param name="objBtn"></param>
        /// <param name="objForeColor"></param>
        /// <param name="objBackColor"></param>
        public void SetButtonColor(UISymbolButton objBtn, Color objForeColor, Color objBackColor)
        {
            if (objForeColor != objBtn.ForeColor)
            {
                objBtn.ForeColor = objForeColor;
            }
            if (objBackColor != objBtn.BackColor)
            {
                objBtn.BackColor = objBackColor;
            }
        }

        /// <summary>
        /// Color the button (the Button class can be replaced with another class later)
        /// Description: If the color is the same, skip it.
        /// </summary>
        /// <param name="objBtn"></param>
        /// <param name="objForeColor"></param>
        /// <param name="objBackColor"></param>
        public void SetButtonColor(Button objBtn, Color objForeColor, Color objBackColor)
        {
            if (objForeColor != objBtn.ForeColor)
            {
                objBtn.ForeColor = objForeColor;
            }
            if (objBackColor != objBtn.BackColor)
            {
                objBtn.BackColor = objBackColor;
            }
        }

        /// <summary>
        /// Color the button (the Button class can be replaced with another class later)
        /// Description: If the color is the same, skip it.
        /// </summary>
        /// <param name="objBtn"></param>
        /// <param name="objBackColor"></param>
        public void SetButtonBackColor(UISymbolButton objBtn, Color objBackColor)
        {
            SetButtonColor(objBtn, objBtn.ForeColor, objBackColor);
        }
        /// <summary>
        /// Color the button (the Button class can be replaced with another class later)
        /// Description: If the color is the same, skip it.
        /// </summary>
        /// <param name="objBtn"></param>
        /// <param name="objBackColor"></param>
        public void SetButtonBackColor(Button objBtn, Color objBackColor)
        {
            SetButtonColor(objBtn, objBtn.ForeColor, objBackColor);
        }

        /// <summary>
        /// Change the string in the button (the Button class may be replaced with  class later)
        /// Description: Pass if the string is the same.
        /// </summary>
        /// <param name="objBtn"></param>
        /// <param name="strText"></param>
        public void SetButtonText(Button objBtn, string strText)
        {
            if (strText != objBtn.Text)
            {
                objBtn.Text = strText;
            }
        }

        /// <summary>
        /// Change the grid view font
        /// </summary>
        /// <param name="objGridView"></param>
        /// <param name="strFontName"></param>
        /// <param name="dSize"></param>
        /// <param name="objFontStyle"></param>
        public void SetGridViewFont(DataGridView objGridView, string strFontName, double dSize, FontStyle objFontStyle)
        {
            objGridView.Font = new Font(strFontName, (float)dSize, objFontStyle);
        }
        /// <summary>
        /// Change the grid view font
        /// </summary>
        /// <param name="objGridView"></param>
        /// <param name="dSize"></param>
        public void SetGridViewFont(DataGridView objGridView, double dSize)
        {
            SetGridViewFont(objGridView, objGridView.Font.Name, dSize, objGridView.Font.Style);
        }
        /// <summary>
        /// Initialize the default grid view style.
        /// Description: Used as the default constraints when creating a grid view. Modifying this will affect other parts.
        /// </summary>
        /// <param name="objGridView"></param>
        /// <returns></returns>
        public bool InitializeGridView(DataGridView objGridView)
        {
            bool flag = false;
            SetDoubleBuffered(objGridView, bSetting: true);
            objGridView.BackgroundColor = Color.White;
            objGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            objGridView.AllowUserToResizeRows = false;
            objGridView.AllowUserToResizeColumns = false;
            objGridView.RowHeadersVisible = false;
            objGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            objGridView.ClearSelection();
            objGridView.AllowUserToAddRows = false;
            flag = true;
            return flag;
        }
        /// <summary>
        /// Changing the Grid View double buffering property
        /// </summary>
        /// <param name="objGridView"></param>
        /// <param name="bSetting"></param>
        public void SetDoubleBuffered(DataGridView objGridView, bool bSetting)
        {
            Type type = objGridView.GetType();
            PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(objGridView, bSetting, null);
        }
        /// <summary>
        /// Resets the default style of a rich text box.
        /// Description: Used as the default constraint when creating a rich text box. Modifying this section will affect other sections.
        /// </summary>
        /// <param name="objRich"></param>
        /// <returns></returns>
        public bool InitializeRichTextBox(RichTextBox objRich)
        {
            bool flag = false;
            objRich.ReadOnly = true;
            objRich.Multiline = true;
            objRich.ScrollBars = RichTextBoxScrollBars.Vertical;
            flag = true;
            return flag;
        }
        /// <summary>
        /// Change the font of the rich text box
        /// Description: I should have subtracted it by Control unit.
        /// </summary>
        /// <param name="objRich"></param>
        /// <param name="strFontName"></param>
        /// <param name="dSize"></param>
        /// <param name="objFontStyle"></param>
        public void SetRichTextBoxFont(RichTextBox objRich, string strFontName, double dSize, FontStyle objFontStyle)
        {
            objRich.Font = new Font(strFontName, (float)dSize, objFontStyle);
            objRich.SelectionFont = new Font(strFontName, (float)dSize, objFontStyle);
        }
        /// <summary>
        /// A function for forms with menus to dynamically create menu buttons.
        /// </summary>
        /// <param name="objButton"></param>
        /// <param name="objParent"></param>
        /// <param name="strButtonName"></param>
        /// <param name="iButtonWidth"></param>
        /// <param name="iWhiteSpace"></param>
        /// <param name="eventButton"></param>
        public void SetDynamicMenuButton(Button[] objButton, Control objParent, string[] strButtonName, int iButtonWidth, int iWhiteSpace, EventHandler eventButton)
        {
            for (int i = 0; i < strButtonName.Length; i++)
            {
                objButton[i] = new Button();
                objButton[i].Name = i.ToString();
                objButton[i].Text = strButtonName[i];
                objButton[i].Parent = objParent;
                objButton[i].Size = new Size(iButtonWidth - iWhiteSpace, objParent.Height);
                objButton[i].BackColor = Color.White;
                objButton[i].FlatStyle = FlatStyle.Flat;
                objButton[i].Click += eventButton;
                objButton[i].Location = new Point(i * iButtonWidth + 9, 0);             // thay doi vi tri button, 9 la khoang cach tu button dau tien den mep ben trai
            }
        }

    }
}
