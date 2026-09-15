using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignVision
{
	public abstract class CVisionLibraryAbstract
	{
		/// <summary>
		/// Lỗi
		/// </summary>
		protected CVisionLibraryError m_objError;

		/// <summary>
		/// Tham số khởi tạo
		/// </summary>
		protected CInitializeParameter m_objInitializeParameter;

		/// <summary>
		/// Hàm khởi tạo
		/// </summary>
		public CVisionLibraryAbstract()
		{
			m_objError = new CVisionLibraryError();
			m_objInitializeParameter = new CInitializeParameter();
		}

		/// <summary>
		/// Tham số khởi tạo
		/// </summary>
		public class CInitializeParameter : ICloneable
		{
			/// <summary>
			/// Tên file VPP
			/// </summary>
			public string strVppFileName;
			/// <summary>
			/// Đường dẫn công thức
			/// </summary>
			public string strRecipePath;
			/// <summary>
			/// Tên công thức
			/// </summary>
			public string strRecipeName;

			public CInitializeParameter()
			{
				strVppFileName = "";
				strRecipePath = "";
				strRecipeName = "";
			}

			public CInitializeParameter( string vppFileName, string recipePath, string recipeName )
			{
				strVppFileName = vppFileName;
				strRecipePath = recipePath;
				strRecipeName = recipeName;
			}

			public object Clone()
			{
				CInitializeParameter objInitializeParameter = new CInitializeParameter();
				objInitializeParameter.strVppFileName = strVppFileName;
				objInitializeParameter.strRecipePath = strRecipePath;
				objInitializeParameter.strRecipeName = strRecipeName;
				return objInitializeParameter;
			}
		}
		/// <summary>
		/// Lớp kiểm tra cảnh báo phát sinh
		/// Kiểu dữ liệu trả về khi gọi hàm
		/// </summary>
		public class CVisionLibraryError : ICloneable
		{
			/// <summary>
			/// Thời điểm xảy ra sự kiện
			/// </summary>
			public string strEventTime;
			/// <summary>
			/// Tên lớp được thực thi
			/// </summary>
			public string strClassName;
			/// <summary>
			/// Tên hàm được thực thi
			/// </summary>
			public string strFunctionName;
			/// <summary>
			/// Thông báo cảnh báo
			/// </summary>
			public string strMessage;

			public object Clone()
			{
				CVisionLibraryError objError = new CVisionLibraryError();
				objError.strEventTime = this.strEventTime;
				objError.strFunctionName = this.strFunctionName;
				objError.strMessage = this.strMessage;
				return objError;
			}
		}

		public abstract bool Initialize( CInitializeParameter objInitializeParameter );

		public abstract void DeInitialize();
		/// <summary>
		/// Phương thức trừu tượng để tải công thức
		/// </summary>
		/// <param name="strRecipePath"></param>
		/// <param name="strRecipeName"></param>
		/// <returns></returns>
		public abstract bool LoadRecipe( string strRecipePath, string strRecipeName );
		/// <summary>
		/// Phương thức trừu tượng để lưu công thức
		/// </summary>
		/// <param name="strRecipePath"></param>
		/// <param name="strRecipeName"></param>
		/// <returns></returns>
		public abstract bool SaveRecipe( string strRecipePath, string strRecipeName );
		/// <summary>
		/// Trả về thông tin trạng thái cảnh báo hiện tại.
		/// </summary>
		/// <returns></returns>
		public CVisionLibraryError GetErrorCode()
		{
			return m_objError.Clone() as CVisionLibraryError;
		}
		/// <summary>
		/// Tạo thông báo lỗi
		/// </summary>
		/// <param name="strFunctionName"></param>
		/// <param name="iReturnCode"></param>
		/// <param name="strMessage"></param>
		/// <returns></returns>
		public CVisionLibraryError MakeErrorMessage( string strClassName, string strFunctionName, string strMessage = "" )
		{
			m_objError.strEventTime = System.DateTime.Now.ToString( "yyyy/MM/dd hh:mm:ss" );
			m_objError.strClassName = strClassName;
			m_objError.strFunctionName = strFunctionName;
			m_objError.strMessage = strMessage;
			return m_objError;
		}

		/// <summary>
		/// Lấy tham số khởi tạo
		/// </summary>
		/// <returns></returns>
		public CInitializeParameter GetInitializeParameter()
		{
			return m_objInitializeParameter;
		}
		/// <summary>
		/// Thay đổi đường dẫn file VPP
		/// </summary>
		/// <param name="strVppName"></param>
		public void SetVppFileName( string strVppFileName )
		{
			m_objInitializeParameter.strVppFileName = strVppFileName;
		}
	}
}