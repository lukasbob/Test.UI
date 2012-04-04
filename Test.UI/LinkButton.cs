using System.Web.UI;

namespace Siteimprove.UI
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using Extensions.EnumExtensions;
	using Extensions.HtmlTextWriter;
	using Interfaces;

	[DefaultProperty("Text")]
	[ToolboxData("<{0}:LinkButton runat=server></{0}:LinkButton>")]
	[ParseChildren(false)]
	public class LinkButton : BaseControl, IHyperLink, IIconButton
	{
		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>
		/// The text.
		/// </value>
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text { get; set; }

		#region IHyperLink implementation
		/// <summary>
		/// Gets or sets the navigate URL.
		/// </summary>
		/// <value>
		/// The navigate URL.
		/// </value>
		[Bindable(true)]
		[Category("Navigation")]
		[DefaultValue("")]
		[Localizable(false)]
		public string NavigateUrl { get; set; }

		/// <summary>
		/// Gets or sets the link target.
		/// </summary>
		/// <value>
		/// The link target.
		/// </value>
		[Bindable(false)]
		[Category("Navigation")]
		[DefaultValue("")]
		[Localizable(false)]
		public LinkTarget Target { get; set; }
		#endregion

		#region IIconButton implementation
		/// <summary>
		/// Gets or sets the icon position.
		/// </summary>
		/// <value>
		/// The icon position.
		/// </value>
		[Bindable(false)]
		[Category("Appearance")]
		[Localizable(false)]
		public IconPosition IconPosition { get; set; }
		#endregion

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			var cssClass = string.Join(" ", new List<string> { "btn", IconPosition.CssClass(), CssClass }.Where(str => !string.IsNullOrEmpty(str)));
			var dataAttribute = SerializeDataProperty();
			writer.Tag("a", e => e
						  ["href", NavigateUrl]
						  ["target", Target.HtmlAttributeValue()]
						  ["class", cssClass]
						  ["title", ToolTip, !string.IsNullOrEmpty(ToolTip)]
						  ["data-linkbutton", dataAttribute, Data != null])
				.Tag("span")
					.Text(Text)
					.Do(RenderChildren)
				.EndTag()
			.EndTag();
			base.Render(writer);
		}

	}
}

