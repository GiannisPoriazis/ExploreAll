using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreAll
{
    public partial class Sights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SightsWrapper.Text = String.Empty;
            DataTable dt = DBSupport.GetData("SightsTable");

            for(int i=0; i<dt.Rows.Count; i+=2) 
            {
                DataRow dr = dt.Rows[i];

                if (i < dt.Rows.Count - 1)
                {
                    DataRow dr2 = dt.Rows[i + 1];
                    SightsWrapper.Text += String.Format(
                        ExploreAllHelper.Row,
                        String.Format(ExploreAllHelper.SightHtml, dr["Name"], dr["Label"], "data:image/png;base64," + ExploreAllHelper.GetImageSource(dr["Thumbnail"].ToString()), dr["Description"], dr["Name"], dr["Label"], dr["Description"], dr["Lat"], dr["Long"]) +
                        String.Format(ExploreAllHelper.SightHtml, dr2["Name"], dr2["Label"], "data:image/png;base64," + ExploreAllHelper.GetImageSource(dr2["Thumbnail"].ToString()), dr2["Description"], dr2["Name"], dr2["Label"], dr2["Description"], dr2["Lat"], dr2["Long"])
                    );
                }
                else
                {
                    SightsWrapper.Text += String.Format(
                        ExploreAllHelper.Row,
                        String.Format(ExploreAllHelper.SightHtml, dr["Name"], dr["Label"], "data:image/png;base64," + ExploreAllHelper.GetImageSource(dr["Thumbnail"].ToString()), dr["Description"], dr["Name"], dr["Label"], dr["Description"], dr["Lat"], dr["Long"])
                    );
                }
            }

            string navMenu = String.Empty;
            int navPages = 1;
            for (int i = 6; i < dt.Rows.Count; i += 6)
            {
                navPages++;
                navMenu += String.Format(ExploreAllHelper.CNPage, navPages);                
            }


            SightsWrapper.Text += String.Format(
                ExploreAllHelper.CounterNavigationHtml,
                navMenu
            );
        }
    }
}