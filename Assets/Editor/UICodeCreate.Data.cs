

namespace Editor
{
	/// <summary>
	/// time:2019/6/2 0:37
	/// author:Sun
	/// des:UICodeCreate.Data
	///
	/// github:https://github.com/KingSun5
	/// csdn:https://blog.csdn.net/Mr_Sun88
	/// </summary>
	public partial class UiCodeCreate {

		/// <summary>
		/// Model模板类脚本路径
		/// </summary>
		private string _modelTemplatePath = "Assets/Template/ModelTemplate.cs";
		/// <summary>
		/// Model模板类脚本内容
		/// </summary>
		private string _modelTemplateContent
		{
			get { return GetFileContent(_modelTemplatePath); }
		}
		/// <summary>
		/// View模板类脚本路径
		/// </summary>
		private string _viewTemplatePath = "Assets/Template/ViewTemplate.cs";
		/// <summary>
		/// View模板类脚本内容
		/// </summary>
		private string _viewTemplateContent
		{
			get { return GetFileContent(_viewTemplatePath); }
		}
		/// <summary>
		/// Control模板类脚本路径
		/// </summary>
		private string _controlTemplatePath = "Assets/Template/ControlTemplate.cs";
		/// <summary>
		/// Control模板类脚本内容
		/// </summary>
		private string _controlTemplateContent
		{
			get { return GetFileContent(_controlTemplatePath); }
		}
		/// <summary>
		/// 生成文件路径
		/// </summary>
		private string _UiFilePath = "Assets/Scripts/UI/";

	}
}
