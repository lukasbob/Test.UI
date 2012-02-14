<%@ Page Language="C#" Inherits="Siteimprove.UI.MonoTest.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
		<link href="<%= Page.ClientScript.GetWebResourceUrl(typeof(BaseControl), "Siteimprove.UI.Static.siteimprove-ui.css") %>" rel="stylesheet"/>
</head>
<body>
	<section>
		<header><h1>Buttons</h1></header>
		
		<h2>Simple button</h2>
	 	<div class="content">
			<SI:Button Text="Hello" ID="buttonWithData" runat="server" />
			<textarea><SI:Button Text="Hello" runat="server" /></textarea>
		</div>
		
		<h2>Button with icon on the left</h2>
	 	<div class="content">		
			<SI:Button Text="Hello" IconPosition="Left" runat="server"/>
			<textarea><SI:Button Text="Hello" IconPosition="Left" runat="server"/></textarea>
		</div>
		
		<h2>Button with icon on the right</h2>
	 	<div class="content">		
			<SI:Button Text="Hello" IconPosition="Right" runat="server"/>
			<textarea><SI:Button Text="Hello" IconPosition="Right" runat="server"/></textarea>
		</div>
		
		<h2>Button with custom child HTML</h2>
	 	<div class="content">	 		
			<SI:Button Text="Hello" IconPosition="Right" runat="server"><span>With children</span></SI:Button>
			<textarea><SI:Button Text="Hello" runat="server"><span class="child-node">With children (Bugfix)</span></SI:Button></textarea>
		</div>
			
	</section>
	
	<section>
		<header><h1>Link buttons</h1></header>
			
		<h2>Simple</h2>
		<div class="content">			
			<SI:LinkButton NavigateUrl="http://google.com" Text="Boo" runat="server" />
			<textarea><SI:LinkButton NavigateUrl="http://google.com" Text="Boo" runat="server" /></textarea>
		</div>
	</section>
	
	<section>
		<header><h1>Table View</h1></header>		
	</section>

</body>
</html>
