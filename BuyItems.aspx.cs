using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class BuyItems : System.Web.UI.Page
{
    static string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1

    public void databind()
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems ", conn);//表为T_SaleItems
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }
    protected void GV_Buy_Items_Page_Index_Changing(object sender, GridViewPageEventArgs e)
    {
        GV_Buy_Items.PageIndex = e.NewPageIndex;
        GV_Buy_Items.DataBind();
        databind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Signature.Text = "欢迎您，尊敬的"+Session["userid"].ToString();
        if (!IsPostBack)
        {
            databind();
        }
    }

    protected void B_Search1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems where Name like @name ", conn);//表为T_SaleItems
        cmd.Parameters.Add("@name","%"+ TB_SName.Text+"%");
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }

    protected void B_Search2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems where  Price >'" + Convert.ToInt32(TB_SPrice.Text) + "' ", conn);//表为T_SaleItems
 //       cmd.Parameters.Add("@price", TB_SPrice.Text);
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }

    protected void B_Search3_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems where Class='" +DDL_Class.Text + "' ", conn);//表为T_SaleItems
    //    cmd.Parameters.Add("@class", TB_SClass.Text);
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }

    protected void B_Search4_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems where SoldMan like @soldman", conn);//表为T_SaleItems
        cmd.Parameters.Add("@soldman","%"+ TB_SSoldMan.Text+"%");
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }
    protected void B_Search5_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_SaleItems where GoodsId='" + TB_GoodsId.Text + "' ", conn);//表为T_SaleItems
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }
    protected void B_Reset_Click(object sender, EventArgs e)
    {
        databind();
    }

    protected void B_Search6_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(coonStr);
        string temcmd = "select * from T_SaleItems where ";
        if (TB_SName.Text != "")
        {
            temcmd += "Name like '" + TB_SName.Text + "'";
        }
        if(TB_SSoldMan.Text!="")
        {
            temcmd+=" SoldMan like '"+TB_SSoldMan.Text+"'";
        }
         SqlCommand cmd = new SqlCommand(temcmd,conn);
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Buy_Items.DataSource = dt1;
        GV_Buy_Items.DataBind();
    }
}