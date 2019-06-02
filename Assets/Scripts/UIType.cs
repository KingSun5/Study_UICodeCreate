using System.Text;
using Extension;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// time:2019/6/2 13:57
/// author:Sun
/// des:UI类型
///
/// github:https://github.com/KingSun5
/// csdn:https://blog.csdn.net/Mr_Sun88
/// </summary>
public class UIType : MonoBehaviour
{

	/// <summary>
	/// 变量名字
	/// </summary>
	public string VariableName
	{
		get { return "_"+gameObject.name.LowercaseFirst(); }
	}
	
	/// <summary>
	/// UI类型
	/// </summary>
	public string ComponentName
	{
		get
		{
			if (null != GetComponent<ScrollRect>())
				return "ScrollRect";
			if (null != GetComponent<InputField>())
				return "InputField";
			if (null != GetComponent<Button>())
				return "Button";
			if (null != GetComponent<Text>())
				return "Text";
			if (null != GetComponent<RawImage>())
				return "RawImage";
			if (null != GetComponent<Toggle>())
				return "Toggle";
			if (null != GetComponent<Slider>())
				return "Slider";
			if (null != GetComponent<Scrollbar>())
				return "Scrollbar";
			if (null != GetComponent<Image>())
				return "Image";
			if (null != GetComponent<ToggleGroup>())
				return "ToggleGroup";
			if (null != GetComponent<Animator>())
				return "Animator";
			if (null != GetComponent<Canvas>())
				return "Canvas";
			if (null != GetComponent<RectTransform>())
				return "RectTransform";

			return "Transform";
		}
	}

	/// <summary>
	/// 变量声明内容
	/// </summary>
	public string StatementContent
	{
		get { return "private"+" "+ ComponentName + " " + VariableName+";"; }
	}

	/// <summary>
	/// 变量绑定内容
	/// </summary>
	public string BindVariableContent
	{
		get
		{
			var content = VariableName + " = " + "GameObject.Find(\"" + gameObject.name + "\")";
			var bindProperty = "GetComponent<" + ComponentName + ">();";
			return content+"."+bindProperty;
		}
	}
	
}
