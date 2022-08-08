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
    [ToolboxData("<{0}:PieChart runat=server></{0}:PieChart>")]
    public class PieChart : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]

        public string Title { get; set; }
        public string Sec1 { get; set; }
        public string Sec2 { get; set; }
        public string Sec3 { get; set; }

        protected HtmlGenericControl cardContainer;
        protected HtmlGenericControl cardHeader;
        protected HtmlGenericControl cardBody;
        protected HtmlGenericControl ctChart;
        protected HtmlGenericControl textCenter;
        protected HtmlGenericControl legendItem1;
        protected HtmlGenericControl textPrimary;
        protected HtmlGenericControl squareFull1;
        protected HtmlGenericControl legendText1;
        protected HtmlGenericControl legendItem2;
        protected HtmlGenericControl textSecondary;
        protected HtmlGenericControl squareFull2;
        protected HtmlGenericControl legendText2;
        protected HtmlGenericControl legendItem3;
        protected HtmlGenericControl textInfo;
        protected HtmlGenericControl squareFull3;
        protected HtmlGenericControl legendText3;

        protected override void CreateChildControls()
        {

            legendText3 = new HtmlGenericControl("span");
            legendText3.Attributes.Add("class", "legend-text");
            legendText3.InnerHtml = Sec3;

            squareFull3 = new HtmlGenericControl("i");
            squareFull3.Attributes.Add("class", "fa fa-fw fa-square-full");


            textInfo = new HtmlGenericControl("span");
            textInfo.Attributes.Add("class", "fa-xs text-primary mr-1 legend-tile");
            textInfo.Controls.Add(squareFull3);
            textInfo.Controls.Add(legendText3);

            legendItem3 = new HtmlGenericControl("span");
            legendItem3.Attributes.Add("class", "legend-item mr-3");
            legendItem3.Controls.Add(textInfo);

            legendText2 = new HtmlGenericControl("span");
            legendText2.Attributes.Add("class", "legend-text");
            legendText2.InnerHtml = Sec2;

            squareFull2 = new HtmlGenericControl("i");
            squareFull2.Attributes.Add("class", "fa fa-fw fa-square-full");

            textSecondary = new HtmlGenericControl("span");
            textSecondary.Attributes.Add("class", "fa-xs text-primary mr-1 legend-tile");
            textSecondary.Controls.Add(squareFull2);
            textSecondary.Controls.Add(legendText2);

            legendItem2 = new HtmlGenericControl("span");
            legendItem2.Attributes.Add("class", "legend-item mr-3");
            legendItem2.Controls.Add(textSecondary);

            legendText1 = new HtmlGenericControl("span");
            legendText1.Attributes.Add("class", "legend-text");
            legendText1.InnerHtml = Sec1;

            squareFull1 = new HtmlGenericControl("i");
            squareFull1.Attributes.Add("class", "fa fa-fw fa-square-full ");

            textPrimary = new HtmlGenericControl("span");
            textPrimary.Attributes.Add("class", "fa-xs text-primary mr-1 legend-tile");
            textPrimary.Controls.Add(squareFull1);
            textPrimary.Controls.Add(legendText1);

            legendItem1 = new HtmlGenericControl("span");
            legendItem1.Attributes.Add("class", "legend-item mr-3");
            legendItem1.Controls.Add(textPrimary);

            textCenter = new HtmlGenericControl("div");
            textCenter.Attributes.Add("class", "text-center m-t-40");
            textCenter.Controls.Add(legendItem1);
            textCenter.Controls.Add(legendItem2);
            textCenter.Controls.Add(legendItem3);

            ctChart = new HtmlGenericControl("div");
            ctChart.Attributes.Add("class", "ct-chart-category ct-golden-section");
            ctChart.Attributes.Add("style", "height: 315px;");

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
            cardContainer.Controls.Add(cardBody);


            Controls.Add(cardContainer);

            //string jsinstall = "var chart = new Chartist.Pie('.ct-chart-category', {" +
            //                             "series: [60, 30, 30]," +
            //                             "labels: ['Bananas', 'Apples', 'Grapes']" +
            //                           "},  {" +
            //                            "donut: true," +
            //                            "showLabel: false," +
            //                             "donutWidth: 40" +

            //                           "});";

            //registerJavaScript(jsinstall);


        }

        //public void registerJavaScript(string jsinistall)
        //{
        //    ScriptManager scr = ScriptManager.GetCurrent(Page);

        //    if ((scr != null) && (scr.IsInAsyncPostBack))
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), jsinistall, true);
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), this.ClientID + "_startup", jsinistall, true);
        //    }

        //}
    }
}