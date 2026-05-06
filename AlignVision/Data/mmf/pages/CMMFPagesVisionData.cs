using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;

namespace AlignVision
{
    internal sealed class CMMFPagesVisionData : MMVisionData_PageBase
    {
        public enum enumLanguage
        {
            LANGUAGE_KOREA = 0,
            LANGUAGE_CHINA = 1,
            LANGUAGE_ENGLISH = 2,
            LANGUAGE_VIETNAM = 3,
            LANGUAGE_FINAL = 10
        }
        /// <summary>
        /// Vị trí master tọa độ X
        /// </summary>
        public class CMasterPositionX
        {
            private CMMFPagesVisionData m_objVisionData = null;

            public double this[int iIndex]
            {
                get
                {
                    return m_objVisionData.DoubleData[100 + iIndex];
                }
                set
                {
                    m_objVisionData.DoubleData[100 + iIndex] = value;
                }
            }

            public CMasterPositionX(CMMFPagesVisionData objVisionData)
            {
                m_objVisionData = objVisionData;
            }
        }

        /// <summary>
        /// Vị trí master tọa độ Y
        /// </summary>
        public class CMasterPositionY
        {
            private CMMFPagesVisionData m_objVisionData = null;

            public double this[int iIndex]
            {
                get
                {
                    return m_objVisionData.DoubleData[102 + iIndex];
                }
                set
                {
                    m_objVisionData.DoubleData[102 + iIndex] = value;
                }
            }

            public CMasterPositionY(CMMFPagesVisionData objVisionData)
            {
                m_objVisionData = objVisionData;
            }
        }

        /// <summary>
        /// Vị trí master góc độ
        /// </summary>
        public class CMasterPositionAngle
        {
            private CMMFPagesVisionData m_objVisionData = null;

            public double this[int iIndex]
            {
                get
                {
                    return m_objVisionData.DoubleData[104 + iIndex];
                }
                set
                {
                    m_objVisionData.DoubleData[104 + iIndex] = value;
                }
            }

            public CMasterPositionAngle(CMMFPagesVisionData objVisionData)
            {
                m_objVisionData = objVisionData;
            }
        }

        public CMasterPositionX objMasterPositionX;

        public CMasterPositionY objMasterPositionY;

        public CMasterPositionAngle objMasterPositionAngle;

        public bool bTrigger
        {
            get
            {
                return base.BoolData[100];
            }
            set
            {
                base.BoolData[100] = value;
            }
        }

        public bool bLive
        {
            get
            {
                return base.BoolData[101];
            }
            set
            {
                base.BoolData[101] = value;
            }
        }

        public bool bLightOn
        {
            get
            {
                return base.BoolData[102];
            }
            set
            {
                base.BoolData[102] = value;
            }
        }

        public bool bShowDialogVisionLive
        {
            get
            {
                return base.BoolData[103];
            }
            set
            {
                base.BoolData[103] = value;
            }
        }

        public bool bSaveMasterPosition
        {
            get
            {
                return base.BoolData[104];
            }
            set
            {
                base.BoolData[104] = value;
            }
        }

        public bool bLogInRequest
        {
            get
            {
                return base.BoolData[105];
            }
            set
            {
                base.BoolData[105] = value;
            }
        }

        public bool bLogInReply
        {
            get
            {
                return base.BoolData[106];
            }
            set
            {
                base.BoolData[106] = value;
            }
        }

        public bool bCameraConnected
        {
            get
            {
                return base.BoolData[107];
            }
            set
            {
                base.BoolData[107] = value;
            }
        }

        public bool bHeartBeat
        {
            get
            {
                return base.BoolData[108];
            }
            set
            {
                base.BoolData[108] = value;
            }
        }

        public int iErrorCode
        {
            get
            {
                return base.IntData[100];
            }
            set
            {
                base.IntData[100] = value;
            }
        }

        public int iImageWidth
        {
            get
            {
                return base.IntData[101];
            }
            set
            {
                base.IntData[101] = value;
            }
        }

        public int iImageHeight
        {
            get
            {
                return base.IntData[102];
            }
            set
            {
                base.IntData[102] = value;
            }
        }

