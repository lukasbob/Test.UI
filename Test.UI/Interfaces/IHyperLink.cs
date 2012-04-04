
namespace Siteimprove.UI.Interfaces
{
	public interface IHyperLink
	{
		/// <summary>
		/// Gets or sets the link target.
		/// </summary>
		/// <value>
		/// The link target.
		/// </value>
		LinkTarget Target { get; set; }

		/// <summary>
		/// Gets or sets the navigate URL.
		/// </summary>
		/// <value>
		/// The navigate URL.
		/// </value>
		string NavigateUrl { get; set; }
	}
}
