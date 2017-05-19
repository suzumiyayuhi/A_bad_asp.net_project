using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Salemen_Information : System.Web.UI.Page
{
    static string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1

    public void databind()
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems where SoldMan=@name", conn);//表为T_SaleItems
        cmd.Parameters.Add(new SqlParameter("@name", Session["salemanid"].ToString()));
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Edition_Items.DataSource = dt1;
        GV_Edition_Items.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            databind();
        }
        L_Signature.Text = Session["salemanid"].ToString();
        SqlConnection coon = new SqlConnection(coonStr);
        coon.Open();
        SqlCommand cmd = coon.CreateCommand();
        cmd.CommandText = "select * from dbo.T_SaleMen where Id=@name";
        cmd.Parameters.Add(new SqlParameter("@name", Session["salemanid"].ToString()));
        SqlDataReader Reader = cmd.ExecuteReader();
        if (Reader.Read())
        {
            L_Benefits.Text = Reader[3].ToString();
        }
        coon.Close();
    }



    protected void B_Update_Click(object sender, EventArgs e)
    {
        string newnumber = TB_Number.Text;
        string itemname = TB_Name.Text;
        SqlConnection conn = new SqlConnection(coonStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("update T_SaleItems set Number=@num where Name=@itemname and SoldMan=@soldmanname", conn);//表为T_SaleItems
        cmd.Parameters.Add(new SqlParameter("@num", newnumber));
        cmd.Parameters.Add(new SqlParameter("@itemname", itemname));
        cmd.Parameters.Add(new SqlParameter("@soldmanname", Session["salemanid"].ToString()));
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('库存修改成功')</script>");
        conn.Close();

        conn.Open();
        cmd.CommandText = "select * from dbo.T_SaleMen where Id=@name";
        cmd.Parameters.Add(new SqlParameter("@name", Session["salemanid"].ToString()));
        SqlDataReader Reader = cmd.ExecuteReader();
        if (Reader.Read())
        {
            L_Benefits.Text = Reader[3].ToString();
        }
        conn.Close();
        databind();
    }

    protected void B_Add_Click(object sender, EventArgs e)
    {
        string str_name = TB_Name1.Text;
        string str_price = TB_Price1.Text;
        string str_class = DDL_Class1.Text;
        string str_goodsid = TB_GoodsId.Text;
        string str_number = "0";
        string str_SoldMan = Session["salemanid"].ToString();
        string str_ItemImg = TB_ItemImg.Text;

        SqlConnection conn = new SqlConnection(coonStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert into dbo.T_SaleItems  (Name,Price,Number,Class,SoldMan,GoodsId,GoodsImg) values ('" + str_name + "','" + str_price + "','" + str_number + "','" + str_class + "','" + str_SoldMan + "','" + str_goodsid + "','" + str_ItemImg + "')", conn);

        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('商品增加成功')</script>");
        conn.Close();
        databind();
    }
}