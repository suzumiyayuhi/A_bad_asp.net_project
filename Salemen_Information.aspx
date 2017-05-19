<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Salemen_Information.aspx.cs" Inherits="Salemen_Information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
</head>
<body style="background:url(img/1.jpg)">
    <form id="form1" runat="server">
    <div style="text-align:center;padding:250px">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;账号:<asp:Label ID="L_Signature" runat="server" Text="Label"></asp:Label><br />
        
        当前盈利:<asp:Label ID="L_Benefits" runat="server" Text="Label"></asp:Label><br />
        <asp:GridView ID="GV_Edition_Items" runat="server" AllowPaging="true" AllowSorting="true"
             CellPadding="4" PageSize="5" AutoGenerateColumns="false"
             ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="商品名" />
                <asp:BoundField DataField="Price" HeaderText="单价" />
                <asp:BoundField DataField="Number" HeaderText="库存" />
                <asp:BoundField DataField="Class" HeaderText="商品类型" />
                <asp:BoundField DataField="SoldMan" HeaderText="卖家名" Visible="false" />
                <asp:BoundField DataField="GoodsId" HeaderText="商品ID" Visible="false" />
                <asp:BoundField DataField="GoodsImg" HeaderText="商品ID" Visible="false" />

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
        </asp:GridView>
        <br />
        商品名:<asp:TextBox ID="TB_Name" runat="server"></asp:TextBox><br />
        &nbsp;&nbsp;&nbsp;&nbsp;数额:<asp:TextBox ID="TB_Number" runat="server"></asp:TextBox><br />
        <div style="padding:5px;">
            <asp:Button CssClass="a_demo_one" ID="B_Update" runat="server" Text="库存更新" OnClick="B_Update_Click"/> <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;名称:<asp:TextBox ID="TB_Name1" runat="server"></asp:TextBox> <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 单价:<asp:TextBox ID="TB_Price1" runat="server"></asp:TextBox><br />
           商品类型:<asp:DropDownList ID="DDL_Class1" runat="server">
                <asp:ListItem>水果</asp:ListItem>
                <asp:ListItem>电器</asp:ListItem>
                <asp:ListItem>书籍</asp:ListItem>
          </asp:DropDownList>
          <br />
         &nbsp; &nbsp;&nbsp;&nbsp;  商品ID:<asp:TextBox ID="TB_GoodsId" runat="server"></asp:TextBox><br />
         商品图片:<asp:TextBox ID="TB_ItemImg" runat="server"></asp:TextBox> <br />
         <asp:Button CssClass="a_demo_one" ID="B_Add" runat="server" Text="增加商品" OnClick="B_Add_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
