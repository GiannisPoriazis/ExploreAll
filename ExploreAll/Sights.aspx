<%@ Page Language="C#" MasterPageFile="~/system/templates/base.Master" AutoEventWireup="true" CodeBehind="Sights.aspx.cs" Inherits="ExploreAll.Sights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="TravelGuide Site Template - Easly find places, guides, directions, info.">
    <meta name="author" content="Ansonika">
    <title>TravelGuide Site Template - Easly find places, guides, directions, info.</title>

    <!-- Favicons-->
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
    <link rel="apple-touch-icon" type="image/x-icon" href="img/apple-touch-icon-57x57-precomposed.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="72x72" href="img/apple-touch-icon-72x72-precomposed.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="114x114" href="img/apple-touch-icon-114x114-precomposed.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="144x144" href="img/apple-touch-icon-144x144-precomposed.png">

    <!-- GOOGLE FONT -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,500,700,300" rel="stylesheet" type="text/css">

    <!-- BASE CSS -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/animate.min.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/bootstrap.min.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/style.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/menu.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/icon_fonts/css/all_icons.min.css" rel="stylesheet">

    <!-- SPECIFIC CSS -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/ion.rangeSlider.css" rel="stylesheet">
    
    <!-- YOUR CUSTOM CSS -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/custom.css" rel="stylesheet">
    
    <style>
        html,
        body {
            height: 100%;
        }

        #form1, #form1 > div:not(.aspNetHidden) {
            height: 100%;
        }
    </style>

    <!--[if lt IE 9]>
      <script src="js/html5shiv.min.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid full-height">
        <div class="row row-height">
            <div class="col-lg-7 col-md-6 content-left">
                <div id="filters_map">
                    <a data-toggle="collapse" href="#collapseFiltesmap" aria-expanded="false" aria-controls="collapseFiltesmap" class="btn_filter" id="open_filters"></a>
                    <div class="pull-right">
                        <a href="florence-bars-grid.html" class="btn_filter" id="grid"></a>
                        <a href="florence-bars-list.html" class="btn_filter" id="list"></a>
                    </div>
                    <div id="collapseFiltesmap" class="collapse">
                        <div class="filter_type clearfix">
                            <h6>Duration</h6>
                            <div class="range_wp">
                                <input type="text" id="range" name="range" value="">
                            </div>
                        </div>
                        <div class="filter_type clearfix">
                            <h6>Review score</h6>
                            <ul>
                                <li>
                                    <label>Superb: 9+ (77)</label>
                                    <input type="checkbox" class="js-switch" checked>
                                </li>
                                <li>
                                    <label>Very good: 8+ (552)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                                <li>
                                    <label>Good: 7+ (909)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                                <li>
                                    <label>Pleasant: 6+ (1196)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                                <li>
                                    <label>No rating (198)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                            </ul>
                        </div>
                        <div class="filter_type clearfix">
                            <h6>Type</h6>
                            <ul>
                                <li>
                                    <label>Cocktails Bar (77)</label>
                                    <input type="checkbox" class="js-switch" checked>
                                </li>
                                <li>
                                    <label>Pub (552)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                                <li>
                                    <label>Snack Bars (909)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                                <li>
                                    <label>Coffee Bar (1196)</label>
                                    <input type="checkbox" class="js-switch">
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <asp:Literal runat="server" ID="SightsWrapper"></asp:Literal>
            </div>
            <!-- End content-left-->

            <div class=" col-lg-5 col-md-6 map-right">
                <div class="map" id="map"></div>
                <!-- map-->
            </div>

        </div>
        <!-- End row-->
    </div>
    <!-- End container-fluid -->

    <!-- Footer ================================================== -->
    <footer class="hidden-lg hidden-md">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-12">
                    <h3>About us</h3>
                    <p>Dolorem nusquam molestie ut mei, ut sit dico omnis. Cu quod congue has, at sumo esse viderer mea. Id assum saperet definitiones qui.</p>
                    <p><img src="public/img/logo_2.png" alt="img" class="hidden-xs" width="170" height="30" data-retina="true">
                    </p>
                </div>
                <div class="col-md-3 col-sm-4">
                    <h3>About</h3>
                    <ul>
                        <li><a href="#0">About us</a>
                        </li>
                        <li><a href="#0">Faq</a>
                        </li>
                        <li><a href="#0">Contacts</a>
                        </li>
                        <li><a href="#0">Login</a>
                        </li>
                        <li><a href="#0">Register</a>
                        </li>
                        <li><a href="#0">Terms and conditions</a>
                        </li>
                    </ul>
                </div>
                <div class="col-md-3 col-sm-4" id="newsletter">
                    <h3>Newsletter</h3>
                    <p>
                        Join our newsletter to keep be informed about offers and news.
                    </p>
                    <div id="message-newsletter_2">
                    </div>
                    <form method="post" action="assets/newsletter.php" name="newsletter_2" id="newsletter_2">
                        <div class="form-group">
                            <input name="email_newsletter_2" id="email_newsletter_2" type="email" value="" placeholder="Your mail" class="form-control">
                        </div>
                        <p>
                            <input type="submit" value="Subscribe" class="button" id="submit-newsletter_2">
                        </p>
                    </form>
                </div>
                <div class="col-md-2 col-sm-4">
                    <h3>Settings</h3>
                    <div class="styled-select">
                        <select class="form-control" name="lang" id="lang">
                            <option value="English" selected>English</option>
                            <option value="French">French</option>
                            <option value="Spanish">Spanish</option>
                            <option value="Russian">Russian</option>
                        </select>
                    </div>
                </div>
            </div>
            <!-- End row -->
            <hr>
            <div class="row">
                <div class="col-sm-6">
                    © TravelGuide 2016 - All Rights Reserved
                </div>
                <div class="col-sm-6">
                    <div id="social_footer">
                        <ul>
                            <li><a href="#0"><i class="icon-facebook"></i></a>
                            </li>
                            <li><a href="#0"><i class="icon-twitter"></i></a>
                            </li>
                            <li><a href="#0"><i class="icon-google"></i></a>
                            </li>
                            <li><a href="#0"><i class="icon-instagram"></i></a>
                            </li>
                            <li><a href="#0"><i class="icon-pinterest"></i></a>
                            </li>
                        </ul>

                    </div>
                </div>
            </div>
            <!-- End row -->
        </div>
        <!-- End container -->
    </footer>
    <!-- End Footer =============================================== -->

    <!-- COMMON SCRIPTS -->
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/jquery-2.2.4.min.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/common_scripts_min.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/assets/validate.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/functions.js"></script>

    <!-- SPECIFIC SCRIPTS -->
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/raphael-2.1.4.min.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/justgage.min.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/score.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAS_xFikYQ4BeuE-gIb8S6tt-evLHRwEMs"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/bars_map.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/infobox.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/ion.rangeSlider.min.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/switchery.js"></script>
    <script>
        'use strict';
        var elems = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
        elems.forEach(function (html) {
            var switchery = new Switchery(html, {
                size: 'small'
            });
        });

        $("#range").ionRangeSlider({
            hide_min_max: true,
            keyboard: true,
            min: 30,
            max: 180,
            from: 60,
            to: 130,
            type: 'double',
            step: 1,
            prefix: "Min. ",
            grid: false
        });

        var markersData;

        $(document).ready(function () {
            markersData = { 'Mustsee': [] };
            $(".interest-point").each(function () {
                markersData['Mustsee'].push({
                    type_point: $(this).attr("data-category"),
                    location_latitude: parseFloat($(this).attr("data-lat")),
                    location_longitude: parseFloat($(this).attr("data-long")),
                    map_image_url: null,
                    rate: 'Superb | 7.5',
                    name_point: $(this).attr("data-title"),
                    description_point: $(this).attr("data-desc"),
                    get_directions_start_address: '',
                    phone: null,
                    url_detail: null
                });
            });
            initMapObject();
        });
    </script>
</asp:Content>