using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public class CDocument
    {
        public CDialogInitProgramIntro View_Intro;

        public CConfig m_objConfig;

        private CDefine.enumRunMode m_eRunMode;

        /// <summary>
        /// Quản lý form hiện thị hình ảnh
        /// </summary>
        public Dictionary<CDefine.enumCamera, CFormDisplay> m_objFormDisplay;


        public bool Initialize()
        {
            bool result = false;

            View_Intro = new CDialogInitProgramIntro();
            View_Intro.Show();

            // Khởi tạo cấu hình
            m_objConfig = new CConfig();
            if (m_objConfig.Initialize() == false)
            {
                throw new Exception();
            }
            View_Intro.setStatus("Initialize Config", 10);

            // Khởi tạo form hiển thị hình ảnh
            {
                m_objFormDisplay = new Dictionary<CDefine.enumCamera, CFormDisplay>();
                foreach (CDefine.enumCamera index in Enum.GetValues(typeof(CDefine.enumCamera)))
                {
                    m_objFormDisplay[index] = new CFormDisplay();
                }
                View_Intro.setStatus("Initialize CFormDisplay", 20);
            }


            View_Intro.setStatus("Initialize CFormDisplay", 30);
            View_Intro.setStatus("Initialize CFormDisplay", 40);
            View_Intro.setStatus("Initialize CFormDisplay", 50);
            View_Intro.setStatus("Initialize CFormDisplay", 60);
            View_Intro.setStatus("Initialize CFormDisplay", 70);
            View_Intro.setStatus("Initialize CFormDisplay", 80);


            result = true;
            return result;

        }

        public CDefine.enumRunMode GetRunMode() => m_eRunMode;

        public void SetRunMode(CDefine.enumRunMode eRunMode) => m_eRunMode = eRunMode;

        public DialogResult SetMessage(string strMessage)
        {
            CDialogMessage cDialogMessage = new CDialogMessage(this, strMessage);
            return cDialogMessage.ShowDialog();
        }


        public CMainFrame GetMainFrame()
        {
            CMainFrame cMainFrame = null;
            try
            {
                FormCollection openForms = Application.OpenForms;
                int count = openForms.Count;
                for (int i = 0; i < count; i++)
                {
                    cMainFrame = openForms[i] as CMainFrame;
                    if (null != cMainFrame)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace);
            }
            return cMainFrame;
        }

    }
}
