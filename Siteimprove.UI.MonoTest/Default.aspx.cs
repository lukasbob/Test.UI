using System;
using System.Collections.Generic;

namespace Siteimprove.UI.MonoTest
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			buttonWithData.Data = new List<string> { "boo", "foo" };

			var tableData = new List<RowExample> {
				new RowExample { Col1 = "Foo", Col2 = "Bar"},
				new RowExample { Col1 = "Moo", Col2 = "Car"}				
			};

			TableView1.DataSource = tableData;

		}

	}



	public class RowExample
	{
		public string Col1 { get; set; }
		public string Col2 { get; set; }
	}
}