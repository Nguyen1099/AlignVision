using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CVisionLibraryCogBlob : CVisionLibraryAbstract
    {
        /// <summary>
        /// Công cụ Blob
        /// </summary>
        public CogBlobTool m_objCogTool;
        /// <summary>
        /// Tham số đầu vào
        /// </summary>
        public struct stInputData
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
        /// Tham số đầu ra
        /// </summary>
        public struct stOutputData
        {
            /// <summary>
            /// Cung cấp thông tin kết quả Blob
            /// </summary>
            public CogBlobResults objBlobResults;
            /// <summary>
            /// Tọa độ tâm X, Y và góc đầu ra
            /// </summary>
            public List<double> objOutputCenterX;
            public List<double> objOutputCenterY;
            public List<double> objOutputAngle;
            /// <summary>
            /// Diện tích đầu ra
            /// </summary>
            public int iOutputBlobCount;
            // 						/// <summary>
            // 						/// Diện tích đầu ra
            // 						/// </summary>
            // 						public List<double> objOutputArea;
            // 						/// <summary>
            // 						/// Chiều rộng hình chữ nhật bao Blob đầu ra
            // 						/// </summary>
            // 						public List<double> objOutputWidth;
            // 						/// <summary>
            // 						/// Chiều cao hình chữ nhật bao Blob đầu ra
            // 						/// </summary>
            // 						public List<double> objOutputHeight;

            public void Init()
            {
                objBlobResults = null;
                iOutputBlobCount = 0;
                objOutputCenterX = new List<double>();
                objOutputCenterY = new List<double>();
                objOutputAngle = new List<double>();
                // 				objOutputArea = new List<double>();
                // 				objOutputWidth = new List<double>();
                // 				objOutputHeight = new List<double>();
            }
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public CVisionLibraryCogBlob()
        {
        }
        /// <summary>
        /// Hàm khởi tạo sao chép
        /// </summary>
        /// <param name="obj"></param>
        public CVisionLibraryCogBlob(CVisionLibraryCogBlob obj)
        {
            this.m_objInitializeParameter = obj.m_objInitializeParameter.Clone() as CInitializeParameter;
            this.m_objCogTool = CogSerializer.DeepCopyObject(obj.m_objCogTool, CogSerializationOptionsConstants.All) as CogBlobTool;
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
                m_objCogTool = new CogBlobTool();
                // Tải file VPP
                LoadRecipe(m_objInitializeParameter.strRecipePath, m_objInitializeParameter.strRecipeName);

                // Chế độ phân vùng ảnh 
                // 				m_objCogTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                // 				m_objCogTool.RunParams.SortMeasure = CogBlobMeasureConstants.CenterMassY;
                // 				m_objCogTool.RunParams.SortEnabled = true;
                // 				m_objCogTool.RunParams.SortAscending = true;
                // 				m_objCogTool.RunParams.RunTimeMeasures.Clear();
                // 				int iTotalMeasureCount = 8;
                // 				int iIndex = 0;
                // 				CogBlobMeasure[] objMeasure = new CogBlobMeasure[ iTotalMeasureCount ];
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.Area );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.CenterMassX );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.CenterMassY );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.Angle );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.BoundingBoxExtremaAngleWidth );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.BoundingBoxExtremaAngleHeight );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.Acircularity );
                // 				objMeasure[ iIndex++ ] = new CogBlobMeasure( CogBlobMeasureConstants.Label, CogBlobMeasureModeConstants.Filter, CogBlobFilterModeConstants.IncludeBlobsInRange, 1, 1 );
                // 				for( int iLoopCount = 0; iLoopCount < iTotalMeasureCount; iLoopCount++ ) {
                // 					m_objCogTool.RunParams.RunTimeMeasures.Add( objMeasure[ iLoopCount ] );
                // 				}

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
                        m_objCogTool = CogSerializer.LoadObjectFromFile(strFileName) as CogBlobTool;
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
        public bool HLRun(stInputData objInput, out stOutputData objOutput)
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
                    if (null == m_objCogTool.Results)
                    {
                        string strError = m_objCogTool.GetType().Name + ".Results is null";
                        MakeErrorMessage(this.GetType().Name, MethodBase.GetCurrentMethod().Name, strError);
                        break;
                    }
                    objOutput.objBlobResults = m_objCogTool.Results;
                    // Xuất giá trị kết quả
                    int[] iBlobResultID = m_objCogTool.Results.GetBlobIDs(false);
                    double[] dBlobReslutX = m_objCogTool.Results.GetBlobMeasures(CogBlobMeasureConstants.CenterMassX, iBlobResultID);
                    double[] dBlobReslutY = m_objCogTool.Results.GetBlobMeasures(CogBlobMeasureConstants.CenterMassY, iBlobResultID);
                    double[] dBlobReslutAngle = m_objCogTool.Results.GetBlobMeasures(CogBlobMeasureConstants.Angle, iBlobResultID);
                    //double[] dBlobReslutArea = m_objCogTool.Results.GetBlobMeasures( CogBlobMeasureConstants.Area, iBlobResultID );
                    //double[] dBlobResultWidth = m_objCogTool.Results.GetBlobMeasures( CogBlobMeasureConstants.BoundingBoxExtremaAngleWidth, iBlobResultID );
                    //double[] dBlobResultHeight = m_objCogTool.Results.GetBlobMeasures( CogBlobMeasureConstants.BoundingBoxExtremaAngleHeight, iBlobResultID );

                    objOutput.iOutputBlobCount = m_objCogTool.Results.GetBlobs().Count;
                    foreach (var item in dBlobReslutX)
                    {
                        objOutput.objOutputCenterX.Add(item);
                    }
                    foreach (var item in dBlobReslutY)
                    {
                        objOutput.objOutputCenterY.Add(item);
                    }
                    foreach (var item in dBlobReslutAngle)
                    {
                        objOutput.objOutputAngle.Add(item);
                    }
                    //foreach( var item in dBlobReslutArea ) {
                    //	objOutput.objOutputArea.Add( item );
                    //}
                    //foreach( var item in dBlobResultWidth ) {
                    //	objOutput.objOutputWidth.Add( item );
                    //}
                    //foreach( var item in dBlobResultHeight ) {
                    //	objOutput.objOutputHeight.Add( item );
                    //}
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
