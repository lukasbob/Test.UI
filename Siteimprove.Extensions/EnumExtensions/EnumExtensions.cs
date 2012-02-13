namespace Siteimprove.Extensions.EnumExtensions {
	using System;
	using Attributes;
	public static class EnumExtensions {

		/// <summary>
		/// Will get the string value for a given enums value, this will
		/// only work if you assign the Css attribute to
		/// the items in your enum.
		/// </summary>		
		/// <returns>The assigned CSS class of the type.</returns>
		public static string CssClass(this Enum value) {
			var fieldInfo = value.GetType().GetField(value.ToString());
			var attribs = fieldInfo.GetCustomAttributes(typeof(CssClassAttribute), false) as CssClassAttribute[];
			return attribs != null && attribs.Length > 0 ? attribs[0].CssClass : null;
		}
		
		public static string HtmlAttributeName(this Enum value) {
			var fieldInfo = value.GetType().GetField(value.ToString());
			var attribs = fieldInfo.GetCustomAttributes(typeof(HtmlAttrAttribute), false) as HtmlAttrAttribute[];
			return attribs != null && attribs.Length > 0 ? attribs[0].HtmlAttributeName : null;
		}
		
		public static string HtmlAttributeValue(this Enum value) {
			var fieldInfo = value.GetType().GetField(value.ToString());
			var attribs = fieldInfo.GetCustomAttributes(typeof(HtmlAttrAttribute), false) as HtmlAttrAttribute[];
			return attribs != null && attribs.Length > 0 ? attribs[0].AttributeValue : null;
		}
	}
}
