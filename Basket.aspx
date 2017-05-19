<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Basket.aspx.cs" Inherits="Basket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
</head>
<body style="background:url(img/1.jpg)">
    <form id="form1" runat="server">
    <div style="text-align:right"> 
        <asp:Label ID="L_Signature" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;<a href="Buyer_Information.aspx">信息管理</a>&nbsp;&nbsp;&nbsp;&nbsp;  <a href="BuyItems.aspx">去购物</a>
    </div>

    <div>
    <asp:GridView ID="GV_Basket" runat="server" AllowSorting="True" CellPadding="6"  AutoGenerateColumns="False" OnRowDeleting="GV_Basket_Deleting" >
    <Columns>
                <asp:BoundField DataField="Id" HeaderText="用户" visible="false"/>
                <asp:BoundField DataField="ItemId1" HeaderText="商品ID" visible="true"/>
                <asp:BoundField DataField="ItemNum1" HeaderText="数量"  />
                <asp:BoundField DataField="ItemPrice" HeaderText="该商品总额度" />
                <asp:BoundField DataField="ItemName" HeaderText="商品名称" />
                <asp:BoundField DataField="SoldMan" HeaderText="卖家" />
                <asp:CommandField ShowDeleteButton="True" />
    </Columns>
    </asp:GridView>
    <asp:Button   ID="B_Buy" runat="server" CssClass="a_demo_one" Text="购买" 
            onclick="B_Buy_Click" />
    </div>
    </form>
</body>
</html>
