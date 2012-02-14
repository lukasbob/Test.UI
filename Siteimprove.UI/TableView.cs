using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteimprove.Extensions.HtmlTextWriter;

namespace Siteimprove.UI
{
	[ToolboxData("<{0}:TableView runat=server></{0}:TableView>")]
	public class TableView : CompositeDataBoundControl
	{
		[PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(Row))]
		public ITemplate RowTemplate { get; set; }

		/// <summary>
		/// Delegates event handling to bound event handlers.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="TableViewEventArgs"/> instance containing the event data.</param>
		public delegate void TableViewItemEventHandler(object sender, TableViewEventArgs e);

		/// <summary>
		/// Occurs when the <see cref="Row"/> is created.
		/// </summary>
		public event TableViewItemEventHandler ItemCreated;

		/// <summary>
		/// Occurs when data is bound to the <see cref="Row"/>.
		/// </summary>
		public event TableViewItemEventHandler ItemDataBound;

		private bool _dataBound;

		/// <summary>
		/// Raises the <see cref="ItemCreated"/> event.
		/// </summary>
		/// <param name="e">The <see cref="TableViewEventArgs"/> instance containing the event data.</param>
		public void OnItemCreated(TableViewEventArgs e)
		{
			TableViewItemEventHandler handler = ItemCreated;
			if (handler != null) { handler(this, e); }
		}

		/// <summary>
		/// Raises the <see cref="ItemDataBound"/> event.
		/// </summary>
		/// <param name="e">The <see cref="TableViewEventArgs"/> instance containing the event data.</param>
		public void OnItemDataBound(TableViewEventArgs e)
		{
			TableViewItemEventHandler handler = ItemDataBound;
			if (handler != null) { handler(this, e); }
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (!_dataBound) { DataBind(); }
			base.Render(writer);
		}

		protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
		{
			var count = 0;
			if (dataBinding) {
				Controls.Clear();



				foreach (var item in dataSource) {
					var row = new Row(item, count);
					var rowEvent = new TableViewEventArgs(row);

					if (RowTemplate != null) {
						RowTemplate.InstantiateIn(row);
					}

					OnItemCreated(rowEvent); // Raise the OnItemCreated event.
					row.DataBind();
					OnItemDataBound(rowEvent); // Raise the OnItemDataBound event.

					Controls.Add(row);

					count++;
				}

				_dataBound = true;
			}

			return count;
		}
	}

	public class Row : BaseControl, IDataItemContainer
	{
		/// <summary>
		/// Initializes a new iViewState["Text"] = value;nstance of the <see cref="Row"/> class.
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
			writer.Tag("tr", e => e["class", CssClass, !string.IsNullOrEmpty(CssClass)])
				.Do(RenderChildren)
			.EndTag("tr");
		}
	}


	public class TableViewEventArgs : EventArgs
	{
		public TableViewEventArgs(Row item) { Item = item; }

		public Row Item { get; private set; }
	}

}
