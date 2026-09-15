using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CVisionOneCamOneStage
    {
        /// <summary>
        /// Số lượng mark sử dụng trong 1 khung hình camera
        /// </summary>
        private enum enumMarkIndex
        {
            MARK_1 = 0,
            MARK_2,
            CALIBRATION_1,
            CALIBRATION_2,

        }

        /// <summary>
        /// Định nghĩa cấu trúc để truyền các tham số của Task.
        /// </summary>
        private struct structureParamMain
        {
            public CVisionLibraryToolAlign objTool;
            public string strRecipePath;
            public string strRecipeName;
            public CDefine.enumAlignToolType eAlignToolType;
            public int iMarkIndex;
        }
        private struct structureParamSub
        {
            public CVisionLibraryAbstract.CInitializeParameter objInitialize;
            public CVisionLibraryAbstract objVisionLibrary;
            public CVisionLibraryToolAlign.enumToolKind eToolKind;
        }
        private struct structureCopyConstructor
        {
            public CVisionLibraryToolAlign objTool;
            public int iMarkIndex;
        }

        public int m_iCameraIndex;

        public List<CVisionLibraryToolAlign> m_objListTool;

        public CVisionOneCamOneStage()
        {
            m_objListTool = new List<CVisionLibraryToolAlign>();
        }

        public void Initialize(string strRecipePath, string strRecipeName, int iCameraIndex)
        {
            m_iCameraIndex = iCameraIndex;
            Initialize(strRecipePath, strRecipeName, iCameraIndex, Enum.GetValues(typeof(enumMarkIndex)).Length);
        }

        public void Initialize(string strRecipePath, string strRecipeName, int iCameraIndex, int iMarkCount)
        {
            m_iCameraIndex = iCameraIndex;
            var tasks = new List<Task<structureParamMain>>();
            Func<object, structureParamMain> action = (object obj) =>
            {
                structureParamMain objParam = (structureParamMain)obj;
                Initialize(objParam.objTool, objParam.strRecipePath, objParam.strRecipeName, objParam.eAlignToolType, objParam.iMarkIndex);
                return objParam;
            };
            var pDocument = CDocument.GetDocument;
            CConfig.CRecipeParameter objRecipeParameter = pDocument.m_objConfig.GetRecipeParameter((CDefine.enumCamera)m_iCameraIndex);
            for (int iLoopMarkCount = 0; iLoopMarkCount < iMarkCount; iLoopMarkCount++)
            {
                CVisionLibraryToolAlign objTool = new CVisionLibraryToolAlign();

                // Điền thông tin vào đối số Task và xuất các tác vụ dưới dạng danh sách.
                structureParamMain objParam = new structureParamMain();
                objParam.objTool = objTool;
                objParam.strRecipePath = strRecipePath;
                objParam.strRecipeName = strRecipeName;
                objParam.eAlignToolType = objRecipeParameter.objListAlignTool[iLoopMarkCount].eAlignToolType;
                objParam.iMarkIndex = iLoopMarkCount;
                tasks.Add(Task<structureParamMain>.Factory.StartNew(action, objParam));
                m_objListTool.Add(objTool);
            }

            try
            {
                // Task 완료 대기
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                string strError = string.Format("{0} {1} {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CDocument.GetDocument.SetMessage(strError);
            }
        }

        /// <summary>
        /// Hàm khởi tạo cho từng công cụ trong danh sách m_objListTool
        /// </summary>
        /// <param name="objTool"></param>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        /// <param name="eAlignToolType"></param>
        /// <param name="iMarkIndex"></param>
        private void Initialize(CVisionLibraryToolAlign objTool, string strRecipePath, string strRecipeName, CDefine.enumAlignToolType eAlignToolType, int iMarkIndex)
        {
            var tasks = new List<Task<structureParamSub>>();
            Func<object, structureParamSub> action = (object obj) =>
            {
                structureParamSub objParam = (structureParamSub)obj;
                objParam.objVisionLibrary.Initialize(objParam.objInitialize);
                return objParam;
            };
            CVisionLibraryAbstract.CInitializeParameter objInitialize = new CVisionLibraryAbstract.CInitializeParameter();
            objInitialize.strRecipePath = strRecipePath;
            objInitialize.strRecipeName = strRecipeName;
            // Only Pattern
            {
                objInitialize.strVppFileName = string.Format("");
                CVisionLibraryToolAlign.enumToolKind eToolKind = CVisionLibraryToolAlign.enumToolKind.MAIN_PATTERN;
                structureParamSub objParam = new structureParamSub();
                objParam.objVisionLibrary = objTool.m_objMainPattern;
                objParam.objInitialize = objInitialize.Clone() as CVisionLibraryAbstract.CInitializeParameter;
                objParam.eToolKind = eToolKind;
                tasks.Add(Task<structureParamSub>.Factory.StartNew(action, objParam));
            }
            // Only Line
            {
                objInitialize.strVppFileName = string.Format("");
                CVisionLibraryToolAlign.enumToolKind eToolKind = CVisionLibraryToolAlign.enumToolKind.MAIN_LINE;
                structureParamSub objParam = new structureParamSub();
                objParam.objVisionLibrary = objTool.m_objMainLine;
                objParam.objInitialize = objInitialize.Clone() as CVisionLibraryAbstract.CInitializeParameter;
                objParam.eToolKind = eToolKind;
                tasks.Add(Task<structureParamSub>.Factory.StartNew(action, objParam));
            }
            try
            {
                // Wait for all tasks to complete
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                string strError = string.Format("{0} {1} {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CDocument.GetDocument.SetMessage(strError);
            }

        }

        /// <summary>
        /// Hàm giải phóng bộ nhớ cho các đối tượng trong danh sách m_objListTool
        /// </summary>
        public void Deinitialize()
        {
            foreach (var item1 in m_objListTool)
            {
                item1.Deinitialize();
            }
        }


        /// <summary>
        /// SaveRecipe: Lưu công thức cho tất cả các công cụ trong danh sách m_objListTool
        /// </summary>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        public void SaveRecipe(string strRecipePath, string strRecipeName)
        {
            foreach (var index in this.m_objListTool)
            {
                index.SaveRecipe(strRecipePath, strRecipeName);
            }
        }

        /// <summary>
        /// LoadRecipe: Tải công thức cho tất cả các công cụ trong danh sách m_objListTool
        /// </summary>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        public void LoadRecipe(string strRecipePath, string strRecipeName)
        {
            foreach (var item1 in this.m_objListTool)
            {
                item1.LoadRecipe(strRecipePath, strRecipeName);
            }
        }


    }
}
