using System;
using System.Collections.Specialized;
using System.Web;

namespace Siteimprove.Extensions.UriExtensions
{
	public static class UriExtensions
	{
		/// <summary>
		/// Takes the current <see cref="Uri"/> and alters its existing query string with the values in the passed query collection
		/// </summary>
		/// <param name="uri">The URI.</param>		
		/// <param name="queryString">The Query String </param>
		/// <returns>a new URI with the query string altered to contain the keys and values passed in <paramref name="queryString"/>.</returns>
		public static Uri WithAlteredQuery(this Uri uri, NameValueCollection queryString)
		{
			var uriBuilder = new UriBuilder(uri);

			var oldQueryString = HttpUtility.ParseQueryString(uri.Query);

			foreach (var key in queryString.AllKeys) {
				oldQueryString[key] = queryString[key];
			}

			uriBuilder.Query = oldQueryString.ToString();

			return uriBuilder.Uri;
		}
	}
}
