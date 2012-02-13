using System;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Siteimprove.UI {
	[ToolboxItem(false)]
	public class BaseControl : Control {
		/// <summary>
		/// Gets or sets the css class.
		/// </summary>
		/// <value>
		/// The css class.
		/// </value>
		[Category("Appearance")]
		public string CssClass { get; set; }

		/// <summary>
		/// Gets or sets the tool tip.
		/// </summary>
		/// <value>
		/// The tool tip.
		/// </value>
		[Category("Appearance")]
		[Localizable(true)]
		[DefaultValue("")]
		public string ToolTip { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public object Data { get; set; }

		private bool _serializeDataPropertyCalled;

		/// <summary>
		/// Serializes the data property.
		/// </summary>
		/// <returns>
		/// The data property.
		/// </returns>
		protected string SerializeDataProperty() {
			_serializeDataPropertyCalled = true;
			var javascriptSerializer = new JavaScriptSerializer();
			return javascriptSerializer.Serialize(Data);
		}

		protected override void Render(HtmlTextWriter writer) {
			if (!_serializeDataPropertyCalled) {
				throw new Exception("Please implement a data property on the root element of the control, using the Data attribute and the SerializeDataProperty method.");
			}

			RenderChildren(writer);
			base.Render(writer);
		}
	}
}
