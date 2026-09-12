using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        public class CAlignOptionParameter : ICloneable
        {
            /// <summary>
            /// Số lần thử lại
            /// </summary>
            public int iAlignRetryCount;

            /// <summary>
            /// Có sử dụng Retry Align khi gía trị out spec hay không
            /// </summary>
            public bool bUseRetryAlign;

            /// <summary>
            ///  Số lần thử lại khi mark NG
            /// </summary>
            public int iMarkRetryCount;

            /// <summary>
            /// Có sử dụng Retry Align khi mark NG hay không
            /// </summary>
            public bool bUseRetryAfterMarkNG;
            /// <summary>
            /// Thời gian trễ trigger
            /// </summary>
            public int iDelayTimeTrigger;
            /// <summary>
            /// Thời gian trễ đèn
            /// </summary>
            public int iDelayTimeLight;
            /// <summary>
            /// Thời gian trễ trigger khi thử lại
            /// </summary>
            public int iDelayTimeTriggerRetry;
            /// <summary>
            /// Độ trễ grab cho hiệu chuẩn
            /// </summary>
            public int iDelayTimeCalibration;
            /// <summary>
            /// Thời gian chờ camera (timeout)
            /// </summary>
            public int iCameraTimeOut;

            public CAlignOptionParameter()
            {
                this.iAlignRetryCount = 0;
                this.bUseRetryAlign = false;
                this.iMarkRetryCount = 0;
                this.bUseRetryAfterMarkNG = false;
                this.iDelayTimeTrigger = 0;
                this.iDelayTimeLight = 0;
                this.iDelayTimeTriggerRetry = 0;
                this.iDelayTimeCalibration = 0;
                this.iCameraTimeOut = 0;
            }
            public object Clone()
            {
                CAlignOptionParameter obj = new CAlignOptionParameter();
                obj.iAlignRetryCount = this.iAlignRetryCount;
                obj.bUseRetryAlign = this.bUseRetryAlign;
                obj.iMarkRetryCount = this.iMarkRetryCount;
                obj.bUseRetryAfterMarkNG = this.bUseRetryAfterMarkNG;
                obj.iDelayTimeTrigger = this.iDelayTimeTrigger;
                obj.iDelayTimeLight = this.iDelayTimeLight;
                obj.iDelayTimeTriggerRetry = this.iDelayTimeTriggerRetry;
                obj.iDelayTimeCalibration = this.iDelayTimeCalibration;
                obj.iCameraTimeOut = this.iCameraTimeOut;
                return obj;
            }
        }

        private CAlignOptionParameter m_objAlignOptionParameter = new CAlignOptionParameter();

        public CAlignOptionParameter GetAlignOptionParameter() => m_objAlignOptionParameter.Clone() as CAlignOptionParameter;

        public bool LoadAlignOptionParameter()
        {
            bool bReturn = false;

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string strSection = "AlignOptionParameter";
            m_objAlignOptionParameter.iAlignRetryCount = classINIRecipe.GetInt32(strSection, "iAlignRetryCount", 0);
            m_objAlignOptionParameter.bUseRetryAlign = classINIRecipe.GetBool(strSection, "bUseRetryAlign", false);
            m_objAlignOptionParameter.iMarkRetryCount = classINIRecipe.GetInt32(strSection, "iMarkRetryCount", 0);
            m_objAlignOptionParameter.bUseRetryAfterMarkNG = classINIRecipe.GetBool(strSection, "bUseRetryAfterMarkNG", false);
            m_objAlignOptionParameter.iDelayTimeTrigger = classINIRecipe.GetInt32(strSection, "iDelayTimeTrigger", 100);
            m_objAlignOptionParameter.iDelayTimeLight = classINIRecipe.GetInt32(strSection, "iDelayTimeLight", 25);
            m_objAlignOptionParameter.iDelayTimeTriggerRetry = classINIRecipe.GetInt32(strSection, "iDelayTimeTriggerRetry", 100);
            m_objAlignOptionParameter.iDelayTimeCalibration = classINIRecipe.GetInt32(strSection, "iDelayTimeCalibration", 1000);
            m_objAlignOptionParameter.iCameraTimeOut = classINIRecipe.GetInt32(strSection, "iCameraTimeOut", 8000);

            bReturn = true;
            return bReturn;
        }

        private bool SaveALignOptionParameter()
        {
            bool bReturn = false;
            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string strSection = "AlignOptionParameter";

            classINIRecipe.WriteValue(strSection, "iAlignRetryCount", m_objAlignOptionParameter.iAlignRetryCount);
            classINIRecipe.WriteValue(strSection, "bUseRetryAfterMarkNG", m_objAlignOptionParameter.bUseRetryAfterMarkNG);
            classINIRecipe.WriteValue(strSection, "iMarkRetryCount", m_objAlignOptionParameter.iMarkRetryCount);
            classINIRecipe.WriteValue(strSection, "bUseRetryAlign", m_objAlignOptionParameter.bUseRetryAlign);
            classINIRecipe.WriteValue(strSection, "iDelayTimeTrigger", m_objAlignOptionParameter.iDelayTimeTrigger);
            classINIRecipe.WriteValue(strSection, "iDelayTimeLight", m_objAlignOptionParameter.iDelayTimeLight);
            classINIRecipe.WriteValue(strSection, "iDelayTimeTriggerRetry", m_objAlignOptionParameter.iDelayTimeTriggerRetry);
            classINIRecipe.WriteValue(strSection, "iDelayTimeCalibration", m_objAlignOptionParameter.iDelayTimeCalibration);
            classINIRecipe.WriteValue(strSection, "iCameraTimeOut", m_objAlignOptionParameter.iCameraTimeOut);

            return bReturn;
        }

        /// <summary>
        /// Save Align Option Parameter
        /// </summary>
        /// <param name="ọbjAlignOptionParameter"></param>
        /// <returns></returns>
        public bool SaveAlignOptionParameter(CAlignOptionParameter ọbjAlignOptionParameter)
        {
            bool bReturn = false;
            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string strSection = "AlignOptionParameter";
            classINIRecipe.WriteValue(strSection, "iAlignRetryCount", ọbjAlignOptionParameter.iAlignRetryCount);
            classINIRecipe.WriteValue(strSection, "bUseRetryAfterMarkNG", ọbjAlignOptionParameter.bUseRetryAfterMarkNG);
            classINIRecipe.WriteValue(strSection, "iMarkRetryCount", m_objAlignOptionParameter.iMarkRetryCount);
            classINIRecipe.WriteValue(strSection, "bUseRetryAlign", ọbjAlignOptionParameter.bUseRetryAlign);
            classINIRecipe.WriteValue(strSection, "iDelayTimeTrigger", ọbjAlignOptionParameter.iDelayTimeTrigger);
            classINIRecipe.WriteValue(strSection, "iDelayTimeLight", ọbjAlignOptionParameter.iDelayTimeLight);
            classINIRecipe.WriteValue(strSection, "iDelayTimeTriggerRetry", ọbjAlignOptionParameter.iDelayTimeTriggerRetry);
            classINIRecipe.WriteValue(strSection, "iDelayTimeCalibration", ọbjAlignOptionParameter.iDelayTimeCalibration);
            classINIRecipe.WriteValue(strSection, "iCameraTimeOut", ọbjAlignOptionParameter.iCameraTimeOut);
            m_objAlignOptionParameter = ọbjAlignOptionParameter.Clone() as CAlignOptionParameter;

            bReturn = true;
            return bReturn;
        }
    }
}
