using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public class CVisionLibraryCogToolBlock :CVisionLibraryAbstract
    {
        /// <summary>
        /// Khối công cụ
        /// </summary>
        public CogToolBlock m_objCogTool;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public CVisionLibraryCogToolBlock()
        {
        }
        /// <summary>
        /// Hàm khởi tạo sao chép
        /// </summary>
        /// <param name="obj"></param>
        public CVisionLibraryCogToolBlock(CVisionLibraryCogToolBlock obj)
        {
            this.m_objInitializeParameter = obj.m_objInitializeParameter.Clone() as CInitializeParameter;
            this.m_objCogTool = CogSerializer.DeepCopyObject(obj.m_objCogTool, CogSerializationOptionsConstants.All) as CogToolBlock;
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
                m_objCogTool = new CogToolBlock();
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
                    // Nếu không có tên file thì sao chép từ VPP mặc định (VPP chính chỉ tải và sử dụng file mặc định trong thư mục Debug nên không cần lưu)
                    if ("" == m_objInitializeParameter.strVppFileName)
                    {
                        //if( null != m_objInitializeParameter.objDefaultVpp ) {
                        //	m_objCogTool = CogSerializer.DeepCopyObject( m_objInitializeParameter.objDefaultVpp, CogSerializationOptionsConstants.All ) as CogToolBlock;
                        //}
                    }
                    else
                    {
                        string strFileName = strRecipePath + "\\" + strRecipeName + "\\" + string.Format("{0}.{1}.vpp", m_objCogTool.GetType().Name, m_objInitializeParameter.strVppFileName);
                        // Kiểm tra file, nếu chưa tồn tại thì tạo file VPP mặc định
                        if (false == File.Exists(strFileName))
                        {
                            // Sao chép VPP mặc định nếu có
                            //if( null != m_objInitializeParameter.objDefaultVpp ) {
                            //	m_objCogTool = CogSerializer.DeepCopyObject( m_objInitializeParameter.objDefaultVpp, CogSerializationOptionsConstants.All ) as CogToolBlock;
                            //}
                            //SaveRecipe(strRecipePath, strRecipeName);

                            MessageBox.Show("Không tìm thấy file VPP: " + strFileName, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            m_objCogTool = CogSerializer.LoadObjectFromFile(strFileName) as CogToolBlock;
                        }
                    }
                    m_objCogTool.GarbageCollectionEnabled = true;
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
        /// Lưu recipe
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
                    if (m_objInitializeParameter.strVppFileName.IndexOf("SubPattern") != -1)
                        CogSerializer.SaveObjectToFile(m_objCogTool, strFileName, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                    else
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
        /// Chạy recipe
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            bool bReturn = false;

            do
            {
                try
                {
                    // Chạy VPP (thực thi tất cả công cụ)
                    m_objCogTool.Run();
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
    }
}
