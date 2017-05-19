using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;

public partial class GoodsInformation : System.Web.UI.Page
{
    static string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1

    public void databind()
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_Comments where GoodsId='" + L_GoodsId.Text + "' ", conn);//表为T_SaleItems
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Comments.DataSource = dt1;
        GV_Comments.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        L_Signature.Text = "欢迎您，尊敬的" + Session["userid"].ToString();
        if (!IsPostBack)
        {
            string strid = Page.Request.QueryString["GoodsId"];
            SqlConnection coon = new SqlConnection(coonStr);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_SaleItems where GoodsId=@name";
            cmd.Parameters.Add(new SqlParameter("@name", strid));
            SqlDataReader Reader = cmd.ExecuteReader();
            Reader.Read();
            L_Name.Text = Reader[0].ToString();
            L_Price.Text = Reader[1].ToString();
            L_Number.Text = Reader[2].ToString();
            L_Class.Text = Reader[3].ToString();
            L_SoldMan.Text = Reader[4].ToString();
            L_GoodsId.Text = Reader[5].ToString();
            I_Item.ImageUrl = Reader[6].ToString();
            coon.Close();
            L_WHOSHOP.Text = "欢迎来到" + L_SoldMan.Text + "的小店!";
            coon.Open();
            cmd.CommandText = "select * from dbo.T_SaleMen where Id='"+L_SoldMan.Text+"'";
            SqlDataReader reader1=cmd.ExecuteReader();
            reader1.Read();
            I_WHOSHOP.ImageUrl = reader1[4].ToString();
            coon.Close();
            databind();
        }
    }
    
    protected void B_Buy_Click(object sender, EventArgs e)
    {
        int tem = Convert.ToInt32(TB_Number.Text);
        int temprice = Convert.ToInt32(L_Price.Text);
        int temtotalprice = tem * temprice;
   //     Response.Write(tem + " " + temprice + " " + temtotalprice);
        if(tem<Convert.ToInt32(TB_Number.Text))
        {
            Response.Write("<script>alert('库存不足')</script>");
        }
        else
        {
            SqlConnection coon = new SqlConnection(coonStr);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_Users where Id=@name";
            cmd.Parameters.Add(new SqlParameter("@name", Session["userid"].ToString()));
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                Session["Money"] = Reader[3].ToString();
            }
            coon.Close();
            if(Convert.ToInt32(Session["Money"].ToString())<temtotalprice)
            {
                Response.Write("<script>alert('余额不足')</script>");
            }
            else
            {
                int temnewnum = Convert.ToInt32(L_Number.Text) - tem;
                coon.Open();
                cmd.CommandText = "update T_SaleItems set Number=@newnum where GoodsId=@goodsid";//表名为T_Users
                cmd.Parameters.Add(new SqlParameter("@newnum", temnewnum));
                cmd.Parameters.Add(new SqlParameter("@goodsid", L_GoodsId.Text));
                cmd.ExecuteNonQuery();
                coon.Close();

                coon.Open();
                cmd.CommandText = "select *  from T_SaleMen where Id=@salemanid";
                cmd.Parameters.Add(new SqlParameter("@salemanid", L_SoldMan.Text));
                SqlDataReader Reader1 = cmd.ExecuteReader();
                Reader1.Read();
                int oldbenefits = Convert.ToInt32(Reader1[3].ToString());
                int newbenefits = oldbenefits + temtotalprice;
                coon.Close();
                coon.Open();
                cmd.CommandText = "update T_SaleMen set Benefits=@newbenefits where Id=@salemanid";
                cmd.Parameters.Add(new SqlParameter("@newbenefits",newbenefits));
                cmd.ExecuteNonQuery();
                coon.Close();

                coon.Open();
                int newmoney = Convert.ToInt32(Session["Money"].ToString()) - temtotalprice;
                cmd.CommandText = "update T_Users set Money=@newmoney where Id=@name";
                cmd.Parameters.Add(new SqlParameter("@newmoney", newmoney));
                cmd.ExecuteNonQuery();
                coon.Close();
                string str="null";
                coon.Open();
                cmd.CommandText = "insert into dbo.T_Comments (Id,GoodsName,Text,SoldMan,GoodsId) values ('" + Session["userid"] + "','" + L_Name.Text + "','" + str + "','" + L_SoldMan.Text + "','" + L_GoodsId.Text + "')";
                cmd.ExecuteNonQuery();
                coon.Close();
                Response.Write("<script>alert('购买成功')</script>");


            }
        }
    }
    protected void B_Buy2_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(TB_Number.Text) > Convert.ToInt32(L_Number.Text))
        {
            Response.Write("<script>alert('商品库存不足请重试')</script>");
        }
        else
        {
            int temprice = Convert.ToInt32(L_Price.Text) * Convert.ToInt32(TB_Number.Text);
            SqlConnection coon = new SqlConnection(coonStr);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "insert into dbo.T_Basket (Id,ItemId1,ItemNum1,Itemprice,ItemName,SoldMan) values('" + Session["userid"] + "','" + L_GoodsId.Text + "','" + TB_Number.Text + "','" + temprice + "','" + L_Name.Text + "','" + L_SoldMan.Text + "')";
            cmd.ExecuteNonQuery();
            coon.Close();

            int tem = Convert.ToInt32(TB_Number.Text);
            int temprice1 = Convert.ToInt32(L_Price.Text);
            int temtotalprice = tem * temprice1;
            int temnewnum = Convert.ToInt32(L_Number.Text) - tem;
            coon.Open();
            cmd.CommandText = "update T_SaleItems set Number=@newnum where GoodsId=@goodsid";//表名为T_Users
            cmd.Parameters.Add(new SqlParameter("@newnum", temnewnum));
            cmd.Parameters.Add(new SqlParameter("@goodsid", L_GoodsId.Text));
            cmd.ExecuteNonQuery();
            coon.Close();

            coon.Open();
            cmd.CommandText = "select *  from T_SaleMen where Id=@salemanid";
            cmd.Parameters.Add(new SqlParameter("@salemanid", L_SoldMan.Text));
            SqlDataReader Reader1 = cmd.ExecuteReader();
            Reader1.Read();
            int oldbenefits = Convert.ToInt32(Reader1[3].ToString());
            int newbenefits = oldbenefits + temtotalprice;
            coon.Close();
            coon.Open();
            cmd.CommandText = "update T_SaleMen set Benefits=@newbenefits where Id=@salemanid";
            cmd.Parameters.Add(new SqlParameter("@newbenefits", newbenefits));
            cmd.ExecuteNonQuery();
            coon.Close();
        }
    }
}