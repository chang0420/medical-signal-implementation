<%@ Page Language="C#" AutoEventWireup="true" CodeFile="登入.aspx.cs" Inherits="登入" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="https://code.jquery.com/resources/demos/style.css">
	<link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/css/bootstrap.min.css" />
	<script src="https://cdn.staticfile.org/jquery/2.1.1/jquery.min.js"></script>
	<script src="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>
    <title></title>
    <style>
        .body{
            /*background-color:lightslategrey;*/
            /*background-color:lightsteelblue;*/
            position:absolute;
            top:0px;
            left:0px;
            background-image:url(圖/4.png);
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
right:25%;
width:60px;
height:40px;
}
.btn1{
position:absolute;
right:65%;
width:60px;
height:40px;
}
.lblXX{
position:absolute;
/*right:65%;*/
top:80%;
width:220px;
}
        .auto-style1 {
            position: absolute;
            top: 308px;
            left: 655px;
        }
        .auto-style2 {
            position: absolute;
            top: 258px;
            left: 655px;
            width:210px;
        }
    </style>
</head>
<body class="body">
    <div class="login-form">
   
    <form id="form1" runat="server" class="form">
             <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:Label class="auto-style2" ID="Label4"  runat="server" Text="健康檢查紀錄" Font-Names="微軟正黑體" Font-Size="25pt" Font-Bold="True" ForeColor="#006600"></asp:Label>
        <div class="auto-style1">
            <asp:Label ID="Label1"  runat="server" Text="帳號：" Font-Names="微軟正黑體" Font-Size="17pt" Font-Bold="True" ForeColor="#003366"></asp:Label>
            <asp:TextBox ID="txtbxAcc" runat="server" Font-Size="14pt"></asp:TextBox>
            <br /><br /><br />
            <asp:Label ID="Label2" runat="server" Text="密碼：" Font-Names="微軟正黑體" Font-Size="17pt" Font-Bold="True" ForeColor="#003366"></asp:Label>
            <div class="login-form">
            <asp:TextBox ID="txtbxP" runat="server" Font-Size="14pt" TextMode="Password"  class="password" placeholder="Password" onkeyup="value=value.replace(/[^\u0000-\u00ff]/g,)"  
   onbeforepaste="clipboarddata.setdata(text,clipboarddata.getdata(text).replace(/[^\u0000-\u00ff]/g,))" OnTextChanged="txtbxP_TextChanged"></asp:TextBox>
            <i class="show_pass glyphicon glyphicon-eye-open"></i>
             </div>
                <br />
            <br />
            <asp:Label class="lblXX" ID="Label3" runat="server" Text="密碼帳號有誤!" Visible="False" Font-Names="微軟正黑體" Font-Size="15pt" ForeColor="#CC3300"></asp:Label>
            <asp:Button class="btn1" ID="btnLog" runat="server" Text=" 登入 " BackColor="#666699" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC" Font-Bold="True" OnClick="btnLog_Click"  />
            <asp:Button class="btn" ID="btnNewAc" runat="server" Text=" 註冊 " BackColor="#666699" BorderStyle="None" Font-Names="微軟正黑體" Font-Size="13pt" ForeColor="#FFFFCC" Font-Bold="True" OnClick="btnNewAc_Click" />
          </div>
                </ContentTemplate>
            </asp:UpdatePanel>
   

       
    </form>
</div>

    <script>
        $('.show_pass').click(function () {
            let pass_type = $('input.password').attr('type');

            if (pass_type === 'password' ){
            $('input.password').attr('type', 'text');
            $('.show_pass').removeClass('glyphicon - eye - open').addClass('glyphicon - eye - close');
        } else {
            $('input.password').attr('type', 'password');
            $('.show_pass').removeClass('glyphicon - eye - close').addClass('glyphicon - eye - open');
        }
    })
    </script>
</body>
</html>
