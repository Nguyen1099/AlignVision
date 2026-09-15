using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CVisionLibraryCogFixture : CVisionLibraryAbstract
    {
        /// <summary>
        /// Công cụ Fixture
        /// </summary>
        public CogFixtureTool m_objCogTool;
        /// <summary>
        /// Tham số đầu vào
        /// </summary>
        public struct stInputData
        {
            /// <summary>
            /// Ảnh Cognex
            /// </summary>
            public CogImage8Grey objCogImage;
            /// <summary>
            /// Độ tịnh tiến theo trục X
            /// </summary>
            public double TranslationX;
            /// <summary>
            /// Độ tịnh tiến theo trục Y
            /// </summary>
            public double TranslationY;

            public void Init()
            {
                objCogImage = null;
                TranslationX = 0.0;
                TranslationY = 0.0;
            }
        }
        /// <summary>
        /// Tham số đầu ra
        /// </summary>
        public struct stOutputData
        {
            /// <summary>
            /// Ảnh Cognex
            /// </summary>
            public CogImage8Grey objCogImage;

            public void Init()
            {
                objCogImage = null;
            }
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public CVisionLibraryCogFixture()
        {
        }
        /// <summary>
        /// Hàm khởi tạo sao chép
        /// </summary>
        /// <param name="obj"></param>
        public CVisionLibraryCogFixture(CVisionLibraryCogFixture obj)
        {
            this.m_objInitializeParameter = obj.m_objInitializeParameter.Clone() as CInitializeParameter;
            this.m_objCogTool = CogSerializer.DeepCopyObject(obj.m_objCogTool, CogSerializationOptionsConstants.All) as CogFixtureTool;
        }
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="objInitializeParameter"></param>
        /// <returns></returns>
        public override bool Initialize(CInitializeParameter objInitializeParameter)
        {
            bool bReturn = false;

            do
            {
                // Khởi tạo tham số
                m_objInitializeParameter = (CInitializeParameter)objInitializeParameter.Clone();
                // Tạo công cụ
                m_objCogTool = new CogFixtureTool();
                // Tải file VPP
                LoadRecipe(m_objInitializeParameter.strRecipePath, m_objInitializeParameter.strRecipeName);

                bReturn = true;
            } while (false);

            return bReturn;
        }
        /// <summary>
        /// Giải phóng tài nguyên
        /// </summary>
        public override void DeInitialize()
        {
            if (null != m_objCogTool)
            {
                m_objCogTool.Dispose();
            }
        }
        /// <summary>
        /// Tải công thức
        /// </summary>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        /// <returns></returns>
        public override bool LoadRecipe(string strRecipePath, string strRecipeName)
        {
            bool bReturn = false;

            do
            {
                try
                {
                    string strFileName = strRecipePath + "\\" + strRecipeName + "\\" + string.Format("{0}.{1}.vpp", m_objCogTool.GetType().Name, m_objInitializeParameter.strVppFileName);
                    // Kiểm tra file, nếu chưa tồn tại thì tạo file VPP mặc định
                    if (false == File.Exists(strFileName))
                    {
                        SaveRecipe(strRecipePath, strRecipeName);
                    }
                    else
                    {
                        m_objCogTool = CogSerializer.LoadObjectFromFile(strFileName) as CogFixtureTool;
                    }
                }
                catch (Exception ex)
                {
                    MakeErrorMessage(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    break;
                }

                bReturn = true;
            } while (false);

            return bReturn;
        }
        /// <summary>
        /// Lưu công thức
        /// </summary>
        /// <param name="strRecipePath"></param>
        /// <param name="strRecipeName"></param>
        /// <returns></returns>
        public override bool SaveRecipe(string strRecipePath, string strRecipeName)
        {
            bool bReturn = false;

            do
            {
                string strFileName = strRecipePath + "\\" + strRecipeName + "\\" + string.Format("{0}.{1}.vpp", m_objCogTool.GetType().Name, m_objInitializeParameter.strVppFileName);

                try
                {
                    CogSerializer.SaveObjectToFile(m_objCogTool, strFileName, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.All);
                }
                catch (Exception ex)
                {
                    MakeErrorMessage(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    break;
                }

                bReturn = true;
            } while (false);

            return bReturn;
        }
        /// <summary>
        /// Chạy công thức
        /// </summary>
        /// <param name="objInput"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public bool Run(stInputData objInput, out stOutputData objOutput)
        {
            bool bReturn = false;

            objOutput = new stOutputData();
            objOutput.Init();
            // Ảnh gốc
            ICogImage objOriginImage = null;

            do
            {
                try
                {
                    // Kiểm tra giá trị null
                    if (null == objInput.objCogImage)
                    {
                        string strError = "objCogImage is null";
                        MakeErrorMessage(this.GetType().Name, MethodBase.GetCurrentMethod().Name, strError);
                        break;
                    }
                    objOriginImage = m_objCogTool.InputImage;
                    // Gán tham số đầu vào
                    m_objCogTool.InputImage = objInput.objCogImage;
                    // Chạy VPP
                    m_objCogTool.Run();
                    // Xuất giá trị kết quả
                    CogImage8Grey objOutputImage = m_objCogTool.OutputImage as CogImage8Grey;
                    if (null == objOutputImage)
                    {
                        string strError = "objOutputImage is null";
                        MakeErrorMessage(this.GetType().Name, MethodBase.GetCurrentMethod().Name, strError);
                        //break;
                        // Nếu không hiệu chuẩn được thì xử lý thế nào ..?
                        objOutputImage = objInput.objCogImage;
                    }
                    objOutput.objCogImage = objOutputImage;
                }
                catch (Exception ex)
                {
                    MakeErrorMessage(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                    break;
                }

                bReturn = true;
            } while (false);

            m_objCogTool.InputImage = objOriginImage;

            return bReturn;
        }
    }
}
