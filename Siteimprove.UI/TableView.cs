using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siteimprove.UI
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:TableView runat=server></{0}:TableView>")]
	public class TableView : WebControl
	{
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text
		{
			get
			{
				String s = (String)ViewState["Text"];
				return (s ?? String.Empty);
			}

			set
			{
				ViewState["Text"] = value;
			}
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			output.Write(Text);
		}
	}
}
