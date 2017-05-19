<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="Comments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style="background:url(img/1.jpg)">
    <form id="form1" runat="server">
    <div style="text-align:right"> 
        <asp:Label ID="L_Signature" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;<a href="Buyer_Information.aspx">信息管理</a>&nbsp;&nbsp;&nbsp;&nbsp;  <a href="BuyItems.aspx">去购物</a>
    </div>

    <div  style="padding:250px;text-align:center;">
    <asp:GridView ID="GV_Comments" runat="server" AllowPaging="false" AllowSorting="True"
             CellPadding="4" PageSize="5" AutoGenerateColumns="False" OnPageIndexChanging="GV_Comments_Page_Index_Changing" OnRowEditing="GV_Comments_Editing" OnRowUpdating="GV_Comments_Updating" OnRowCancelingEdit="GV_Comments_Cancel"
             ForeColor="#333333" GridLines="None"   
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="用户" visible="false"/>
                <asp:BoundField DataField="GoodsName" HeaderText="商品名" />
                <asp:BoundField DataField="Text" HeaderText="内容"  />
                <asp:BoundField DataField="SoldMan" HeaderText="卖家" />
                <asp:BoundField DataField="GoodsId" HeaderText="商品ID" Visible="true" />
                <asp:CommandField />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView> <br />

    </div>
    </form>
</body>
</html>
