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
    [ToolboxData("<{0}:ColumnChart runat=server></{0}:ColumnChart>")]
    public class ColumnChart : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]

        public string Title { get; set; }

        protected HtmlGenericControl cardContainer;
        protected HtmlGenericControl cardHeader;
        protected HtmlGenericControl title;
        protected HtmlGenericControl cardBody;
        protected HtmlGenericControl ctChart;

        protected override void CreateChildControls() { 
        
            ctChart = new HtmlGenericControl("div");
            ctChart.Attributes.Add("class", "ct-chart-product ct-golden-section");
            
            cardBody = new HtmlGenericControl("div");
            cardBody.Attributes.Add("class", "card-body");
            cardBody.Controls.Add(ctChart);

            title = new HtmlGenericControl("h5");
            title.Attributes.Add("class", "mb-0");
            title.InnerHtml = Title;

            cardHeader = new HtmlGenericControl("div");
            cardHeader.Attributes.Add("class", "card-header");
            cardHeader.Controls.Add(title);

            cardContainer = new HtmlGenericControl("div");
            cardContainer.Attributes.Add("class", "card");
            cardContainer.Controls.Add(cardHeader);
            cardContainer.Controls.Add(cardBody);

            Controls.Add(cardContainer);        
        
        }

    
    }
}