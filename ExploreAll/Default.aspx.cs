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
                case "Welcome":
                    Welcome.Text = data["Value"].ToString();
                    break;
                case "Card1":
                    Card1.Text =  data["Value"].ToString();
                    break;
                case "Text2":
                    Text2.Text = data["Value"].ToString();
                    break;
                case "Text1":
                    Text1.Text = data["Value"].ToString();
                    break;
                case "Card2":
                    Card2.Text = data["Value"].ToString();
                    break;
                case "Card3":
                    Card3.Text = data["Value"].ToString();
                    break;
                case "Text3":
                    Text3.Text = data["Value"].ToString();
                    break;
                case "Card4":
                    Card4.Text = data["Value"].ToString();
                    break;
                case "Text4":
                    Text4.Text = data["Value"].ToString();
                    break;
                case "Card5":
                    Card5.Text = data["Value"].ToString();
                    break;
                case "Text5":
                    Text5.Text = data["Value"].ToString();
                    break;
                case "Card6":
                    Card6.Text = data["Value"].ToString();
                    break;
                case "Text6":
                    Text6.Text = data["Value"].ToString();
                    break;
                case "Card7":
                    Card7.Text = data["Value"].ToString();
                    break;
                case "Text7":
                    Text7.Text = data["Value"].ToString();
                    break;
                case "Card8":
                    Card8.Text = data["Value"].ToString();
                    break;
                case "Text8":
                    Text8.Text = data["Value"].ToString();
                    break;
                case "Section1":
                    Section1.Text = data["Value"].ToString();
                    break;
                case "Subsection1":
                    Subsection1.Text = data["Value"].ToString();
                    break;
                case "Section2":
                    Section2.Text = data["Value"].ToString();
                    break;
                case "Subsection2":
                    Subsection2.Text = data["Value"].ToString();
                    break;
                case "Photos1":
                    Photos1.Text = data["Value"].ToString();
                    break;
                case "Pic1":
                    Pic1.Text = data["Value"].ToString();
                    break;
                case "Desc1":
                    Desc1.Text = data["Value"].ToString();
                    break;
                case "Pic2":
                    Pic2.Text = data["Value"].ToString();
                    break;
                case "Desc2":
                    Desc2.Text = data["Value"].ToString();
                    break;
                case "Pic3":
                    Pic3.Text = data["Value"].ToString();
                    break;
                case "Desc3":
                    Desc3.Text = data["Value"].ToString();
                    break;
                case "Pic4":
                    Pic4.Text = data["Value"].ToString();
                    break;
                case "Desc4":
                    Desc4.Text = data["Value"].ToString();
                    break;
                case "Photos2":
                    Photos2.Text = data["Value"].ToString();
                    break;
                case "Pics1":
                    Pics1.Text = data["Value"].ToString();
                    break;
                case "Descs1":
                    Descs1.Text = data["Value"].ToString();
                    break;
                case "Pics2":
                    Pics2.Text = data["Value"].ToString();
                    break;
                case "Descs2":
                    Descs2.Text = data["Value"].ToString();
                    break;
                case "Pics3":
                    Pics3.Text = data["Value"].ToString();
                    break;
                case "Descs3":
                    Descs3.Text = data["Value"].ToString();
                    break;
                case "Pics4":
                    Pics4.Text = data["Value"].ToString();
                    break;
                case "Descs4":
                    Descs4.Text = data["Value"].ToString();
                    break;
                case "Photos4":
                    Photos4.Text = data["Value"].ToString();
                    break;            
                case "Img1":
                    Img1.Text = data["Value"].ToString();
                    break;
                case "Descr1":
                    Descr1.Text = data["Value"].ToString();
                    break;
                case "Img2":
                    Img2.Text = data["Value"].ToString();
                    break;
                case "Descr2":
                    Descr2.Text = data["Value"].ToString();
                    break;
                case "Img3":
                    Img3.Text = data["Value"].ToString();
                    break;
                case "Descr3":
                    Descr3.Text = data["Value"].ToString();
                    break;
                case "Section3":
                    Section3.Text = data["Value"].ToString();
                    break;
                case "SubCard1":
                    SubCard1.Text = data["Value"].ToString();
                    break;
                case "SubText1":
                    SubText1.Text = data["Value"].ToString();
                    break;
                case "SubCard2":
                    SubCard2.Text = data["Value"].ToString();
                    break;
                case "SubText2":
                    SubText2.Text = data["Value"].ToString();
                    break;
                case "SubCard3":
                    SubCard3.Text = data["Value"].ToString();
                    break;
                case "SubText3":
                    SubText3.Text = data["Value"].ToString();
                    break;
                case "Footer1":
                    Footer1.Text = data["Value"].ToString();
                    break;
                case "FooterText1":
                    FooterText1.Text = data["Value"].ToString();
                    break;
                case "LinkHeader":
                    LinkHeader.Text = data["Value"].ToString();
                    break;
                case "Link1":
                    Link1.Text = data["Value"].ToString();
                    break;
                case "Link2":
                    Link2.Text = data["Value"].ToString();
                    break;
                case "Link3":
                    Link3.Text = data["Value"].ToString();
                    break;
                case "Link4":
                    Link4.Text = data["Value"].ToString();
                    break;
                case "Link5":
                    Link5.Text = data["Value"].ToString();
                    break;
                case "Link6":
                    Link6.Text = data["Value"].ToString();
                    break;
                case "Footer2":
                    Footer2.Text = data["Value"].ToString();
                    break;
                case "FooterText2":
                    FooterText2.Text = data["Value"].ToString();
                    break;
                case "Language":
                    Language.Text = data["Value"].ToString();
                    break;
                case "SubFooter":
                    Subfooter.Text = data["Value"].ToString();
                    break;
                default:
                    break;

            }
        }
    }
}