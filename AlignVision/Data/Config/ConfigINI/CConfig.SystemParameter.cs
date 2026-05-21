using System;
using System.Collections.Generic;
using System.Linq;
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

			public string strRecipe;

			public CDefine.enumLightControllerType eLightControllerType;

			public CSystemParameter()
			{
				eSimulationMode = CDefine.enumSimulationMode.SIMULATION_MODE_ON;
				strUserID = "";
				strUserPassword = "";
                strRecipe = "";
				eLightControllerType = CDefine.enumLightControllerType.LLIGHT;
			}

			public object Clone()
			{
				CSystemParameter cSystemParameter = new CSystemParameter();
				cSystemParameter.eSimulationMode = eSimulationMode;
				cSystemParameter.strUserID = strUserID;
				cSystemParameter.strUserPassword = strUserPassword;
				cSystemParameter.strRecipe = strRecipe;
				cSystemParameter.eLightControllerType = eLightControllerType;
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
			m_objSystemParameter.strRecipe = classINI.GetString(section, "strRecipe", "1000");
			m_objSystemParameter.eLightControllerType = (CDefine.enumLightControllerType)classINI.GetInt32("SYSTEM", "eLightControllerType", (int)CDefine.enumLightControllerType.LLIGHT);
			
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
			classINI.WriteValue(section, "strRecipe", objSystemParameter.strRecipe);
			classINI.WriteValue(section, "eLightControllerType", (int)objSystemParameter.eLightControllerType);
			
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
			classINI.WriteValue(section, "strRecipe", m_objSystemParameter.strRecipe);
			classINI.WriteValue(section, "eLightControllerType", (int)m_objSystemParameter.eLightControllerType);

			result = true;
			return result;
		}



	}
}
