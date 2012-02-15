﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siteimprove.Extensions.HtmlTextWriter;
using Siteimprove.Extensions.StringExtensions;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Web.UI.HtmlControls;

namespace Siteimprove.UI
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:Grid runat=server></{0}:Grid>")]
	[ParseChildren(ChildrenAsProperties = true)]
	public class Grid : CompositeDataBoundControl
	{
		[PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(Row))]
		public ITemplate Columns { get; set; }
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
		/// <param name="e">The <see cref="TableViewEventArgs"/> instance containing the event data.</param>
		public void OnItemCreated(GridEventArgs e)
		{
			GridItemEventHandler handler = ItemCreated;
			if (handler != null) { handler(this, e); }
		}

		/// <summary>
		/// Raises the <see cref="ItemDataBound"/> event.
		/// </summary>
		/// <param name="e">The <see cref="TableViewEventArgs"/> instance containing the event data.</param>
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
		
		private ContentPlaceHolder _colGroup = new ContentPlaceHolder();
		private ContentPlaceHolder _tableBody = new ContentPlaceHolder();
		private ContentPlaceHolder _tableHead = new ContentPlaceHolder();
		
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
					
					row.Data = new { rownum = StartRow + count };
					
					OnItemCreated(rowEvent); // Raise the OnItemCreated event.
					row.DataBind();
					OnItemDataBound(rowEvent); // Raise the OnItemDataBound event.
					
					if (count == 0) {
						foreach (var control in row.Controls) {
							var column = control as Column;
							if (column == null) { continue; }
							
							// Add a table header cell to the table head collection.
							_tableHead.Controls.Add(new Column{ 
								Text = column.DataField,
								CellTag = CellTag.TableHeader
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
			};
			
			return count;
		}
		
		private string SerializeDataProperty()
		{
			var javascriptSerializer = new JavaScriptSerializer();
			return javascriptSerializer.Serialize(Data);
		}
		
		public override void RenderBeginTag (HtmlTextWriter writer)	{
			Data.UniqueID = UniqueID;
			Data.StartRow = StartRow;
			Data.TotalRows = TotalRows;
			Data.PageSize = PageSize;
			
			writer.Tag("table", e => e
			           ["class", CssClass, !CssClass.IsNullOrEmpty()]
			           ["id", ID, !ID.IsNullOrEmpty()]
			           ["summary", Summary, !Summary.IsNullOrEmpty()]
			           ["data-tableview", SerializeDataProperty()]);
		}
		
		public override void RenderEndTag (HtmlTextWriter writer)	{
			writer.EndTag();
		}
		
		protected override void RenderContents (HtmlTextWriter writer)
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
