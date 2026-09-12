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
        public class CStageParameter : ICloneable
        {
            /// <summary>
            /// Loại tool khi sử dụng (pattern / findline)
            /// </summary>
            public CDefine.enumAlignToolType eAlignToolType;

            /// <summary>
            /// Tham số căn chỉnh
            /// </summary>
            public structureAlignParameter objAlignParameter;
            /// <summary>
            /// Tham số cài đặt đường stage
            /// </summary>
            //public structureStageLineSettingParameter objStageLineSettingParameter;

            /// <summary>
            /// Trọng số Easy Align (căn trái, phải, giữa khi align)
            /// </summary>
            public double dWeightX;
            public double dWeightY;
            public double dWeightT;
            public double dAlignMethod;
            /// <summary>
            /// Khoảng cách di chuyển tối đa để hiệu chuẩn, nhập +- mm dựa trên tâm màn hình
            /// </summary>
            public double dCalibrationXYMaxDistance;
            /// <summary>
            /// Số lần phân chia khoảng cách di chuyển tối đa (tối đa 11, phải là số lẻ)
            /// </summary>
            public double dCalibrationXYSteps;
            /// <summary>
            /// Số bước di chuyển tối đa; do di chuyển theo hình vuông nên là bình phương số phân chia. Ví dụ 5 phân chia -> 25; được tính nội bộ
            /// </summary>
            public double dCalibrationXYMoveValidSteps;
            /// <summary>
            /// Góc quay tối đa để hiệu chuẩn, nhập +- độ dựa trên tâm màn hình
            /// </summary>
            public double dCalibrationTMaxRotation;
            /// <summary>
            /// Số lần phân chia góc quay tối đa (tối đa 101, phải là số lẻ)
            /// </summary>
            public double dCalibrationTSteps;
            /// <summary>
            /// Số bước quay tối đa; vì là di chuyển đơn giản nên số phân chia = số bước. Ví dụ 31 phân chia -> 31; tính nội bộ
            /// </summary>
            public double dCalibrationTMoveValidSteps;

            public CStageParameter()
            {
                this.eAlignToolType = CDefine.enumAlignToolType.PATTERN_ONLY;
                this.dWeightX = 0.0;
                this.dWeightY = 0.0;
                this.dWeightT = 0.0;
                this.dAlignMethod = 0.0;
                this.dCalibrationXYMaxDistance = 0.0;
                this.dCalibrationXYSteps = 0.0;
                this.dCalibrationXYMoveValidSteps = 0.0;
                this.dCalibrationTMaxRotation = 0.0;
                this.dCalibrationTSteps = 0.0;
                this.dCalibrationTMoveValidSteps = 0.0;
            }

            public object Clone()
            {
                CStageParameter obj = new CStageParameter();
                obj.eAlignToolType = this.eAlignToolType;
                obj.dWeightX = this.dWeightX;
                obj.dWeightY = this.dWeightY;
                obj.dWeightT = this.dWeightT;
                obj.dAlignMethod = this.dAlignMethod;
                obj.dCalibrationXYMaxDistance = this.dCalibrationXYMaxDistance;
                obj.dCalibrationXYSteps = this.dCalibrationXYSteps;
                obj.dCalibrationXYMoveValidSteps = this.dCalibrationXYMoveValidSteps;
                obj.dCalibrationTMaxRotation = this.dCalibrationTMaxRotation;
                obj.dCalibrationTSteps = this.dCalibrationTSteps;
                obj.dCalibrationTMoveValidSteps = this.dCalibrationTMoveValidSteps;

                return obj;
            }
        }

        private CStageParameter[] m_objStageParameter = new CStageParameter[Enum.GetNames(typeof(CDefine.enumStage)).Length];

        public CStageParameter GetStageParameter(CDefine.enumStage index) => (CStageParameter)m_objStageParameter[(int)index].Clone();

        /// <summary>
        /// Load stage parameters from the INI file
        /// </summary>
        /// <returns></returns>
        public bool LoadStageParameter()
        {
            bool bReturn = false;

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            for (int iLoopCount = 0; iLoopCount < m_objStageParameter.Length; iLoopCount++)
            {
                if (m_objStageParameter[iLoopCount] == null)
                {
                   m_objStageParameter[iLoopCount] = new CStageParameter();
                }

                string strSection = ((CDefine.enumStage)iLoopCount).ToString();

                m_objStageParameter[iLoopCount].eAlignToolType = (CDefine.enumAlignToolType)classINIRecipe.GetInt32(strSection, "eAlignType", (int)CDefine.enumAlignToolType.PATTERN_ONLY);
                // tham số căn chỉnh
                m_objStageParameter[iLoopCount].objAlignParameter.bUseAlignLimit = classINIRecipe.GetBool(strSection, "objAlignParameter.bUseAlignLimit", false);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignLimitX = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignLimitX", 5.0);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignLimitY = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignLimitY", 5.0);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignLimitT = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignLimitT", 5.0);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignToleranceX = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignToleranceX", 0.005);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignToleranceY = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignToleranceY", 0.005);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignToleranceT = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignToleranceT", 0.005);
                m_objStageParameter[iLoopCount].objAlignParameter.dAlignDivisionToleranceT = classINIRecipe.GetDouble(strSection, "objAlignParameter.dAlignDivisionToleranceT", 0.005);
                m_objStageParameter[iLoopCount].objAlignParameter.bUseAlignX = classINIRecipe.GetBool(strSection, "objAlignParameter.bUseAlignX", false);

                m_objStageParameter[iLoopCount].dWeightX = classINIRecipe.GetDouble(strSection, "dWeightX", 1.0);
                m_objStageParameter[iLoopCount].dWeightY = classINIRecipe.GetDouble(strSection, "dWeightY", 1.0);
                m_objStageParameter[iLoopCount].dWeightT = classINIRecipe.GetDouble(strSection, "dWeightT", 1.0);
                m_objStageParameter[iLoopCount].dAlignMethod = classINIRecipe.GetDouble(strSection, "dAlignMethod", 4.0);

                // Calibration parameters
                m_objStageParameter[iLoopCount].dCalibrationXYMaxDistance = classINIRecipe.GetDouble(strSection, "dCalibrationXYMaxDistance", 2.0);
                m_objStageParameter[iLoopCount].dCalibrationXYSteps = classINIRecipe.GetDouble(strSection, "dCalibrationXYSteps", 5.0);
                m_objStageParameter[iLoopCount].dCalibrationXYMoveValidSteps = classINIRecipe.GetDouble(strSection, "dCalibrationXYMoveValidSteps", 25.0);
                m_objStageParameter[iLoopCount].dCalibrationTMaxRotation = classINIRecipe.GetDouble(strSection, "dCalibrationTMaxRotation", 1.0);
                m_objStageParameter[iLoopCount].dCalibrationTSteps = classINIRecipe.GetDouble(strSection, "dCalibrationTSteps", 31.0);
                m_objStageParameter[iLoopCount].dCalibrationTMoveValidSteps = classINIRecipe.GetDouble(strSection, "dCalibrationTMoveValidSteps", 31.0);

                // 스테이지 평탄 라인 파라미터
                //m_objStageParameter[iLoopCount].objStageLineSettingParameter.iColorIndex = classINIRecipe.GetInt32(strSection, "objStageLineSettingParameter.iColorIndex", 1);
                //m_objStageParameter[iLoopCount].objStageLineSettingParameter.dLineThickness = classINIRecipe.GetDouble(strSection, "objStageLineSettingParameter.dLineThickness", 1.0);
                //m_objStageParameter[iLoopCount].objStageLineSettingParameter.dPositionWidth = classINIRecipe.GetDouble(strSection, "objStageLineSettingParameter.dPositionWidth", 1000.0);
                //m_objStageParameter[iLoopCount].objStageLineSettingParameter.dPositionHeight = classINIRecipe.GetDouble(strSection, "objStageLineSettingParameter.dPositionHeight", 1000.0);
            }

            bReturn = true;
            return bReturn;
        }

        /// <summary>
        /// Save stage parameters to the INI file
        /// </summary>
        /// <returns></returns>
        private bool SaveStageParameter()
        {
            bool bReturn = false;
            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            for (int iLoopCount = 0; iLoopCount < m_objStageParameter.Length; iLoopCount++)
            {
                string strSection = ((CDefine.enumStage)iLoopCount).ToString();

                classINIRecipe.WriteValue(strSection, "eAlignType", (int)m_objStageParameter[iLoopCount].eAlignToolType);
                // Align parameter
                classINIRecipe.WriteValue(strSection, "objAlignParameter.bUseAlignLimit", m_objStageParameter[iLoopCount].objAlignParameter.bUseAlignLimit);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignLimitX", m_objStageParameter[iLoopCount].objAlignParameter.dAlignLimitX);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignLimitY", m_objStageParameter[iLoopCount].objAlignParameter.dAlignLimitY);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignLimitT", m_objStageParameter[iLoopCount].objAlignParameter.dAlignLimitT);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignToleranceX", m_objStageParameter[iLoopCount].objAlignParameter.dAlignToleranceX);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignToleranceY", m_objStageParameter[iLoopCount].objAlignParameter.dAlignToleranceY);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignToleranceT", m_objStageParameter[iLoopCount].objAlignParameter.dAlignToleranceT);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignDivisionToleranceT", m_objStageParameter[iLoopCount].objAlignParameter.dAlignDivisionToleranceT);
                classINIRecipe.WriteValue(strSection, "objAlignParameter.bUseAlignX", m_objStageParameter[iLoopCount].objAlignParameter.bUseAlignX);

                // Calibration
                classINIRecipe.WriteValue(strSection, "dWeightX", m_objStageParameter[iLoopCount].dWeightX);
                classINIRecipe.WriteValue(strSection, "dWeightY", m_objStageParameter[iLoopCount].dWeightY);
                classINIRecipe.WriteValue(strSection, "dWeightT", m_objStageParameter[iLoopCount].dWeightT);
                classINIRecipe.WriteValue(strSection, "dAlignMethod", m_objStageParameter[iLoopCount].dAlignMethod);
                classINIRecipe.WriteValue(strSection, "dCalibrationXYMaxDistance", m_objStageParameter[iLoopCount].dCalibrationXYMaxDistance);
                classINIRecipe.WriteValue(strSection, "dCalibrationXYSteps", m_objStageParameter[iLoopCount].dCalibrationXYSteps);
                classINIRecipe.WriteValue(strSection, "dCalibrationXYMoveValidSteps", m_objStageParameter[iLoopCount].dCalibrationXYMoveValidSteps);
                classINIRecipe.WriteValue(strSection, "dCalibrationTMaxRotation", m_objStageParameter[iLoopCount].dCalibrationTMaxRotation);
                classINIRecipe.WriteValue(strSection, "dCalibrationTSteps", m_objStageParameter[iLoopCount].dCalibrationTSteps);
                classINIRecipe.WriteValue(strSection, "dCalibrationTMoveValidSteps", m_objStageParameter[iLoopCount].dCalibrationTMoveValidSteps);

                // Stage Flatness Line Parameters
                //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.iColorIndex", m_objStageParameter[iLoopCount].objStageLineSettingParameter.iColorIndex);
                //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.dLineThickness", m_objStageParameter[iLoopCount].objStageLineSettingParameter.dLineThickness);
                //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.dPositionWidth", m_objStageParameter[iLoopCount].objStageLineSettingParameter.dPositionWidth);
                //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.dPositionHeight", m_objStageParameter[iLoopCount].objStageLineSettingParameter.dPositionHeight);
            }

            bReturn = true;
            return bReturn;
        }

        /// <summary>
        /// Save stage parameters to the INI file for a specific stage index
        /// </summary>
        /// <param name="iStageIndex"></param>
        /// <param name="objStageParameter"></param>
        /// <returns></returns>
        public bool SaveStageParameter(int iStageIndex, CStageParameter objStageParameter)
        {
            bool bReturn = false;

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string strSection = ((CDefine.enumStage)iStageIndex).ToString();
            var varParameterOrigin = m_objStageParameter[iStageIndex];

            classINIRecipe.WriteValue(strSection, "eAlignType", (int)objStageParameter.eAlignToolType);
            // Align parameter
            classINIRecipe.WriteValue(strSection, "objAlignParameter.bUseAlignLimit", objStageParameter.objAlignParameter.bUseAlignLimit);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.bUseAlignX", objStageParameter.objAlignParameter.bUseAlignX);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignLimitX", objStageParameter.objAlignParameter.dAlignLimitX);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignLimitY", objStageParameter.objAlignParameter.dAlignLimitY);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignLimitT", objStageParameter.objAlignParameter.dAlignLimitT);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignToleranceX", objStageParameter.objAlignParameter.dAlignToleranceX);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignToleranceY", objStageParameter.objAlignParameter.dAlignToleranceY);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignToleranceT", objStageParameter.objAlignParameter.dAlignToleranceT);
            classINIRecipe.WriteValue(strSection, "objAlignParameter.dAlignDivisionToleranceT", objStageParameter.objAlignParameter.dAlignDivisionToleranceT);

            classINIRecipe.WriteValue(strSection, "dWeightX", objStageParameter.dWeightX);
            classINIRecipe.WriteValue(strSection, "dWeightY", objStageParameter.dWeightY);
            classINIRecipe.WriteValue(strSection, "dWeightT", objStageParameter.dWeightT);
            classINIRecipe.WriteValue(strSection, "dAlignMethod", objStageParameter.dAlignMethod);

            //Calibration
            classINIRecipe.WriteValue(strSection, "dCalibrationXYMaxDistance", objStageParameter.dCalibrationXYMaxDistance);
            classINIRecipe.WriteValue(strSection, "dCalibrationXYSteps", objStageParameter.dCalibrationXYSteps);
            classINIRecipe.WriteValue(strSection, "dCalibrationXYMoveValidSteps", objStageParameter.dCalibrationXYMoveValidSteps);
            classINIRecipe.WriteValue(strSection, "dCalibrationTMaxRotation", objStageParameter.dCalibrationTMaxRotation);
            classINIRecipe.WriteValue(strSection, "dCalibrationTSteps", objStageParameter.dCalibrationTSteps);
            classINIRecipe.WriteValue(strSection, "dCalibrationTMoveValidSteps", objStageParameter.dCalibrationTMoveValidSteps);

            // Stage Flatness Line Parameters
            //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.iColorIndex", objStageParameter.objStageLineSettingParameter.iColorIndex);
            //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.dLineThickness", objStageParameter.objStageLineSettingParameter.dLineThickness);
            //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.dPositionWidth", objStageParameter.objStageLineSettingParameter.dPositionWidth);
            //classINIRecipe.WriteValue(strSection, "objStageLineSettingParameter.dPositionHeight", objStageParameter.objStageLineSettingParameter.dPositionHeight);
            m_objStageParameter[iStageIndex] = (CStageParameter)objStageParameter.Clone();

            bReturn = true;
            return bReturn;
        }
    }
}
