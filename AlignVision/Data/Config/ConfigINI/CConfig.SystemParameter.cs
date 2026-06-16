using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public sealed partial class CConfig
    {
		/// <summary>
		/// System Parameter Class
		/// </summary>
		public class CSystemParameter : ICloneable
		{
			public CDefine.enumSimulationMode eSimulationMode;

			public string strUserID;

			public string strUserPassword;

			public string strBootRecipe;

			public string strRecipePath; 

            public string strImagePath; 

            public CDefine.enumLightControllerType eLightControllerType;

			public CDefine.enumLanguage eLanguage;

			public CSystemParameter()												  
			{
				eSimulationMode = CDefine.enumSimulationMode.SIMULATION_MODE_ON;
				strUserID = "";
				strUserPassword = "";
                strBootRecipe = "";
				strRecipePath = CDefine.DEF_ALIGN_RECIPE_PATH;
                strImagePath = CDefine.DEF_ALIGN_REPORT_IMAGE_PATH;
                eLightControllerType = CDefine.enumLightControllerType.LLIGHT;
                eLanguage = CDefine.enumLanguage.LANGUAGE_ENGLISH;
            }

			public object Clone()
			{
				CSystemParameter cSystemParameter = new CSystemParameter();
				cSystemParameter.eSimulationMode = eSimulationMode;
				cSystemParameter.strUserID = strUserID;
				cSystemParameter.strUserPassword = strUserPassword;
				cSystemParameter.strBootRecipe = strBootRecipe;
				cSystemParameter.strRecipePath = strRecipePath;
				cSystemParameter.strImagePath = strImagePath;
                cSystemParameter.eLightControllerType = eLightControllerType;
				cSystemParameter.eLanguage = eLanguage;
				return cSystemParameter;
			}
		}

		private CSystemParameter m_objSystemParameter = new CSystemParameter();
		public CSystemParameter GetSystemParameter() => m_objSystemParameter;

		public bool LoadSystemParameter()
		{
			bool result = false;
			string path = string.Format(@"{0}\{1}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
			ClassINI classINI = new ClassINI(path);

			string section = $"SYSTEM";
			m_objSystemParameter.eSimulationMode = (CDefine.enumSimulationMode)classINI.GetInt32("SYSTEM", "eSimulationMode", (int)CDefine.enumSimulationMode.SIMULATION_MODE_ON);
			m_objSystemParameter.strUserPassword = classINI.GetString(section, "strUserPassword", "1234");
			m_objSystemParameter.strBootRecipe = classINI.GetString(section, "strRecipe", "1000");
			//m_objSystemParameter.strRecipePath = classINI.GetString(section, "strRecipePath", CDefine.DEF_ALIGN_RECIPE_PATH);
            //m_objSystemParameter.strImagePath = classINI.GetString(section, "strImagePath", CDefine.DEF_ALIGN_REPORT_IMAGE_PATH);
            m_objSystemParameter.eLightControllerType = (CDefine.enumLightControllerType)classINI.GetInt32("SYSTEM", "eLightControllerType", (int)CDefine.enumLightControllerType.LLIGHT);
            m_objSystemParameter.eLanguage = (CDefine.enumLanguage)classINI.GetInt32("SYSTEM", "eLanguage", (int)CDefine.enumLanguage.LANGUAGE_ENGLISH);

            result = true;
			return result;
		}
		public bool SaveSystemParameter(CSystemParameter objSystemParameter)
		{
			bool result = false;
			string path = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
			ClassINI classINI = new ClassINI(path);

			string section = $"SYSTEM";
			classINI.WriteValue(section, "eSimulationMode", (int)objSystemParameter.eSimulationMode);
			classINI.WriteValue(section, "strUserPassword", objSystemParameter.strUserPassword);
			classINI.WriteValue(section, "strRecipe", objSystemParameter.strBootRecipe);
            classINI.WriteValue(section, "strRecipePath", objSystemParameter.strRecipePath);
            classINI.WriteValue(section, "strImagePath", objSystemParameter.strImagePath);
            classINI.WriteValue(section, "eLightControllerType", (int)objSystemParameter.eLightControllerType);
			classINI.WriteValue(section, "eLanguage", (int)objSystemParameter.eLanguage);

            result = true;
			return result;
		}
		private bool SaveSystemParameter()
		{
			bool result = false;
			string path = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
			ClassINI classINI = new ClassINI(path);

			string section = $"SYSTEM";
			classINI.WriteValue(section, "eSimulationMode", (int)m_objSystemParameter.eSimulationMode);
			classINI.WriteValue(section, "strUserPassword", m_objSystemParameter.strUserPassword);
			classINI.WriteValue(section, "strRecipe", m_objSystemParameter.strBootRecipe);
            classINI.WriteValue(section, "strRecipePath", m_objSystemParameter.strRecipePath);
            classINI.WriteValue(section, "strImagePath", m_objSystemParameter.strImagePath);
            classINI.WriteValue(section, "eLightControllerType", (int)m_objSystemParameter.eLightControllerType);
			classINI.WriteValue(section, "eLanguage", (int)m_objSystemParameter.eLanguage);

            result = true;
			return result;
		}



	}
}
