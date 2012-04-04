/*globals Faux:false, SI:false*/
(function(window, undefined) {

	"use strict";

	$(function () {
		$('.tableview').each(function() {
			var tbl = new SI.UI.TableView({ el: this });
		});
	});

})(window);
