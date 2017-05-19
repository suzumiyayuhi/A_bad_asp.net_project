using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Basket : System.Web.UI.Page
{
    static string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
    public void databind()
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_Basket where Id='" + Session["userid"].ToString() + "' ", conn);//表为T_SaleItems
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Basket.DataSource = dt1;
        GV_Basket.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        L_Signature.Text = Session["userid"].ToString();
        if (!IsPostBack)
        {
            databind();
        }
    }

    protected void GV_Basket_Deleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete from T_Basket where ItemName='" + GV_Basket.Rows[e.RowIndex].Cells[4].Text + "'", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        databind();
    }

    protected void B_Buy_Click(object sender, EventArgs e)
    {
        int money,total=0;
        SqlConnection conn = new SqlConnection(coonStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from T_Users where Id='" + Session["userid"].ToString() + "' ", conn);
        SqlDataReader Reader = cmd.ExecuteReader();
        Reader.Read();
        money = Convert.ToInt32(Reader[3].ToString());
        conn.Close();

        conn.Open();
        cmd.CommandText = "select * from T_Basket where Id='" + Session["userid"].ToString() + "'";
        SqlDataReader Reader1 = cmd.ExecuteReader();
        while (true)
        {
            if (Reader1.Read())
            {
                total += Convert.ToInt32(Reader1[3].ToString());
            }
            else
                break;
        }
        conn.Close();

        if (money < total)
        {
            Response.Write("<script>alert('余额不足')</script>");
        }
        else
        {
            conn.Open();
            int temmoney = money - total;
            cmd.CommandText = "update T_Users set Money='" + temmoney.ToString() + "' where Id='" + Session["userid"].ToString() + "'";
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string str = "null";
            int sz = GV_Basket.Rows.Count;
            for (int i = 0; i != sz; i++)
            {
                cmd.CommandText = "insert into dbo.T_Comments (Id,GoodsName,Text,SoldMan,GoodsId) values ('" + Session["userid"] + "','" + GV_Basket.Rows[i].Cells[4].Text + "','" + str + "','" + GV_Basket.Rows[i].Cells[5].Text + "','" + GV_Basket.Rows[i].Cells[1].Text + "')";
                cmd.ExecuteNonQuery();
                Response.Write(GV_Basket.Rows[i].Cells[1].Text);
            }
            conn.Close();
            

            conn.Open();
            cmd.CommandText = "delete from T_Basket where Id='" + Session["userid"].ToString() + "'";
            cmd.ExecuteNonQuery();
            conn.Close();


            Response.Write("<script>alert('购买完成')</script>");
   //         Response.Redirect("Buyer_Information.aspx");
        }
    }
}