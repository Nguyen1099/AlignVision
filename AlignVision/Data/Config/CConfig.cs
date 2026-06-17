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

        private string m_strRecipePath = string.Empty;

        public bool Initialize()
        {
            bool result = false;
            CreatFolder(CDefine.DEF_ALIGN_RECIPE_PATH);
            CreatFolder(CDefine.DEF_ALIGN_REPORT_LOG_PATH);
            CreatFolder(CDefine.DEF_ALIGN_REPORT_IMAGE_PATH);

            m_strCurrentPath = Directory.GetCurrentDirectory();
            ClassINI objINI = new ClassINI(string.Format(@"{0}\{1}", m_strCurrentPath, CDefine.DEF_VISION_CONFIG_INI));
            m_strRecipePath = string.Format(@"{0}\{1}", CDefine.DEF_ALIGN_RECIPE_PATH, objINI.GetString("SYSTEM", "strBootRecipe", "1000"));
            CreatFolder(m_strRecipePath);

            var configInitializeSetList = new List<ConfigInitializeSet>()
            {
                new ConfigInitializeSet(() => LoadSystemParameter(), () => SaveSystemParameter()), 
                new ConfigInitializeSet(() => LoadRecipeParameter(), () => SaveRecipeParameter()),
                new ConfigInitializeSet(() => LoadOptionParameter(), () => SaveOptionParameter()),
                new ConfigInitializeSet(() => LoadDeviceParameter(), () => SaveDeviceParameter()),

                new ConfigInitializeSet(() => LoadCameraParameter(), () => SaveCameraParameter()),
                new ConfigInitializeSet(() => LoadLightControllerParameter(), () => SaveLightControllerParameter()),
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
