<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Regist.aspx.cs" Inherits="Regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
</head>
<body style="background-image:url(img/1.jpg)">
    <form id="form1" runat="server">
    <div style="text-align:center;padding:250px">
    账号:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="TB_Signature" runat="server"></asp:TextBox>
        <br />
    密码:&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="TB_Password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
    身份证:&nbsp&nbsp<asp:TextBox ID="TB_IDCard" runat="server"></asp:TextBox>
        <br />
        <br />
    店铺图片:&nbsp&nbsp<asp:TextBox ID="TB_Background" runat="server"></asp:TextBox>
        <br />
        <div style="padding:5px;">
            <asp:Button CssClass="a_demo_one" ID="B_Regist" runat="server" Text="买家注册" OnClick="B_Regist_Click"/>
        </div>
        <div style="padding:5px;">
            <asp:Button CssClass="a_demo_one" ID="B_Regist2" runat="server" Text="卖家注册" OnClick="B_Regist_Click2"/>
        </div>
    </div>
    </form>
</body>
</html>
