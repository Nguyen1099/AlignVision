using System;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        public class CLightControllerParameter : ICloneable
        {
            public enum enumType
            {
                TYPE_SOCKET,
                TYPE_SERIAL,
                TYPE_FINAL
            }

            public enum enumSerialPortParity
            {
                PARITY_NONE,
                PARITY_ODD,
                PARITY_EVEN,
                PARITY_MARK,
                PARITY_SPACE
            }

            public enum enumSerialPortStopBits
            {
                STOP_BITS_NONE,
                STOP_BITS_ONE,
                STOP_BITS_TWO,
                STOP_BITS_ONE_POINT_FIVE
            }

            public enum enumLIghtChannel
            {
                CHANNEL_1,
                CHANNEL_2,
                CHANNEL_3,
                CHANNEL_4,
                CHANNEL_FINAL
            }

            public enumType eType;

            public string strSocketIPAddress;

            public int iSocketPortNumber;

            public string strSerialPortName;

            public int iSerialPortBaudrate;

            public int iSerialPortDataBits;

            public enumSerialPortParity eParity;

            public enumSerialPortStopBits eStopBits;

            public int[] iIntensity = new int[Enum.GetValues(typeof(CDefine.enumLightChannel)).Length];

            public object Clone()
            {
                CLightControllerParameter cLightControllerParameter = new CLightControllerParameter();
                cLightControllerParameter.eType = eType;
                cLightControllerParameter.strSocketIPAddress = strSocketIPAddress;
                cLightControllerParameter.iSocketPortNumber = iSocketPortNumber;
                cLightControllerParameter.strSerialPortName = strSerialPortName;
                cLightControllerParameter.iSerialPortBaudrate = iSerialPortBaudrate;
                cLightControllerParameter.iSerialPortDataBits = iSerialPortDataBits;
                cLightControllerParameter.eParity = eParity;
                cLightControllerParameter.eStopBits = eStopBits;
                cLightControllerParameter.iIntensity = (int[])iIntensity.Clone();
                return cLightControllerParameter;
            }
        }

        private CLightControllerParameter m_objLightControllerParameter = new CLightControllerParameter();
        public CLightControllerParameter GetLightControllerParameter() => (CLightControllerParameter)m_objLightControllerParameter.Clone();
        public bool LoadLightControllerParameter()
        {
            bool result = false;
            string strSystemPath = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(strSystemPath);

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string sectionName = "LIGHT_CONTROLLER";
            m_objLightControllerParameter.eType = (CLightControllerParameter.enumType)classINI.GetInt32(sectionName, "eType", 1);
            m_objLightControllerParameter.strSocketIPAddress = classINI.GetString(sectionName, "strSocketIPAddress", "");
            m_objLightControllerParameter.iSocketPortNumber = classINI.GetInt32(sectionName, "iSocketPortNumber", 0);
            m_objLightControllerParameter.strSerialPortName = classINI.GetString(sectionName, "strSerialPortName", "COM26");
            m_objLightControllerParameter.iSerialPortBaudrate = classINI.GetInt32(sectionName, "iSerialPortBaudrate", 9600);
            m_objLightControllerParameter.iSerialPortDataBits = classINI.GetInt32(sectionName, "iSerialPortDataBits", 8);
            m_objLightControllerParameter.eParity = (CLightControllerParameter.enumSerialPortParity)classINI.GetInt32(sectionName, "eParity", 0);
            m_objLightControllerParameter.eStopBits = (CLightControllerParameter.enumSerialPortStopBits)classINI.GetInt32(sectionName, "eStopBits", 1);

            int countChannel = Enum.GetNames(typeof(CDefine.enumLightChannel)).Length;
            for (int j = 0; j < countChannel; j++)
            {
                string text = "CHANNEL_" + (CDefine.enumLightChannel)j;
                m_objLightControllerParameter.iIntensity[j] = classINIRecipe.GetInt32(sectionName, "iIntensity_" + text, 100);
            }

            result = true;
            return result;
        }
        private bool SaveLightControllerParameter()
        {
            bool result = false;
            string strSystemPath = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(strSystemPath);

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string sectionName = "LIGHT_CONTROLLER";
            classINI.WriteValue(sectionName, "eType", (int)m_objLightControllerParameter.eType);
            classINI.WriteValue(sectionName, "strSocketIPAddress", m_objLightControllerParameter.strSocketIPAddress);
            classINI.WriteValue(sectionName, "iSocketPortNumber", m_objLightControllerParameter.iSocketPortNumber);
            classINI.WriteValue(sectionName, "strSerialPortName", m_objLightControllerParameter.strSerialPortName);
            classINI.WriteValue(sectionName, "iSerialPortBaudrate", m_objLightControllerParameter.iSerialPortBaudrate);
            classINI.WriteValue(sectionName, "iSerialPortDataBits", m_objLightControllerParameter.iSerialPortDataBits);
            classINI.WriteValue(sectionName, "eParity", (int)m_objLightControllerParameter.eParity);
            classINI.WriteValue(sectionName, "eStopBits", (int)m_objLightControllerParameter.eStopBits);

            int countChannel = Enum.GetNames(typeof(CDefine.enumLightChannel)).Length;
            for (int j = 0; j < countChannel; j++)
            {
                string text = "CHANNEL_" + (CDefine.enumLightChannel)j;
                classINIRecipe.WriteValue(sectionName, "iIntensity" + text, m_objLightControllerParameter.iIntensity[j]);
                //classINI.WriteValue(sectionName, "iIntensity" + text, m_objLightControllerParameter.iIntensity[j]);
            }

            result = true;
            return result;
        }
        public bool SaveLightControllerParameter(CLightControllerParameter objLightControllerParameter)
        {
            bool result = false;
            string strSystemPath = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(strSystemPath);

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string sectionName = "LIGHT_CONTROLLER";
            classINI.WriteValue(sectionName, "eType", (int)objLightControllerParameter.eType);
            classINI.WriteValue(sectionName, "strSocketIPAddress", objLightControllerParameter.strSocketIPAddress);
            classINI.WriteValue(sectionName, "iSocketPortNumber", objLightControllerParameter.iSocketPortNumber);
            classINI.WriteValue(sectionName, "strSerialPortName", objLightControllerParameter.strSerialPortName);
            classINI.WriteValue(sectionName, "iSerialPortBaudrate", objLightControllerParameter.iSerialPortBaudrate);
            classINI.WriteValue(sectionName, "iSerialPortDataBits", objLightControllerParameter.iSerialPortDataBits);
            classINI.WriteValue(sectionName, "eParity", (int)objLightControllerParameter.eParity);
            classINI.WriteValue(sectionName, "eStopBits", (int)objLightControllerParameter.eStopBits);

            int countChannel = Enum.GetNames(typeof(CDefine.enumLightChannel)).Length;
            for (int i = 0; i < countChannel; i++)
            {
                string text = "CHANNEL_" + (CDefine.enumLightChannel)i;
                classINIRecipe.WriteValue(sectionName, "iIntensity" + text, objLightControllerParameter.iIntensity[i]);
                //classINI.WriteValue(sectionName, "iIntensity" + text, objLightControllerParameter.iIntensity[i]);
            }
            m_objLightControllerParameter = (CLightControllerParameter)objLightControllerParameter.Clone();

            result = true;
            return result;
        }

    }
}
