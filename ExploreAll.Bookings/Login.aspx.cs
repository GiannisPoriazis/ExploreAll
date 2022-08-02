using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExploreAll;

namespace ExploreAll_Bookings
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static bool DoLogin(string username, string password)
        {
            bool res = false;
            System.Web.SessionState.HttpSessionState ses = HttpContext.Current.Session;
            DataTable dt = DBSupport.GetData("UserTable");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Username"].ToString() == username && dr["Password"].ToString() == password)
                {
                    ses["Role"] = dr["Role"];
                    ses["User"] = dr["Username"];
                    res = true;
                }
            }

            return res;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            bool auth = DoLogin(username.Text, password.Text);
            if (auth)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                Response.Redirect("Default.aspx");
            }
        }
    }
}