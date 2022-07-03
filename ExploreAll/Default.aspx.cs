using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreAll
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DBSupport.GetData("LabelsTable");
            foreach (DataRow dr in dt.Rows)
                SetValues(dr);
        }

        protected void SetValues(DataRow data)
        {
            switch (data["Selector"])
            {
                case "Header1":
                    Header1.Text = data["Value"].ToString();
                    break;
                case "Subtitle1":
                    Subtitle1.Text = data["Value"].ToString();
                    break;
                default:
                    break;    
            }
        }
    }
}