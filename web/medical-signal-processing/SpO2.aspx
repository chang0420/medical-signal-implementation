<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpO2.aspx.cs" Inherits="SpO2HR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="js/bootstrap/css/bootstrap.min.css"/>

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css"/>
  <link rel="stylesheet" href="https://code.jquery.com/resources/demos/style.css"/>
	<link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/css/bootstrap.min.css" />
	<script src="https://cdn.staticfile.org/jquery/2.1.1/jquery.min.js"></script>
	<script src="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css"/>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
    <title></title>
    <style>
    .back-to-top {
      display: none;
      /* 默认是隐藏的，这样在第一屏才不显示 */
      position: fixed;
      /* 位置是固定的 */
      bottom: 20px;
      /* 显示在页面底部 */
      right: 30px;
      /* 显示在页面的右边 */
      z-index: 99;
      /* 确保不被其他功能覆盖 */
      border: 1px solid #5cb85c;
      /* 显示边框 */
      outline: none;
      /* 不显示外框 */
      background-color: #fff;
      /* 设置背景背景颜色 */
      color: #5cb85c;
      /* 设置文本颜色 */
      cursor: pointer;
      /* 鼠标移到按钮上显示手型 */
      padding: 10px 15px 15px 15px;
      /* 增加一些内边距 */
      border-radius: 10px;
      /* 增加圆角 */
    }

    .back-to-top:hover {
      background-color: #5cb85c;
      /* 鼠标移上去时，反转颜色 */
      color: #fff;
    }
  </style>
    <style>
        .body{
            /*background-color:ivory;*/
            background-color:floralwhite; 
            position:absolute;
            top:0px;
            left:0px;
            background-size:100%;
            height:100%;
            width:100%;
        }
        /*.H {
            position:absolute;
            top:0px;
            left:0px;
            background-image:url(圖/1.png);
            background-size:100%;
            height:100%;
            width:100%;
            background-repeat:no-repeat;           
        }*/
        .btnSpo2{
            position:absolute;
            right:423px;
            width: 75px;
            height: 40px;
        }        
        .btnHR{
            position:absolute;
            right:289px;
            width:125px;
            height: 40px;
        }        
        .btnECG{
            position:absolute;
            right:209px;
            width: 70px;
            height: 40px;
        }        
        .btn溫度{
            position:absolute;
            right:135px;
            width: 65px;
            height: 40px;
        }     
        .btn濕度{
            position:absolute;
            right:55px;
            width:75px;
            height: 40px;
        }     
        .lbl{
            position:absolute;
            left:185px;
        }
        /*.SpO2{
            position:absolute;
            top:370px;
            left:200px;
        }*/
        .ChartSpO2{
            position:absolute;
            top:385px;
            right:155px;
        }
        .SpO2{
            position:absolute;
            top:370px;
            left:130px;
            width:900px;
        }
        .Spo2T{
            position:absolute;
            top:310px;
            left:100px;
            width:900px;
        }
        .L{
            position:absolute;
            top:405px;
            right:100px;
        }
        .ChartHR{
            position:absolute;
            top:890px;
            right:155px;
        }
        .HR{
            position:absolute;
            top:880px;
            left:130px;
            width:900px;
        }
        .HRT{
            position:absolute;
            top:817px;
            left:100px;
            width:900px;
        }
        .L2{
            position:absolute;
            top:908px;
            right:100px;
        }
        .Chart溫度{
            position:absolute;
            top:1880px;
            right:155px;
        }
        .溫度{
            position:absolute;
            top:1860px;
            left:130px;
            width:900px;
        }
        .溫度T{
            position:absolute;
            top:1792px;
            left:100px;
            width:900px;
        }
        .L4{
            position:absolute;
            top:1835px;
            right:100px;
        }
        .Chart濕度{
            position:absolute;
            top:2370px;
            right:155px;
        }
        .濕度{
            position:absolute;
            top:2370px;
            left:130px;
            width:900px;
        }
        .濕度T{
            position:absolute;
            top:2307px;
            left:100px;
            width:900px;
        }
        .L5{
            position:absolute;
            top:2395px;
            right:100px;
        }
        .ECGT{
            position:absolute;
            top:1335px;
            left:100px;
            width:900px;
        }
        .ECGPC1{
            position:absolute;
            top:1410px;
            left:130px;
            width:1250px;
        }
        .img{
            position:absolute;
            top:230px;
            right:0px;
            background-image:url(圖/背景.png);
            background-size:100%;
            height:100%;
            width:100%;
            background-repeat:no-repeat;
        }
        .ll{
position: absolute;
left: 100px;
}

        
        
        
    </style>
   
