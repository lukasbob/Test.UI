using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Siteimprove.UI.MonoTest
{
	public partial class Default : System.Web.UI.Page
	{
		protected override void OnLoad (EventArgs e)
		{
			buttonWithData.Data = new List<string>{ "boo", "foo" };
			base.OnLoad (e);
		}
	
	}
}

