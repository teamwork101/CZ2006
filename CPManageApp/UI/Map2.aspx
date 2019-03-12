<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Map2.aspx.cs" Inherits="CPManageApp.UI.UserHomepage" %>

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
            #description {
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
      }

      #infowindow-content .title {
        font-weight: bold;
      }

      #infowindow-content {
        display: none;
      }

      #map #infowindow-content {
        display: inline;
      }

      .pac-card {
        margin: 10px 10px 0 0;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
        background-color: #fff;
        font-family: Roboto;
      }

      #pac-container {
        padding-bottom: 12px;
        margin-right: 12px;
      }

      .pac-controls {
        display: inline-block;
        padding: 5px 11px;
      }

      .pac-controls label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }

      #pac-input {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 400px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

      #title {
        color: #fff;
        background-color: #4d90fe;
        font-size: 25px;
        font-weight: 500;
        padding: 6px 12px;
      }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="map2.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBQtJTgRmPAOo0p7m4IeqlhcQgWiD1bdZ4&libraries=places&&callback=initMap" async defer></script>
    <%-- <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCDoZwHDtJ0GKx-U9Y-SZwgL_5vNDeDBKs&libraries=places&&callback=initMap" async defer></script> --%>


    <section class="py-5">
        <div class="container">
            <br />

            <h2 class="title">Map</h2>
            <div class="row">
                <div class="pac-card" id="pac-card">
                    <div>
                        <div id="title">
                            Autocomplete search
                        </div>
                        <div id="type-selector" class="pac-controls">
                            <input type="radio" name="type" id="changetype-all" checked="checked">
                            <label for="changetype-all">All</label>

                            <input type="radio" name="type" id="changetype-establishment">
                            <label for="changetype-establishment">Establishments</label>

                            <input type="radio" name="type" id="changetype-address">
                            <label for="changetype-address">Addresses</label>

                            <input type="radio" name="type" id="changetype-geocode">
                            <label for="changetype-geocode">Geocodes</label>
                        </div>
                        <div id="strict-bounds-selector" class="pac-controls">
                            <input type="checkbox" id="use-strict-bounds" value="">
                            <label for="use-strict-bounds">Strict Bounds</label>
                        </div>
                    </div>
                    <div id="pac-container">
                        <input id="pac-input" type="text"
                               placeholder="Enter a location">
                    </div>
                </div>
                <div id="map"></div>
                
                <div id="infowindow-content">
                    <img src="" width="16" height="16" id="place-icon">
                    <span id="place-name"  class="title"></span><br>
                    <span id="place-address"></span>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
