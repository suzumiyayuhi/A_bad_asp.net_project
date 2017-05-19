<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsInformation.aspx.cs" Inherits="GoodsInformation" %>

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
        <asp:Label ID="L_Signature" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;<a href="Buyer_Information.aspx">信息管理</a>                      
    </div>
    <div style="text-align:center;padding:250px">
    <asp:Label Font-Size=55 ID="L_WHOSHOP" runat="server" Text="d"></asp:Label>
    <asp:Image ID="I_WHOSHOP" runat="server" />
    <br /><br /><br />
    商品图片:<asp:Image ID="I_Item" runat="server" /><br />
        
    商品名称:<asp:Label ID="L_Name" runat="server" Text="Label"></asp:Label><br />
    商品单价: <asp:Label ID="L_Price" runat="server" Text="Label"></asp:Label><br />
     &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;库存: <asp:Label ID="L_Number" runat="server" Text="Label"></asp:Label><br />
    商品类型: <asp:Label ID="L_Class" runat="server" Text="Label"></asp:Label><br />
    &nbsp; &nbsp;卖家名: <asp:Label ID="L_SoldMan" runat="server" Text="Label"></asp:Label><br />
    &nbsp; &nbsp; <asp:Label ID="L_GoodsId" runat="server" Text="Label" Visible="false"></asp:Label><br />
        购买数额:<asp:TextBox ID="TB_Number" runat="server"></asp:TextBox> <br />
        <asp:Button CssClass="a_demo_one" ID="B_Buy" runat="server" Text="购买" OnClick="B_Buy_Click"/> 
         <asp:Button CssClass="a_demo_one" ID="B_AddTo" runat="server" Text="加入购物车" OnClick="B_Buy2_Click"/> 


         <asp:GridView ID="GV_Comments" runat="server" AllowPaging="false" AllowSorting="True"
             CellPadding="4" PageSize="5" AutoGenerateColumns="False" 
             ForeColor="#333333" GridLines="None"   
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="用户" visible="true"/>
                <asp:BoundField DataField="GoodsName" HeaderText="商品名" />
                <asp:BoundField DataField="Text" HeaderText="内容"  />
                <asp:BoundField DataField="SoldMan" HeaderText="卖家" />
                <asp:BoundField DataField="GoodsId" HeaderText="商品ID" Visible="false" />
                <asp:CommandField />
                <asp:CommandField ButtonType="Button" ShowEditButton="false" />
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
