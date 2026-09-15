using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignVision
{
    public sealed partial class CConfig
    {
        /// <summary>
        /// Tham số recipe
        /// </summary>
        public class CRecipeParameter : ICloneable
        {
            /// <summary>
            /// Vị trí chuẩn
            /// Danh sách động (số sản phẩm trong khay * số mark cần tìm trên mỗi sản phẩm)           
            /// </summary>
            public List<structureMasterPosition> objListMasterPosition;

            /// <summary>
            /// Tham số tool căn chỉnh
            /// Danh sách động (số mark cần tìm)
            /// </summary>
            public List<structureRecipeParameterAlignTool> objListAlignTool;

            /// <summary>
            /// Số lượng mark trên mỗi sản phẩm
            /// </summary>
            // 1 camera có 4 mark: 2 mark pảttern + 2 mark calibration
            public int iProductMarkCount = 4;

            public void Init()
            {
                objListMasterPosition = new List<structureMasterPosition>();
                objListAlignTool = new List<structureRecipeParameterAlignTool>();
                iProductMarkCount = 0;
            }

            public object Clone()
            {
                CRecipeParameter obj = new CRecipeParameter();

                obj.objListAlignTool = new List<structureRecipeParameterAlignTool>();
                for (int iLoopList = 0; iLoopList < this.objListAlignTool.Count; iLoopList++)
                {
                    structureRecipeParameterAlignTool objAlignTool = new structureRecipeParameterAlignTool();
                    objAlignTool = (structureRecipeParameterAlignTool)this.objListAlignTool[iLoopList].Clone();
                    obj.objListAlignTool.Add(objAlignTool);
                }
                obj.objListMasterPosition = new List<structureMasterPosition>();
                for (int iLoopList = 0; iLoopList < this.objListMasterPosition.Count; iLoopList++)
                {
                    structureMasterPosition objMasterPosition = new structureMasterPosition();
                    objMasterPosition = (structureMasterPosition)this.objListMasterPosition[iLoopList].Clone();
                    obj.objListMasterPosition.Add(objMasterPosition);
                }
                obj.iProductMarkCount = this.iProductMarkCount;
                return obj;
            }
        }

        private CRecipeParameter[] m_objRecipeParameter = new CRecipeParameter[Enum.GetNames(typeof(CDefine.enumCamera)).Length];

        public CRecipeParameter GetRecipeParameter(CDefine.enumCamera eCameraIndex) => m_objRecipeParameter[(int)eCameraIndex].Clone() as CRecipeParameter;

        /// <summary>
        /// Load recipe parameter from ini file
        /// </summary>
        /// <returns></returns>
        public bool LoadRecipeParameter()
        {
            bool bResult = false;
            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            for (int i = 0; i < Enum.GetNames(typeof(CDefine.enumCamera)).Length; i++)
            {
                if (m_objRecipeParameter[i] == null)
                {
                    m_objRecipeParameter[i] = new CRecipeParameter();
                    m_objRecipeParameter[i].Init();
                }

                string sectionName = ((CDefine.enumCamera)i).ToString();
                m_objRecipeParameter[i].iProductMarkCount = classINIRecipe.GetInt32(sectionName, "ProductMarkCount", 4);

                m_objRecipeParameter[i].objListMasterPosition.Clear();
                for (int iLoopMarkCount = 0; iLoopMarkCount < m_objRecipeParameter[i].iProductMarkCount; iLoopMarkCount++)
                {
                    structureMasterPosition objMasterPosition = new structureMasterPosition();
                    objMasterPosition.Init();
                    objMasterPosition.dPositionX = classINIRecipe.GetDouble(sectionName, string.Format("objMasterPosition[{0}].dPositionX", iLoopMarkCount), 0.0);
                    objMasterPosition.dPositionY = classINIRecipe.GetDouble(sectionName, string.Format("objMasterPosition[{0}].dPositionY", iLoopMarkCount), 0.0);
                    objMasterPosition.dPositionT = classINIRecipe.GetDouble(sectionName, string.Format("objMasterPosition[{0}].dPositionT", iLoopMarkCount), 0.0);
                    m_objRecipeParameter[i].objListMasterPosition.Add(objMasterPosition);
                }

                m_objRecipeParameter[i].objListAlignTool.Clear();
                for (int iLoopMarkCount = 0; iLoopMarkCount < m_objRecipeParameter[i].iProductMarkCount; iLoopMarkCount++)
                {
                    structureRecipeParameterAlignTool objAlignTool = new structureRecipeParameterAlignTool();
                    objAlignTool.Init();
                    objAlignTool.eAlignToolType = (CDefine.enumAlignToolType)classINIRecipe.GetInt32(sectionName, string.Format("objListAlignTool.eAlignToolType[{0}]", iLoopMarkCount), 0);
                    objAlignTool.ePatternResultType = (CDefine.enumPatternResultType)classINIRecipe.GetInt32(sectionName, string.Format("objListAlignTool.ePatternResultType[{0}]", iLoopMarkCount), 0);
                    objAlignTool.iDemandScore = classINIRecipe.GetInt32(sectionName, string.Format("objListAlignTool.iDemandScore[{0}]", iLoopMarkCount), 0);
                    m_objRecipeParameter[i].objListAlignTool.Add(objAlignTool);
                }
            }

            bResult = true;
            return bResult;
        }

        /// <summary>
        /// Save recipe parameter to ini file
        /// </summary>
        /// <returns></returns>
        private bool SaveRecipeParameter()
        {
            bool bResult = false;
            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            for (int i = 0; i < Enum.GetNames(typeof(CDefine.enumCamera)).Length; i++)
            {
                string strSection = ((CDefine.enumCamera)i).ToString();

                classINIRecipe.WriteValue(strSection, "iProductMarkCount", m_objRecipeParameter[i].iProductMarkCount);
                try
                {
                    for (int iLoopMarkCount = 0; iLoopMarkCount < m_objRecipeParameter[i].objListMasterPosition.Count; iLoopMarkCount++)
                    {
                        classINIRecipe.WriteValue(strSection, string.Format("objMasterPosition[{0}].dPositionX", iLoopMarkCount), m_objRecipeParameter[i].objListMasterPosition[iLoopMarkCount].dPositionX);
                        classINIRecipe.WriteValue(strSection, string.Format("objMasterPosition[{0}].dPositionY", iLoopMarkCount), m_objRecipeParameter[i].objListMasterPosition[iLoopMarkCount].dPositionY);
                        classINIRecipe.WriteValue(strSection, string.Format("objMasterPosition[{0}].dPositionT", iLoopMarkCount), m_objRecipeParameter[i].objListMasterPosition[iLoopMarkCount].dPositionT);
                    }

                    for (int iLoopMarkCount = 0; iLoopMarkCount < m_objRecipeParameter[i].objListAlignTool.Count; iLoopMarkCount++)
                    {
                        classINIRecipe.WriteValue(strSection, string.Format("objListAlignTool.eAlignToolType[{0}]", iLoopMarkCount), (int)m_objRecipeParameter[i].objListAlignTool[iLoopMarkCount].eAlignToolType);
                        classINIRecipe.WriteValue(strSection, string.Format("objListAlignTool.ePatternResultType[{0}]", iLoopMarkCount), (int)m_objRecipeParameter[i].objListAlignTool[iLoopMarkCount].ePatternResultType);
                        classINIRecipe.WriteValue(strSection, string.Format("objListAlignTool.iDemandScore[{0}]", iLoopMarkCount), m_objRecipeParameter[i].objListAlignTool[iLoopMarkCount].iDemandScore);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error saving recipe parameter: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            bResult = true;
            return bResult;
        }

        public bool SaveRecipeParameter(CDefine.enumCamera eCameraIndex, CRecipeParameter objRecipeParameter)
        {
            bool bResult = false;

            string strRecipePath = string.Format(@"{0:S}\{1:S}", m_strRecipePath, CDefine.DEF_VISION_RECIPE_INI);
            ClassINI classINIRecipe = new ClassINI(strRecipePath);

            string strSection = ((CDefine.enumCamera)eCameraIndex).ToString();

            classINIRecipe.WriteValue(strSection, "iProductMarkCount", objRecipeParameter.iProductMarkCount);
            try
            {
                for (int iLoopMarkCount = 0; iLoopMarkCount < objRecipeParameter.objListMasterPosition.Count; iLoopMarkCount++)
                {
                    classINIRecipe.WriteValue(strSection, string.Format("objMasterPosition[{0}].dPositionX", iLoopMarkCount), objRecipeParameter.objListMasterPosition[iLoopMarkCount].dPositionX);
                    classINIRecipe.WriteValue(strSection, string.Format("objMasterPosition[{0}].dPositionY", iLoopMarkCount), objRecipeParameter.objListMasterPosition[iLoopMarkCount].dPositionY);
                    classINIRecipe.WriteValue(strSection, string.Format("objMasterPosition[{0}].dPositionT", iLoopMarkCount), objRecipeParameter.objListMasterPosition[iLoopMarkCount].dPositionT);
                }

                for (int iLoopMarkCount = 0; iLoopMarkCount < objRecipeParameter.objListAlignTool.Count; iLoopMarkCount++)
                {
                    classINIRecipe.WriteValue(strSection, string.Format("objListAlignTool.eAlignToolType[{0}]", iLoopMarkCount), (int)objRecipeParameter.objListAlignTool[iLoopMarkCount].eAlignToolType);
                    classINIRecipe.WriteValue(strSection, string.Format("objListAlignTool.ePatternResultType[{0}]", iLoopMarkCount), (int)objRecipeParameter.objListAlignTool[iLoopMarkCount].ePatternResultType);
                    classINIRecipe.WriteValue(strSection, string.Format("objListAlignTool.iDemandScore[{0}]", iLoopMarkCount), objRecipeParameter.objListAlignTool[iLoopMarkCount].iDemandScore);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error saving recipe parameter: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            m_objRecipeParameter[(int)eCameraIndex] = objRecipeParameter;

            bResult = true;
            return bResult;
        }
    }
}
