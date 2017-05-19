using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Comments : System.Web.UI.Page
{
    static string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
    public void databind()
    {
        SqlConnection conn = new SqlConnection(coonStr);
        SqlCommand cmd = new SqlCommand("select * from T_Comments where Id='"+Session["userid"].ToString()+"' ", conn);//表为T_SaleItems
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        GV_Comments.DataSource = dt1;
        GV_Comments.DataBind();
    }

    protected void GV_Comments_Editing(object sender, GridViewEditEventArgs e)
    {
        GV_Comments.EditIndex = e.NewEditIndex;  //GridView编辑项索引等于单击行的索引
        databind();
    }

    protected void GV_Comments_Updating(object sender, GridViewUpdateEventArgs e)
    {
        int xxx = e.RowIndex;
        SqlConnection conn = new SqlConnection(coonStr);
        conn.Open();
        string newtext = (GV_Comments.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text;

        string gd = (GV_Comments.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox).Text;
        SqlCommand cmd = new SqlCommand("update T_Comments set Text=@newte where GoodsId=@id", conn);
        cmd.Parameters.Add(new SqlParameter("@newte",newtext));
        cmd.Parameters.Add(new SqlParameter("@id",gd));
        cmd.ExecuteNonQuery();
        conn.Close();
        GV_Comments.EditIndex = -1;
        databind();
    }

    protected void GV_Comments_Cancel(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Comments.EditIndex = -1;
        databind();
    }

    protected void GV_Comments_Page_Index_Changing(object sender, GridViewPageEventArgs e)
    {
        GV_Comments.PageIndex = e.NewPageIndex;
        GV_Comments.DataBind();
        databind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        L_Signature.Text = Session["userid"].ToString();
        if (!IsPostBack)
        {
            databind();
        }
    }

}