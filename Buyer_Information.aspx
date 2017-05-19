<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Buyer_Information.aspx.cs" Inherits="Buyer_Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
</head>

<body style="background:url(img/1.jpg)">
    <form id="form1" runat="server">
        <div style="text-align:right"> 
        <asp:Label ID="L_User" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;<a href="Buyer_Information.aspx">信息管理</a>&nbsp;&nbsp;&nbsp;&nbsp;  <a href="BuyItems.aspx">去购物</a>
    </div>

        <div style="text-align:right"> 
                            
    </div>

    <div style="text-align:center;padding:250px">
       账号名:  <asp:Label ID="L_Signature" runat="server" Text="Label"></asp:Label><br />
      &nbsp; &nbsp; 余额:  <asp:Label ID="L_Money" runat="server" Text="Label"></asp:Label><br />
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密码:
        <asp:TextBox ID="TB_Password1" runat="server" TextMode="Password"></asp:TextBox> <br />
    确认密码:
        <asp:TextBox ID="TB_Password2" runat="server" TextMode="Password"></asp:TextBox> <br />
        <div style="padding:5px;">
            <asp:Button CssClass="a_demo_one" ID="B_Go" runat="server" Text="确认" OnClick="B_Go_Click"/> <br /><br />

            身份证:<asp:TextBox ID="TB_NP" runat="server"></asp:TextBox><br />
            &nbsp;&nbsp;&nbsp;&nbsp;金额:<asp:TextBox ID="TB_Money" runat="server"></asp:TextBox><br />
            <asp:Button CssClass="a_demo_one" ID="B_Go2" runat="server" Text="充值" OnClick="B_Go2_Click"/> <br />
            <a href=Comments.aspx>评论</a>
            <br />
            <a href=Basket.aspx>购物车</a>

        </div>
    </div>
    </form>
</body>
</html>
