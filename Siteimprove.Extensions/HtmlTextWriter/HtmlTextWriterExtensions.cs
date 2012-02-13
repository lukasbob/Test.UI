namespace Siteimprove.Extensions.HtmlTextWriter {
	using System;
	using System.Collections.Generic;
	using System.Web;
	using System.Web.UI;
	using siteimprove.controls;

	/// <summary>
	/// Provides extension methods for the HtmlTextWriterClass.
	/// </summary>
	public static class HtmlTextWriterExtensions {

		public static System.Web.UI.HtmlTextWriter DoIfElse(this System.Web.UI.HtmlTextWriter writer, bool test, Action<System.Web.UI.HtmlTextWriter> iffunc, Action<System.Web.UI.HtmlTextWriter> elsefunc) {
			if (test) {
				iffunc(writer);
			} else {
				elsefunc(writer);
			}
			return writer;
		}

		public static System.Web.UI.HtmlTextWriter AddControl(this System.Web.UI.HtmlTextWriter writer, Control ctrl) {
			ctrl.RenderControl(writer);
			return writer;
		}

		public static System.Web.UI.HtmlTextWriter Do(this System.Web.UI.HtmlTextWriter writer, Action<System.Web.UI.HtmlTextWriter> func) {
			func(writer);
			return writer;
		}

		/// <summary>
		/// Exececutes a function if a condition is met.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="test">The condition for the function to be executed.</param>
		/// <param name="func">The function to be executed if "test" is true.</param>
		/// <returns>The writer.</returns>
		/// 
		public static System.Web.UI.HtmlTextWriter DoIf(this System.Web.UI.HtmlTextWriter writer, bool test, Action<System.Web.UI.HtmlTextWriter> func) {
			if (test)
				func(writer);
			return writer;
		}

		/// <summary>
		/// Renders a start tag if a condition is met, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tag">The tag to render the start tag of.</param>
		/// <param name="test">The condition for the tag to be rendered.</param>
		/// <returns>The writer.</returns>
		/// 
		public static System.Web.UI.HtmlTextWriter TagIf(this System.Web.UI.HtmlTextWriter writer, bool test, HtmlTextWriterTag tag) {
			if (test) {
				writer.RenderBeginTag(tag);
			}
			return writer;
		}
		/// <summary>
		/// Renders a start tag if a condition is met, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tagName">The tag to render the start tag of.</param>
		/// <param name="test">The condition for the tag to be rendered.</param>
		/// <returns>The writer.</returns>
		/// 
		public static System.Web.UI.HtmlTextWriter TagIf(this System.Web.UI.HtmlTextWriter writer, bool test, string tagName) {
			if (test) {
				writer.RenderBeginTag(tagName);
			}
			return writer;
		}
		/// <summary>
		/// Renders a start tag if a condition is met, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tag">The tag to render the start tag of.</param>
		/// <param name="test">The condition for the tag to be rendered.</param>
		/// <returns>The writer.</returns>
		/// 
		public static System.Web.UI.HtmlTextWriter TagIf(this System.Web.UI.HtmlTextWriter writer, bool test, HtmlTextWriterTag tag, Func<HtmlAttributeManager, HtmlAttributeManager> appender) {
			if (test) {
				HtmlAttributeManager manager = new HtmlAttributeManager(writer);
				appender(manager);
				writer.RenderBeginTag(tag);
			}
			return writer;
		}
		/// <summary>
		/// Renders a start tag if a condition is met, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tagName">The tag to render the start tag of.</param>
		/// <param name="test">The condition for the tag to be rendered.</param>
		/// <returns>The writer.</returns>
		/// 
		public static System.Web.UI.HtmlTextWriter TagIf(this System.Web.UI.HtmlTextWriter writer, bool test, string tagName, Func<HtmlAttributeManager, HtmlAttributeManager> appender) {
			if (test) {
				HtmlAttributeManager manager = new HtmlAttributeManager(writer);
				appender(manager);
				writer.RenderBeginTag(tagName);
			}
			return writer;
		}
		/// <summary>
		/// Renders a start tag, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tag">The tag to render the start tag of.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Tag(this System.Web.UI.HtmlTextWriter writer, HtmlTextWriterTag tag) {
			writer.RenderBeginTag(tag);

			return writer;
		}
		/// <summary>
		/// Renders a start tag, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tagName">The tag to render the start tag of.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Tag(this System.Web.UI.HtmlTextWriter writer, string tagName) {
			writer.RenderBeginTag(tagName);

			return writer;
		}
		/// <summary>
		/// Renders a start tag, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tag">The tag to render the start tag of.</param>
		/// <param name="appender">A delegate that takes in an HtmlAttributeManager for appending
		/// attributes to the start tag.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Tag(this System.Web.UI.HtmlTextWriter writer, HtmlTextWriterTag tag, Func<HtmlAttributeManager, HtmlAttributeManager> appender) {

			HtmlAttributeManager manager = new HtmlAttributeManager(writer);
			appender(manager);

			writer.RenderBeginTag(tag);

			return writer;
		}
		/// <summary>
		/// Renders a start tag, the tag is closed by a call to the EndTag-method.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="tagName">The tag to render the start tag of.</param>
		/// <param name="appender">A delegate that takes in an HtmlAttributeManager for appending
		/// attributes to the start tag.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Tag(this System.Web.UI.HtmlTextWriter writer, string tagName, Func<HtmlAttributeManager, HtmlAttributeManager> appender) {

			HtmlAttributeManager manager = new HtmlAttributeManager(writer);
			appender(manager);

			writer.RenderBeginTag(tagName);

			return writer;
		}

		/// <summary>
		/// Renders a Div start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Div(this System.Web.UI.HtmlTextWriter writer) {
			return writer.Tag(HtmlTextWriterTag.Div);
		}

		/// <summary>
		/// Renders a Div start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="appender">A delegate that takes in an HtmlAttributeManager for appending
		/// attributes to the start tag.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Div(this System.Web.UI.HtmlTextWriter writer, Func<HtmlAttributeManager, HtmlAttributeManager> attributes) {
			return writer.Tag(HtmlTextWriterTag.Div, attributes);
		}

		/// <summary>
		/// Renders a Body start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Body(this System.Web.UI.HtmlTextWriter writer) {
			return writer.Tag(HtmlTextWriterTag.Body);
		}

		/// <summary>
		/// Renders a Body start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="appender">A delegate that takes in an HtmlAttributeManager for appending
		/// attributes to the start tag.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Body(this System.Web.UI.HtmlTextWriter writer, Func<HtmlAttributeManager, HtmlAttributeManager> attributes) {
			return writer.Tag(HtmlTextWriterTag.Body, attributes);
		}

		/// <summary>
		/// Renders a Html start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Html(this System.Web.UI.HtmlTextWriter writer) {
			return writer.Tag(HtmlTextWriterTag.Html);
		}

		/// <summary>
		/// Renders a Html start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="appender">A delegate that takes in an HtmlAttributeManager for appending
		/// attributes to the start tag.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Html(this System.Web.UI.HtmlTextWriter writer, Func<HtmlAttributeManager, HtmlAttributeManager> attributes) {
			return writer.Tag(HtmlTextWriterTag.Html, attributes);
		}

		/// <summary>
		/// Renders a Span start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Span(this System.Web.UI.HtmlTextWriter writer) {
			return writer.Tag(HtmlTextWriterTag.Span);
		}

		/// <summary>
		/// Renders a Span start tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="attributes">A delegate that takes in an HtmlAttributeManager for appending
		/// attributes to the start tag.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Span(this System.Web.UI.HtmlTextWriter writer, Func<HtmlAttributeManager, HtmlAttributeManager> attributes) {
			return writer.Tag(HtmlTextWriterTag.Span, attributes);
		}

		/// <summary>
		/// Renders an anchor tag.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="url">The url of the hyperlink.</param>
		/// <param name="title">The title of the hyperlink.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Href(this System.Web.UI.HtmlTextWriter writer, string url, string title) {

			return writer.Tag(HtmlTextWriterTag.A, e => e[HtmlTextWriterAttribute.Href, url]);
		}


		/// <summary>
		/// Closes the latest started tag.
		/// </summary>
		/// <param name="writer">The writer to render the end tag to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter EndTag(this System.Web.UI.HtmlTextWriter writer) {
			writer.RenderEndTag();
			return writer;
		}
		public static System.Web.UI.HtmlTextWriter EndTagIf(this System.Web.UI.HtmlTextWriter writer, bool test) {
			if (test) {
				writer.RenderEndTag();
			}
			return writer;
		}

		/// <summary>
		/// Closes the latest started tag.
		/// </summary>
		/// <param name="writer">The writer to render the end tag to.</param>
		/// <param name="ignored">The tag this call closes, only specified for readability,
		/// this parameter is ignored.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter EndTag(this System.Web.UI.HtmlTextWriter writer, HtmlTextWriterTag ignored) {
			return writer.EndTag();
		}
		public static System.Web.UI.HtmlTextWriter EndTag(this System.Web.UI.HtmlTextWriter writer, string tagName) {
			return writer.EndTag();
		}
		/// <summary>
		/// Closes the latest started tag if a condition is met.
		/// </summary>
		/// <param name="writer">The writer to render the end tag to.</param>
		/// <param name="ignored">The tag this call closes, only specified for readability,
		/// this parameter is ignored.</param>
		/// <param name="test">The condition to be met.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter EndTagIf(this System.Web.UI.HtmlTextWriter writer, bool test, HtmlTextWriterTag ignored) {
			if (test) {
				writer.EndTag();
			}
			return writer;
		}
		/// <summary>
		/// Closes the latest started tag if a condition is met.
		/// </summary>
		/// <param name="writer">The writer to render the end tag to.</param>
		/// <param name="ignored">The tag this call closes, only specified for readability,
		/// this parameter is ignored.</param>
		/// <param name="test">The condition to be met.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter EndTagIf(this System.Web.UI.HtmlTextWriter writer, bool test, string tagName) {
			if (test) {
				writer.EndTag();
			}
			return writer;
		}
		/// <summary>
		/// Renders a text literal to the writer.
		/// </summary>
		/// <param name="writer">The writer to render the text to.</param>
		/// <param name="text">The text to render.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Text(this System.Web.UI.HtmlTextWriter writer, string text) {
			return writer.Text(text, false);
		}

		/// <summary>
		/// Renders a text literal to the writer.
		/// </summary>
		/// <param name="writer">The writer to render the text to.</param>
		/// <param name="text">The text to render.</param>
		/// <param name="htmlEncode">If set to true the text will be html-encoded.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Text(this System.Web.UI.HtmlTextWriter writer, string text, bool htmlEncode) {
			if (htmlEncode) {
				writer.Write(HttpUtility.HtmlEncode(text));
			} else {
				writer.Write(text);
			}

			return writer;
		}

		/// <summary>
		/// Renders a text literal to the writer.
		/// </summary>
		/// <param name="writer">The writer to render the text to.</param>
		/// <param name="value">An object that represents the text to be written.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Text(this System.Web.UI.HtmlTextWriter writer, object value) {
			if (value != null) {
				IFormattable formattable = value as IFormattable;
				if (formattable != null) {
					writer.Text(formattable.ToString(null, null));
				} else {
					writer.Text(value.ToString());
				}
			}

			return writer;
		}

		/// <summary>
		/// Repeats over the specified collection.
		/// </summary>
		/// <typeparam name="T">The type of items in the collection.</typeparam>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="collection">The collection to repeat over.</param>
		/// <param name="binder">A function that will be called for each of the elements
		/// in the collection, the first parameter is the item in the collection, the second
		/// parameter the index of the item in the collection, and the third is the writer
		/// to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Bind<T>(this System.Web.UI.HtmlTextWriter writer,
			 IEnumerable<T> collection, Func<T, int, System.Web.UI.HtmlTextWriter, System.Web.UI.HtmlTextWriter> binder) {

			int index = 0;
			foreach (T item in collection) {
				binder(item, index++, writer);
			}

			return writer;
		}
		/// <summary>
		/// Repeats over the specified collection.
		/// </summary>
		/// <typeparam name="T">The type of items in the collection.</typeparam>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="collection">The collection to repeat over.</param>
		/// <param name="binder">A function that will be called for each of the elements
		/// in the collection, the first parameter is the item in the collection, the second
		/// parameter the index of the item in the collection, and the third is the writer
		/// to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Bind<T>(this System.Web.UI.HtmlTextWriter writer,
			  IEnumerable<T> collection, Action<T, int, System.Web.UI.HtmlTextWriter> binder) {

			int index = 0;
			foreach (T item in collection) {
				binder(item, index++, writer);
			}

			return writer;
		}
		/// <summary>
		/// Repeats over the specified collection.
		/// </summary>
		/// <typeparam name="T">The type of items in the collection.</typeparam>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="collection">The collection to repeat over.</param>
		/// <param name="binder">A function that will be called for each of the elements
		/// in the collection, the first parameter is the item in the collection, the second
		/// parameter the index of the item in the collection, the third is the writer
		/// to render to, and the fourth and fifth are booleans stating if the current
		/// item is respectively the first or the last item in the collection.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Bind<T>(this System.Web.UI.HtmlTextWriter writer,
			  IEnumerable<T> collection, Action<T, int, System.Web.UI.HtmlTextWriter, bool, bool> binder) {

			int index = 0;
			bool first = true;
			IEnumerator<T> enu = collection.GetEnumerator();

			if (!enu.MoveNext()) return writer;

			T current = enu.Current;
			while (enu.MoveNext()) {
				binder(current, index++, writer, first, false);
				current = enu.Current;
				first = false;
			}
			binder(current, index, writer, first, true);

			return writer;
		}

		/// <summary>
		/// Repeats the specified number of times.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="times">The number of times to repeat.</param>
		/// <param name="binder">A function that will be called the specified number of times,
		/// the first parameter is the number of the call (starting with one), the
		/// second parameter is the writer to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Repeat(this System.Web.UI.HtmlTextWriter writer, int times,
			 Func<int, System.Web.UI.HtmlTextWriter, System.Web.UI.HtmlTextWriter> binder) {
			if (times < 0) throw new ArgumentOutOfRangeException("times");

			for (int i = 1; i <= times; i++) {
				binder(i, writer);
			}

			return writer;
		}

		/// <summary>
		/// Repeats the specified number of times.
		/// </summary>
		/// <param name="writer">The writer to render to.</param>
		/// <param name="times">The number of times to repeat.</param>
		/// <param name="binder">A function that will be called the specified number of times,
		/// the first parameter is the number of the call (starting with one), the
		/// second parameter is the writer to render to.</param>
		/// <returns>The writer.</returns>
		public static System.Web.UI.HtmlTextWriter Repeat(this System.Web.UI.HtmlTextWriter writer, int times,
			  Action<int, System.Web.UI.HtmlTextWriter> binder) {
			if (times < 0) throw new ArgumentOutOfRangeException("times");

			for (int i = 1; i <= times; i++) {
				binder(i, writer);
			}

			return writer;
		}

		/// <summary>
		/// If the attribute value is not null or empty, adds the markup attribute and the attribute value to the opening tag of the
		/// element that the System.Web.UI.HtmlTextWriter object creates with a subsequent
		/// call to the Overload:System.Web.UI.HtmlTextWriter.RenderBeginTag method.
		/// </summary>		
		/// <param name="HTMLAttrName">A string containing the name of the attribute to add.</param>
		/// <param name="value">A string containing the value to assign to the attribute.</param>
		public static void AddAttributeIfNotEmpty(this System.Web.UI.HtmlTextWriter writer, string HTMLAttrName, string value) {
			writer.AddAttributeIfNotEmpty(HTMLAttrName, value, false);
		}
		public static void AddAttributeIfNotEmpty(this System.Web.UI.HtmlTextWriter writer, string HTMLAttrName, string value, bool fEncode) {
			if (!String.IsNullOrEmpty(value)) {
				writer.AddAttribute(HTMLAttrName, value, fEncode);
			}
		}
		/// <summary>
		/// If the boolean expression is true, adds the markup attribute and the attribute value to the opening tag of the
		/// element that the System.Web.UI.HtmlTextWriter object creates with a subsequent
		/// call to the Overload:System.Web.UI.HtmlTextWriter.RenderBeginTag method.
		/// </summary>		
		/// <param name="HTMLAttrName">A string containing the name of the attribute to add.</param>		
		/// <param name="expression">A boolean expression thatr indicates whether the attribute should be written.</param>
		public static void AddAttributeIfTrue(this System.Web.UI.HtmlTextWriter writer, string HTMLAttrName, bool expression) {
			if (expression) {
				writer.AddAttribute(HTMLAttrName, HTMLAttrName);
			}
		}

	}
}
