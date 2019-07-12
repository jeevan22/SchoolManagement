<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="SchoolManagement.LoginForm" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>School Management</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

   
    <link href="theme/css/bootstrap-cerulean.min.css" rel="stylesheet">

    <link href="theme/css/charisma-app.css" rel="stylesheet">
    <link href='theme/bower_components/fullcalendar/dist/fullcalendar.css' rel='stylesheet'>
    <link href='theme/bower_components/fullcalendar/dist/fullcalendar.print.css' rel='stylesheet' media='print'>
    <link href='theme/bower_components/chosen/chosen.min.css' rel='stylesheet'>
    <link href='theme/bower_components/colorbox/example3/colorbox.css' rel='stylesheet'>
    <link href='theme/bower_components/responsive-tables/responsive-tables.css' rel='stylesheet'>
    <link href='theme/bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css' rel='stylesheet'>
    <link href='theme/css/jquery.noty.css' rel='stylesheet'>
    <link href='theme/css/noty_theme_default.css' rel='stylesheet'>
    <link href='theme/css/elfinder.min.css' rel='stylesheet'>
    <link href='theme/css/elfinder.theme.css' rel='stylesheet'>
    <link href='theme/css/jquery.iphone.toggle.css' rel='stylesheet'>
    <link href='theme/css/uploadify.css' rel='stylesheet'>
    <link href='theme/css/animate.min.css' rel='stylesheet'>

    <!-- jQuery -->
    <script src="theme/bower_components/jquery/jquery.min.js"></script>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style type="text/css">
        #Username{
            top:0px;
        }
         #password{
            top:0px;
        }
    </style>
</head>
<body>
    <div class="ch-container">
        <div class="row">

            <div class="row">
                <div class="col-md-12 center login-header">
                    <h2>Welcome to School Management</h2>
                </div>
                <!--/span-->
            </div>
            <!--/row-->

            <div class="row">
                <div class="well col-md-5 center login-box">
                    <div class="alert alert-info">
                        Please login with your Username and Password.
           
                    </div>
                    <form class="form-horizontal" runat="server" >
                        <fieldset>
                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user red"></i></span>
                                <asp:TextBox ID="Username" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <br>

                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                                <asp:TextBox ID="password" class="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>

                            <p class="center col-md-5">
                                <asp:Button ID="loginBtn" runat="server" class="btn btn-primary" Text="Login" OnClick="loginBtn_Click"  />
                            </p>
                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                        </fieldset>
                    </form>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
        <!--/fluid-row-->

    </div>

    <script src="theme/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

    <!-- library for cookie management -->
    <script src="theme/js/jquery.cookie.js"></script>
    <!-- calender plugin -->
    <script src='theme/bower_components/moment/min/moment.min.js'></script>
    <script src='theme/bower_components/fullcalendar/dist/fullcalendar.min.js'></script>
    <!-- data table plugin -->
    <script src='theme/js/jquery.dataTables.min.js'></script>

    <!-- select or dropdown enhancer -->
    <script src="theme/bower_components/chosen/chosen.jquery.min.js"></script>
    <!-- plugin for gallery image view -->
    <script src="theme/bower_components/colorbox/jquery.colorbox-min.js"></script>
    <!-- notification plugin -->
    <script src="theme/js/jquery.noty.js"></script>
    <!-- library for making tables responsive -->
    <script src="theme/bower_components/responsive-tables/responsive-tables.js"></script>
    <!-- tour plugin -->
    <script src="theme/bower_components/bootstrap-tour/build/js/bootstrap-tour.min.js"></script>
    <!-- star rating plugin -->
    <script src="theme/js/jquery.raty.min.js"></script>
    <!-- for iOS style toggle switch -->
    <script src="theme/js/jquery.iphone.toggle.js"></script>
    <!-- autogrowing textarea plugin -->
    <script src="theme/js/jquery.autogrow-textarea.js"></script>
    <!-- multiple file upload plugin -->
    <script src="theme/js/jquery.uploadify-3.1.min.js"></script>
    <!-- history.js for cross-browser state change on ajax -->
    <script src="theme/js/jquery.history.js"></script>
    <!-- application script for Charisma demo -->
    <script src="theme/js/charisma.js"></script>


</body>
</html>