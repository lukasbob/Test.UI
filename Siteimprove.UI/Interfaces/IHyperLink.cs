
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
		LinkTarget LinkTarget { get; set; }

		string LinkUrl { get; set; }
	}
}
