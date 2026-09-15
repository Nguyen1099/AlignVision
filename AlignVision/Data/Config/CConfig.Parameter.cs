using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        /// <summary>
        /// Cấu trúc thông tin công cụ Align
        /// </summary>
        public struct structureRecipeParameterAlignTool : ICloneable
        {
            /// <summary>
            /// Loại công cụ căn chỉnh
            /// </summary>
            public CDefine.enumAlignToolType eAlignToolType;

            /// <summary>
            /// Loại kết quả mẫu
            /// </summary>
            public CDefine.enumPatternResultType ePatternResultType;
            public int iDemandScore;

            public void Init()
            {
                this.eAlignToolType = CDefine.enumAlignToolType.PATTERN_ONLY;
                this.ePatternResultType = CDefine.enumPatternResultType.SEQUENTIAL_SEARCH;
                this.iDemandScore = 0;
            }

            public object Clone()
            {
                structureRecipeParameterAlignTool obj = new structureRecipeParameterAlignTool();
                obj.eAlignToolType = this.eAlignToolType;
                obj.ePatternResultType = this.ePatternResultType;
                obj.iDemandScore = this.iDemandScore;
                return obj;
            }
        }

        /// <summary>
        /// Cấu trúc thông tin vị trí Master
        /// </summary>
        public struct structureMasterPosition : ICloneable
        {
            public double dPositionX;
            public double dPositionY;
            public double dPositionT;

            public void Init()
            {
                this.dPositionX = 0.0;
                this.dPositionY = 0.0;
                this.dPositionT = 0.0;
            }

            public object Clone()
            {
                structureMasterPosition obj = new structureMasterPosition();
                obj.dPositionX = this.dPositionX;
                obj.dPositionY = this.dPositionY;
                obj.dPositionT = this.dPositionT;
                return obj;
            }
        }


        /// <summary>
        /// Cấu trúc thông tin giới hạn Align
        /// </summary>
        public struct structureAlignParameter : ICloneable
        {
            // XYT, UVW cần thiết chỉ sử dụng những gì cần
            public bool bUseAlignLimit;
            public double dAlignLimitX;
            public double dAlignLimitY;
            public double dAlignLimitT;
            public double dAlignLimitLX;
            public double dAlignLimitLY;
            public double dAlignLimitRX;
            public double dAlignLimitRY;
            public double dAlignToleranceX;
            public double dAlignToleranceY;
            public double dAlignToleranceT;
            public double dAlignDivisionToleranceT;
            public bool bUseAlignX;


            public void Init()
            {
                this.bUseAlignLimit = false;
                this.dAlignLimitX = 0.0;
                this.dAlignLimitY = 0.0;
                this.dAlignLimitT = 0.0;
                this.dAlignLimitLX = 0.0;
                this.dAlignLimitLY = 0.0;
                this.dAlignLimitRX = 0.0;
                this.dAlignLimitRY = 0.0;
                this.dAlignToleranceX = 0.0;
                this.dAlignToleranceY = 0.0;
                this.dAlignToleranceT = 0.0;
                this.dAlignDivisionToleranceT = 0.0;
                this.bUseAlignX = false;
            }

            public object Clone()
            {
                structureAlignParameter obj = new structureAlignParameter();
                obj.bUseAlignLimit = this.bUseAlignLimit;
                obj.dAlignLimitX = this.dAlignLimitX;
                obj.dAlignLimitY = this.dAlignLimitY;
                obj.dAlignLimitT = this.dAlignLimitT;
                obj.dAlignLimitLX = this.dAlignLimitLX;
                obj.dAlignLimitLY = this.dAlignLimitLY;
                obj.dAlignLimitRX = this.dAlignLimitRX;
                obj.dAlignLimitRY = this.dAlignLimitRY;
                obj.dAlignToleranceX = this.dAlignToleranceX;
                obj.dAlignToleranceY = this.dAlignToleranceY;
                obj.dAlignToleranceT = this.dAlignToleranceT;
                obj.dAlignDivisionToleranceT = this.dAlignDivisionToleranceT;
                obj.bUseAlignX = this.bUseAlignX;
                return obj;
            }
        }


    }
}
