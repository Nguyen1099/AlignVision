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
            FORM_VIEW_SETUP_SETTING_CAMERA = 0, 
            FORM_VIEW_SETUP_CALIBRATION, 
            FORM_VIEW_SETUP_TEACH, 
            //FORM_VIEW_SIMULATION, 
            FORM_VIEW_SETUP_FINAL
        };

        public enum FormViewConfig
        {
            FORM_VIEW_CONFIG_OPTION = 0,
            FORM_VIEW_CONFIG_FINAL
        };

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
