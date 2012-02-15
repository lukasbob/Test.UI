using System;
using System.Web.UI;
using Siteimprove.Extensions.HtmlTextWriter;

namespace Siteimprove.UI
{
	public class Row : BaseControl, IDataItemContainer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Row"/> class.
		/// </summary>
		/// <param name="dataItem">The data item.</param>
		/// <param name="index">The index.</param>
		public Row(object dataItem, int index)
		{
			DataItem = dataItem;
			DataItemIndex = index;
		}

		#region Implementation of IDataItemContainer

		public object DataItem { get; private set; }
		public int DataItemIndex { get; private set; }
		public int DisplayIndex { get; private set; }

		#endregion

		protected override void Render(HtmlTextWriter writer)
		{
			var dataAttribute = SerializeDataProperty();
			writer.Tag("tr", e => e
				["class", CssClass, !string.IsNullOrEmpty(CssClass)]
				["data-row", dataAttribute, Data != null])
				.Do(RenderChildren)
			.EndTag("tr");
		}
	}
}

