using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CDefine
    {
        public const string DEF_VISION_CONFIG_INI = "VisionConfig.ini";

        public const string DEF_VISION_CAMERA_INI = "VisionCamera.ini";

        public const string DEF_VISION_DEVICE_INI = "VisionDevice.ini";

        public const string DEF_DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";

        public const string DEF_ALIGN_RECIPE_PATH = "D:\\AlignRecipe";

        public const string DEF_ALIGN_REPORT_LOG_PATH = "D:\\AlignReport\\Logs";

        public const string DEF_ALIGN_REPORT_IMAGE_PATH = "D:\\AlignReport\\Images";

        #region Form
        public enum FormView
        {
            FORM_VIEW_MAIN = 0,
            FORM_VIEW_SETUP,
            FORM_VIEW_CONFIG,
            //FORM_VIEW_IO, 
            //FORM_VIEW_REPORT, 
            //FORM_VIEW_RESET, 
            FORM_VIEW_FINAL
        };

        public enum FormViewMain
        {
            FORM_VIEW_MAIN = 0,
            FORM_VIEW_MAIN_FINAL
        };

        public enum FormViewSetup
        {
            FORM_VIEW_SETUP_TEACH = 0,
            FORM_VIEW_SETUP_SETTING_CAMERA,
            FORM_VIEW_SETUP_CALIBRATION,
            FORM_VIEW_SETUP_FINAL
        };

        public enum FormViewConfig
        {
            FORM_VIEW_CONFIG_OPTION = 0,
            FORM_VIEW_CONFIG_FINAL
        };

        #endregion
        #region System Parameter
        public enum enumSimulationMode
        {
            SIMULATION_MODE_OFF = 0,
            SIMULATION_MODE_ON,
            SIMULATION_MODE_FINAL
        }

        public enum enumUserAuthorityLevel
        {
            USER_AUTHORITY_LEVEL_OPERATOR = 0,
            USER_AUTHORITY_LEVEL_ENGINEER,
            USER_AUTHORITY_LEVEL_MASTER,
            USER_AUTHORITY_LEVEL_FINAL
        }

        public enum enumLanguage
        {
            LANGUAGE_KOREA = 0,
            LANGUAGE_CHINA,
            LANGUAGE_ENGLISH,
            LANGUAGE_VIETNAM,
            LANGUAGE_FINAL
        }

        public enum enumRunMode
        {
            RUN_MODE_STOP = 0,
            RUN_MODE_START,
            RUN_MODE_FINAL
        }

        public enum enumImageSaveType
        {
            TYPE_SAVE_ALL = 0,
            TYPE_SAVE_OK,
            TYPE_SAVE_NG
        };

        public enum enumImageFormatType
        {
            TYPE_BMP = 0,
            TYPE_JPG
        };

        #endregion
        #region Light Controller
        public enum enumLightControllerType
        {
            LLIGHT = 0,
            VCC,
            LIGHT_CONTROLLER_FINAL
        }
        public enum enumLightChannel
        {
            LIGHT_MAIN_ALIGN_1_1 = 0,
            LIGHT_MAIN_ALIGN_1_2,
            //LIGHT_MAIN_ALIGN_2_1,
            //LIGHT_MAIN_ALIGN_2_2
        }
        //public enum enumLightController
        //{
        //    LIGHT_CONTROLLER_MAIN = 0,
        //}
        #endregion
        #region Camera Parameter
        public enum enumCamera
        {
            CAMERA_ALIGN_1 = 0,
            CAMERA_ALIGN_2
        }
        public enum enumStage
        {
            STAGE_MAIN_ALIGN_1,
            STAGE_MAIN_ALIGN_2
        }

        #endregion

    }
}
