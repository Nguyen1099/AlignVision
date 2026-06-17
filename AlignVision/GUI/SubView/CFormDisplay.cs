using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro.Display;

namespace AlignVision
{
    public partial class CFormDisplay : Form
    {
        private CDocument m_objDocument;

        private int iCamera;
        public CFormDisplay()
        {
            InitializeComponent();
        }

        public bool Initialize(CDefine.enumCamera iCamera, CDocument objDocument)
        {
            bool result = false;          
            m_objDocument = objDocument;
            this.iCamera = (int)iCamera;

            if (InitializeForm())
            {
                result = true;
            }
            return result;
        }

        public bool InitializeForm()
        {

            bool result = false;

            result = true;
            return result;
        }

        public CogDisplay getCogDisplay()
        {
            return cogDisplay;
        }
    }
}
