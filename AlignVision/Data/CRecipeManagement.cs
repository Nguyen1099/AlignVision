using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CRecipeManagement
    {
        private CDocument m_objDocument;

        public CRecipeManagement(CDocument objDocument)
        {
            m_objDocument = objDocument;
        }

        public bool Initialize()
        {
            bool result = false;

            result = true;
            return result;
        }

        /// <summary>
        /// Lấy tên thư mục con trong đường dẫn strFilePath
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public List<string> GetDirectoryList(string strFilePath)
        {
            List<string> list = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(strFilePath);
            if (directoryInfo.Exists)
            {
                DirectoryInfo[] directories = directoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < directories.Length; i++)
                {
                    list.Add(directories[i].Name);
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy dữ liệu từ file VisionModel.INI
        /// </summary>
        /// <returns></returns>
        public List<CConfig.CRecipeInformation> GetModelParameterList()
        {
            List<string> directoryList = GetDirectoryList(CDefine.DEF_ALIGN_RECIPE_PATH);

            return directoryList
                   .Select(index => m_objDocument.m_objConfig.GetRecipeParameter(index))      // Lấy thông tin cấu hình từ mỗi thư mục con
                   .OrderBy(model => model.strIndex)    // Sắp xếp theo strIndex
                   .ToList();
        }


        /// <summary>
        ///  Copy dữ liệu từ folder này sang folder khác
        /// </summary>
        /// <param name="strExitFilePath"></param>
        /// <param name="strNewFilePath"></param>
        public void SetDirectoryCopy(string strExitFilePath, string strNewFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(strExitFilePath);
            if (true == directoryInfo.Exists)
            {
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                if (false == Directory.Exists(strNewFilePath))
                {
                    Directory.CreateDirectory(strNewFilePath);
                }
                FileInfo[] files = directoryInfo.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    string destFileName = Path.Combine(strNewFilePath, files[i].Name);
                    files[i].CopyTo(destFileName, overwrite: true);
                }
                for (int j = 0; j < directories.Length; j++)
                {
                    string destFileName = Path.Combine(strNewFilePath, directories[j].Name);
                    SetDirectoryCopy(directories[j].FullName, destFileName);
                }
            }
        }

        /// <summary>
        /// Xóa folder
        /// </summary>
        /// <param name="strFilePath"></param>
        public void SetDirectoryDelete(string strFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(strFilePath);
            try
            {
                directoryInfo.Delete(recursive: true);
            }
            catch (IOException ex)
            {
                Trace.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        ///  Kiểm tra PPID có trùng lặp không ?
        /// </summary>
        /// <param name="strPPID"></param>
        /// <returns></returns>
        public bool GetPPIDDuplicate(string strPPID)
        {
            List<string> directoryList = GetDirectoryList(CDefine.DEF_ALIGN_RECIPE_PATH);
            return directoryList.Any(PPID => PPID == strPPID);
        }

        /// <summary>
        /// Kiểm tra Index trùng lặp
        /// </summary>
        /// <param name="strIndex"></param>
        /// <returns></returns>
        public bool GetIndexDuplicate(string strIndex)
        {
            return GetModelParameterList().Any(model => model.strIndex == strIndex);
        }
        /// <summary>
        ///  Ghi thông tin (PPID và Name) vào file INI
        /// </summary>
        /// <param name="strPPID"></param>
        /// <param name="strName"></param>
        public void SetPPIDMatch(string strPPID, string strIndex)
        {
            var model = m_objDocument.m_objConfig.GetRecipeParameter(strPPID);
            model.strIndex = strIndex;
            model.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            m_objDocument.m_objConfig.SaveRecipeParameter(model, strPPID);
        }



    }
}
