using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Buyer_Information : System.Web.UI.Page
{
    static string coonStr = "Data Source=.;Initial Catalog=M1;Persist Security Info=True;User ID=sa;Password=";//库为M1
    protected void Page_Load(object sender, EventArgs e)
    {
        L_User.Text = Session["userid"].ToString();
        if (!IsPostBack)
        {
            L_Signature.Text = Session["userid"].ToString();

            SqlConnection coon = new SqlConnection(coonStr);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = "select * from dbo.T_Users where Id=@name";
            cmd.Parameters.Add(new SqlParameter("@name", Session["userid"].ToString()));
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                L_Money.Text = Reader[3].ToString();
            }
            coon.Close();
        }
    }

    protected void B_Go_Click(object sender, EventArgs e)
    {
        string sig = Session["userid"].ToString();
        string pwd1 = TB_Password1.Text;
        string pwd2 = TB_Password2.Text;
        if(pwd1==""||pwd2=="")
        {
            Response.Write("<script>alert('密码不能为空')</script>");
        }
        else
        {
            if(pwd1!=pwd2)
            {
                Response.Write("<script>alert('两次输入密码不同')</script>");
            }
            else
            {
                SqlConnection coon = new SqlConnection(coonStr);
                coon.Open();
                SqlCommand cmd = coon.CreateCommand();
                cmd.CommandText = "update T_Users set Password=@pwd where Id=@name";//表名为T_Users
                cmd.Parameters.Add(new SqlParameter("@name", sig));
                cmd.Parameters.Add(new SqlParameter("@pwd", pwd1));
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('修改密码完成')</script>");
                coon.Close();
            }
        }
    }

    protected void B_Go2_Click(object sender, EventArgs e)
    {
        SqlConnection coon = new SqlConnection(coonStr);
        coon.Open();
        SqlCommand cmd = coon.CreateCommand();
        cmd.CommandText = "select * from dbo.T_Users where Id=@name";
        cmd.Parameters.Add(new SqlParameter("@name", Session["userid"].ToString()));
        SqlDataReader Reader = cmd.ExecuteReader();
        Reader.Read();
        string NPnumber = Reader[2].ToString();
        string temMoney = Reader[3].ToString();
        if(NPnumber!=TB_NP.Text)
        {
            Response.Write("<script>alert('身份证输入有误')</script>");
        }
        else
        {
            if(Convert.ToInt32(TB_Money.Text)<0)
            {
                Response.Write("<script>alert('金额输入有误')</script>");
            }
            else
            {
                int money = System.Convert.ToInt32(temMoney) + System.Convert.ToInt32(TB_Money.Text);
                coon.Close();
                coon.Open();
                cmd.CommandText = "update T_Users set Money=@money where Id=@name";
                cmd.Parameters.Add(new SqlParameter("@money", money));
                cmd.ExecuteNonQuery();
                coon.Close();
                Response.Write("<script>alert('充值成功')</script>");

                coon.Open();
                cmd.CommandText = "select * from dbo.T_Users where Id=@name";
            
                SqlDataReader Reader1 = cmd.ExecuteReader();
                if (Reader1.Read())
                {
                    L_Money.Text = Reader1[3].ToString();
                }
                coon.Close();
            }
        }
        coon.Close();
    }
}