<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
</head>
<body style="background-image:url(img/1.jpg)">
    <form id="form1" runat="server">
    <div>

    <div style="text-align:center;padding:250px">
    账号:<asp:TextBox ID="TB_Signature" runat="server"></asp:TextBox>
        <br />
    密码:<asp:TextBox ID="TB_Password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        
        <div style="padding:5px;">
            <asp:Button CssClass="a_demo_one" ID="B_Login1" runat="server" Text="买家登入" OnClick="B_Login1_Click"/> 
        </div>
        <div style="padding:5px;">
            <asp:Button CssClass="a_demo_one" ID="B_Login2" runat="server" Text="卖家登入" OnClick="B_Login2_Click"/> 
        </div>
        <div style="padding:10px">
            <a href="Regist.aspx">点此注册</a>
        </div>
    </div>

    </div>
    </form>
</body>
</html>
