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
    [ToolboxData("<{0}:LinearChart runat=server></{0}:LinearChart>")]
    public class LinearChart : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]


        public string Title { get; set; }

        public int Revenue { get; set; }

        public float Percentage { get; set; }

        protected HtmlGenericControl cardContainer;
        protected HtmlGenericControl cardHeader;
        protected HtmlGenericControl cardBody;
        protected HtmlGenericControl totalRev;
        protected HtmlGenericControl cardFooter;
        protected HtmlGenericControl display7;
        protected HtmlGenericControl textPrimary;
        protected HtmlGenericControl textSuccess;

        protected override void CreateChildControls()
        {

            textSuccess = new HtmlGenericControl("span");
            textSuccess.Attributes.Add("class", "text-success float-right");
            textSuccess.InnerHtml = Percentage.ToString() + '%' ;
            
            textPrimary = new HtmlGenericControl("span");
            textPrimary.Attributes.Add("class", "text-primary d-inline-block");
            textPrimary.InnerHtml = Revenue.ToString() + '$'; 
           
            display7 = new HtmlGenericControl("p");
            display7.Attributes.Add("class", "display-7 font-weight-bold");
            display7.Controls.Add(textPrimary);
            display7.Controls.Add(textSuccess);

            cardFooter = new HtmlGenericControl("div");
            cardFooter.Attributes.Add("class", "card-footer");
            cardFooter.Controls.Add(display7);
          
            
            totalRev = new HtmlGenericControl("div");
            totalRev.Attributes.Add("id", "morris_totalrevenue");
            
            cardBody = new HtmlGenericControl("div");
            cardBody.Attributes.Add("class", "card-body");          
            cardBody.Controls.Add(totalRev);

            cardHeader = new HtmlGenericControl("h5");
            cardHeader.Attributes.Add("class", "card-header");
            cardHeader.InnerHtml = Title;
            cardHeader.Controls.Add(cardBody);
            cardHeader.Controls.Add(cardFooter);

            cardContainer = new HtmlGenericControl("div");
            cardContainer.Attributes.Add("div", "card");
            cardContainer.Controls.Add(cardHeader);
           
          

            Controls.Add(cardContainer);

        }
    }
}
      
