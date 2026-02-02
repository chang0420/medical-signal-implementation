<%@ Page Language="C#" AutoEventWireup="true" CodeFile="註冊.aspx.cs" Inherits="註冊" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title><style>
        .body{
            /*background-color:lightslategrey;*/
            /*background-color:lightsteelblue;*/
            position:absolute;
            top:0px;
            left:0px;
            background-image:url(圖/5.png);
            background-size:100%;/*
            height:100%;
            width:100%;*/
            background-repeat:no-repeat;         
        }
        .b{
            position:absolute; top:35%; left:39%;
        }
        .btn{
            position:absolute;
            width:60px;
            height:40px;/*
            left: 200px;*/
        }
        .btn3{
            position:absolute;
            width:60px;
            height:40px;/**/
            left: 120px;
        }
        .auto-style1 {
            position: absolute;
            top: 258px;
            left: 705px;
                           width: 660px;
                       }
        .Title{
            position: absolute;
            top: 240px;
            left: 240px;
            width: 400px;
            height: 244px;
        }
                      
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        
        <div class="auto-style1">
            
            <asp:TextBox ID="txtbxName" runat="server" Font-Size="14pt"></asp:TextBox>
            <asp:Label ID="lblName"  runat="server" Text="     姓名：" Font-Names="微軟正黑體" Font-Size="13pt" Font-Bold="True" ForeColor="#003366" Visible="False"></asp:Label>

            <br /><br />
            <asp:TextBox ID="txtbxID" runat="server" Font-Size="14pt"></asp:TextBox>
            <asp:Label ID="lblID" runat="server" Text="身分證字號：" Font-Names="微軟正黑體" Font-Size="13pt" Font-Bold="True" ForeColor="#003366" Visible="False"></asp:Label>
            
            <br /> <br />        
            
           
            <asp:TextBox ID="txtbxBD" runat="server" Font-Size="14pt" TextMode="Date"></asp:TextBox>
             <asp:Label ID="lblBD" runat="server" Text="生日：" Font-Names="微軟正黑體" Font-Size="13pt" Font-Bold="True" ForeColor="#003366" Visible="False"></asp:Label>
            <br /><br />
           
            <asp:TextBox ID="txtbxAddress" runat="server" Font-Size="14pt"></asp:TextBox>
             <asp:Label ID="lblAddress" runat="server" Text="住址：" Font-Names="微軟正黑體" Font-Size="13pt" Font-Bold="True" ForeColor="#003366" Visible="False"></asp:Label>
            <br /><br />
           
            <asp:TextBox ID="txtbxEMail" runat="server" Font-Size="14pt"></asp:TextBox>
             <asp:Label ID="lblEmail" runat="server" Text="E-Mail：" Font-Names="微軟正黑體" Font-Size="13pt" Font-Bold="True" ForeColor="#003366" Visible="False"></asp:Label>
            <br /><br /><br />


            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button class="btn" ID="btnLog" runat="server" Text=" 註冊 " BackColor="#666699" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC" Font-Bold="True" OnClick="btnLog_Click"  />
            <asp:Button class="btn3" ID="Button1" runat="server" Text=" 返回 " BackColor="#666699"  Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC" Font-Bold="True" OnClick="Button1_Click"  />

            
        </div>
        <asp:Table class="Title" ID="Table1" runat="server" Font-Bold="True" Font-Names="微軟正黑體" Font-Size="17pt" ForeColor="#003366"  >
            <asp:TableRow runat="server" HorizontalAlign="Right">
                <asp:TableCell runat="server">姓名：<br /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Right">
                <asp:TableCell runat="server">身分證字號：</asp:TableCell>
            </asp:TableRow>            
            <asp:TableRow runat="server" HorizontalAlign="Right">
                <asp:TableCell runat="server">生日：</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Right">
                <asp:TableCell runat="server">住址：</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Right">
                <asp:TableCell runat="server">E-Mail：</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
