using System;
using System.ComponentModel;
using System.Web.UI;
using Siteimprove.Extensions.HtmlTextWriter;
using Siteimprove.Extensions.StringExtensions;
using Siteimprove.UI.Interfaces;
using Siteimprove.Extensions.EnumExtensions;

namespace Siteimprove.UI
{
	public class Column : BaseControl, IHyperLink
	{
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
				
		#region IHyperLink implementation
		public LinkTarget Target { get; set;}

		public string NavigateUrl { get; set; }
		#endregion		
				
		private HtmlTextWriterTag Tag { get { return CellTag == CellTag.TableHeader ? HtmlTextWriterTag.Th : HtmlTextWriterTag.Td; } }
		
		protected override void Render(HtmlTextWriter writer)
		{
			string bindValue = string.Empty;
			if (!DataField.IsNullOrEmpty() && DataItemContainer != null) {
				var row = (Row)DataItemContainer;
				var property = row.DataItem.GetType().GetProperty(DataField);
				CssClass = property.PropertyType.Name;
				bindValue = property.GetValue(row.DataItem, null).ToString();
			}
						
			var dataAttribute = SerializeDataProperty();
			
			writer.Tag(Tag, e => e
			           ["class", CssClass, !CssClass.IsNullOrEmpty()]
			           ["data-cell", dataAttribute, Data != null])
				.TagIf(!NavigateUrl.IsNullOrEmpty(), "a", e => e
				       ["href", NavigateUrl]
				       ["target", Target.HtmlAttributeValue()])
					.Text(Text)
					.DoIf(!DataField.IsNullOrEmpty(), wr => wr.Text(bindValue))
				.Do(RenderChildren)
				.EndTagIf(!NavigateUrl.IsNullOrEmpty())
			.EndTag();
		}
	}
}

