/*globals _:false,SI:false*/
(function (global, undefined) {

	"use strict";

	var eventSplitter = /^(\S+)\s*(.*)$/;

	/**
	 * View for handling common UI actions: event binding and delegation.
	 * @type {[type]}
	 */
	var View = SI.Base.extend({

		constructor: function (opts) {
			this.cid = _.uniqueId("comp");
			if (opts && opts.el) { this.el = opts.el; }
			this.delegateEvents();
			this.initialize.apply(this, arguments);
		},

		initialize: function() {},

		fire: function (eventName, args) {
			$(this.el).trigger(eventName, args);
		},

		on: function (eventName, fnc) {
			$(this.el).on(eventName, fnc);
		},

		off: function (eventName) {
			$(this.el).off(eventName);
		},

		delegateEvents: function () {
			var events = this.events;
			if (!events) { return; }
			var key, match, eventName, selector, method, methodName;
			for (key in events) {
				methodName = events[key];
				match = key.match(eventSplitter);
				eventName = match[0];
				selector = match[2];
				method = this[methodName];

				if (typeof method === "undefined") {
					throw "No method named \"" + methodName + "\"";
				}

				method = _.bind(method, this);
				eventName += ".delegate" + this.cid;
				$(this.el).on(eventName, selector, method);
			}
		},

		destroy: function () {

		}
	});

	SI.UI.View = View;

})(this);
