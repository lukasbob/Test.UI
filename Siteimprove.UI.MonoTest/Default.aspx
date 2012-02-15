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
		</div>
		
		<h2>Button with icon on the left</h2>
		<div class="content">		
			<SI:Button ID="Button2" Text="Hello" IconPosition="Left" runat="server"/>
		</div>
		
		<h2>Button with icon on the right</h2>
		<div class="content">		
			<SI:Button ID="Button4" Text="Hello" IconPosition="Right" runat="server"/>
		</div>
		
		<h2>Button with custom child HTML</h2>
		<div class="content">	 		
			<SI:Button ID="Button6" Text="Hello" IconPosition="Right" runat="server"> <span>With children</span></SI:Button>
		</div>
	</section>
	
	<section>
		<header><h1>Link buttons</h1></header>
			
		<h2>Simple</h2>
		<div class="content">			
			<SI:LinkButton ID="LinkButton1" NavigateUrl="http://google.com" Text="Boo" runat="server" />
		</div>
	</section>	

	<section>
		<header><h1>Grid</h1></header>
		<h2>Simple Table</h2>
		<div class="content">
			<SI:Grid Summary="a short table summary" Caption="Caption" ID="TableView1" runat="server">
				<Columns>
					<SI:Column DataField="Col1" runat="server" Width=100 />
					<SI:Column DataField="Col2" runat="server" Width=200 />
					<SI:Column DataField="Col3" runat="server" Width=120 />
					<SI:Column DataField="Col4" runat="server" />
				</Columns>
				<EmptyTemplate>
					<SI:Column Text="No data found" runat="server"/>
				</EmptyTemplate>
			</SI:Grid>
		</div>
		
		<h2>Simple Table with an empty template</h2>
		<div class="content">
			<SI:Grid Summary="a short table summary" Caption="Foobar" ID="TableView2" runat="server">
				<Columns>
					<SI:Column DataField="Col1" runat="server" />
					<SI:Column DataField="Col2" runat="server" />
					<SI:Column DataField="Col3" runat="server" />
					<SI:Column DataField="Col4" runat="server" />
				</Columns>
				<EmptyTemplate>
					<SI:Column Text="No data found" runat="server"/>
				</EmptyTemplate>
			</SI:Grid>
		</div>
	</section>		

</body>
</html>
