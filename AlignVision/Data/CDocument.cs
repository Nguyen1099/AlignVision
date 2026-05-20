using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CDocument
    {
        public CDialogInitProgramIntro View_Intro;

        /// <summary>
        /// Quản lý form hiện thị hình ảnh
        /// </summary>
        public Dictionary<CDefine.enumCamera, CFormDisplay> m_objFormDisplay;


        public bool Initialize()
        {
            bool result = false;

            View_Intro = new CDialogInitProgramIntro();
            View_Intro.Show();

            // Khởi tạo form hiển thị hình ảnh
            {
                m_objFormDisplay = new Dictionary<CDefine.enumCamera, CFormDisplay>();
                foreach (CDefine.enumCamera index in Enum.GetValues(typeof(CDefine.enumCamera)))
                {
                    m_objFormDisplay[index] = new CFormDisplay();
                }
                View_Intro.setStatus("Initialize CFormDisplay", 10);
            }
            View_Intro.setStatus("Initialize CFormDisplay", 20);
            View_Intro.setStatus("Initialize CFormDisplay", 30);
            View_Intro.setStatus("Initialize CFormDisplay", 40);
            View_Intro.setStatus("Initialize CFormDisplay", 50);
            View_Intro.setStatus("Initialize CFormDisplay", 60);
            View_Intro.setStatus("Initialize CFormDisplay", 70);
            View_Intro.setStatus("Initialize CFormDisplay", 80);


            result = true;
            return result;

        }
    }
}
