/*globals SI*/
(function(window, undefined) {

	"use strict";

	var Utils = SI.Utils = {
		/**
		 * Parses a URL into a URL string and a query string object.
		 * @param  {[type]} url [description]
		 * @return {[type]}
		 */
		parseUri: function(url) {
			var queryString = {}, urlNoQs;
			url.replace(
				new RegExp("([^?=&]+)(=([^&]*))?", "g"),
				function($0, $1, $2, $3) { if (typeof $3 !== "undefined") {
					queryString[$1] = $3;
				} else {
					urlNoQs = $0;
				}
			});
			return {url: urlNoQs, queryString: queryString };
		}
	};

})(window);
