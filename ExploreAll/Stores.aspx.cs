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
                case "ContentOne":
                    ContentOne.Text = data["Value"].ToString();
                    break;
                case "SubContent1":
                    SubContent1.Text = data["Value"].ToString();
                    break;
                case "ContentTwo":
                    ContentTwo.Text = data["Value"].ToString();
                    break;
                case "SubContent2":
                    SubContent2.Text = data["Value"].ToString();
                    break;
                case "ContentThree":
                    ContentThree.Text = data["Value"].ToString();
                    break;
                case "SubContent3":
                    SubContent3.Text = data["Value"].ToString();
                    break;
                case "ContentFour":
                    ContentFour.Text = data["Value"].ToString();
                    break;
                case "SubContent4":
                    SubContent4.Text = data["Value"].ToString();
                    break;



                default:
                  break;
               
            }



            }
        }
    }
