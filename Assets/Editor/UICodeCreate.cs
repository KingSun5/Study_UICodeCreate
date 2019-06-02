

using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	/// <summary>
	/// time:2019/6/2 0:37
	/// author:Sun
	/// des:UICodeCreate
	///
	/// github:https://github.com/KingSun5
	/// csdn:https://blog.csdn.net/Mr_Sun88
	/// </summary>
	public partial class UiCodeCreate
	{
		
		public static readonly UiCodeCreate Instance = new UiCodeCreate();
		

		[MenuItem("Assets/Create/Create UI Code")]
		public static void CreateUiCode()
		{
			//获取选中的Prefab
			var objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets | SelectionMode.TopLevel);

			for (var i = 0; i < objs.Length; i++)
			{
				Instance.CreateViewCode(objs[i] as GameObject);
			}
			AssetDatabase.Refresh();
		}

		/// <summary>
		/// 创建View类
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="objPath"></param>
		private void CreateViewCode(GameObject obj)
		{
			//变量声明
			StringBuilder statementContent = new StringBuilder();
			//变量绑定
			StringBuilder bindVariableContent = new StringBuilder();
			//写入内容
			StringBuilder fileContent = new StringBuilder();
			fileContent.Append(_viewTemplateContent);
			foreach (UIType child in obj.GetComponentsInChildren<UIType>(true))
			{
				statementContent.Append("\n");
				statementContent.Append("		");
				statementContent.Append(child.StatementContent);
				bindVariableContent.Append("\n");
				bindVariableContent.Append("			");
				bindVariableContent.Append(child.BindVariableContent);
			}
			//替换脚本名和命名空间
			fileContent = fileContent.Replace("TemNamespace", "UI."+obj.name).Replace("ViewTemplate", obj.name);
			//添加属性和绑定
			fileContent = fileContent.Replace("/*声明*/", statementContent.ToString()).Replace("/*绑定*/", bindVariableContent.ToString());
			CreateFileAndWrite(obj.name, fileContent.ToString(),"View");
			CreateModelCode(obj);
			CreateControlCode(obj);
		}

		/// <summary>
		/// 创建Model类
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="objPath"></param>
		private void CreateModelCode(GameObject obj)
		{
			//写入内容
			StringBuilder fileContent = new StringBuilder();
			fileContent.Append(_modelTemplateContent);
			//替换脚本名和命名空间
			fileContent = fileContent.Replace("TemNamespace", "UI."+obj.name).Replace("ModelTemplate", obj.name);
			CreateFileAndWrite(obj.name, fileContent.ToString(),"Model");
		}

		/// <summary>
		/// 创建Control类
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="objPath"></param>
		private void CreateControlCode(GameObject obj)
		{
			//写入内容
			StringBuilder fileContent = new StringBuilder();
			fileContent.Append(_controlTemplateContent);
			//替换脚本名和命名空间
			fileContent = fileContent.Replace("TemNamespace", "UI."+obj.name).Replace("ControlTemplate", obj.name);
			CreateFileAndWrite(obj.name, fileContent.ToString(),"Control");
		}

		/// <summary>
		/// 获取文件内容
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private string GetFileContent(string filePath)
		{
			if (File.Exists(filePath))
			{
				return File.ReadAllText(filePath);

			}
			else
			{
				Debug.Log("Error:["+filePath+"]该文件不存在！");
				return null;
			}
		}

		/// <summary>
		/// 创建文件并写入
		/// </summary>
		/// <returns></returns>
		private void CreateFileAndWrite(string name,string content,string type)
		{
			var path = _UiFilePath + name;
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			File.WriteAllText(path+"/"+name+"."+type+".cs",content);
		}
		
	}
}
