<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<!--
Design by Free CSS Templates
http://www.freecsstemplates.org
Released for free under a Creative Commons Attribution 2.5 License

Name       : TwoColours 
Description: A two-column, fixed-width design with dark color scheme.
Version    : 1.0
Released   : 20130811

-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600,700,900" rel="stylesheet" />
<link href="default.css" rel="stylesheet" type="text/css" media="all" />
<link href="fonts.css" rel="stylesheet" type="text/css" media="all" />

<!--[if IE 6]><link href="default_ie6.css" rel="stylesheet" type="text/css" /><![endif]-->

    <style type="text/css">
        .auto-style1 {
            width: 260px;
        }
        .auto-style2 {
            width: 374px;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            width: 253px;
            height: 30px;
        }
        .auto-style5 {
            height: 28px;
        }
        .auto-style6 {
            width: 374px;
            height: 28px;
        }
        .auto-style7 {
            height: 28px;
            width: 253px;
        }
    </style>

</head>
<body>
<div id="header">
	<div id="menu" class="container">
		<ul>
			<li><a href="Homepage.aspx" accesskey="1" title="">Homepage</a></li>
			<li><a href="HowItWorks.aspx" accesskey="2" title="">How Does It Work</a></li>
			<li class="current_page_item"><a href="#" accesskey="3" title="">Try</a></li>
			<li><a href="AboutUs.aspx" accesskey="4" title="">About Us</a></li>			
		</ul>
	</div>
</div>
<div id="logo" class="container">
	<h1><a href="#">b2b clustering</a></h1>
</div>

<div id="featured-wrapper">
	<div id="featured" class="container">
		<div class="major">
			<h2>KULUSTUR</h2>
			<span class="byline">
            <form id="form1" runat="server">
   
    
         <table border="1" style="width:1000px;  margin: 0 auto;">
            <tr><td class="auto-style1"><b style="font-weight: bold">FILTERS</b></td><td class="auto-style4">&nbsp;</td><td class="auto-style3"></td><td class="auto-style2"><b style="font-weight: bold">ATTRIBUTES</b></td><td><b style="font-weight: bold">WEIGHT</b></td></tr>
             <tr><td class="auto-style1">
                 <asp:CheckBox ID="cbRegion" runat="server"  Text="Region" AutoPostBack="True" OnCheckedChanged="cbRegion_CheckedChanged" />
                 </td><td class="auto-style4">
                 <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" Enabled="False">
                     <asp:ListItem Value="0">ALL</asp:ListItem>
                     <asp:ListItem Value="1">Turkey</asp:ListItem>
                     <asp:ListItem Value="2">Abroad</asp:ListItem>
                 </asp:DropDownList>
                 </td><td class="auto-style3">&nbsp;</td><td class="auto-style2">
                     <asp:CheckBox ID="cbRecency" runat="server" Text="Recency" AutoPostBack="True" OnCheckedChanged="cbRecency_CheckedChanged" />
                 </td><td>
                 <center><asp:TextBox ID="txtRecency" runat="server" Width="29px" MaxLength="2" Enabled="False"></asp:TextBox></center>
                 </td></tr>
             
              <tr><td class="auto-style1">
                  <asp:CheckBox ID="cbCity" runat="server" Text="City" AutoPostBack="True" OnCheckedChanged="cbCity_CheckedChanged" />
                  </td><td class="auto-style4">
                  <asp:TextBox ID="txtCity" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                       </td><td class="auto-style3">&nbsp;</td><td class="auto-style2">
                      <asp:CheckBox ID="cbFrequency" runat="server"  Text="Frequency" AutoPostBack="True" OnCheckedChanged="cbFrequency_CheckedChanged" />
                       </td><td>
                <center>  <asp:TextBox ID="txtFrequency" runat="server" Width="29px" MaxLength="2" Enabled="False"></asp:TextBox></center>
                  </td></tr>
                 <tr><td class="auto-style1">
                     <asp:CheckBox ID="cbTime" runat="server"  Text="Time" AutoPostBack="True" OnCheckedChanged="cbTime_CheckedChanged" />
                     </td><td class="auto-style4">
                     <asp:DropDownList ID="DropDownList2" runat="server" Width="100px" Enabled="False">
                         <asp:ListItem Value="0">ALL</asp:ListItem>
                         <asp:ListItem Value="1">2015</asp:ListItem>
                         <asp:ListItem Value="2">2014</asp:ListItem>
                     </asp:DropDownList>
                          </td><td class="auto-style3">&nbsp;</td><td class="auto-style2">
                         <asp:CheckBox ID="cbMonetary" runat="server"  Text="Monetary" AutoPostBack="True" OnCheckedChanged="cbMonetary_CheckedChanged"/>
                          </td><td>
                    <center> <asp:TextBox ID="txtMonetary" runat="server" Width="29px" MaxLength="2" Enabled="False"></asp:TextBox></center>
                     </td></tr>

             <tr><td>
                     &nbsp;</td><td class="auto-style4">
                         &nbsp;</td><td class="auto-style3">&nbsp;</td><td class="auto-style2">
                         <asp:CheckBox ID="cbDiscount" runat="server"  Text="Discount Rate" AutoPostBack="True" OnCheckedChanged="cbDiscount_CheckedChanged" />
                          </td><td>
                 <center>    <asp:TextBox ID="txtDiscount" runat="server" Width="29px" MaxLength="2" Enabled="False"></asp:TextBox></center>
                     </td></tr>
             <tr><td class="auto-style5">Iteration</td><td class="auto-style7">
                  <asp:TextBox ID="txtIteration" runat="server" Width="100px"></asp:TextBox>
                  </td><td class="auto-style5"></td><td class="auto-style6">
                  <asp:CheckBox ID="cbAmount" runat="server" Text="Amount per Transaction" AutoPostBack="True" OnCheckedChanged="cbAmount_CheckedChanged" />
                 </td><td class="auto-style5">
                                  <center>        <asp:TextBox ID="txtAmount" runat="server" Width="29px" MaxLength="2" Enabled="False"></asp:TextBox></center>

			</td></tr>
             <tr><td>
    
                 Clusters</td><td class="auto-style4">
    
                  <asp:TextBox ID="txtClusters" runat="server" Width="100px"></asp:TextBox>
                 </td><td class="auto-style3"></td><td class="auto-style2">
                  &nbsp;</td><td>&nbsp;</td></tr>
             <tr><td>
    
                 &nbsp;</td><td class="auto-style4">
    
                     &nbsp;</td><td class="auto-style3">
    
    
        <asp:Button ID="cluster" runat="server" OnClick="cluster_Click" Text="Cluster" />
                 </td><td class="auto-style2"></td><td></td></tr>
      


        </table>   
    
    </form>
    
    
            </div>
	</div>
</div>

<div id="copyright" class="container">
	<p>Copyright (c) 2013 Sitename.com. All rights reserved. | Photos by <a href="http://fotogrph.com/">Fotogrph</a> | Design by <a href="http://www.freecsstemplates.org/" rel="nofollow">FreeCSSTemplates.org</a>.</p>
</div>
</body>
</html>
