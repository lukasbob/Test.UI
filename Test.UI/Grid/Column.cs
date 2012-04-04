using System;
using System.ComponentModel;
using System.Web.UI;
using Siteimprove.Extensions.EnumExtensions;
using Siteimprove.Extensions.HtmlTextWriter;
using Siteimprove.Extensions.StringExtensions;
using Siteimprove.Extensions.TypeExtensions;
using Siteimprove.UI.Interfaces;

namespace Siteimprove.UI
{
	public enum SortOrder
	{
		Unsorted,
		Ascending,
		Descending
	}

	public static class SortOrderExtensions
	{
		public static SortOrder Reversed(this SortOrder sortOrder)
		{
			switch (sortOrder) {
				case SortOrder.Ascending: return SortOrder.Descending;
				case SortOrder.Descending: return SortOrder.Ascending;
				default: return SortOrder.Unsorted;
			}
		}

	}

	[ToolboxData("<{0}:Column runat=server></{0}:Column>")]
	[ParseChildren(false)]
	public class Column : BaseControl, IHyperLink
	{
		public object BindValue { get; set; }
		public Type BindType { get; private set; }

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>
		/// The text.
		/// </value>
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the data field.
		/// </summary>
		/// <value>
		/// The data field.
		/// </value>
		[Bindable(false)]
		[Category("Data")]
		[DefaultValue("")]
		[Localizable(false)]
		public string DataField { get; set; }

		/// <summary>
		/// Gets or sets the type of cell.
		/// </summary>
		/// <value>
		/// The type of cell.
		/// </value>
		[Bindable(false)]
		[Category("Appearance")]
		[DefaultValue("TableCell")]
		[Localizable(false)]
		public CellTag CellTag { get; set; }

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>
		/// The width.
		/// </value>
		[Bindable(false)]
		[Category("Appearance")]
		[DefaultValue("TableCell")]
		[Localizable(false)]
		public int Width { get; set; }

		/// <summary>
		/// Gets the default sort order.
		/// </summary>
		[Bindable(false)]
		[Category("Data")]
		[DefaultValue("Unsorted")]
		[Localizable(false)]
		public SortOrder DefaultSortOrder { get; private set; }

		#region IHyperLink implementation
		public LinkTarget Target { get; set; }

		public string NavigateUrl { get; set; }
		#endregion

		private HtmlTextWriterTag Tag { get { return CellTag == CellTag.TableHeader ? HtmlTextWriterTag.Th : HtmlTextWriterTag.Td; } }

		protected override void OnPreRender(System.EventArgs e)
		{
			BindValue = string.Empty;
			if (!DataField.IsNullOrEmpty() && DataItemContainer != null) {

				var row = (Row)DataItemContainer;
				var property = row.DataItem.GetType().GetProperty(DataField);

				BindType = property.PropertyType;

				// Set the right CSS class
				CssClass = BindType.Name;

				// Get the data from the data source
				BindValue = property.GetValue(row.DataItem, null);
				
				// Set the default sort order
				DefaultSortOrder = BindType.IsNumeric() ? SortOrder.Descending : SortOrder.Ascending;

				// Add a bind property to the cell so that we can bnid updated values later on.
				this.Data.Bind = DataField;
			}

			base.OnPreRender(e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			

			var dataAttribute = SerializeDataProperty();

			writer.Tag(Tag, e => e
						  ["class", CssClass, !CssClass.IsNullOrEmpty()]
						  ["data-cell", dataAttribute, !dataAttribute.IsNullOrEmpty()])
				.TagIf(!NavigateUrl.IsNullOrEmpty(), "a", e => e
						 ["href", NavigateUrl]
						 ["target", Target.HtmlAttributeValue()])
					.Text(Text)
					.DoIf(!DataField.IsNullOrEmpty(), wr => wr.Text(BindValue.ToString()))
				.Do(RenderChildren)
				.EndTagIf(!NavigateUrl.IsNullOrEmpty())
			.EndTag();
		}
	}
}

