using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace WebApp_july
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-9MP9HNQ\SQLEXPRESS;database=asp;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;

            string strselect = "select count(id) from tab3 where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(strselect, con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if(cid=="1")
            {
               
            string strsel = "select id from tab3 where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
             SqlCommand cmd1 = new SqlCommand(strsel, con);
             con.Open();
             string id = cmd1.ExecuteScalar().ToString();
             con.Close();
                Session["uid"] = id;
                Response.Redirect("profileview.aspx");
                //Label1.Text = "Success";
            }
            else
            {

                Label1.Text = "invalid username and password";
                
            }
        }
    }
}