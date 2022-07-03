using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreAll.Admin
{
    public partial class GetImageSource : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Byte[] bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadDirectory"]) + Request["file"]);
            String file = Convert.ToBase64String(bytes);
            Response.ClearContent();
            Response.Write(file);
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}