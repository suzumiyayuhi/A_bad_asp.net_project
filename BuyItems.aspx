<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyItems.aspx.cs" Inherits="BuyItems" %>

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

    <div style="padding:250px;text-align:center;">
     <asp:GridView ID="GV_Buy_Items" runat="server" AllowPaging="true" AllowSorting="true"
             CellPadding="4" PageSize="5" AutoGenerateColumns="false" OnPageIndexChanging="GV_Buy_Items_Page_Index_Changing"
             ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="商品名" />
                <asp:BoundField DataField="Price" HeaderText="单价" />
                <asp:BoundField DataField="Number" HeaderText="库存" />
                <asp:BoundField DataField="Class" HeaderText="商品类型" />
                <asp:BoundField DataField="SoldMan" HeaderText="卖家名"  />
                <asp:BoundField DataField="GoodsId" HeaderText="商品ID" Visible="false" />
                <asp:HyperLinkField HeaderText="详细信息" Text="物品详情" DataNavigateUrlFields="GoodsId" DataNavigateUrlFormatString="GoodsInformation.aspx?GoodsId={0}"
                    Target="mainframe" NavigateUrl="GoodsInformation.aspx" >
                    </asp:HyperLinkField>
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
        <asp:TextBox ID="TB_SName" runat="server"></asp:TextBox>
        <asp:Button ID="B_Search1" CssClass="a_demo_one"   runat="server" Text="按商品名筛选" 
            onclick="B_Search1_Click" /><br />

        <asp:TextBox ID="TB_SPrice" runat="server"></asp:TextBox>
        <asp:Button ID="B_Search2" CssClass="a_demo_one"   runat="server" Text="按价格筛选" 
            onclick="B_Search2_Click" /> <br />

        <asp:DropDownList ID="DDL_Class"
            runat="server">
            <asp:ListItem>水果</asp:ListItem>
            <asp:ListItem>电器</asp:ListItem>
            <asp:ListItem>书籍</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="B_Search3" CssClass="a_demo_one"   runat="server" Text="按商品类别筛选"
         onclick="B_Search3_Click" /><br />

        <asp:TextBox ID="TB_SSoldMan" runat="server"></asp:TextBox>
        <asp:Button ID="B_Search4" CssClass="a_demo_one"   runat="server" Text="按卖家筛选"
         onclick="B_Search4_Click" /><br />

        <asp:TextBox ID="TB_GoodsId" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="B_Search5" CssClass="a_demo_one"   runat="server" Text="搜索商品ID" 
            onclick="B_Search5_Click" Visible="false" /><br />
            <asp:Button ID="B_Search6" CssClass="a_demo_one"   runat="server" Text="综合搜索" 
            onclick="B_Search6_Click" /> 
            <asp:Button ID="B_Reset" CssClass="a_demo_one"   runat="server" Text="重置" 
            onclick="B_Reset_Click" /> 
    </div>
    </form>
</body>
</html>
