using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public CRecipeManagement m_objRecipeManagement;

        private CDefine.enumRunMode m_eRunMode;

        private static CDocument m_objDocument;

        /// <summary>
        /// Quản lý form hiện thị hình ảnh
        /// </summary>
        public Dictionary<CDefine.enumCamera, CFormDisplay> m_objFormDisplay;

        public static CDocument GetDocument
        {
            get
            {
                if (null == m_objDocument)
                {
                    m_objDocument = new CDocument();
                }
                return m_objDocument;
            }
        }


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

            // Khởi tạo quản lý recipe
            m_objRecipeManagement = new CRecipeManagement(this);
            if (m_objRecipeManagement.Initialize() == false)
            {
                throw new Exception();
            }
            View_Intro.setStatus("Initialize CRecipeManagement", 20);

            // Khởi tạo form hiển thị hình ảnh
            {
                m_objFormDisplay = new Dictionary<CDefine.enumCamera, CFormDisplay>();
                foreach (CDefine.enumCamera index in Enum.GetValues(typeof(CDefine.enumCamera)))
                {
                    m_objFormDisplay[index] = new CFormDisplay();
                }
                View_Intro.setStatus("Initialize CFormDisplay", 30);
            }

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

        public static void Exception(Exception ex, string comment = "")
        {
            StringBuilder sb = new StringBuilder();
            StackTrace trace = new StackTrace(ex, true);
            CDocument objDocument = CDocument.GetDocument;
            if (null != objDocument)
            {
                sb.Append(comment).AppendLine();
                int count = 0;
                if (trace.FrameCount != 0)
                {
                    foreach (StackFrame sf in trace.GetFrames())
                    {
                        count++;
                        sb.AppendFormat(
                            "[Depth:{0}, Line:{1}, Method:{2}, File:{3}]",
                            count,
                            sf.GetFileLineNumber(),
                            sf.GetMethod().Name,
                            Path.GetFileName(sf.GetFileName())
                            ).AppendLine();
                    }
                }
                sb.AppendFormat("[Message:{0}]", ex.Message);
                //objDocument.SetUpdateLog(CDefine.enumLogType.LOG_EXCEPTION, sb.ToString());
            }
        }


    }
}
