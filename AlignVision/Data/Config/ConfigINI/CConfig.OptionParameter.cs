using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        public class COptionParameter : ICloneable
        {
            public bool bImageSave;

            public bool bImageGraphicSave;

            /// <summary>
            /// Image save type
            /// </summary>
            public CDefine.enumImageSaveType eImageSaveType;

            /// <summary>
            /// Image storage period (days)
            /// </summary>
            public int iPeriodImage;

            /// <summary>
            /// Database storage period (days)
            /// </summary>
            public int iPeriodDatabase;

            /// <summary>
            /// Image save drive volume setting
            /// </summary>
            public int dImageSaveDriveVolume;

            /// <summary>
            /// Number of backups to save
            /// </summary>
            public int iBackupCount;

            /// <summary>
            /// Backup cycle days
            /// </summary>
            public int iBackupDay;

            public bool bLinkPlcRecipe;

            public bool bUseCenterLine;

            public int iCenterLineColorIndex;

            /// <summary>
            /// Manual mark window wait time.
            /// </summary>
            public int iManualMarkWaitTime;

            public COptionParameter()
            {
                bImageSave = false;
                bImageGraphicSave = false;
                eImageSaveType = CDefine.enumImageSaveType.TYPE_SAVE_ALL;
                iPeriodImage = 0;
                iPeriodDatabase = 0;
                dImageSaveDriveVolume = 0;
                iBackupCount = 0;
                iBackupDay = 0;
                bLinkPlcRecipe = false;
                bUseCenterLine = false;
                iCenterLineColorIndex = 0;
                iManualMarkWaitTime = 0;
            }
            public object Clone()
            {
                COptionParameter cOptionParameter = new COptionParameter();
                cOptionParameter.dImageSaveDriveVolume = dImageSaveDriveVolume;
                cOptionParameter.bImageSave = bImageSave;
                cOptionParameter.bImageGraphicSave = bImageGraphicSave;
                cOptionParameter.eImageSaveType = eImageSaveType;
                cOptionParameter.iPeriodImage = iPeriodImage;
                cOptionParameter.iPeriodDatabase = iPeriodDatabase;
                cOptionParameter.iBackupCount = iBackupCount;
                cOptionParameter.iBackupDay = iBackupDay;
                cOptionParameter.bLinkPlcRecipe = bLinkPlcRecipe;
                cOptionParameter.bUseCenterLine = bUseCenterLine;
                cOptionParameter.iCenterLineColorIndex = iCenterLineColorIndex;
                cOptionParameter.iManualMarkWaitTime = iManualMarkWaitTime;
                return cOptionParameter;
            }
        }

        private COptionParameter m_objOptionParameter = new COptionParameter();

        public COptionParameter GetOptionParameter() => (COptionParameter)m_objOptionParameter.Clone();

        public bool LoadOptionParameter()
        {
            bool result = false;
            string path = string.Format(@"{0}\{1}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(path);

            string section = $"OPTION";
            m_objOptionParameter.bImageSave             = classINI.GetBool(section, "bImageSave", false);
            m_objOptionParameter.bImageGraphicSave      = classINI.GetBool(section, "bImageGraphicSave", false);
            m_objOptionParameter.eImageSaveType         = (CDefine.enumImageSaveType)classINI.GetInt32(section, "eImageSaveType", (int)CDefine.enumImageSaveType.TYPE_SAVE_ALL);
            m_objOptionParameter.iPeriodImage           = classINI.GetInt32(section, "iPeriodImage", 30);
            m_objOptionParameter.iPeriodDatabase        = classINI.GetInt32(section, "iPeriodDatabase", 30);
            m_objOptionParameter.dImageSaveDriveVolume  = classINI.GetInt32(section, "dImageSaveDriveVolume", 80);
            m_objOptionParameter.iBackupCount           = classINI.GetInt32(section, "iBackupCount", 30);
            m_objOptionParameter.iBackupDay             = classINI.GetInt32(section, "iBackupDay", 3);
            m_objOptionParameter.bLinkPlcRecipe         = classINI.GetBool(section, "bLinkPlcRecipe", false);
            m_objOptionParameter.bUseCenterLine         = classINI.GetBool(section, "bUseCenterLine", false);
            m_objOptionParameter.iCenterLineColorIndex  = classINI.GetInt32(section, "iCenterLineColorIndex", 0);
            m_objOptionParameter.iManualMarkWaitTime    = classINI.GetInt32(section, "iManualMarkWaitTime", 30000);
            result = true;
            return result;
        }

        public bool SaveOptionParameter(COptionParameter objOptionParameter)
        {
            bool result = false;
            string path = string.Format(@"{0}\{1}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(path);

            string section = $"OPTION";
            classINI.WriteValue(section, "bImageSave", objOptionParameter.bImageSave);
            classINI.WriteValue(section, "bImageGraphicSave", objOptionParameter.bImageGraphicSave);
            classINI.WriteValue(section, "eImageSaveType", (int)objOptionParameter.eImageSaveType);
            classINI.WriteValue(section, "iPeriodImage", objOptionParameter.iPeriodImage);
            classINI.WriteValue(section, "iPeriodDatabase", objOptionParameter.iPeriodDatabase);
            classINI.WriteValue(section, "dImageSaveDriveVolume", objOptionParameter.dImageSaveDriveVolume);
            classINI.WriteValue(section, "iBackupCount", objOptionParameter.iBackupCount);
            classINI.WriteValue(section, "iBackupDay", objOptionParameter.iBackupDay);
            classINI.WriteValue(section, "bLinkPlcRecipe", objOptionParameter.bLinkPlcRecipe);
            classINI.WriteValue(section, "bUseCenterLine", objOptionParameter.bUseCenterLine);
            classINI.WriteValue(section, "iCenterLineColorIndex", objOptionParameter.iCenterLineColorIndex);
            classINI.WriteValue(section, "iManualMarkWaitTime", objOptionParameter.iManualMarkWaitTime);
            result = true;
            return result;
        }

        private bool SaveOptionParameter()
        {
            bool result = false;
            string path = string.Format(@"{0}\{1}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI);
            ClassINI classINI = new ClassINI(path);

            string section = $"OPTION";
            classINI.WriteValue(section, "bImageSave", m_objOptionParameter.bImageSave);
            classINI.WriteValue(section, "bImageGraphicSave", m_objOptionParameter.bImageGraphicSave);
            classINI.WriteValue(section, "eImageSaveType", (int)m_objOptionParameter.eImageSaveType);
            classINI.WriteValue(section, "iPeriodImage", m_objOptionParameter.iPeriodImage);
            classINI.WriteValue(section, "iPeriodDatabase", m_objOptionParameter.iPeriodDatabase);
            classINI.WriteValue(section, "dImageSaveDriveVolume", m_objOptionParameter.dImageSaveDriveVolume);
            classINI.WriteValue(section, "iBackupCount", m_objOptionParameter.iBackupCount);
            classINI.WriteValue(section, "iBackupDay", m_objOptionParameter.iBackupDay);
            classINI.WriteValue(section, "bLinkPlcRecipe", m_objOptionParameter.bLinkPlcRecipe);
            classINI.WriteValue(section, "bUseCenterLine", m_objOptionParameter.bUseCenterLine);
            classINI.WriteValue(section, "iCenterLineColorIndex", m_objOptionParameter.iCenterLineColorIndex);
            classINI.WriteValue(section, "iManualMarkWaitTime", m_objOptionParameter.iManualMarkWaitTime);
            result = true;

            return result;
        }
    }
}
