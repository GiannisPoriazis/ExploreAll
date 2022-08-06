using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ExploreAll
{    
    public class WebMethodResult
    {
        public string data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class ExploreAllHelper
    {
        public static string StoreHtml = @"<div class='col-sm-6'>
                            <div class='img_wrapper'>
                                <div class='ribbon'>
                                    <span>Popular</span>
                                </div>
                                <div class='tools_i'>
                                    <form action='http://maps.google.com/maps' method='get' target='_blank' class='directions_list'>
                                        <input type='hidden' name='daddr' value='43.773460, 11.255985'>
                                        <button type='submit' class='tooltip_styled tooltip-effect-4'>
                                            <span class='tooltip-item'></span>
                                            <span class='tooltip-content'>Directions</span>
                                        </button>
                                    </form>
                                    <div class='wishlist_close'></div>
                                </div>
                                <!-- End tools i-->
                                <div class='img_container'>
                                    <a href='florence-must-see-detail.html'>
                                        <img style='background-image: url({6}); background-size: cover; background-position: center;' width='800' height='533' width='800' height='533' class='img-responsive' alt=''>
                                        <div class='short_info'>
                                            <h3>{0}</h3>
                                            <em>{1}</em>
                                            <div class='score_wp'>{3}
                                                <div id='score_1' class='score' data-value='{2}'></div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <!--End img_wrapper-->
                        </div>
                        <div class='col-sm-6'>
                            <div class='desc'>
                                {5}
                                <p>
                                    {4}
                                </p>
                                <p><a href='florence-must-see-detail.html' class='button small'>Read more</a>
                                </p>
                            </div>
                        </div>
                    </div>";
        public static string SightHtml = @"<div class='col-lg-6 col-md-12 col-sm-6 interest-point' data-title='{4}' data-category='{5}' data-desc='{6}' data-lat='{7}' data-long='{8}'>
                            <div class='img_wrapper'>
                                <div class='ribbon'>
                                    <span>Popular</span>
                                </div>
                                <div class='tools_i'>
                                    <div class='directions_list_map' onclick='onHtmlClick('Bars', 1)'>
                                        <a class='tooltip_styled tooltip-effect-4'><span class='tooltip-item'></span>
								    <div class='tooltip-content'>View on map</div>
								    </a>
                                    </div>
                                    <div class='wishlist'>
                                        <a class='tooltip_styled tooltip-effect-4'><span class='tooltip-item'></span>
								    <div class='tooltip-content'>Bookmark</div>
								    </a>
                                    </div>
                                </div>
                                <!-- End tool_i -->
                                <div class='img_container'>
                                    <a href = 'florence-bar-detail.html'>
                                        <img style='background-image: url({2}); background-size: cover; background-position: center;' width='800' height='533' class='img-responsive' alt=''>
                                        <div class='short_info'>
                                            <h3>{0}</h3>
                                            <em>{1}</em>
                                            <p>
                                                {3}
                                            </p>
                                            <div class='score_wp'>Superb
                                                <div id='score_2' class='score' data-value='8.5'></div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <!-- End img_wrapper -->
                        </div>";
        public static string CounterNavigationHtml = @"<nav>
                        <ul class='pagination'>
                            <li class='disabled'><a href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a>
                            </li>
                                <li class='active'><a href = '#'>1<span class='sr-only'>(current)</span></a>
                            </li>
                            {0}
                            <li>
                                <a href='#' aria-label='Next'>
                                    <span aria-hidden='true'>&raquo;</span>
                                </a>
                            </li>
                        </ul>
                    </nav>";
        public static string CNPage = @"<li><a>{0}</a></li>";
        public static string Row = @"<div class='row'>{0}</div>";

        public static string GetImageSource(string FileName)
        {
            string fileUri = string.Empty;
            string url = $"http://localhost:44320/GetImageSource.aspx?file={FileName}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                fileUri = reader.ReadToEnd();
            }

            return fileUri;
        }
    }
}