<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>


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

</head>
<body>
<div id="header">
	<div id="menu" class="container">
		<ul>
			<li><a href="Homepage.aspx" accesskey="1" title="">Homepage</a></li>
			<li><a href="HowItWorks.aspx" accesskey="2" title="">How Does It Work</a></li>
			<li><a href="Default.aspx" accesskey="3" title="">Try</a></li>
			<li><a href="AboutUs.aspx" accesskey="4" title="">About Us</a></li>			
		</ul>
	</div>
</div>
<div id="logo" class="container">
	<h1><a href="#">b2b clustering</a></h1>
</div>
<div id="page" class="container">
	<div id="content">
		<div class="title">
			<h2>Welcome to our website</h2>
			<span class="byline">Mauris vulputate dolor sit amet nibh</span>
		</div>
		<p>This is <strong>TwoColours</strong>, a free, fully standards-compliant CSS template designed by <a href="http://www.freecsstemplates.org/" rel="nofollow">FreeCSSTemplates.org</a>. The photos in this template are from <a href="http://fotogrph.com/"> Fotogrph</a>. This free template is released under a <a href="http://creativecommons.org/licenses/by/3.0/">Creative Commons Attributions 3.0</a> license, so you are pretty much free to do whatever you want with it (even use it commercially) provided you keep the links in the footer intact. Aside from that, have fun with it :) </p>
	</div>
	<div id="sidebar"><a href="#" class="image image-full"><img src="images/pic05.jpg" alt="" /></a></div>
</div>
<div id="featured-wrapper">
	<div id="featured" class="container">
		<div class="major">
			<h2>Maecenas lectus sapien</h2>
			<span class="byline">Cras vitae metus aliquam risus pellentesque pharetra<br />
            <asp:Repeater ID="Repeater1" runat="server" Visible="true">
                        
                          <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table border="1" style="width:800px; margin: 0 auto; " >
                    <tr >
                        <th >
                           <h3> Results </h3>
                        </th>
                    </tr>
            </HeaderTemplate>

 <ItemTemplate>
                        
               <table id="table" border="1" style="width:800px; margin: 0 auto;"">

                    <tr style="width:800px;">
                       <td colspan="2">
                           <div style="margin-left: auto; margin-right: auto; text-align: center;">
                                          Cluster <asp:Label ID="titleID" runat="server" Text='<%#Eval("clusterID")%>' Font-Bold="True" Visible="True" ></asp:Label> 
                                                
                             </div>
                                      </td>
                                  </tr>
                            
                   <tr>
                       <td  style="width:500px;">
                           Member: 
                       </td> 
                       <td  style="width:300px;"> 
                           <center><asp:Label ID="lblMember" runat="server" Text='<%#Eval("IDD")%>' Font-Bold="True" Visible="True">  </asp:Label> <b>Firms</b>   </center>          
                      </td>
                   </tr>

                  <tr>
                       <td  style="width:500px;">
                           Average Total Expense: 
                       </td> 
                       <td  style="width:300px;"> 
                          <center> <asp:Label ID="Label1" runat="server" Text='<%#Eval("avgnettotal")%>' Font-Bold="True" Visible="True">  </asp:Label> <b> TL </b>    </center>           
                      </td>
                   </tr>

                     <tr>
                       <td  style="width:500px;">
                           Average Total Discount: 
                       </td> 
                       <td  style="width:300px;"> 
                          <center> <asp:Label ID="Label2" runat="server" Text='<%#Eval("avgtotaldiscount")%>' Font-Bold="True" Visible="True">  </asp:Label>  <b> TL </b>    </center>           
                      </td>
                   </tr>

                      <tr>
                       <td  style="width:500px;">
                           Average Recency: 
                       </td> 
                       <td  style="width:300px;"> 
                          <center> <asp:Label ID="Label3" runat="server" Text='<%#Eval("avgDays")%>' Font-Bold="True" Visible="True">  </asp:Label>  <b> Days </b>    </center>           
                      </td>
                   </tr>
                      <tr>
                       <td  style="width:500px;">
                           Average Frequency: 
                       </td> 
                       <td  style="width:300px;"> 
                          <center> <asp:Label ID="Label4" runat="server" Text='<%#Eval("avgFrequency")%>' Font-Bold="True" Visible="True">  </asp:Label>  <b> Transactions </b>    </center>           
                      </td>
                   </tr>
                      <tr>
                       <td  style="width:500px;">
                           Average Amount per Transaction: 
                       </td> 
                       <td  style="width:300px;"> 
                          <center> <asp:Label ID="Label5" runat="server" Text='<%#Eval("avgAmountPerTr")%>' Font-Bold="True" Visible="True">  </asp:Label>  <b> TL </b>    </center>           
                      </td>
                   </tr>
              
                
                </ItemTemplate>

              

                         <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr style="height:10px" bgcolor="#ffffff">
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate><!-- son satırda tabloyu kapayıyoruz  -->
                </table>
            </FooterTemplate>
         
        </asp:Repeater></span>
		&nbsp;</div>
		<div class="column1">
			<span class="icon icon-bar-chart"></span>
			<div class="title">
				<h2>Maecenas lectus sapien</h2>
				<span class="byline">Integer sit amet aliquet pretium</span>
			</div>
		</div>
		<div class="column2">
			<span class="icon icon-qrcode"></span>
			<div class="title">
				<h2>Praesent scelerisque</h2>
				<span class="byline">Integer sit amet aliquet pretium</span>
			</div>
		</div>
		<div class="column3">
			<span class="icon icon-building"></span>
			<div class="title">
				<h2>Fusce ultrices fringilla</h2>
				<span class="byline">Integer sit amet aliquet pretium</span>
			</div>
		</div>
		<div class="column4">
			<span class="icon icon-picture"></span>
			<div class="title">
				<h2>Etiam posuere augue</h2>
				<span class="byline">Integer sit amet aliquet pretium</span>
			</div>
		</div>
	</div>
