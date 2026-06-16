using System;
using System.IO;


namespace AlignVision
{
    public sealed partial class CConfig
    {
        public class CRecipeInformation : ICloneable
        {
            public string strBootRecipe;

            public string strIndex;

            public string UpdateTime;

            public CRecipeInformation()
            {
                strBootRecipe = "";
                strIndex = "";
                UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            public object Clone()
            {
                CRecipeInformation cRecipeInformation = new CRecipeInformation();
                cRecipeInformation.strBootRecipe = strBootRecipe;
                cRecipeInformation.strIndex = strIndex;
                cRecipeInformation.UpdateTime = UpdateTime;
                return cRecipeInformation;
            }
        }

        private CRecipeInformation m_objRecipeParameter = new CRecipeInformation();
        public CRecipeInformation GetRecipeParameter(string strRecipeName = null)
        {
            if (strRecipeName == null)
            {
                strRecipeName = m_objSystemParameter.strBootRecipe;
            }
            string strPath = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, strRecipeName, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINI = new ClassINI(strPath);

            CRecipeInformation objModelParameter = new CRecipeInformation();
            objModelParameter.strBootRecipe = strRecipeName;
            objModelParameter.strIndex = classINI.GetString("MODEL", "strIndex", "1");
            objModelParameter.UpdateTime = classINI.GetString("MODEL", "UpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return objModelParameter;
        }

        /// <summary>
        /// Load dữ liệu recipe
        /// </summary>
        /// <returns></returns>
        public bool LoadRecipeParameter(string strRecipeName = null)
        {
            bool result = false;

            string path = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, m_objSystemParameter.strBootRecipe, CDefine.DEF_VISION_RECIPE_INI);
            if (strRecipeName != null)
            {
                path = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, strRecipeName, CDefine.DEF_VISION_RECIPE_INI);
            }

            ClassINI classINI = new ClassINI(path);
            string strSection = "RECIPE";
            m_objRecipeParameter.strBootRecipe = classINI.GetString(strSection, "strBootRecipe", m_objSystemParameter.strBootRecipe);
            m_objRecipeParameter.strIndex = classINI.GetString(strSection, "strIndex", "1");
            m_objRecipeParameter.UpdateTime = classINI.GetString(strSection, "UpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            result = true;
            return result;
        }

        /// <summary>
        ///  Lưu dữ liệu recipe
        /// </summary>
        /// <returns></returns>
        private bool SaveRecipeParameter(string strRecipeName = null)
        {
            bool result = false;

            string path = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, m_objSystemParameter.strBootRecipe, CDefine.DEF_VISION_RECIPE_INI);
            if (strRecipeName != null)
            {
                path = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, strRecipeName, CDefine.DEF_VISION_RECIPE_INI);
            }

            ClassINI classINI = new ClassINI(path);

            classINI.WriteValue("MODEL", "strBootRecipe", m_objRecipeParameter.strBootRecipe);
            classINI.WriteValue("MODEL", "strIndex", m_objRecipeParameter.strIndex);
            classINI.WriteValue("MODEL", "UpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            result = true;
            return result;
        }

        public bool SaveRecipeParameter(CRecipeInformation objRecipeParameter, string strRecipeName = null)
        {
            bool result = false;

            string path = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, m_objSystemParameter.strBootRecipe, CDefine.DEF_VISION_RECIPE_INI);
            if (strRecipeName != null)
            {
                path = string.Format(@"{0}\{1}\{2}", m_objSystemParameter.strRecipePath, strRecipeName, CDefine.DEF_VISION_RECIPE_INI);
            }

            ClassINI classINI = new ClassINI(path);

            classINI.WriteValue("MODEL", "strBootRecipe", objRecipeParameter.strBootRecipe);
            classINI.WriteValue("MODEL", "strIndex", objRecipeParameter.strIndex);
            classINI.WriteValue("MODEL", "UpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            m_objRecipeParameter = objRecipeParameter;

            result = true;
            return result;
        }



    }
}
