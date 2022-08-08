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
    [ToolboxData("<{0}:InteractivePieChart runat=server></{0}:InteractivePieChart>")]
    public class InteractivePieChart : TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]

        public string Title { get; set; }

        protected HtmlGenericControl cardContainer;
        protected HtmlGenericControl cardHeader;
        protected HtmlGenericControl cardBody;
        protected HtmlGenericControl c3Chart;

        protected override void CreateChildControls()
        {

            c3Chart = new HtmlGenericControl("div");
            c3Chart.Attributes.Add("style", "height: 420px;");
            c3Chart.ID = this.ID;

            cardBody = new HtmlGenericControl("div");
            cardBody.Attributes.Add("class", "card-body");
            cardHeader.Controls.Add(c3Chart); 

            cardHeader = new HtmlGenericControl("h5");
            cardHeader.Attributes.Add("class", "class-header");
            cardHeader.InnerHtml = Title;

            cardContainer = new HtmlGenericControl("div");
            cardContainer.Attributes.Add("class", "card");
            cardContainer.Controls.Add(cardHeader);
            cardContainer.Controls.Add(cardBody);

            Controls.Add(cardContainer);

            string jsinitialization = "$(document).ready(function() {" +
             "$(\"#" + this.ID + "\").var chart = c3.generate({" +
                                  "bindto: '#c3chart_category'," +
                                  "data: {" +
                                       "columns: [" +
                                             "['Men', 100]," +
                                             "['Women', 80]," +
                                             "['Accessories', 50]," +
                                             "['Children', 40]," +
                                             "['Apperal', 20]," +
                                        "]," +
                                        "type: 'donut'," +

                                         "onclick: function(d, i) { console.log('onclick', d, i); }," +
                                         "onmouseover: function(d, i) { console.log('onmouseover', d, i); }," +
                                         "onmouseout: function(d, i) { console.log('onmouseout', d, i); }," +

                                          "colors: {" +
                                              "Men: '#5969ff'," +
                                              "Women: '#ff407b'," +
                                              "Accessories: '#25d5f2'," +
                                              "Children: '#ffc750'," +
                                              "Apperal: '#2ec551'," +


                                           "}" +
                                      "}," +
                                      "donut: {" +
                                           "label: {" +
                                               "show: false" +
                                            "}" +
                                       "}," +

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
