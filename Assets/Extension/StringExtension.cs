namespace Extension
{
	/// <summary>
	/// time:2019/6/2 14:57
	/// author:Sun
	/// des:字符的静态拓展
	///
	/// github:https://github.com/KingSun5
	/// csdn:https://blog.csdn.net/Mr_Sun88
	/// </summary>
	public static class StringExtension {

		/// <summary>
		/// 首字母大写
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string UppercaseFirst(this string str)
		{
			return char.ToUpper(str[0]) + str.Substring(1);
		}

		/// <summary>
		/// 首字母小写
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string LowercaseFirst(this string str)
		{
			return char.ToLower(str[0]) + str.Substring(1);
		}

	}
}
