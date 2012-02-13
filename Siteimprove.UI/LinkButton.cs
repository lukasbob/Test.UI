namespace Siteimprove.UI {
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using Extensions.EnumExtensions;
	using Extensions.HtmlTextWriter;
	using Interfaces;

	public class LinkButton : BaseControl, IHyperLink, IIconButton {

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text { get; set; }

		#region IHyperLink implementation
		/// <summary>
		/// Gets or sets the link URL.
		/// </summary>
		/// <value>
		/// The link URL.
		/// </value>
		public string LinkUrl { get; set; }

		/// <summary>
		/// Gets or sets the link target.
		/// </summary>
		/// <value>
		/// The link target.
		/// </value>
		public LinkTarget LinkTarget { get; set; }
		#endregion

		#region IIconButton implementation
		/// <summary>
		/// Gets or sets the icon position.
		/// </summary>
		/// <value>
		/// The icon position.
		/// </value>
		public IconPosition IconPosition { get; set; }
		#endregion

		protected override void Render(System.Web.UI.HtmlTextWriter writer) {
			var cssClass = string.Join(" ", new List<string> { "btn", IconPosition.CssClass(), CssClass }.Where(str => !string.IsNullOrEmpty(str)));
			var dataAttribute = SerializeDataProperty();
			writer.Tag("a", e => e
						  ["href", LinkUrl]
						  ["target", LinkTarget.HtmlAttributeValue()]
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

