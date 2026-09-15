using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CVisionLibraryToolAlign
    {
        public enum enumToolKind
        {
            MAIN_PATTERN,
            MAIN_LINE
        }

        /// <summary>
        /// Main Line input enum
        /// </summary>
        private enum enumInputMainLine
        {
            InputImage,
        }
        /// <summary>
        /// Main Line output enum
        /// </summary>
        private enum enumOutputMainLine
        {
            X,
            Y,
            T,
            ErrorString,
            Result,
            RMS_1,
            RMS_2,
            LineT_1,
            LineT_2,
            RecordList,
        }
        /// <summary>
        /// Main Line vpp Input
        /// </summary>
        public struct stInputMainLine
        {
            /// <summary>
            /// Ảnh đầu vào
            /// </summary>
            public CogImage8Grey InputImage;
        }
        /// <summary>
        /// Main Line vpp Output
        /// </summary>
        public struct stOutputMainLine
        {
            /// <summary>
            /// Intersection X
            /// </summary>
            public double X;
            /// <summary>
            /// Intersection Y
            /// </summary>
            public double Y;
            /// <summary>
            /// Angel ( deg )
            /// </summary>
            public double T;
            /// <summary>
            /// Từ điển chuỗi [ Key: Tên ToolBlock xảy ra lỗi / Value: Nội dung lỗi ]
            /// </summary>
            public CogStringCollection ErrorString;
            /// <summary>
            /// Trả về true khi tìm được một giao điểm mà không có lỗi
            /// Trả về false trong các trường hợp còn lại
            /// </summary>
            public bool Result;
            // Sai số RMS của đường tìm được
            public double dRmsLine1;
            public double dRmsLine2;
            // Góc của đường tìm được
            public double dLineT1;
            public double dLineT2;
            /// <summary>
            /// Danh sách bản ghi kết quả
            /// Các bản ghi gồm Line1, Line2 và IntersectionPoint
            /// </summary>
            public ICogRecords RecordList;
        }

        /// <summary>
        /// Main Pattern input enum
        /// </summary>
        private enum enumInputMainPattern
        {
            InputImage,
            PatternResultType,
            DemandScore,
        }

        /// <summary>
        /// Main Pattern output enum
        /// </summary>
        private enum enumOutputMainPattern
        {
            KeyName,
            X,
            Y,
            T,
            Score,
            ErrorString,
            Result,
            RecordList,
        }

        /// <summary>
        /// Main Pattern vpp Input
        /// </summary>
        public struct stInputMainPattern
        {
            /// <summary>
            /// 입력 이미지
            /// Ảnh đầu vào
            /// </summary>
            public CogImage8Grey InputImage;
            /// <summary>
            /// 패턴 검색 타입 ( 0 : Sequence, 1: Score )
            /// Chế độ tìm mẫu (0: Theo thứ tự, 1: Theo điểm số)
            /// Sequence : 위에서 아래로 순서대로 패턴툴 검색해서 DemandScore 보다 높은 패턴에서 결과 리턴
            /// Sequence: Chạy các công cụ tìm mẫu lần lượt từ trên xuống và trả về kết quả khi điểm của mẫu vượt DemandScore
            /// Score : 모든 패턴툴을 검색한 뒤 가장 높은 스코어가 DemandScore 보다 높은 경우 결과 리턴
            /// Score: Chạy tất cả công cụ tìm mẫu, rồi trả về kết quả có điểm cao nhất nếu điểm đó vượt DemandScore
            /// </summary>
            public int PatternResultType;
            /// <summary>
            /// 최소 요구 스코어 ( 해당 스코어를 넘는 결과값이 없는 경우 Result false & Error 리턴
            /// Điểm yêu cầu tối thiểu (nếu không có kết quả vượt ngưỡng này thì trả về Result = false và thông tin lỗi)
            /// </summary>
            public int DemandScore;
        }

        /// <summary>
        /// Main Pattern vpp Output
        /// </summary>
        public struct stOutputMainPattern
        {
            /// <summary>
            /// 검색 성공한 경우 패턴 툴 이름을 리턴 [ Key : ToolBlock Name / Value : Tool Name ]
            /// Trả về tên công cụ tìm mẫu khi tìm thành công [ Key: Tên ToolBlock / Value: Tên công cụ ]
            /// </summary>
            public CogStringCollection KeyName;
            /// <summary>
            /// Translation X
            /// </summary>
            public double X;
            /// <summary>
            /// Translation Y
            /// </summary>
            public double Y;
            /// <summary>
            /// Rotation ( deg )
            /// </summary>
            public double T;
            /// <summary>
            /// Score
            /// </summary>
            public int Score;
            /// <summary>
            /// string dictionary [ Key : 에러난 툴 블럭 이름 / Value : 에러 내용 ]
            /// Từ điển chuỗi [ Key: Tên ToolBlock xảy ra lỗi / Value: Nội dung lỗi ]
            /// </summary>
            public CogStringCollection ErrorString;
            /// <summary>
            /// 요구 스코어보다 높은 패턴 결과 찾은 경우 true
            /// Trả về true khi tìm được mẫu có điểm vượt ngưỡng yêu cầu
            /// 그 외 false
            /// Trả về false trong các trường hợp còn lại
            /// </summary>
            public bool Result;
            /// <summary>
            /// 검색 성공한 패턴 툴 레코드
            /// Bản ghi kết quả của công cụ tìm mẫu thành công
            /// </summary>
            public ICogRecords RecordList;
        }

        /// <summary>
        /// Cấu trúc tham số truyền vào khi sao chép đối tượng
        /// </summary>
        private struct structureCopyConstructor
        {
            public enumToolKind eToolKind;
        }

        private struct structureLoadRecipe
        {
            public CVisionLibraryAbstract objVisionLibrary;
            public string strRecipePath;
            public string strRecipeName;
            public enumToolKind eToolKind;
        }

        /// <summary>
        /// Đối tượng khóa để đồng bộ hóa truy cập
        /// </summary>
        public object m_objLock = new object();

        /// <summary>
        /// Only Pattern
        /// </summary>
        public CVisionLibraryCogToolBlock m_objMainPattern;

        /// <summary>
        /// Only Find Line
        /// </summary>
        public CVisionLibraryCogToolBlock m_objMainLine;

        public CVisionLibraryToolAlign()
        {
            this.m_objMainPattern = new CVisionLibraryCogToolBlock();
            this.m_objMainLine = new CVisionLibraryCogToolBlock();
        }

        public CVisionLibraryToolAlign(CVisionLibraryToolAlign obj)
        {
            var tasks = new List<Task<structureCopyConstructor>>();
            Func<object, structureCopyConstructor> action = (object objTask) =>
            {
                structureCopyConstructor objParam = (structureCopyConstructor)objTask;
                switch (objParam.eToolKind)
                {
                    case enumToolKind.MAIN_PATTERN:
                        this.m_objMainPattern = new CVisionLibraryCogToolBlock(obj.m_objMainPattern);
                        break;
                    case enumToolKind.MAIN_LINE:
                        this.m_objMainLine = new CVisionLibraryCogToolBlock(obj.m_objMainLine);
                        break;
                    default:
                        break;
                }
                return objParam;
            };

            // Only Pattern
            {
                structureCopyConstructor objParam = new structureCopyConstructor();
                objParam.eToolKind = enumToolKind.MAIN_PATTERN;
                tasks.Add(Task<structureCopyConstructor>.Factory.StartNew(action, objParam));
            }

            // Only Line
            {
                structureCopyConstructor objParam = new structureCopyConstructor();
                objParam.eToolKind = enumToolKind.MAIN_LINE;
                tasks.Add(Task<structureCopyConstructor>.Factory.StartNew(action, objParam));
            }

            try
            {
                // chờ các Task hoàn thành
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                string strError = string.Format("{0} {1} {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                CDocument.GetDocument.SetMessage(strError);
            }

        }

        /// <summary>
        /// Giải phóng tài nguyên
        /// </summary>
        public void Deinitialize()
        {
            if (null != m_objMainPattern)
            {
                m_objMainPattern.DeInitialize();
            }
            if (null != m_objMainLine)
            {
                m_objMainLine.DeInitialize();
            }
        }

        /// <summary>
        /// Load recipe VPP
        /// </summary>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        public void LoadRecipe(string strRecipePath, string strRecipeName)
        {
            lock (m_objLock)
            {

                var tasks = new List<Task<structureLoadRecipe>>();
                Func<object, structureLoadRecipe> action = (object objTask) =>
                {
                    structureLoadRecipe objParam = (structureLoadRecipe)objTask;
                    objParam.objVisionLibrary.LoadRecipe(objParam.strRecipePath, objParam.strRecipeName);
                    return objParam;
                };

                // Main Pattern
                {
                    structureLoadRecipe objParam = new structureLoadRecipe();
                    objParam.objVisionLibrary = this.m_objMainPattern;
                    objParam.strRecipePath = strRecipePath;
                    objParam.strRecipeName = strRecipeName;
                    objParam.eToolKind = enumToolKind.MAIN_PATTERN;
                    tasks.Add(Task<structureLoadRecipe>.Factory.StartNew(action, objParam));
                }

                // Main Line
                {
                    structureLoadRecipe objParam = new structureLoadRecipe();
                    objParam.objVisionLibrary = this.m_objMainLine;
                    objParam.strRecipePath = strRecipePath;
                    objParam.strRecipeName = strRecipeName;
                    objParam.eToolKind = enumToolKind.MAIN_LINE;
                    tasks.Add(Task<structureLoadRecipe>.Factory.StartNew(action, objParam));
                }

                try
                {
                    // Chờ các Task hoàn thành
                    Task.WaitAll(tasks.ToArray());
                }
                catch (AggregateException ex)
                {
                    string strError = string.Format("{0} {1} {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    CDocument.GetDocument.SetMessage(strError);
                }
            }
        }

        /// <summary>
        /// Lưu recipe VPP
        /// </summary>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        public void SaveRecipe(string strRecipePath, string strRecipeName)
        {
            lock (m_objLock)
            {
                if (null != m_objMainLine)
                {
                    m_objMainLine.SaveRecipe(strRecipePath, strRecipeName);
                }
                if (null != m_objMainPattern)
                {
                    m_objMainPattern.SaveRecipe(strRecipePath, strRecipeName);
                }
            }
        }

        /// <summary>
        /// Run toolBlock
        /// </summary>
        /// <param name="objToolBlock"></param>
        /// <param name="strListInput"></param>
        /// <param name="objListInput"></param>
        /// <param name="strListOutput"></param>
        /// <param name="objListOutput"></param>
        public void Run(CVisionLibraryCogToolBlock objToolBlock, string[] strListInput, object[] objListInput, string[] strListOutput, ref object[] objListOutput)
        {
            lock (m_objLock)
            {
                try
                {
                    // Kiểm tra script có tồn tại trong toolBlock không
                    if (null == objToolBlock.m_objCogTool.Script)
                    {
                        string strError = string.Format("{0} {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                        strError += string.Format("script is null.");
                        CDocument.GetDocument.SetMessage(strError);
                        return;
                    }

                    // Set Input Data
                    {
                        bool bLoopResult = true;
                        foreach (string strItem in strListInput)
                        {
                            if (false == objToolBlock.m_objCogTool.Inputs.Contains(strItem))
                            {
                                bLoopResult = false;
                                break;
                            }
                            if (null == objToolBlock.m_objCogTool.Inputs[strItem])
                            {
                                bLoopResult = false;
                                break;
                            }
                            if (objToolBlock.m_objCogTool.Inputs[strItem].ValueType != strItem.GetType())
                            {
                                bLoopResult = false;
                                break;
                            }
                            objToolBlock.m_objCogTool.Inputs[strItem].Value = strItem;
                        }
                        if (bLoopResult == false)
                        {
                            string strError = string.Format("{0} {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            strError += string.Format("Error : Set Input Data");
                            CDocument.GetDocument.SetMessage(strError);
                        }
                    }

                    // Run toolblock
                    objToolBlock.Run();
                   
                    // Get Output Data
                    {
                        bool bLoopResult = true;
                        foreach (var strKey in strListInput)
                        {
                            if (false == objToolBlock.m_objCogTool.Inputs.Contains(strKey))
                            {
                                bLoopResult = false;
                                break;
                            }
                            if (null == objToolBlock.m_objCogTool.Inputs[strKey])
                            {
                                bLoopResult = false;
                                break;
                            }
                            if (objToolBlock.m_objCogTool.Inputs[strKey].ValueType != strKey.GetType())
                            {
                                bLoopResult = false;
                                break;
                            }
                            objToolBlock.m_objCogTool.Inputs[strKey].Value = strKey;
                        }
                        if (false == bLoopResult)
                        {
                            string strError = string.Format("{0} {1} ", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            strError += string.Format("Error : Set Input Data");
                            CDocument.GetDocument.SetMessage(strError);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string strError = string.Format("{0} {1} {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    CDocument.GetDocument.SetMessage(strError);
                }

            }
        }

        /// <summary>
        /// Main Line vpp Run
        /// </summary>
        /// <param name="objInput"></param>
        /// <param name="objOutput"></param>
        public void Run(stInputMainLine objInput, ref stOutputMainLine objOutput)
        {
            // Phần do người dùng định nghĩa
            string[] strListInput = Enum.GetNames(typeof(enumInputMainLine));
            string[] strListOutput = Enum.GetNames(typeof(enumOutputMainLine));
            object[] objListInput = new object[strListInput.Length];
            objListInput[(int)enumInputMainLine.InputImage] = objInput.InputImage;
            object[] objListOutput = new object[strListOutput.Length];

            // Main Line
            Run(m_objMainLine, strListInput, objListInput, strListOutput, ref objListOutput);

            // Giá trị kết quả
            objOutput.X = (double)objListOutput[(int)enumOutputMainLine.X];
            objOutput.Y = (double)objListOutput[(int)enumOutputMainLine.Y];
            objOutput.T = (double)objListOutput[(int)enumOutputMainLine.T];
            objOutput.ErrorString = objListOutput[(int)enumOutputMainLine.ErrorString] as CogStringCollection;
            objOutput.Result = (bool)objListOutput[(int)enumOutputMainLine.Result];
            objOutput.dRmsLine1 = (double)objListOutput[(int)enumOutputMainLine.RMS_1];
            objOutput.dRmsLine2 = (double)objListOutput[(int)enumOutputMainLine.RMS_2];
            objOutput.dLineT1 = (double)objListOutput[(int)enumOutputMainLine.LineT_1];
            objOutput.dLineT2 = (double)objListOutput[(int)enumOutputMainLine.LineT_2];
            objOutput.RecordList = objListOutput[(int)enumOutputMainLine.RecordList] as ICogRecords;
        }

        /// <summary>
        /// Main Pattern vpp Run
        /// </summary>
        /// <param name="objInput"></param>
        /// <param name="objOutput"></param>
        public void Run(stInputMainPattern objInput, ref stOutputMainPattern objOutput)
        {
            // Phần do người dùng định nghĩa
            string[] strListInput = Enum.GetNames(typeof(enumInputMainPattern));
            string[] strListOutput = Enum.GetNames(typeof(enumOutputMainPattern));
            object[] objListInput = new object[strListInput.Length];
            objListInput[(int)enumInputMainPattern.InputImage] = objInput.InputImage;
            objListInput[(int)enumInputMainPattern.PatternResultType] = objInput.PatternResultType;
            objListInput[(int)enumInputMainPattern.DemandScore] = objInput.DemandScore;
            object[] objListOutput = new object[strListOutput.Length];

            // Main Pattern
            Run(m_objMainPattern, strListInput, objListInput, strListOutput, ref objListOutput);

            // Giá trị kết quả
            objOutput.KeyName = objListOutput[(int)enumOutputMainPattern.KeyName] as CogStringCollection;
            objOutput.X = (double)objListOutput[(int)enumOutputMainPattern.X];
            objOutput.Y = (double)objListOutput[(int)enumOutputMainPattern.Y];
            objOutput.T = (double)objListOutput[(int)enumOutputMainPattern.T];
            objOutput.Score = (int)objListOutput[(int)enumOutputMainPattern.Score];
            objOutput.ErrorString = objListOutput[(int)enumOutputMainPattern.ErrorString] as CogStringCollection;
            objOutput.Result = (bool)objListOutput[(int)enumOutputMainPattern.Result];
            objOutput.RecordList = objListOutput[(int)enumOutputMainPattern.RecordList] as ICogRecords;
        }

    }
}
