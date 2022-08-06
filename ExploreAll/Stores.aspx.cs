using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreAll
{
    public partial class Stores: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DBSupport.GetData("LabelsTable");
            foreach (DataRow dr in dt.Rows)
                SetValues(dr);

            StoresWrapper.Text = String.Empty;
            DataTable stores = DBSupport.GetData("StoresTable");

            for (int i = 0; i < stores.Rows.Count; i += 2)
            {
                DataRow storeRow = stores.Rows[i];

                StoresWrapper.Text += String.Format(
                    ExploreAllHelper.Row,
                    String.Format(ExploreAllHelper.StoreHtml, storeRow["Title"], storeRow["Label"], "7.5", "Superb", storeRow["Description"], storeRow["Title"], "data:image/png;base64," + ExploreAllHelper.GetImageSource(storeRow["Thumbnail"].ToString()))
                );
            }
        }

        protected void SetValues(DataRow data)
        {
            switch (data["Selector"])
            {
                case "HeadTitle":
                    HeadTitle.Text = data["Value"].ToString();
                    break;
                case "SubTitle":
                    SubTitle.Text = data["Value"].ToString();
                    break;
                case "HeadLink1":
                    HeadLink1.Text = data["Value"].ToString();
                    break;
                case "HeadLink2":
                    HeadLink2.Text = data["Value"].ToString();
                    break;
                case "HeadLink3":
                    HeadLink3.Text = data["Value"].ToString();
                    break;                
                case "Categories":
                    Categories.Text = data["Value"].ToString();
                    break;
                case "Tab1":
                    Tab1.Text = data["Value"].ToString();
                    break;
                case "Tab2":
                    Tab2.Text = data["Value"].ToString();
                    break;
                case "Tab3":
                    Tab3.Text = data["Value"].ToString();
                    break;
                case "Tab4":
                    Tab4.Text = data["Value"].ToString();
                    break;
                case "Tab5":
                    Tab5.Text = data["Value"].ToString();
                    break;
                case "Tab6":
                    Tab6.Text = data["Value"].ToString();
                    break;
                case "Tab7":
                    Tab7.Text = data["Value"].ToString();
                    break;
                case "Tab8":
                    Tab8.Text = data["Value"].ToString();
                    break;
                case "StoresFooter1":
                    StoresFooter1.Text = data["Value"].ToString();
                    break;
                case "StoresSubFooter1":
                    StoresSubFooter1.Text = data["Value"].ToString();
                    break;
                case "StoresLinks":
                    StoresLinks.Text = data["Value"].ToString();
                    break;
                case "StoresLink1":
                    StoresLink1.Text = data["Value"].ToString();
                    break;
                case "StoresLink2":
                    StoresLink2.Text = data["Value"].ToString();
                    break;
                case "StoresLink3":
                    StoresLink3.Text = data["Value"].ToString();
                    break;
                case "StoresLink4":
                    StoresLink4.Text = data["Value"].ToString();
                    break;
                case "StoresLink5":
                    StoresLink5.Text = data["Value"].ToString();
                    break;
                case "StoresLink6":
                    StoresLink6.Text = data["Value"].ToString();
                    break;
                case "StoresFooter2":
                    StoresFooter2.Text = data["Value"].ToString();
                    break;
                case "StoresSubFooter2":
                    StoresSubFooter2.Text = data["Value"].ToString();
                    break;
                case "StoresLanguage":
                    StoresLanguage.Text = data["Value"].ToString();
                    break;
                case "StoresCopyright":
                    StoresCopyright.Text = data["Value"].ToString();
                    break;
                case "FilterSet1":
                    FilterSet1.Text = data["Value"].ToString();
                    break;
                case "Filter1":
                    Filter1.Text = data["Value"].ToString();
                    break;
                case "Filter2":
                    Filter2.Text = data["Value"].ToString();
                    break;
                case "Filter3":
                    Filter3.Text = data["Value"].ToString();
                    break;
                case "Filter4":
                    Filter4.Text = data["Value"].ToString();
                    break;
                case "Filter5":
                    Filter5.Text = data["Value"].ToString();
                    break;
                case "FilterSet2":
                    FilterSet2.Text = data["Value"].ToString();
                    break;
                case "Filter6":
                    Filter6.Text = data["Value"].ToString();
                    break;
                case "Filter7":
                    Filter7.Text = data["Value"].ToString();
                    break;
                case "Filter8":
                    Filter8.Text = data["Value"].ToString();
                    break;
                case "Filter9":
                    Filter9.Text = data["Value"].ToString();
                    break;
                case "FilterSlider":
                    FilterSlider.Text = data["Value"].ToString();
                    break;
                default:
                    break;
               
            }
        }
    }
}
