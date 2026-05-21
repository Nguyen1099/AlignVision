using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        private class ConfigInitializeSet
        {
            public Action Load { get; private set; }
            public Action Save { get; private set; }

            public ConfigInitializeSet(Action load, Action save)
            {
                Load = load;
                Save = save;
            }
        }

        /// <summary>
        /// System file path
        /// </summary>
        private string m_strCurrentPath = string.Empty;

        public bool Initialize()
        {
            bool result = false;
            CreatFolder(CDefine.DEF_ALIGN_RECIPE_PATH);
            CreatFolder(CDefine.DEF_ALIGN_REPORT_LOG_PATH);
            CreatFolder(CDefine.DEF_ALIGN_REPORT_IMAGE_PATH);

            m_strCurrentPath = Directory.GetCurrentDirectory();
            ClassINI objINI = new ClassINI(string.Format(@"{0}\{1}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI));

            var configInitializeSetList = new List<ConfigInitializeSet>()
            {
                new ConfigInitializeSet(() => LoadSystemParameter(), () => SaveSystemParameter()),
                new ConfigInitializeSet(() => LoadDeviceParameter(), () => SaveDeviceParameter()),
            };

            foreach (var item in configInitializeSetList)
            {
                item.Load?.Invoke();
            }

            foreach (var item in configInitializeSetList)
            {
                item.Save?.Invoke();
            }

            result = true;
            return result;
        }

        /// <summary>
        /// Creat folder if not exist
        /// </summary>
        /// <param name="folderPath"></param>
        private void CreatFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
