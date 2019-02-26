<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="CPManageApp.UI.UserHomepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <style>
            .top{
                margin-top: -90px;
            }

            #map{
                max-width: 100%;
                max-height: 100%;
                min-width: 60vw;
                min-height: 80vh;
            }
        </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="map.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyANzkX8usvRMGp7TJSLFVaFtq-rCXSXfQ0&callback=initMap" async defer></script>

    <section class="py-5">
        <div class="container">
            <br />

            <h2 class="title">Map</h2>
            <div class="row">
                <div id="map"></div>

            </div>
        </div>
    </section>
</asp:Content>
