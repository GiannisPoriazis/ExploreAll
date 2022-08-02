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
    [ToolboxData("<{0}:SingleChart runat=server></{0}:SingleChart>")]
    public class SingleChart : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public string Title { get; set; }
        public string MetricValue { get; set; }
        public float Percentage { get; set; }
        public string LineColor { get; set; }
        public string FillColor { get; set; }

        protected HtmlGenericControl cardWrapper;
        protected HtmlGenericControl cardBody;
        protected HtmlGenericControl metricValue;
        protected HtmlGenericControl metricLabel;
        protected HtmlGenericControl sparklineRevenue;
        protected HtmlGenericControl textMuted;
        protected HtmlGenericControl metricValueH1;

        protected override void CreateChildControls()
        {
            sparklineRevenue = new HtmlGenericControl("div");
            sparklineRevenue.ID = this.ID;

            metricLabel = new HtmlGenericControl("div");
            metricLabel.Attributes.Add("class", "metric-label d-inline-block float-right text-success font-weight-bold");
            metricLabel.Controls.Add(new HtmlGenericControl("span")
            {
                InnerHtml = "<i class='fa fa-fw fa-arrow-up'></i>"
            });
            metricLabel.Controls.Add(new HtmlGenericControl("span")
            {
                InnerHtml = Percentage.ToString() + '%'
            });
            
            metricValueH1 = new HtmlGenericControl("h1");
            metricValueH1.Attributes.Add("class", "mb-1");
            metricValueH1.InnerHtml = MetricValue;

            metricValue = new HtmlGenericControl("div");
            metricValue.Attributes.Add("class", "metric-value d-inline-block");
            metricValue.Controls.Add(metricValueH1);

            textMuted = new HtmlGenericControl("h5");
            textMuted.Attributes.Add("class", "text-muted");
            textMuted.InnerHtml = Title;

            cardBody = new HtmlGenericControl("div");
            cardBody.Attributes.Add("class", "card-body");
            cardBody.Controls.Add(textMuted);
            cardBody.Controls.Add(metricValue);
            cardBody.Controls.Add(metricLabel);

            cardWrapper = new HtmlGenericControl("div");
            cardWrapper.Attributes.Add("class", "card");
            cardWrapper.Controls.Add(cardBody);
            cardWrapper.Controls.Add(sparklineRevenue);

            Controls.Add(cardWrapper);

            FillColor = (!String.IsNullOrEmpty(FillColor)) ? FillColor : "#dbdeff";
            LineColor = (!String.IsNullOrEmpty(LineColor)) ? LineColor : "#5969ff";

            string jsinitialization = "$(document).ready(function() {" +
                "$(\"#" + this.ID + "\").sparkline([1, 1, 7, 7, 9, 5, 3, 5, 10, 4, 6, 10], {" +
                "type: 'line'," +
                "width: '99.5%'," +
                "height: '100'," +
                "lineColor: '" + LineColor + "'," +
                "fillColor: '" + FillColor + "'," +
                "lineWidth: 2," +
                "spotColor: undefined," +
                "minSpotColor: undefined," +
                "maxSpotColor: undefined," +
                "highlightSpotColor: undefined," +
                "highlightLineColor: undefined," +
                "resize: true" +
                "});});";

            registerJavaScript(jsinitialization);
        }

        public void registerJavaScript(string jsinitialization)
        {
            ScriptManager scr = ScriptManager.GetCurrent(Page);

            if ((scr != null) && (scr.IsInAsyncPostBack))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), jsinitialization, true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), this.ClientID + "_startup", jsinitialization, true);
            }
        }
    }
}
