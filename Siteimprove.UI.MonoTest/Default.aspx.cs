using System;
using System.Collections.Generic;

namespace Siteimprove.UI.MonoTest
{
	public partial class Default : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			buttonWithData.Data = new List<string> { "boo", "foo" };
			base.OnLoad(e);

			var tableData = new List<object> {
				new { col1 = "item 1", col2 = "item 1" },
				new { col1 = "item 2", col2 = "item 2" }
			};
		}

	}
}

