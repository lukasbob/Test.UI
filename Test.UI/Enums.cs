using Test.Extensions.Attributes;

namespace Test.UI
{
	/// <summary>
	/// Defines the icon position for buttons.
	/// </summary>
	public enum IconPosition
	{
		/// <summary>
		/// No icon is defined for this button.
		/// </summary>
		NoIcon,

		/// <summary>
		/// Icon is rendered on the left.
		/// </summary>
		[CssClass("icnL")]
		Left,

		/// <summary>
		/// Icon is rendered on the right
		/// </summary>
		[CssClass("icnR")]
		Right
	}

	public enum LinkTarget
	{
		/// <summary>
		/// Constant default.
		/// </summary>
		Default,

		/// <summary>
		/// Constant same frame.
		/// </summary>
		[HtmlAttr("target", "_self")]
		SameFrame,

		/// <summary>
		/// Constant new window.
		/// </summary>
		[HtmlAttr("target", "_blank")]
		NewWindow,

		/// <summary>
		/// Constant top frame.
		/// </summary>
		[HtmlAttr("target", "_top")]
		TopFrame,

		/// <summary>
		/// Constant parent frame.
		/// </summary>
		[HtmlAttr("target", "_parent")]
		ParentFrame
	}
	
	/// <summary>
	/// Defines two table cell tag types: TD and TH.
	/// </summary>
	public enum CellTag
	{
		/// <summary>
		/// Constant table cell.
		/// </summary>
		TableCell, 
		
		/// <summary>
		/// Constant table header.
		/// </summary>
		TableHeader 
	}
}
