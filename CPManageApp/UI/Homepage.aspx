<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="CPManageApp.UI.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <header>
        <link href="Layout/css/half-slider.css" rel="stylesheet">
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner" role="listbox">
                <!-- Slide One - Set the background image for this slide in the line below -->
                <div class="carousel-item active">
                    <a href='CarparkView.aspx?carparkName=Raffles City'>
                        <img src="/UI/Carousel/Raffles City.jpg" />
                    </a>
                    <div class="carousel-caption d-none d-md-block">
                        <h3>Raffles City</h3>
                    </div>
                </div>

                <!-- Slide Two - Set the background image for this slide in the line below -->
                <div class="carousel-item">
                    <a href='CarparkView.aspx?carparkName=Holland Road Shopping Centre'>
                        <img src="/UI/Carousel/Holland Road Shopping Centre.jpg" />
                    </a>
                    <div class="carousel-caption d-none d-md-block">
                        <h3>Holland Road Shopping Centre</h3>
                    </div>
                </div>
                <!-- Slide Three - Set the background image for this slide in the line below -->
                <div class="carousel-item">
                    <a href='CarparkView.aspx?carparkName=OG Orchard Point'>
                        <img src="/UI/Carousel/OG Orchard Point.jpg" />
                    </a>
                    <div class="carousel-caption d-none d-md-block">
                        <h3>OG Orchard Point</h3>
                    </div>
                </div>

            </div>

            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </header>

    <!-- Page Content -->
    <section class="py-5">
        <div class="container">
            <h1>About Us</h1>
            <p>
                Park n' Go is a smart parking assistant website which provides drivers the carpark information that they need at a click of a button.
            </p>
        </div>
    </section>


</asp:Content>
