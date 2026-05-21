using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        public class CDeviceParameter : ICloneable
        {
            public string strControllerIP;
            public int strControllerPort;

            public object Clone()
            {
                CDeviceParameter cDeviceParameter = new CDeviceParameter();
                cDeviceParameter.strControllerIP = strControllerIP;
                cDeviceParameter.strControllerPort = strControllerPort;
                return cDeviceParameter;
            }
        }

        private CDeviceParameter m_objDeviceParameter = new CDeviceParameter();

        public CDeviceParameter GetDeviceParameter() => (CDeviceParameter)m_objDeviceParameter.Clone();

        public bool LoadDeviceParameter()
        {
            bool result = false;

            string path = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(path);
            string section = $"DEVICE";
            m_objDeviceParameter.strControllerIP = classINI.GetString(section, "strControllerIP", "127.0.0.1");
            m_objDeviceParameter.strControllerPort = classINI.GetInt32(section, "strControllerPort", 5000);
            
            result = true;
            return result;
        }

        public bool SaveDeviceParameter(CDeviceParameter objDeviceParameter)
        {
            bool result = false;

            string path = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(path);
            string section = $"DEVICE";
            classINI.WriteValue(section, "strControllerIP", objDeviceParameter.strControllerIP);
            classINI.WriteValue(section, "strControllerPort", objDeviceParameter.strControllerPort.ToString());

            result = true;
            return result;
        }

        private bool SaveDeviceParameter()
        {
            bool result = false;

            string path = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(path);
            string section = $"DEVICE";
            classINI.WriteValue(section, "strControllerIP", m_objDeviceParameter.strControllerIP);
            classINI.WriteValue(section, "strControllerPort", m_objDeviceParameter.strControllerPort.ToString());

            result = true;
            return result;

        }
    }
}
