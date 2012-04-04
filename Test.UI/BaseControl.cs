
using System;
using System.ComponentModel;
using System.Dynamic;
using System.Web.UI;
using Newtonsoft.Json;

namespace Test.UI
{
	[ToolboxItem(false)]
	public class BaseControl : Control
	{
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

		private dynamic _data;
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public dynamic Data { get { return _data ?? (_data = new ExpandoObject()); } }
		private bool _serializeDataPropertyCalled;

		/// <summary>
		/// Serializes the data property.
		/// </summary>
		/// <returns>
		/// The data property.
		/// </returns>
		protected string SerializeDataProperty()
		{
			_serializeDataPropertyCalled = true;
			return _data == null ? null : JsonConvert.SerializeObject(Data);
		}
		
		protected override void Render(HtmlTextWriter writer)
		{
			if (!_serializeDataPropertyCalled) {
				throw new Exception("Please implement a data property on the root element of the control, using the Data attribute and the SerializeDataProperty method.");
			}
			this.
			RenderChildren(writer);
			base.Render(writer);
		}
	}
}