</head>
<body class="body">

    <%--Go top--%>   
       <button class="js-back-to-top back-to-top" title="回到头部">︽</button>

  <script src="https://cdn.staticfile.org/jquery/2.2.4/jquery.min.js"></script>
  <script>
      $(function () {
          var $win = $(window);
          var $backToTop = $('.js-back-to-top');
          // 当用户滚动到离顶部100像素时，展示回到顶部按钮
          $win.scroll(function () {
              if ($win.scrollTop() > 100) {
                  $backToTop.show();
              } else {
                  $backToTop.hide();
              }
          });
          // 当用户点击按钮时，通过动画效果返回头部
          $backToTop.click(function () {
              $('html, body').animate({
                  scrollTop: 0
              }, 200);
          });
      });
  </script>

    <!--相片輪播-->
    <div id="photoCarousel" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#photoCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#photoCarousel" data-slide-to="1"></li>
            <li data-target="#photoCarousel" data-slide-to="2"></li>
        </ol>

        <div class="carousel-inner">
            <div class="item active">
                <img src="圖/輪播1.png" />
            </div>
            <div class="item">
                <img src="圖/輪播4 .png" />
            </div>
            <div class="item">
                <img src="圖/輪播5.png" />
            </div>
        </div>

        <a class="left carousel-control"
        href="#photoCarousel" data-slide="prev">
        
    </a>
    <a class="right carousel-control"
        href="#photoCarousel" data-slide="next">
    </a>
    </div>

  

    <form id="form1" runat="server" class="Form">
        <div class="H"></div>
            <%--<img style="background-size:100% " src="圖/1.png" />--%>
            <%--<asp:Button class="btn" ID="Button1" runat="server" Text="Heart Rate & SpO2" BackColor="#666699" BorderStyle="None" Font-Names="David Libre" Font-Size="13pt" ForeColor="#FFFFCC"  />
            <asp:Button class="btn2" ID="Button2" runat="server" Text="ECG" BackColor="#666699" BorderStyle="None" Font-Names="David Libre" Font-Size="13pt" ForeColor="#FFFFCC"  />
            <asp:Button class="btn3" ID="Button3" runat="server" Text="溫溼度" BackColor="#666699" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC"   />--%>
           
            <%--<asp:Label CssClass="lbl" ID="Label9" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="12pt" ForeColor="#73734D"></asp:Label>--%>           
        <%--</div>--%>
        <div class="img">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <a href="#Spo2AH" class="btnSpo2" style="font-family: Alef; font-size: 23px; font-weight: bold; color: #336600">SpO2</a>
            <a href="#HRAH" class="btnHR" style="font-family: Alef; font-size: 23px; font-weight: bold; color: #336600">Heart Rate</a>
            <a href="#ECGAH" class="btnECG" style="font-family: Alef; font-size: 23px; font-weight: bold; color: #336600">ECG</a>
            <a href="#溫度AH" class="btn溫度" style="font-family: 微軟正黑體; font-size: 23px; font-weight: bold; color: #336600">溫度</a>
            <a href="#濕度AH" class="btn濕度" style="font-family: 微軟正黑體; font-size: 23px; font-weight: bold; color: #336600">濕度</a>
            <%--<asp:Button  class="btn0" ID="Button1" runat="server" Text="SpO2" BackColor="#669999" BorderStyle="None" Font-Names="David Libre" Font-Size="13pt" ForeColor="#FFFFCC" OnClientClick="window.SPO2.focus;" />
            <asp:Button class="btn" ID="Button2" runat="server" Text="Heart Rate" BackColor="#009999" BorderStyle="None" Font-Names="David Libre" Font-Size="13pt" ForeColor="#FFFFCC"  />
            <asp:Button class="btn2" ID="Button3" runat="server" Text="ECG" BackColor="#009999" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC"   />
            <asp:Button class="btn3" ID="Button4" runat="server" Text="溫度" BackColor="#339966" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC" />
            <asp:Button class="btn4" ID="Button5" runat="server" Text="濕度" BackColor="#99CC00" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#333300"  />--%>

                
           <asp:Label CssClass="lbl" ID="Label2" runat="server" Text="登入中…" Font-Names="微軟正黑體" Font-Size="16pt" ForeColor="#339933"></asp:Label>
            <asp:Label CssClass="ll" ID="Label9" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="16pt" ForeColor="#339933"></asp:Label>
        </ContentTemplate>
                            </asp:UpdatePanel>
                
                </div>
        <%--<asp:Image CssClass="img" ID="Image1" runat="server" Height="35px" Width="1900px" ImageUrl="~/圖/背景.png" />--%>
        <%--SPO2--%>
         <div class="ChartSpO2">           
            <asp:Chart ID="ChartSpO2" runat="server" BackColor="Transparent" TextAntiAliasingQuality="Normal" Width="670px" CssClass="title" DataSourceID="Sp02" OnDataBound="ChartSpO2_DataBound">
                <series>
                    <asp:Series ChartType="Line" Color="0, 64, 64" Font="微軟正黑體, 11.8208952pt, style=Bold" LabelForeColor="PaleGoldenrod" MarkerColor="Green" MarkerStyle="Square" Name="Series1" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" BorderColor="Transparent" MarkerBorderWidth="2" MarkerSize="7" IsValueShownAsLabel="True" XValueMember="測量時間" YValueMembers="測量值" LabelBackColor="DarkOliveGreen" >
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1" BackColor="#F7F9CC" BorderColor="OliveDrab" BackImageWrapMode="Scaled" BorderDashStyle="Solid">
                        <AxisY LabelAutoFitMaxFontSize="13" LineColor="OliveDrab" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Green" Maximum="110" MaximumAutoSize="60" Minimum="70">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                            <ScaleBreakStyle LineColor="SlateGray" />
                        </AxisY>
                        <AxisX LabelAutoFitMaxFontSize="13" LineColor="OliveDrab" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Teal" LabelAutoFitMinFontSize="10">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                            <ScaleBreakStyle LineColor="" />
                        </AxisX>
                        <AxisX2 LineColor="DarkOliveGreen" TitleFont="微軟正黑體, 11.8208952pt">
                        </AxisX2>
                        <AxisY2 LabelAutoFitMaxFontSize="13" LineColor="Firebrick">
                        </AxisY2>
                    </asp:ChartArea>
                </chartareas>
           
            </asp:Chart>
             <asp:AccessDataSource ID="Sp02" runat="server" DataFile="~/健康測量.accdb" SelectCommand="SELECT [測量時間], [測量值] FROM [使用者紀錄] WHERE ([測量項目] = ?) ORDER BY [測量時間]">
                 <SelectParameters>
                     <asp:Parameter DefaultValue="spo2" Name="測量項目2" Type="String" />
                 </SelectParameters>
             </asp:AccessDataSource>
         </div>
        <div class="L">
            <asp:Label ID="Label3" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Red">■ 嚴重</asp:Label><br />

            <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Blue">■ 偏低</asp:Label><br />
            <asp:Label ID="Label5" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Green">■ 正常</asp:Label>
        </div>

        <asp:Label ID="Spo2AH" CssClass="Spo2T" runat="server" Text="SpO2"  Font-Size="32pt" ForeColor="#8080C0" Font-Names="DejaVu Sans Mono" Font-Strikeout="False" Font-Bold="True"></asp:Label>
        <div class="SpO2">            
            
            <br />
            <asp:GridView  ID="GVspo2" runat="server" Height="306px" Width="295px" AutoGenerateColumns="False" BorderStyle="Double" DataSourceID="Sp02" Font-Names="微軟正黑體" ForeColor="#003366" OnDataBound="GVspo2_DataBound" OnRowDataBound="GVspo2_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="測量時間" HeaderText="測量時間" SortExpression="測量時間" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="測量值" HeaderText="測量值" SortExpression="測量值" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server"></asp:AccessDataSource>
            </div>

            <%--HR--%>
            <div class="ChartHR">           
            <asp:Chart ID="ChartHR" runat="server" BackColor="Transparent" TextAntiAliasingQuality="Normal" Width="670px" CssClass="title" DataSourceID="HR" OnDataBound="ChartHR_DataBound">
                <series>
                    <asp:Series ChartType="Line" Color="0, 64, 64" Font="微軟正黑體, 11.8208952pt, style=Bold" LabelForeColor="DarkOliveGreen" MarkerColor="Green" MarkerStyle="Square" Name="Series1" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" BorderColor="Transparent" MarkerBorderWidth="2" MarkerSize="7" IsValueShownAsLabel="True" XValueMember="測量時間" YValueMembers="測量值" LabelBackColor="YellowGreen" >
                        <SmartLabelStyle CalloutLineColor="OliveDrab" />
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Azure" BorderColor="Teal">
                        <AxisY LabelAutoFitMaxFontSize="13" LineColor="Teal" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Green" Maximum="130"  Minimum="40">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                        </AxisY>
                        <AxisX LabelAutoFitMaxFontSize="13" LineColor="Teal" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Teal" LabelAutoFitMinFontSize="10">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                        </AxisX>
                        <%--<AxisX2 LineColor="OliveDrab" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Teal">
                            <LabelStyle ForeColor="Teal" />
                        </AxisX2>
                        <AxisY2 LabelAutoFitMaxFontSize="13" LineColor="OliveDrab" TitleForeColor="Teal">
                            <LabelStyle ForeColor="Teal" />
                        </AxisY2>--%>
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>             
                <asp:AccessDataSource ID="HR" runat="server" DataFile="~/健康測量.accdb" SelectCommand="SELECT [測量時間], [測量值] FROM [使用者紀錄] WHERE ([測量項目] = ?) ORDER BY [測量時間]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="HR" Name="測量項目" Type="String" />
                    </SelectParameters>
                </asp:AccessDataSource>
         </div>

        <div class="L2">
            <asp:Label ID="Label7" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Red">■ 過快</asp:Label><br />

            <asp:Label ID="Label8" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Blue">■ 偏快</asp:Label><br />
            <asp:Label ID="Label11" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Green">■ 正常</asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Orange">■ 過慢</asp:Label>
        </div>

        <asp:Label ID="HRAH" CssClass="HRT" runat="server" Text="Heart Rate"  Font-Size="32pt" ForeColor="#993366" Font-Names="DejaVu Sans Mono" Font-Strikeout="False" Font-Bold="True"></asp:Label>
        <div class="HR">
            <%--<asp:Label ID="Label12" runat="server" Text="Heart Rate"  Font-Size="21pt" ForeColor="#8080C0" Font-Names="DejaVu Sans Mono" Font-Strikeout="False" Font-Bold="True"></asp:Label>--%>
            <br />
            <asp:GridView  ID="GVHR" runat="server" Height="306px" Width="295px" AutoGenerateColumns="False" BorderStyle="Double" Font-Names="微軟正黑體" ForeColor="#003366" DataSourceID="HR">
                <Columns>
                    <asp:BoundField DataField="測量時間" HeaderText="測量時間" SortExpression="測量時間" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="測量值" HeaderText="測量值" SortExpression="測量值" >
                    <ControlStyle ForeColor="#666633" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>                
            </asp:GridView>
            </div>
        <%--ECG--%>
        <asp:Label ID="ECGAH" CssClass="ECGT" runat="server" Text="ECG"  Font-Size="32pt" ForeColor="#CC6600" Font-Names="DejaVu Sans Mono" Font-Strikeout="False" Font-Bold="True"></asp:Label>
        <asp:Image CssClass="ECGPC1" ID="Image1" runat="server"  /> 
      

             <%--溫度--%>
         <div class="Chart溫度">           
            <asp:Chart ID="ChartTem" runat="server" BackColor="Transparent" TextAntiAliasingQuality="Normal" Width="670px" CssClass="title" DataSourceID="溫度" OnDataBound="ChartTem_DataBound"  >
                <series>
                    <asp:Series ChartType="Line" Color="0, 64, 64" Font="微軟正黑體, 11.8208952pt, style=Bold" LabelForeColor="PaleGoldenrod" MarkerColor="Green" MarkerStyle="Square" Name="Series1" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" BorderColor="Transparent" MarkerBorderWidth="2" MarkerSize="7" IsValueShownAsLabel="True" XValueMember="測量時間" YValueMembers="測量值" LabelBackColor="DarkOliveGreen" >
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1" BackColor="#F7F9CC" BorderColor="OliveDrab" BackImageWrapMode="Scaled" BorderDashStyle="Solid">
                        <AxisY LabelAutoFitMaxFontSize="13" LineColor="OliveDrab" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Green" Maximum="50" MaximumAutoSize="50" Minimum="10">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                            <ScaleBreakStyle LineColor="SlateGray" />
                        </AxisY>
                        <AxisX LabelAutoFitMaxFontSize="13" LineColor="OliveDrab" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Teal" LabelAutoFitMinFontSize="10">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                            <ScaleBreakStyle LineColor="" />
                        </AxisX>
                        <AxisX2 LineColor="DarkOliveGreen" TitleFont="微軟正黑體, 11.8208952pt">
                        </AxisX2>
                        <AxisY2 LabelAutoFitMaxFontSize="13" LineColor="Firebrick">
                        </AxisY2>
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
             <asp:AccessDataSource ID="溫度" runat="server" DataFile="~/健康測量.accdb" SelectCommand="SELECT [測量時間], [測量值] FROM [使用者紀錄] WHERE ([測量項目] = ?) ORDER BY [測量時間]">
                 <SelectParameters>
                     <asp:Parameter DefaultValue="溫度" Name="測量項目" Type="String" />
                 </SelectParameters>
             </asp:AccessDataSource>
         </div>
        <%--<div class="L3">
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Red">■ 嚴重</asp:Label><br />

            <asp:Label ID="Label10" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Blue">■ 偏低</asp:Label><br />
            <asp:Label ID="Label13" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Green">■ 正常</asp:Label>
        </div>--%>

        <asp:Label ID="溫度AH" CssClass="溫度T" runat="server" Text="Temperature"  Font-Size="32pt" ForeColor="#8080C0" Font-Names="DejaVu Sans Mono" Font-Strikeout="False" Font-Bold="True"></asp:Label>
        <div class="溫度">            
            <br />
            <asp:GridView  ID="GridView1" runat="server" Height="306px" Width="295px" AutoGenerateColumns="False" BorderStyle="Double" DataSourceID="溫度" Font-Names="微軟正黑體" ForeColor="#003366">
                <Columns>
                    <asp:BoundField DataField="測量時間" HeaderText="測量時間" SortExpression="測量時間" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="測量值" HeaderText="測量值" SortExpression="測量值" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            </div>

            <%--濕度--%>
            <div class="Chart濕度">           
            <asp:Chart ID="ChartHumi" runat="server" BackColor="Transparent" TextAntiAliasingQuality="Normal" Width="670px" CssClass="title" DataSourceID="濕度" OnDataBound="ChartHumi_DataBound" >
                <series>
                    <asp:Series ChartType="Line" Color="0, 64, 64" Font="微軟正黑體, 11.8208952pt, style=Bold" LabelForeColor="DarkOliveGreen" MarkerColor="Green" MarkerStyle="Square" Name="Series1" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" BorderColor="Transparent" MarkerBorderWidth="2" MarkerSize="7" IsValueShownAsLabel="True" LabelBackColor="YellowGreen" XValueMember="測量時間" YValueMembers="測量值" >
                        <SmartLabelStyle CalloutLineColor="OliveDrab" />
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Azure" BorderColor="Teal">
                        <AxisY LabelAutoFitMaxFontSize="13" LineColor="Teal" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Green" Maximum="100"  Minimum="10" LogarithmBase="20">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                        </AxisY>
                        <AxisX LabelAutoFitMaxFontSize="13" LineColor="Teal" TitleFont="微軟正黑體, 11.8208952pt" TitleForeColor="Teal" LabelAutoFitMinFontSize="10">
                            <MajorGrid LineColor="OliveDrab" />
                            <LabelStyle ForeColor="DarkOliveGreen" />
                        </AxisX>
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>             
                <asp:AccessDataSource ID="濕度" runat="server" DataFile="~/健康測量.accdb" SelectCommand="SELECT [測量時間], [測量值] FROM [使用者紀錄] WHERE ([測量項目] = ?) ORDER BY [測量時間]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="濕度" Name="測量項目" Type="String" />
                    </SelectParameters>
                </asp:AccessDataSource>
         </div>

        <div class="L5">
           
            <asp:Label ID="Label15" runat="server" Text="Label" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="Orange">■ 舒適</asp:Label>
        </div>

        <asp:Label ID="濕度AH" CssClass="濕度T" runat="server" Text="Humidity"  Font-Size="32pt" ForeColor="#993366" Font-Names="DejaVu Sans Mono" Font-Strikeout="False" Font-Bold="True"></asp:Label>
        <div class="濕度">
            <br />
            <asp:GridView  ID="GridView2" runat="server" Height="306px" Width="295px" AutoGenerateColumns="False" BorderStyle="Double" Font-Names="微軟正黑體" ForeColor="#003366" DataSourceID="濕度">
                <Columns>
                    <asp:BoundField DataField="測量時間" HeaderText="測量時間" SortExpression="測量時間" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="測量值" HeaderText="測量值" SortExpression="測量值" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                
            </asp:GridView>
            <br /><br /><br /><br />
        </div>
    </form>
</body>
</html>
