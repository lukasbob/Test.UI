<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Siteimprove.UI.MonoTest.Default" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<title>Default</title>
		<link href="<%= Page.ClientScript.GetWebResourceUrl(typeof(BaseControl), "Siteimprove.UI.Static.siteimprove-ui.css") %>" rel="stylesheet"/>
</head>
<body>	
	<section>
		<header><h1>Buttons</h1></header>
		
		<h2>Simple button</h2>
		<div class="content">
			<SI:Button Text="Hello" ID="buttonWithData" runat="server" />
			<textarea><SI:Button ID="Button1" Text="Hello" runat="server" /></textarea>
		</div>
		
		<h2>Button with icon on the left</h2>
		<div class="content">		
			<SI:Button ID="Button2" Text="Hello" IconPosition="Left" runat="server"/>
			<textarea><SI:Button ID="Button3" Text="Hello" IconPosition="Left" runat="server"/></textarea>
		</div>
		
		<h2>Button with icon on the right</h2>
		<div class="content">		
			<SI:Button ID="Button4" Text="Hello" IconPosition="Right" runat="server"/>
			<textarea><SI:Button ID="Button5" Text="Hello" IconPosition="Right" runat="server"/></textarea>
		</div>
		
		<h2>Button with custom child HTML</h2>
		<div class="content">	 		
			<SI:Button ID="Button6" Text="Hello" IconPosition="Right" runat="server"><span>With children</span></SI:Button>
			<textarea><SI:Button ID="Button7" Text="Hello" runat="server"><span class="child-node">With children (Bugfix)</span></SI:Button></textarea>
		</div>
			
	</section>
	
	<section>
		<header><h1>Link buttons</h1></header>
			
		<h2>Simple</h2>
		<div class="content">			
			<SI:LinkButton ID="LinkButton1" NavigateUrl="http://google.com" Text="Boo" runat="server" />
			<textarea><SI:LinkButton ID="LinkButton2" NavigateUrl="http://google.com" Text="Boo" runat="server" /></textarea>
		</div>
	</section>	

	<section>
		<header><h1>Table View</h1></header>
		<h2>Simple Table</h2>	
		<SI:TableView ID="TableView1" runat="server">
			<RowTemplate>
					<SI:Cell runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Col1") %>' />
					<SI:Cell runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Col2") %>' />
					<SI:Cell runat="server" Bind='<%# DataBinder.GetPropertyValue(Container.DataItem, "Col1") %>' />

			</RowTemplate>
		</SI:TableView>
	</section>		

</body>
</html>
