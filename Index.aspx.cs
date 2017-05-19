using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Login1_Click(object sender, EventArgs e)
    {
        string sig = TB_Signature.Text, pwd = TB_Password.Text;
        if (sig == "" || pwd == "")
            Response.Write("<script>alert('帐户和密码不能为空')</script>");
        else
        {
            string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
            SqlConnection coon = new SqlConnection(coonStr);//建立连接
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_Users where Id=@name";//表名为T_Users
            cmd.Parameters.Add(new SqlParameter("@name", sig));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true && sig == reader[0].ToString())
            {
                string pwd1 = reader[1].ToString();
                if (pwd1 == pwd)
                {
                    Session["userid"] = sig;
                    Response.Write("<script>alert('登入成功')</script>");
                    Response.Redirect("BuyItems.aspx");
                }
                else
                {
                    Response.Write("<script>alert('密码错误')</script>");
                }
            }
            else
                Response.Write("<script>alert('帐户不存在')</script>");
        }
    }

    protected void B_Login2_Click(object sender, EventArgs e)
    {
        string sig = TB_Signature.Text, pwd = TB_Password.Text;
        if (sig == "" || pwd == "")
            Response.Write("<script>alert('帐户和密码不能为空')</script>");
        else
        {
            string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
            SqlConnection coon = new SqlConnection(coonStr);//建立连接
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_SaleMen where Id=@name";//表名为T_SaleMen
            cmd.Parameters.Add(new SqlParameter("@name", sig));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true && sig == reader[0].ToString())
            {
                string pwd1 = reader[1].ToString();
                if (pwd1 == pwd)
                {
                    Session["salemanid"] = sig;
                    Response.Write("<script>alert('登入成功')</script>");
                    Response.Redirect("Salemen_Information.aspx");
                }
                else
                {
                    Response.Write("<script>alert('密码错误')</script>");
                }
            }
            else
                Response.Write("<script>alert('帐户不存在')</script>");
        }
    }
}