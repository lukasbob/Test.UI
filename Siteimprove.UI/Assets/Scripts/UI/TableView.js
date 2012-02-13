/*globals Faux:false,SI:false*/
(function(global, undefined) {

	"use strict";

	/**
	 * Represents a table view.
	 * @type {Faux}
	 */
	var TableView = SI.UI.TableView = SI.UI.View.extend({

		tooltipElement: $("<div class='tip'/>"),

		events: {
			"click th a": "sort",
			"click button.refresh-row": "refreshRow",
			"row-refreshed": "setRefreshMessage"
		},

		sort: function (e) {
			e.preventDefault();
			var url = e.currentTarget.href;
		},

		refreshRow: function (e) {
			var self = this,
				currentRow = $(e.currentTarget).parents("tr"),
				rowNum = parseInt(currentRow.data("rownum"), 10);

			this.update({
				params: {
					startrow: rowNum,
					rowcount: 1
				},
				success: function (data) {
					var newRow = $(data).find("[data-rownum=" + rowNum + "]").get(0);
					currentRow.replaceWith(newRow);
					self.fire("row-refreshed", [currentRow]);
				}
			});
		},

		setRefreshMessage: function () {
			console.log("refresh message set here");
		},

		hideTooltip: function(e) {
			this._config.tooltipElement.empty();
		},

		update: function (opts) {
			var url = location.href,
				uri = SI.Utils.parseUri(url);
			$.ajax({
				url: uri.url + "?" + $.param(opts.params) + $.param(uri.queryString),
				success: opts.success
			});
		}
	});

})(this);
