using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
    public class CDocument
    {

        /// <summary>
        /// Quản lý form hiện thị hình ảnh
        /// </summary>
        public Dictionary<CDefine.enumCamera, CFormDisplay> m_objFormDisplay;


        public bool Initialize()
        {
            bool result = false;

            // Khởi tạo form hiển thị hình ảnh
            {
                m_objFormDisplay = new Dictionary<CDefine.enumCamera, CFormDisplay>();
                foreach (CDefine.enumCamera index in Enum.GetValues(typeof(CDefine.enumCamera)))
                {
                    m_objFormDisplay[index] = new CFormDisplay();
                }
            }

            result = true;
            return result;

        }
    }
}
