using ExploreAll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreAll_Bookings.system.template
{
    public partial class _base : System.Web.UI.MasterPage
    {
        public string User;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if(HttpContext.Current.Session["User"] != null)
                User = HttpContext.Current.Session["User"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DBSupport.GetData("UserPermissions");

        }
    }
}