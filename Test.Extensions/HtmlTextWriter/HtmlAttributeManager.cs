using System;
using System.Text;
using System.Web.UI;

namespace Test.Extensions.HtmlTextWriter {
	/// <summary>
	/// Handles the writing of attributes to the HtmlTextWriter specified
	/// in the constructor.
	/// </summary>
	public class HtmlAttributeManager {
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="writer">The writer to use for writing.</param>
		public HtmlAttributeManager(System.Web.UI.HtmlTextWriter writer) {			

			this.Writer = writer;
		}

		/// <summary>
		/// The writer this manager writes to.
		/// </summary>
		public System.Web.UI.HtmlTextWriter Writer { get; private set; }

		/// <summary>
		/// Applies the value to the specified attribute to the HtmlTextWriter
		/// this instance contains.
		/// </summary>
		/// <param name="attribute">The attribute to set.</param>
		/// <param name="value">The value to set to the attribute.</param>
		/// <returns>The attribute manager.</returns>
		public HtmlAttributeManager this[System.Web.UI.HtmlTextWriterAttribute attribute, string value] {
			get {
				if (!String.IsNullOrEmpty(value)) {
					this.Writer.AddAttribute(attribute, value);
				}
				return this;
			}
		}

        /// <summary>
        /// Applies the value to the specified attribute to the HtmlTextWriter
        /// this instance contains.
        /// </summary>
        /// <param name="attrName">The attribute to set.</param>
        /// <param name="value">The value to set to the attribute.</param>
        /// <returns>The attribute manager.</returns>
		public HtmlAttributeManager this[string attrName, string value] {
			get {
				if (!String.IsNullOrEmpty(value)) {
					this.Writer.AddAttribute(attrName, value); 
				}
				return this;
			}
		}

        /// <summary>
        /// Applies the value to the specified attribute to the HtmlTextWriter
        /// this instance contains if test evaluates to true.
        /// </summary>
        /// <param name="attribute">The attribute to set.</param>
        /// <param name="value">The value to set to the attribute.</param>
        /// <param name="test">The condition for the attribute to be added.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager this[System.Web.UI.HtmlTextWriterAttribute attribute, string value, bool test] {
            get {
                if (!test) return this;
                if (!String.IsNullOrEmpty(value)) {
                    this.Writer.AddAttribute(attribute, value);
                }
                return this;
            }
        }

        /// <summary>
        /// Applies the value to the specified attribute to the HtmlTextWriter
        /// this instance contains if test evaluates to true.
        /// </summary>
        /// <param name="attrName">The attribute to set.</param>
        /// <param name="value">The value to set to the attribute.</param>
        /// <param name="test">The condition for the attribute to be added.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager this[string attrName, string value, bool test] {
            get {
                if (!test) return this;
                if (!String.IsNullOrEmpty(value)) {
                    this.Writer.AddAttribute(attrName, value);
                }
                return this;
            }
        }

		/// <summary>
		/// Adds the class attribute to the tag being rendered.
		/// </summary>
		/// <param name="className">The name of the class.</param>
		/// <returns>The attribute manager.</returns>
		public HtmlAttributeManager Class(string className) {
			return this[HtmlTextWriterAttribute.Class, className];
		}

		/// <summary>
		/// Adds the class attribute to the tag being rendered.
		/// </summary>
		/// <param name="classNames">The names of the classes to set to the attribute.</param>
		/// <returns>The attribute manager.</returns>
		public HtmlAttributeManager Class(params string[] classNames) {
			StringBuilder namesString = new StringBuilder();

			foreach (string name in classNames) {
				if (namesString.Length > 0) {
					namesString.Append(" ");
				}

				namesString.Append(name);
			}

			return this[HtmlTextWriterAttribute.Class, namesString.ToString()];
		}

		/// <summary>
		/// Adds the id attribute to the tag being rendered.
		/// </summary>
		/// <param name="className">The id to set.</param>
		/// <returns>The attribute manager.</returns>
		public HtmlAttributeManager Id(string elementId) {
			return this[HtmlTextWriterAttribute.Id, elementId];
		}

		/// <summary>
		/// Adds the name attribute to the tag being rendered.
		/// </summary>
		/// <param name="className">The name to set.</param>
		/// <returns>The attribute manager.</returns>
		public HtmlAttributeManager Name(string elementName) {
			return this[HtmlTextWriterAttribute.Name, elementName];
		}


	}
}
