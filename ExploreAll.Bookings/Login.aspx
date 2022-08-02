<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExploreAll_Bookings.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>ExploreAll</title>

    <!-- Bootstrap -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/vendor/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/vendor/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/vendor/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="<%# ResolveClientUrl(@"~/")%>public/build/css/custom.min.css" rel="stylesheet">

    <style>
        .logo {
            background: url(public/images/exploreall.png);
            background-size: cover;
            background-repeat: no-repeat;
            background-position: center;
            min-height: 150px;
        }
    </style>
</head>
<body class="login">
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form ">
          <section class="login_content">
            <form id="form1" runat="server">
              <h1>Login Form</h1>
              <div>
                <asp:TextBox runat="server" ID="username" CssClass="form-control" placeholder="Username"></asp:TextBox>
              </div>
              <div>
                <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
              </div>
              <div>
                <asp:Button runat="server" OnClick="Login_Click" Text="Sign In" />
                <a class="reset_pass" href="#">Lost your password?</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">New to site?
                  <a href="#signup" class="to_register"> Create Account </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1 class="logo"></h1>
                  <p> Copyright © 2022 ExploreAll. All rights reserved.</p>
                </div>
              </div>
            </form>
          </section>
        </div>

        <div id="register" class="animate form registration_form">
          <section class="login_content">
            <form>
              <h1>Create Account</h1>
              <div>
                <input type="text" class="form-control" placeholder="Username" required="" />
              </div>
              <div>
                <input type="email" class="form-control" placeholder="Email" required="" />
              </div>
              <div>
                <input type="password" class="form-control" placeholder="Password" required="" />
              </div>
              <div>
                <a class="btn btn-default submit" href="index.html">Submit</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Already a member ?
                  <a href="#signin" class="to_register"> Log in </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-paw"></i> Gentelella Alela!</h1>
                  <p>©2016 All Rights Reserved. Gentelella Alela! is a Bootstrap 3 template. Privacy and Terms</p>
                </div>
              </div>
            </form>
          </section>
        </div>
      </div>
    </div>
  </body>
</html>