namespace Test.Extensions.Attributes {
	using System;
	/// <summary>
	/// Defines a CSS attribute for a type.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class CssClassAttribute : Attribute {
		/// <summary>
		/// The CSS class for this type.
		/// </summary>
		public readonly string CssClass;

		/// <summary>
		/// Initializes a new instance of the <see cref="CssClassAttribute"/> class.
		/// </summary>
		/// <param name="cssClass">The CSS class.</param>
		public CssClassAttribute(string cssClass) {
			CssClass = cssClass;
		}
	}
	
	/// <summary>
	/// Html attr attribute.
	/// </summary>/
	[AttributeUsage(AttributeTargets.All)]
	public class HtmlAttrAttribute : Attribute {
		/// <summary>
		/// The HTML Attribute name for this type.
		/// </summary>
		public readonly string HtmlAttributeName;
		
		/// <summary>
		/// The attribute value.
		/// </summary>
		public readonly string AttributeValue;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="HtmlAttrAttribute"/> class.
		/// </summary>
		/// <param name="htmlAttributeName">The name of the HTML attribute to set.</param>
		/// <param name="attributeValue">The value to set the HTML attribute to.</param>
		public HtmlAttrAttribute(string htmlAttributeName, string attributeValue) {
			HtmlAttributeName = htmlAttributeName;
			AttributeValue = attributeValue;
		}
	}
	
}
