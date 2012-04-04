using System;
using System.Collections.Generic;
using Test.UI;

namespace Siteimprove.UI.MonoTest
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			buttonWithData.Data.List = new List<string> { "boo", "foo" };

			TableView1.DataSource = new List<RowExample> {
				new RowExample { Col1 = "Foo",   Col2 = new DateTime(1977, 3, 15), Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Moo",   Col2 = new DateTime(1977, 3, 15), Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Flbby", Col2 = new DateTime(1977, 3, 15), Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Snttr", Col2 = new DateTime(1977, 3, 15), Col3 = 4, Col4 = 123451235 },
				new RowExample { Col1 = "Moo",   Col2 = new DateTime(1977, 3, 15), Col3 = 4, Col4 = 123451235 }
			};

			TableView1.ItemDataBound += (snd, evt) => {
				var row = evt.Item;
				var item = ((RowExample)row.DataItem);

				row.Controls.AddAt(2, new Column {
					DataField = "Col2",
					Text = item.Col1 + "adfasdf"
				});
			};
		}

		public void Format(object sender, EventArgs e)
		{
			var col = ((Column)sender);
			if (col.BindValue is int) {
				col.BindValue = ((int)col.BindValue).ToString();
			}

			if (col.BindValue is decimal) {
				col.BindValue = ((decimal)col.BindValue).ToString("#0.00");
			}

			if (col.BindValue is double) {
				col.BindValue = ((double)col.BindValue).ToString("#0.00");
			}

			if (col.BindValue is DateTime) {
				col.BindValue = ((DateTime)col.BindValue).ToShortDateString();
			}
		}
	}



	public class RowExample
	{
		public string Col1 { get; set; }
		public DateTime Col2 { get; set; }
		public int Col3 { get; set; }
		public long Col4 { get; set; }
	}
}