        public int iLogInResult
        {
            get
            {
                return base.IntData[103];
            }
            set
            {
                base.IntData[103] = value;
            }
        }

        public int iAuthorityLevel
        {
            get
            {
                return base.IntData[104];
            }
            set
            {
                base.IntData[104] = value;
            }
        }

        public int iProgramExitStatus
        {
            get
            {
                return base.IntData[105];
            }
            set
            {
                base.IntData[105] = value;
            }
        }

        public string strMachineRecipePPID
        {
            get
            {
                return base.StringData[100];
            }
            set
            {
                base.StringData[100] = value;
            }
        }

        public string strMachineRecipeName
        {
            get
            {
                return base.StringData[101];
            }
            set
            {
                base.StringData[101] = value;
            }
        }

        public string strVisionRecipePPID
        {
            get
            {
                return base.StringData[102];
            }
            set
            {
                base.StringData[102] = value;
            }
        }

        public string strVisionRecipeIndex
        {
            get
            {
                return base.StringData[103];
            }
            set
            {
                base.StringData[103] = value;
            }
        }

        public string strLoginID
        {
            get
            {
                return base.StringData[104];
            }
            set
            {
                base.StringData[104] = value;
            }
        }

        public string strLoginPassword
        {
            get
            {
                return base.StringData[105];
            }
            set
            {
                base.StringData[105] = value;
            }
        }

        public string strLoginName
        {
            get
            {
                return base.StringData[106];
            }
            set
            {
                base.StringData[106] = value;
            }
        }

        public CMMFPagesVisionData(MemoryMappedFile memMap, uint pageIndex, uint pageCount)
            : base(memMap, pageIndex, pageCount)
        {
            objMasterPositionX = new CMasterPositionX(this);
            objMasterPositionY = new CMasterPositionY(this);
            objMasterPositionAngle = new CMasterPositionAngle(this);
        }

        public void DefaultValue()
        {
            base.ByteData.Clear();
            base.BoolData.Clear();
            base.IntData.Clear();
            base.FloatData.Clear();
            base.DoubleData.Clear();
            base.StringData.Clear();
        }

        //public void SetVisionData(CDefine.structureVisionResult objVisionData)
        //{
        //    int idx = 0;
        //    int num = 0;
        //    int num2 = 0;
        //    try
        //    {
        //        iImageWidth = 0;
        //        iImageHeight = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(ex.Message + "->" + ex.StackTrace);
        //    }
        //    base.BoolData[idx] = objVisionData.bResult;
        //    base.StringData[num2++] = objVisionData.strEventTime;
        //    base.StringData[num2++] = objVisionData.strTactTime;
        //    for (int i = 0; i < 2; i++)
        //    {
        //        base.DoubleData[num++] = objVisionData.dPositionX[i];
        //        base.DoubleData[num++] = objVisionData.dPositionY[i];
        //        base.DoubleData[num++] = objVisionData.dPositionAngle[i];
        //        base.DoubleData[num++] = objVisionData.dScore[i];
        //    }
        //}

        //public void GetVisionData(out CDefine.structureVisionResult objVisionData)
        //{
        //    int idx = 0;
        //    int num = 0;
        //    int num2 = 0;
        //    objVisionData = new CDefine.structureVisionResult();
        //    try
        //    {
        //        if (0 < iImageWidth && 0 < iImageHeight)
        //        {
        //            byte[] value = base.ByteData.ToBytes(iImageWidth * iImageHeight);
        //            ImageConverter imageConverter = new ImageConverter();
        //            objVisionData.objInputImage = (Bitmap)imageConverter.ConvertFrom(value);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(ex.Message + "->" + ex.StackTrace);
        //    }
        //    objVisionData.bResult = base.BoolData[idx];
        //    objVisionData.strEventTime = base.StringData[num2++];
        //    objVisionData.strTactTime = base.StringData[num2++];
        //    for (int i = 0; i < 2; i++)
        //    {
        //        objVisionData.dPositionX[i] = base.DoubleData[num++];
        //        objVisionData.dPositionY[i] = base.DoubleData[num++];
        //        objVisionData.dPositionAngle[i] = base.DoubleData[num++];
        //        objVisionData.dScore[i] = base.DoubleData[num++];
        //    }
        //}
    }

}

