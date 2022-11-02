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
    public partial class profileview : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"server=DESKTOP-9MP9HNQ\SQLEXPRESS;database=asp;Integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select Name,Age,Address,Photo from tab3 where id=" + Session["uid"] + "";
                SqlCommand cm = new SqlCommand(s, con);
                con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();
                }
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s="update tab3 set Age="+TextBox2.Text+",Address='"+TextBox3+"'";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            int x = cmd.ExecuteNonQuery();
            con.Close();
            if(x!=0)
            {
                Label1.Text = "updated";
            }
        }
    }
}