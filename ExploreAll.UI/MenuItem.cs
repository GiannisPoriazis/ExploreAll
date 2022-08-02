using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using ExploreAll.Common;

namespace ExploreAll.UI
{
    [ToolboxData("<{0}:Grid runat=server></{0}:Grid>")]
    public class MenuItem : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public int Permission = (int)CommonHelper.eBoolValues.Ignore;
        public string Target { get; set; }
        public string Title { get; set; }

        protected HtmlGenericControl listElement;
        protected HtmlGenericControl pageLink;

        protected override void CreateChildControls()
        {
            if (Permission != (int)CommonHelper.eBoolValues.Ignore && HttpContext.Current.Session["Role"] != null)
            {
                DataTable UserRoles = DBSupport.GetData("UserPermissions");
                DataRow User = null;

                foreach (DataRow role in UserRoles.Rows)
                {
                    if (role["Role"].ToString() == HttpContext.Current.Session["Role"].ToString())
                    {
                        User = role;
                        break;
                    }
                }

                if (!(bool)User[CommonHelper.Permissions[Permission]])
                    return;
            }

            listElement = new HtmlGenericControl("li");
            listElement.Attributes.Add("class", "nav-item");

            pageLink = new HtmlGenericControl("a");
            pageLink.Attributes.Add("class", "nav-link");
            pageLink.Attributes.Add("href", Target);
            pageLink.InnerText = Title; 

            listElement.Controls.Add(pageLink);
            Controls.Add(listElement);
        }
    }
}
