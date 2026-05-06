using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AlignVision
{
	public interface CFormInterface
	{
		bool SetChangeLanguage();

		void SetTimer(bool bTimer);

		void SetVisible(bool bVisible);
	}

}
