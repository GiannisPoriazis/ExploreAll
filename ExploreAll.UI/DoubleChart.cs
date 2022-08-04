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
    [ToolboxData("<{0}:DoubleChart runat=server></{0}:DoubleChart>")]
    public class DoubleChart : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]

        public string Title { get; set; }
        public string Graph1 {  get; set; }
        public string Graph2 { get; set; }

        protected HtmlGenericControl cardContainer;
        protected HtmlGenericControl cardHeader;
        protected HtmlGenericControl cardBody;
        protected HtmlGenericControl ctChart;
        protected HtmlGenericControl textCenter;
        protected HtmlGenericControl legendItem;
        protected HtmlGenericControl legendText;
        protected HtmlGenericControl legendItem2;
        protected HtmlGenericControl legendText2;   



        protected override void CreateChildControls()
        {
            legendText2 = new HtmlGenericControl("span");
            legendText2.Attributes.Add("class", "legend-text");
            legendText2.InnerHtml = Graph2;

            legendItem2 = new HtmlGenericControl("span");
            legendItem2.Attributes.Add("class", "legend-item mr-2");
            legendItem2.Controls.Add(new HtmlGenericControl("span")
            {
                InnerHtml = "<i class='fa fa-fw fa-square-full'></i>"
            });
            legendItem2.Controls.Add(legendText2);

            legendText =new HtmlGenericControl("span");
            legendText.Attributes.Add("class", "legend-text");
            legendText.InnerHtml = Graph1;


            legendItem = new HtmlGenericControl("span");
            legendItem.Attributes.Add("class", "legend-item mr-2");
            legendItem.Controls.Add(new HtmlGenericControl("span")
            {
                InnerHtml = "<i class='fa fa-fw fa-square-full'></i>"
            });
            legendItem.Controls.Add(legendText);
            

            textCenter =new HtmlGenericControl("div");
            textCenter.Attributes.Add("class", "text-center");
            textCenter.Controls.Add(legendItem);
            textCenter.Controls.Add(legendItem2);

            ctChart = new HtmlGenericControl("div");
            ctChart.Attributes.Add("class", "ct-chart ct-golden-section");
            ctChart.Attributes.Add("style", "height: 354px;");

            cardBody = new HtmlGenericControl("div");
            cardBody.Attributes.Add("class", "card-body");
            cardBody.Controls.Add(ctChart);
            cardBody.Controls.Add(textCenter);

            cardHeader = new HtmlGenericControl("h5");
            cardHeader.Attributes.Add("class", "card-header");
            cardHeader.InnerHtml = Title;

            cardContainer = new HtmlGenericControl("div");
            cardContainer.Attributes.Add("class", "card");
            cardContainer.Controls.Add(cardHeader);
            cardHeader.Controls.Add(cardBody);

            Controls.Add(cardContainer);
        }

    }
}