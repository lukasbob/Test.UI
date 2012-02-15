using System;
using System.Collections.Generic;
using System.Resources;

namespace Siteimprove.UI.MonoTest
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			buttonWithData.Data = new List<string> { "boo", "foo" };

			TableView1.DataSource = new List<RowExample> {
				new RowExample { Col1 = "Foo",   Col2 = "Bar", Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Moo",   Col2 = "Car", Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Flbby", Col2 = "Car", Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Snttr", Col2 = "Car", Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Moo",   Col2 = "Car", Col3 = 4, Col4 = 123451235 }
			};
			
			TableView1.ItemDataBound += (snd, evt) => {
				var row = evt.Item;
				row.Controls.AddAt(2, new Column{ DataField = "Col2" });
			};

			ResXResourceWriter resourceWriter = new ResXResourceWriter("Resources/strings.resx");
			resourceWriter.AddResource("goodbye", "Hello snooty");
			resourceWriter.Close();
		}
	}

	public class RowExample
	{
		public string Col1 { get; set; }
		public string Col2 { get; set; }
		public int Col3 { get; set; }
		public long Col4 { get; set; }
	}
}