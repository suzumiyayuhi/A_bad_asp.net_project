using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Regist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void B_Regist_Click(object sender, EventArgs e)
    {
        string sig = TB_Signature.Text, pwd = TB_Password.Text;
        if (sig == "" || pwd == "")
            Response.Write("<script>alert('帐户和密码不能为空')</script>");
        else
        {
            string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
            SqlConnection coon = new SqlConnection(coonStr);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_Users where id=@name";//表名为T_Users
            cmd.Parameters.Add(new SqlParameter("@name", sig));
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true && sig == reader[0].ToString())
            {
                Response.Write("<script>alert('帐户已存在')</script>");
            }
            else
            {
                coon.Close();
                coon.Open();
                SqlCommand cmd1 = new SqlCommand("insert into dbo.T_Users  (Id,Password,PN,Money) values ('" + sig + "','" + pwd + "','" + TB_IDCard.Text + "','" + 0 + "')", coon);
                cmd1.ExecuteNonQuery();
                coon.Close();
                Response.Write("<script>alert('注册成功')</script>");
                Response.Redirect("Index.aspx");
            }
        }
    }

    protected void B_Regist_Click2(object sender, EventArgs e)
    {
        string sig = TB_Signature.Text, pwd = TB_Password.Text;
        if (sig == "" || pwd == "")
            Response.Write("<script>alert('帐户和密码不能为空')</script>");
        else
        {
            string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
            SqlConnection coon = new SqlConnection(coonStr);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_SaleMen where id=@name";//表名为T_SaleMen
            cmd.Parameters.Add(new SqlParameter("@name", sig));
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true && sig == reader[0].ToString())
            {
                Response.Write("<script>alert('帐户已存在')</script>");
            }
            else
            {
                coon.Close();
                coon.Open();
                SqlCommand cmd1 = new SqlCommand("insert into M1.dbo.T_SaleMen  (Id,Password,PN,Benefits,Background) values ('" + sig + "','" + pwd + "','" + TB_IDCard.Text + "','" + 0 + "','"+TB_Background.Text+"')", coon);
                cmd1.ExecuteNonQuery();
                coon.Close();
                Response.Write("<script>alert('注册成功')</script>");
                Response.Redirect("Index.aspx");
            }
        }
    }
}