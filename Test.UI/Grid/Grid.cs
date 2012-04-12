using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Test.Extensions.HtmlTextWriter;
using Test.Extensions.StringExtensions;
using Test.Extensions.UriExtensions;
using Test.Extensions.EnumExtensions;

namespace Test.UI
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:Grid runat=server></{0}:Grid>")]
	[ParseChildren(ChildrenAsProperties = true)]
	public class Grid : CompositeDataBoundControl
	{
		[PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(Row))]
		public ITemplate Columns { get; set; }

		[PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(Row))]
		public ITemplate EmptyTemplate { get; set; }

		/// <summary>
		/// Delegates event handling to bound event handlers.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="GridEventArgs"/> instance containing the event data.</param>
		public delegate void GridItemEventHandler(object sender, GridEventArgs e);

		/// <summary>
		/// Occurs when the <see cref="Row"/> is created.
		/// </summary>
		public event GridItemEventHandler ItemCreated;

		/// <summary>
		/// Occurs when data is bound to the <see cref="Row"/>.
		/// </summary>
		public event GridItemEventHandler ItemDataBound;

		private bool _dataBound;

		/// <summary>
		/// Raises the <see cref="ItemCreated"/> event.
		/// </summary>
		/// <param name="e">The <see cref="GridEventArgs"/> instance containing the event data.</param>
		public void OnItemCreated(GridEventArgs e)
		{
			GridItemEventHandler handler = ItemCreated;
			if (handler != null) { handler(this, e); }
		}

		/// <summary>
		/// Raises the <see cref="ItemDataBound"/> event.
		/// </summary>
		/// <param name="e">The <see cref="GridEventArgs"/> instance containing the event data.</param>
		public void OnItemDataBound(GridEventArgs e)
		{
			GridItemEventHandler handler = ItemDataBound;
			if (handler != null) { handler(this, e); }
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (!_dataBound) { DataBind(); }
			base.Render(writer);
		}

		private List<string>_cssClassList = new List<string>();

		#region Public properties

		public int StartRow { get; set; }
		public int PageSize { get; set; }
		public int TotalRows { get; set; }

		public string Caption { get; set; }
		public string Summary { get; set; }

		private dynamic _data;
		public dynamic Data { get { return _data ?? (_data = new ExpandoObject()); } }

		#endregion

		#region Content placeholders

		private readonly ContentPlaceHolder _colGroup = new ContentPlaceHolder();
		private readonly ContentPlaceHolder _tableBody = new ContentPlaceHolder();
		private readonly ContentPlaceHolder _tableHead = new ContentPlaceHolder();

		#endregion

		protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
		{
			var count = 0;

			if (dataSource != null && dataBinding) {
				Controls.Clear();
				Controls.Add(_colGroup);
				Controls.Add(_tableHead);
				Controls.Add(_tableBody);

				foreach (var item in dataSource) {
					var row = new Row(item, count);
					var rowEvent = new GridEventArgs(row);

					if (Columns != null) {
						Columns.InstantiateIn(row);
					}

					row.Data.RowNum = StartRow + count;

					OnItemCreated(rowEvent); // Raise the OnItemCreated event.
					row.DataBind();
					OnItemDataBound(rowEvent); // Raise the OnItemDataBound event.

					// First row: Create columns & table headers.
					if (count == 0) {

						// Find out what the current sort order is
						string currentSortOrder = Context.Request.QueryString["SortOrder"];
						string currentSortBy = Context.Request.QueryString["SortBy"];

						foreach (var control in row.Controls) {
							var column = control as Column;
							if (column == null) { continue; }

							// Work out if a sort link is required, and if so, which parameters it should pass.
							// Starting point is the default sort order.
							SortOrder sortOrder = column.DefaultSortOrder;

							// The column is currently sorted if the SortBy query parameter matches the data field key.
							bool isCurrentlySorted = currentSortBy == column.DataField;

							// If the column is currently sorted, then parse the current sort order and reverse it.
							if (isCurrentlySorted && !currentSortOrder.IsNullOrEmpty()) {
								sortOrder = currentSortOrder.AsEnum(SortOrder.Unsorted).Reversed();
							}

							// Add a table header cell to the table head collection.
							_tableHead.Controls.Add(new Column {
								Text = column.DataField,
								CellTag = CellTag.TableHeader,
								NavigateUrl = sortOrder == SortOrder.Unsorted
									? null
									: Context.Request.Url.WithAlteredQuery(new NameValueCollection {
										{ "SortOrder", sortOrder.ToString() },
										{ "SortBy", column.DataField }
									}).ToString()
							});

							// Add a column to the colgroup collection.
							var col = new HtmlGenericControl("col");
							if (column.Width > 0) {
								col.Attributes.Add("style", "width:" + column.Width + "px;");
							}

							_colGroup.Controls.Add(col);
						}
					}

					_tableBody.Controls.Add(row);

					count++;
				}

				_dataBound = true;
			}

			if (EmptyTemplate != null && (dataSource == null || count == 0)) {
				var emptyRow = new Row(null, count);
				EmptyTemplate.InstantiateIn(emptyRow);
				_tableBody.Controls.Add(emptyRow);
			}

			return count;
		}

		private string SerializeDataProperty()
		{
			return JsonConvert.SerializeObject(Data);
		}

		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			Data.UniqueID = UniqueID;
			Data.StartRow = StartRow;
			Data.TotalRows = TotalRows;
			Data.PageSize = PageSize;

			_cssClassList.Add("grid");
			_cssClassList.Add(CssClass);

			writer.Tag("table", e => e
						  ["class", string.Join(" ", _cssClassList.ToArray())]
						  ["id", ID, !ID.IsNullOrEmpty()]
						  ["summary", Summary, !Summary.IsNullOrEmpty()]
						  ["data-tableview", SerializeDataProperty()]);
		}

		public override void RenderEndTag(HtmlTextWriter writer)
		{
			writer.EndTag();
		}

		protected override void RenderContents(HtmlTextWriter writer)
		{
			writer.TagIf(!Caption.IsNullOrEmpty(), "caption").Text(Caption).EndTagIf(!Caption.IsNullOrEmpty())
				.Tag("colgroup").Do(_colGroup.RenderControl).EndTag()
				.Tag("thead").Do(_tableHead.RenderControl).EndTag()
				.Tag("tbody").Do(_tableBody.RenderControl).EndTag();
		}

	}

	public class GridEventArgs : EventArgs
	{
		public GridEventArgs(Row item) { Item = item; }

		public Row Item { get; private set; }
	}
}
