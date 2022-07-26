<%@ Page Title="" Language="C#" MasterPageFile="~/system/templates/base.Master" AutoEventWireup="true" CodeBehind="~/Default.aspx.cs" Inherits="ExploreAll.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="Ansonika">

    <!-- Favicons-->
    <link rel="shortcut icon" href="<%# ResolveClientUrl(@"~/")%>public/img/favicon.ico" type="image/x-icon">
    <link rel="apple-touch-icon" type="image/x-icon" href="<%# ResolveClientUrl(@"~/")%>public/img/apple-touch-icon-57x57-precomposed.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="72x72" href="<%# ResolveClientUrl(@"~/")%>public/img/apple-touch-icon-72x72-precomposed.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="114x114" href="<%# ResolveClientUrl(@"~/")%>public/img/apple-touch-icon-114x114-precomposed.png">
    <link rel="apple-touch-icon" type="image/x-icon" sizes="144x144" href="<%# ResolveClientUrl(@"~/")%>public/img/apple-touch-icon-144x144-precomposed.png">

    <!-- GOOGLE FONT -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,500,700,300" rel="stylesheet" type="text/css">

    <!-- BASE CSS -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/animate.min.css" rel="stylesheet">  
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/bootstrap.min.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/style.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/menu.css" rel="stylesheet">
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/icon_fonts/css/all_icons.min.css" rel="stylesheet">
    
    <!-- YOUR CUSTOM CSS -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/css/custom.css" rel="stylesheet">

    <!-- Modernizr -->
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/modernizr.js"></script>

    <style>
        header {
            background: transparent;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">  
    <!-- SubHeader =============================================== -->
    <section class="header-video">
        <div id="hero_video">
            <div id="sub_content_in">
                <asp:Literal runat="server" ID="Welcome"></asp:Literal>
                
                <p>
                    ΒΡΕΙΤΕ ΟΤΙ ΑΝΑΖΗΤΑΤΕ ΣΤΟ ΝΗΣΙ ΤΟΥ ΗΦΑΙΣΤΟΥ
                </p>

            </div>
            <!-- End sub_content -->
        </div>
        <img src="<%# ResolveClientUrl(@"~/")%>public/img/video_fix.png" alt="" class="header-video--media" data-video-src="<%# ResolveClientUrl(@"~/")%>public/video/intro" data-teaser-source="<%# ResolveClientUrl(@"~/")%>public/video/intro" data-provider="" data-video-width="1920" data-video-height="960">
    </section>
    <!-- End Header video -->
    <!-- End SubHeader ============================================ -->

    <div class="container margin_60_30">
        <div class="main_title">
            <asp:Literal runat="server" ID="Header1"></asp:Literal>
            <asp:Literal runat="server" ID="Subtitle1"></asp:Literal>
            <span><em></em></span>
        </div>

        <div class="row box_cat">
            <div class="col-md-3 col-sm-6">
                <a href="florence-must-see-map-listing.html">
                    <span>23</span>
                    <i class=" icon_set_1_icon-1"></i>
                    <asp:Literal runat="server" ID="Card1"></asp:Literal>
                    <p>
                       <asp:Literal runat="server" ID="Text1"></asp:Literal>
                    </p>
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <a href="florence-event-map-listing.html">
                    <span>34</span>
                    <i class="icon_set_1_icon-41"></i>
                    <asp:Literal runat="server" ID="Card2"></asp:Literal>
                    <p> 
                      <asp:Literal runat="server" ID="Text2"></asp:Literal>
                    </p>
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <a href="florence-hotels-map-listing.html">
                    <span>12</span>
                    <i class="icon_set_1_icon-6"></i>
                    <asp:Literal runat="server" ID="Card3"></asp:Literal>
                    <p>
                       <asp:Literal runat="server" ID="Text3"></asp:Literal>
                    </p>
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <a href="florence-restaurants-map-listing.html">
                    <span>43</span>
                    <i class="icon_set_1_icon-58"></i>
                    <asp:Literal runat="server" ID="Card4"></asp:Literal>
                    <p>
                       <asp:Literal runat="server" ID="Text4"></asp:Literal>
                    </p>
                </a>
            </div>
        </div>
        <!-- End row -->

        <div class="row box_cat">
            <div class="col-md-3 col-sm-6">
                <a href="florence-bars-map-listing.html">
                    <span>23</span>
                    <i class="icon_set_1_icon-20"></i>
                     <asp:Literal runat="server" ID="Card5"></asp:Literal>
                    <p>
                        <asp:Literal runat="server" ID="Text5"></asp:Literal>
                    </p>
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <a href="florence-shops-map-listing.html">
                    <span>34</span>
                    <i class="icon_set_1_icon-50"></i>
                     <asp:Literal runat="server" ID="Card6"></asp:Literal>
                    <p>
                       <asp:Literal runat="server" ID="Text6"></asp:Literal>
                    </p>
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <a href="florence-transports.html">
                    <span>43</span>
                    <i class="icon_set_1_icon-25"></i>
                     <asp:Literal runat="server" ID="Card7"></asp:Literal>
                    <p>
                        <asp:Literal runat="server" ID="Text7"></asp:Literal>
                    </p>
                </a>
            </div>
            <div class="col-md-3 col-sm-6">
                <a href="faq.html">
                    <span>12</span>
                    <i class="icon_set_1_icon-54"></i>
                     <asp:Literal runat="server" ID="Card8"></asp:Literal>
                    <p>
                      <asp:Literal runat="server" ID="Text8"></asp:Literal>
                    </p>
                </a>
            </div>
        </div>
        <!-- End row -->
    </div>
    <!-- End container -->

    <div class="pattern_dots">
        <div class="container margin_60_45">
            <div class="main_title">
                <asp:Literal runat="server" ID="Section1"></asp:Literal>
                <p>
                   <asp:Literal runat="server" ID="Subsection1"></asp:Literal>
                </p>
                <span><em></em></span>
            </div>
            <!-- End main_title -->

            <div class="row">
                <div class="col-md-8">
                    <div class="img_wrapper_grid">
                        <div class="ribbon">
                            <span>Popular</span>
                        </div>
                        <div class="tools_i">
                            <form action="http://maps.google.com/maps" method="get" target="_blank" class="directions_list">
                                <input type="hidden" name="daddr" value="43.773460, 11.255985">
                                <button type="submit" class="tooltip_styled tooltip-effect-4">
                                    <span class="tooltip-item"></span>
                                    <span class="tooltip-content">Directions</span>
                                </button>
                            </form>
                            <div class="wishlist">
                                <a class="tooltip_styled tooltip-effect-4"><span class="tooltip-item"></span>
                                <div class="tooltip-content">Bookmark</div>
                                </a>
                            </div>
                        </div>
                        <!-- End tools i-->
                        <div class="img_container_grid">
                            <a href="florence-must-see-detail.html">
                                <img src="<%# ResolveClientUrl(@"~/")%>public/img/grid_home_1.jpg" width="800" height="480" class="img-responsive" alt="">
                                <div class="short_info_grid">
                                    <small><strong>Duration: 90 min.</strong></small>
                                    <h3>Duomo Cathedral</h3>
                                    <em>Historic Buildings</em>
                                    <p>
                                        Read more
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper_grid -->
                </div>
                <div class="col-md-4">
                    <div class="img_wrapper_grid">
                        <div class="ribbon">
                            <span>Popular</span>
                        </div>
                        <div class="tools_i">
                            <form action="http://maps.google.com/maps" method="get" target="_blank" class="directions_list">
                                <input type="hidden" name="daddr" value="43.773460, 11.255985">
                                <button type="submit" class="tooltip_styled tooltip-effect-4">
                                    <span class="tooltip-item"></span>
                                    <span class="tooltip-content">Directions</span>
                                </button>
                            </form>
                            <div class="wishlist">
                                <a class="tooltip_styled tooltip-effect-4"><span class="tooltip-item"></span>
                                <div class="tooltip-content">Bookmark</div>
                                </a>
                            </div>
                        </div>
                        <!-- End tools i-->
                        <div class="img_container_grid">
                            <a href="florence-must-see-detail.html">
                                <img src="<%# ResolveClientUrl(@"~/")%>public/img/grid_home_3.jpg" width="800" height="468" class="img-responsive" alt="">
                                <div class="short_info_grid">
                                    <small><strong>Duration: 60 min.</strong></small>
                                    <h3>Santa Maria Novella</h3>
                                    <em>Monuments - Attractions</em>
                                    <p>
                                        Read more
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper_grid -->
                    <div class="img_wrapper_grid">
                        <div class="ribbon">
                            <span>Popular</span>
                        </div>
                        <div class="tools_i">
                            <form action="http://maps.google.com/maps" method="get" target="_blank" class="directions_list">
                                <input type="hidden" name="daddr" value="43.773460, 11.255985">
                                <button type="submit" class="tooltip_styled tooltip-effect-4">
                                    <span class="tooltip-item"></span>
                                    <span class="tooltip-content">Directions</span>
                                </button>
                            </form>
                            <div class="wishlist">
                                <a class="tooltip_styled tooltip-effect-4"><span class="tooltip-item"></span>
                                <div class="tooltip-content">Bookmark</div>
                                </a>
                            </div>
                        </div>
                        <!-- End tools i-->
                        <div class="img_container_grid">
                            <a href="florence-hotel-detail.html">
                                <img src="<%# ResolveClientUrl(@"~/")%>public/img/grid_home_2.jpg" width="800" height="468" class="img-responsive" alt="">
                                <div class="short_info_grid">
                                    <small><strong>From 95$</strong></small>
                                    <h3>Hotel Mariott</h3>
                                    <em>Hotels</em>
                                    <p>
                                        Read more
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper_grid -->
                </div>
            </div>
            <!-- End row -->
            <div class="row">
                <div class="col-md-4">
                    <div class="img_wrapper_grid">
                        <div class="ribbon top">
                            <span>Top rated</span>
                        </div>
                        <div class="tools_i">
                            <form action="http://maps.google.com/maps" method="get" target="_blank" class="directions_list">
                                <input type="hidden" name="daddr" value="43.773460, 11.255985">
                                <button type="submit" class="tooltip_styled tooltip-effect-4">
                                    <span class="tooltip-item"></span>
                                    <span class="tooltip-content">Directions</span>
                                </button>
                            </form>
                            <div class="wishlist">
                                <a class="tooltip_styled tooltip-effect-4"><span class="tooltip-item"></span>
                                <div class="tooltip-content">Bookmark</div>
                                </a>
                            </div>
                        </div>
                        <!-- End tools i-->
                        <div class="img_container_grid">
                            <a href="florence-restaurant-detail.html">
                                <img src="<%# ResolveClientUrl(@"~/")%>public/img/grid_home_4.jpg" width="800" height="468" class="img-responsive" alt="">
                                <div class="short_info_grid">
                                    <small><strong>From 30$</strong></small>
                                    <h3>Da Domenico</h3>
                                    <em>Restaurant</em>
                                    <p>
                                        Read more
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper_grid -->
                </div>
                <div class="col-md-4">
                    <div class="img_wrapper_grid">
                        <div class="ribbon top">
                            <span>Top rated</span>
                        </div>
                        <div class="tools_i">
                            <form action="http://maps.google.com/maps" method="get" target="_blank" class="directions_list">
                                <input type="hidden" name="daddr" value="43.773460, 11.255985">
                                <button type="submit" class="tooltip_styled tooltip-effect-4">
                                    <span class="tooltip-item"></span>
                                    <span class="tooltip-content">Directions</span>
                                </button>
                            </form>
                            <div class="wishlist">
                                <a class="tooltip_styled tooltip-effect-4"><span class="tooltip-item"></span>
                                <div class="tooltip-content">Bookmark</div>
                                </a>
                            </div>
                        </div>
                        <!-- End tools i-->
                        <div class="img_container_grid">
                            <a href="florence-bar-detail.html">
                                <img src="<%# ResolveClientUrl(@"~/")%>public/img/grid_home_5.jpg" width="800" height="468" class="img-responsive" alt="">
                                <div class="short_info_grid">
                                    <small><strong>From 20$</strong></small>
                                    <h3>La Grotta Pub</h3>
                                    <em>Bar - Pun</em>
                                    <p>
                                        Read more
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper_grid -->
                </div>
                <div class="col-md-4">
                    <div class="img_wrapper_grid">
                        <div class="ribbon top">
                            <span>Top rated</span>
                        </div>
                        <div class="tools_i">
                            <form action="http://maps.google.com/maps" method="get" target="_blank" class="directions_list">
                                <input type="hidden" name="daddr" value="43.773460, 11.255985">
                                <button type="submit" class="tooltip_styled tooltip-effect-4">
                                    <span class="tooltip-item"></span>
                                    <span class="tooltip-content">Directions</span>
                                </button>
                            </form>
                            <div class="wishlist">
                                <a class="tooltip_styled tooltip-effect-4"><span class="tooltip-item"></span>
                                <div class="tooltip-content">Bookmark</div>
                                </a>
                            </div>
                        </div>
                        <!-- End tools i-->
                        <div class="img_container_grid">
                            <a href="florence-shop-detail.html">
                                <img src="<%# ResolveClientUrl(@"~/")%>public/img/grid_home_6.jpg" width="800" height="468" class="img-responsive" alt="">
                                <div class="short_info_grid">
                                    <h3>Shopping Mall</h3>
                                    <em>Shop</em>
                                    <p>
                                        Read more
                                    </p>
                                </div>>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper_grid -->
                </div>
            </div>
            <!-- End row -->
        </div>
        <!-- End container -->
    </div>
    <!-- End pattern dots -->

    <div id="map_home">
    </div>
    <!-- End map_home -->

    <section class="bg_white margin_60_30">
        <div class="container">
            <div class="main_title">
                <asp:Literal runat="server" ID="Section2"></asp:Literal>
                <p>
                   <asp:Literal runat="server" ID="Subsection2"></asp:Literal>
                </p>
                <span><em></em></span>
            </div>
            <div id="tabs" class="tabs">
                <nav>
                    <ul>
                        <li><a href="#section-1"><span>Suggested</span></a>
                        </li>
                        <li><a href="#section-2"><span>Top Viewed</span></a>
                        </li>
                    </ul>
                </nav>
                <div class="content">
                    <section id="section-1">
                        <div class="row list_tabs">
                            <div class="col-md-4 col-sm-4">
                                <asp:Literal runat="server" ID="Photos1"></asp:Literal>
                                <ul>
                                    <li>
                                        <div>
                                            <a href="florence-must-see-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_1.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                  <asp:Literal runat="server" ID="Pic1"></asp:Literal>                                                
                                                <asp:Literal runat="server" ID="Desc1"></asp:Literal>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-must-see-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_2.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <asp:Literal runat="server" ID="Pic2"></asp:Literal>  
                                                <asp:Literal runat="server" ID="Desc2"></asp:Literal>  
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-event-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_3.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <asp:Literal runat="server" ID="Pic3"></asp:Literal>  
                                                <asp:Literal runat="server" ID="Desc3"></asp:Literal>  
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-event-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_4.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                 <asp:Literal runat="server" ID="Pic4"></asp:Literal>  
                                                 <asp:Literal runat="server" ID="Desc4"></asp:Literal>  
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-4 col-sm-4">
                             <asp:Literal runat="server" ID="Photos2"></asp:Literal>  
                                <ul>
                                    <li>
                                        <div>
                                            <a href="florence-restaurant-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_5.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                 <asp:Literal runat="server" ID="Pics1"></asp:Literal>  
                                                 <asp:Literal runat="server" ID="Descs1"></asp:Literal>  
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-restaurant-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_6.jpg" alt="" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <asp:Literal runat="server" ID="Pics2"></asp:Literal>  
                                                <asp:Literal runat="server" ID="Descs2"></asp:Literal>  
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-bar-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_7.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                               <asp:Literal runat="server" ID="Pics3"></asp:Literal>  
                                               <asp:Literal runat="server" ID="Descs3"></asp:Literal>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-bar-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_8.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                 <asp:Literal runat="server" ID="Pics4"></asp:Literal>  
                                               <asp:Literal runat="server" ID="Descs4"></asp:Literal>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <asp:Literal runat="server" ID="Photos4"></asp:Literal>
                                <ul>
                                    <li>
                                        <div>
                                            <a href="florence-shop-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_9.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                 <asp:Literal runat="server" ID="Img1"></asp:Literal>  
                                                 <asp:Literal runat="server" ID="Descr1"></asp:Literal>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-shop-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_10.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                   <asp:Literal runat="server" ID="Img2"></asp:Literal>  
                                                 <asp:Literal runat="server" ID="Descr2"></asp:Literal>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-shop-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_11.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <asp:Literal runat="server" ID="Img3"></asp:Literal>  
                                                 <asp:Literal runat="server" ID="Descr3"></asp:Literal>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </section>
                    <section id="section-2">
                        <div class="row list_tabs">
                            <div class="col-md-4 col-sm-4">
                                <h2>Must see and Events</h2>
                                <ul>
                                    <li>
                                        <div>
                                            <a href="florence-must-see-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_12.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Michelangelo Sculpture</h3>
                                                <small>Architectural Buildings</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-must-see-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_13.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Michelangelo Sculpture</h3>
                                                <small>Museum - Attractions</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-event-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_14.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Museum Free Entrance</h3>
                                                <small>Museums - Events</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-event-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_15.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Flea Market</h3>
                                                <small>Attractions - Events</small>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <h2>Eat and Drink</h2>
                                <ul>
                                    <li>
                                        <div>
                                            <a href="florence-restaurant-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_16.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Da Alfredo</h3>
                                                <small>Pizza - Italian</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-restaurant-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_17.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>La Bruschetteria</h3>
                                                <small>International - Italian</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-bar-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_18.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Domenico Bar</h3>
                                                <small>Cocktails Bar</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-bar-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_19.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Francis Bar</h3>
                                                <small>Pub</small>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <h2>Shops</h2>
                                <ul>
                                    <li>
                                        <div>
                                            <a href="florence-shop-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_20.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Florence Boutique</h3>
                                                <small>Men - Women</small>
                                            </a>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <a href="florence-shop-detail.html">
                                                <figure><img src="<%# ResolveClientUrl(@"~/")%>public/img/thumb_tabs_21.jpg" alt="thumb" class="img-rounded" width="60" height="60">
                                                </figure>
                                                <h3>Victoria Secrets</h3>
                                                <small>Men - Children</small>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </section>
                </div>
                <!--  End content -->
            </div>
            <!-- End tabs -->
        </div>
    </section>
    <!--  End section white -->

    <section class="parallax_window_home bright">
        <div class="container">
            <div class="main_title">
                <asp:Literal runat="server" ID="Section3"></asp:Literal>
            </div>
            <div class="row features add_bottom_45">
                <div class="col-sm-4">
                    <div id="feat_2">
                        <a href="about.html" class="bt_info">Read more</a>
                       <asp:Literal runat="server" ID="SubCard1"></asp:Literal>
                        <p>
                             <asp:Literal runat="server" ID="SubText1"></asp:Literal>
                        </p>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div id="feat_1">
                        <a href="about.html" class="bt_info">Read more</a>
                         <asp:Literal runat="server" ID="SubCard2"></asp:Literal>
                        <p>
                            <asp:Literal runat="server" ID="SubText2"></asp:Literal>
                        </p>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div id="feat_3">
                        <a href="about.html" class="bt_info">Read more</a>
                        <asp:Literal runat="server" ID="SubCard3"></asp:Literal>
                        <p>
                            <asp:Literal runat="server" ID="SubText3"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <!-- End row -->
        <div class="text-center">
            <a href="#0" class="button_2">Start Explore</a>
        </div>
    </section>
    <!-- End section -->

    <section class="margin_60" id="subscribe_plan">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h3>Get More Features<span>with a Premium plan</span></h3>
                    <ul>
                        <li><i class="icon_headphones"></i><strong>Listen or Download Audio Guides</strong>Directly from your Smartphone/Tablet, Online or Offline.</li>
                        <li><i class="icon_documents_alt"></i><strong>Read or Download Pdf Travel Guides</strong>Directly from your Smartphone/Tablet, Online or Offline.</li>
                        <li><i class="icon_like"></i><strong>Special Prices</strong>For Restaurants, Hotels, Bars and Cocktail bars....</li>
                        <li><i class="icon_lifesaver"></i><strong>Premium H24 Support</strong>Contact us via email, phone or chat!</li>
                    </ul>
                    <div id="compatib">
                        Compatible with Android/IOS
                    </div>
                </div>
                <div class="col-md-5 col-md-offset-1">
                    <div id="box_subscribe">
                        <ul>
                            <li><a href="#0" class="active">6 Months<span>39<sup>$</sup></span><em>Save -40%</em></a>
                            </li>
                            <li><a href="#0">3 Months<span>15<sup>$</sup></span></a>
                            </li>
                            <li><a href="#0">1 Months<span>10<sup>$</sup></span></a>
                            </li>
                        </ul>
                        <small><a href="#0">*Read more details</a></small>
                        <div class="text-center">
                            <a href="#" class="button_plan">Select plan</a>
                        </div>
                    </div>
                    <div class="shadow">
                    </div>
                </div>
            </div>
            <!--  End row -->
        </div>
        <!--  End container-->
    </section>
    <!--  End section-->

    <!-- Footer ================================================== -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-12">
                    <asp:Literal runat="server" ID="Footer1"></asp:Literal>
                    <p><asp:Literal runat="server" ID="FooterText1"></asp:Literal></p>
                    <p><img src="<%# ResolveClientUrl(@"~/")%>public/img/logo_2.png" alt="img" class="hidden-xs" width="170" height="30" data-retina="true">
                    </p>
                </div>
                <div class="col-md-3 col-sm-4">
                    <asp:Literal runat="server" ID="LinkHeader"></asp:Literal>
                    <ul>
                        <li><a href="0"><asp:Literal runat="server" ID="Link1"></asp:Literal></a>
                        </li>
                        <li><a href="0"><asp:Literal runat="server" ID="Link2"></asp:Literal></a>
                        </li>
                        <li><a href="0"<asp:Literal runat="server" ID="Link3"></asp:Literal></a>
                        </li>
                        <li><a href="0"><asp:Literal runat="server" ID="Link4"></asp:Literal></a>
                        </li>
                        <li><a href="0"><asp:Literal runat="server" ID="Link5"></asp:Literal></a>
                        </li>
                        <li><a href="0"><asp:Literal runat="server" ID="Link6"></asp:Literal></a>
                        </li>
                    </ul>
                </div>
                <div class="col-md-3 col-sm-4" id="newsletter">
                      <asp:Literal runat="server" ID="Footer2"></asp:Literal>
                    <p>
                        <asp:Literal runat="server" ID="FooterText2"></asp:Literal>
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
                     <asp:Literal runat="server" ID="Language"></asp:Literal>
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
                   <asp:Literal runat="server" ID="Subfooter"></asp:Literal>
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

    <!-- Specific scripts -->
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/video_header.js"></script>
    <script>
        'use strict';
        HeaderVideo.init({
            container: $('.header-video'),
            header: $('.header-video--media'),
            videoTrigger: $("#video-trigger"),
            autoPlayVideo: true
        });
        // Tabs
        new CBPFWTabs(document.getElementById('tabs'));
    </script>
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/map_home.js"></script>
    <script src="<%# ResolveClientUrl(@"~/")%>public/js/infobox.js"></script>
</asp:Content>