</div>
<div id="portfolio-wrapper">
	<div id="portfolio" class="container">
		<div class="major">
			<h2>Suspendisse lacus turpis</h2>
			<span class="byline">Lorem ipsum dolor sit amet, consectetuer adipiscing elit</span>
		</div>
		<div class="column1">
			<a href="#" class="image image-full"><img src="images/pic01.jpg" height="150" alt="" /></a>
			<div class="box">
				<p>Etiam non felis. Donec ut ante. In id eros. Suspendisse lacus turpis, cursus egestas at sem. Mauris quam enim, molestie.</p>
				<a href="#" class="button">Read More</a>
			</div>
		</div>			
		<div class="column2">
			<a href="#" class="image image-full"><img src="images/pic02.jpg" height="150" alt="" /></a>
			<div class="box">
				<p>Etiam non felis. Donec ut ante. In id eros. Suspendisse lacus turpis, cursus egestas at sem. Mauris quam enim, molestie.</p>
				<a href="#" class="button">Read More</a>
			</div>
		</div>			
		<div class="column3">
			<a href="#" class="image image-full"><img src="images/pic03.jpg" height="150" alt="" /></a>
			<div class="box">
				<p>Etiam non felis. Donec ut ante. In id eros. Suspendisse lacus turpis, cursus egestas at sem. Mauris quam enim, molestie.</p>
				<a href="#" class="button">Read More</a>
			</div>
		</div>			
		<div class="column4">
			<a href="#" class="image image-full"><img src="images/pic04.jpg" height="150" alt="" /></a>
			<div class="box">
				<p>Etiam non felis. Donec ut ante. In id eros. Suspendisse lacus turpis, cursus egestas at sem. Mauris quam enim, molestie.</p>
				<a href="#" class="button">Read More</a>
			</div>
		</div>			
	</div>
</div>
<div id="contact" class="container">
		<div class="major">
			<h2>Get in touch</h2>
			<span class="byline">Phasellus nec erat sit amet nibh pellentesque congue</span>
		</div>
		<ul class="contact">
			<li><a href="#" class="icon icon-twitter"><span>Twitter</span></a></li>
			<li><a href="#" class="icon icon-facebook"><span></span></a></li>
			<li><a href="#" class="icon icon-dribbble"><span>Pinterest</span></a></li>
			<li><a href="#" class="icon icon-tumblr"><span>Google+</span></a></li>
			<li><a href="#" class="icon icon-rss"><span>Pinterest</span></a></li>
		</ul>
</div>
<div id="copyright" class="container">
	<p>Copyright (c) 2013 Sitename.com. All rights reserved. | Photos by <a href="http://fotogrph.com/">Fotogrph</a> | Design by <a href="http://www.freecsstemplates.org/" rel="nofollow">FreeCSSTemplates.org</a>.</p>
</div>
</body>
</html>
