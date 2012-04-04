using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Siteimprove.UI.Interfaces;
using Test.Extensions.EnumExtensions;
using Test.Extensions.HtmlTextWriter;

namespace Test.UI
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:Button runat=server></{0}:Button>")]
	[ParseChildren(false)]
	public class Button : BaseControl, IIconButton
	{
		/// <summary>
		/// Gets or sets the button text.
		/// </summary>
		/// <value>
		/// The text.
		/// </value>
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the icon position.
		/// </summary>
		/// <value>
		/// The icon position.
		/// </value>
		[Category("Appearance")]
		public IconPosition IconPosition { get; set; }

		protected override void Render(HtmlTextWriter writer)
		{
			var cssClass = string.Join(" ", new List<string> { "btn", IconPosition.CssClass(), CssClass }.Where(str => !string.IsNullOrEmpty(str)));
			var dataAttribute = SerializeDataProperty();
			writer.Tag("button", e => e
						  ["class", cssClass]
						  ["title", ToolTip, !string.IsNullOrEmpty(ToolTip)]
						  ["data-button", dataAttribute, Data != null])
				.Tag("span")
					.Text(Text)
					.Do(RenderChildren)
				.EndTag()
			.EndTag();
		}
	}
}
