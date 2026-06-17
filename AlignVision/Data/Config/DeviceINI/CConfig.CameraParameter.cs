using System;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        public class CCameraParameter : ICloneable
        {
            public struct structureCameraConfig
            {
                public bool bReverseX;

                public bool bReverseY;

                public double dGain;

                public double dExposureTime;

                public double dGamma;

                public double dDigitalShift;

                public double dFrameRate;
            }

            public int iIndex;

            public string strCameraSerialNumber;

            public string strCameraIP;

            public int iCameraWidth;

            public int iCameraHeight;

            public structureCameraConfig objCameraConfig = default(structureCameraConfig);

            public object Clone()
            {
                CCameraParameter cCameraParameter = new CCameraParameter();
                cCameraParameter.iIndex = iIndex;
                cCameraParameter.strCameraSerialNumber = strCameraSerialNumber;
                cCameraParameter.strCameraIP = strCameraIP;
                cCameraParameter.iCameraWidth = iCameraWidth;
                cCameraParameter.iCameraHeight = iCameraHeight;
                cCameraParameter.objCameraConfig.bReverseX = objCameraConfig.bReverseX;
                cCameraParameter.objCameraConfig.bReverseY = objCameraConfig.bReverseY;
                cCameraParameter.objCameraConfig.dGain = objCameraConfig.dGain;
                cCameraParameter.objCameraConfig.dExposureTime = objCameraConfig.dExposureTime;
                cCameraParameter.objCameraConfig.dGamma = objCameraConfig.dGamma;
                cCameraParameter.objCameraConfig.dDigitalShift = objCameraConfig.dDigitalShift;
                cCameraParameter.objCameraConfig.dFrameRate = objCameraConfig.dFrameRate;
                return cCameraParameter;
            }
        }
        private CCameraParameter[] m_objCameraParameter = new CCameraParameter[Enum.GetNames(typeof(CDefine.enumCamera)).Length];
        public CCameraParameter GetCameraParameter(CDefine.enumCamera index) => (CCameraParameter)m_objCameraParameter[(int)index].Clone();

        public bool LoadCameraParameter()
        {
            bool result = false;
            string strSystemPath = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(strSystemPath);

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            int count = Enum.GetNames(typeof(CDefine.enumCamera)).Length;
            for (int i = 0; i < count; i++)
            {
                if (m_objCameraParameter[i] == null)
                {
                    m_objCameraParameter[i] = new CCameraParameter();
                }

                m_objCameraParameter[i].strCameraIP = classINI.GetString("CAMERA", $"strCameraIP_{i}", "127.0.0.1");

                string sectionName = ((CDefine.enumCamera)i).ToString();
                m_objCameraParameter[i].iIndex = classINIRecipe.GetInt32(sectionName, "iIndex", i);
                m_objCameraParameter[i].strCameraSerialNumber = classINIRecipe.GetString(sectionName, "strCameraSerialNumber", "123");
                m_objCameraParameter[i].iCameraWidth = classINIRecipe.GetInt32(sectionName, "iCameraWidth", 3840);
                m_objCameraParameter[i].iCameraHeight = classINIRecipe.GetInt32(sectionName, "iCameraHeight", 2748);
                m_objCameraParameter[i].objCameraConfig.bReverseX = classINIRecipe.GetBool(sectionName, "bReverseX", bValue: false);
                m_objCameraParameter[i].objCameraConfig.bReverseY = classINIRecipe.GetBool(sectionName, "bReverseY", bValue: false);
                m_objCameraParameter[i].objCameraConfig.dExposureTime = classINIRecipe.GetDouble(sectionName, "dExposureTime", 10000.0);
                m_objCameraParameter[i].objCameraConfig.dGain = classINIRecipe.GetDouble(sectionName, "dGain", 1.0);
                m_objCameraParameter[i].objCameraConfig.dGamma = classINIRecipe.GetDouble(sectionName, "dGamma", 0.0);
                m_objCameraParameter[i].objCameraConfig.dDigitalShift = classINIRecipe.GetDouble(sectionName, "dDigitalShift", 0.0);
                m_objCameraParameter[i].objCameraConfig.dFrameRate = classINIRecipe.GetDouble(sectionName, "dFrameRate", 10.0);
            }
            result = true;
            return result;
        }
        private bool SaveCameraParameter()
        {
            bool result = false;
            string strSystemPath = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(strSystemPath);

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            int count = Enum.GetNames(typeof(CDefine.enumCamera)).Length;
            for (int i = 0; i < count; i++)
            {
                classINI.WriteValue("CAMERA", $"strCameraIP_{i}", m_objCameraParameter[i].strCameraIP);

                string sectionName = ((CDefine.enumCamera)i).ToString();
                classINIRecipe.WriteValue(sectionName, "iIndex", m_objCameraParameter[i].iIndex);
                classINIRecipe.WriteValue(sectionName, "strCameraSerialNumber", m_objCameraParameter[i].strCameraSerialNumber);
                classINIRecipe.WriteValue(sectionName, "iCameraWidth", m_objCameraParameter[i].iCameraWidth);
                classINIRecipe.WriteValue(sectionName, "iCameraHeight", m_objCameraParameter[i].iCameraHeight);
                classINIRecipe.WriteValue(sectionName, "bReverseX", m_objCameraParameter[i].objCameraConfig.bReverseX);
                classINIRecipe.WriteValue(sectionName, "bReverseY", m_objCameraParameter[i].objCameraConfig.bReverseY);
                classINIRecipe.WriteValue(sectionName, "dExposureTime", m_objCameraParameter[i].objCameraConfig.dExposureTime);
                classINIRecipe.WriteValue(sectionName, "dGain", m_objCameraParameter[i].objCameraConfig.dGain);
                classINIRecipe.WriteValue(sectionName, "dGamma", m_objCameraParameter[i].objCameraConfig.dGamma);
                classINIRecipe.WriteValue(sectionName, "dDigitalShift", m_objCameraParameter[i].objCameraConfig.dDigitalShift);
                classINIRecipe.WriteValue(sectionName, "dFrameRate", m_objCameraParameter[i].objCameraConfig.dFrameRate);
            }
            result = true;
            return result;
        }

        public bool SaveCameraParameter(CDefine.enumCamera eCamera, CCameraParameter objCameraParameter)
        {
            bool result = false;
            string strSystemPath = string.Format(@"{0:S}\{1:S}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(strSystemPath);

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            classINI.WriteValue("CAMERA", $"strCameraIP_{(int)eCamera}", objCameraParameter.strCameraIP);

            string sectionName = eCamera.ToString();
            classINIRecipe.WriteValue(sectionName, "iIndex", objCameraParameter.iIndex);
            classINIRecipe.WriteValue(sectionName, "strCameraSerialNumber", objCameraParameter.strCameraSerialNumber);
            classINIRecipe.WriteValue(sectionName, "iCameraWidth", objCameraParameter.iCameraWidth);
            classINIRecipe.WriteValue(sectionName, "iCameraHeight", objCameraParameter.iCameraHeight);
            classINIRecipe.WriteValue(sectionName, "bReverseX", objCameraParameter.objCameraConfig.bReverseX);
            classINIRecipe.WriteValue(sectionName, "bReverseY", objCameraParameter.objCameraConfig.bReverseY);
            classINIRecipe.WriteValue(sectionName, "dExposureTime", objCameraParameter.objCameraConfig.dExposureTime);
            classINIRecipe.WriteValue(sectionName, "dGain", objCameraParameter.objCameraConfig.dGain);
            classINIRecipe.WriteValue(sectionName, "dGamma", objCameraParameter.objCameraConfig.dGamma);
            classINIRecipe.WriteValue(sectionName, "dDigitalShift", objCameraParameter.objCameraConfig.dDigitalShift);  
            classINIRecipe.WriteValue(sectionName, "dFrameRate", objCameraParameter.objCameraConfig.dFrameRate);
            m_objCameraParameter[(int)eCamera] = (CCameraParameter)objCameraParameter.Clone();

            result = true;
            return result;
        }

    }
}
