<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Directions.aspx.cs" Inherits="CPManageApp.UI.UserHomepage" %>

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
            }.controls {
        margin-top: 10px;
        border: 1px solid transparent;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        height: 32px;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
      }

      #origin-input,
      #destination-input {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 200px;
      }

      #origin-input:focus,
      #destination-input:focus {
        border-color: #4d90fe;
      }

      #mode-selector {
        color: #fff;
        background-color: #4d90fe;
        margin-left: 12px;
        padding: 5px 11px 0px 11px;
      }

      #mode-selector label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }

    </style>

    <section class="py-5">
        <div class="container">
            <br />

            <div style="display: none">
                <input id="origin-input" class="controls" type="text"
                       placeholder="Enter an origin location">

                <input id="destination-input" class="controls" type="text"
                       placeholder="Enter a destination location">

                <div id="mode-selector" class="controls">
                    <input type="radio" name="type" id="changemode-walking" checked="checked">
                    <label for="changemode-walking">Walking</label>

                    <input type="radio" name="type" id="changemode-transit">
                    <label for="changemode-transit">Transit</label>

                    <input type="radio" name="type" id="changemode-driving">
                    <label for="changemode-driving">Driving</label>
                </div>
            </div>

                <div id="map"></div>
          
            <div id='info'></div>
        

            </div>
    </section>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="directions.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBQtJTgRmPAOo0p7m4IeqlhcQgWiD1bdZ4&libraries=places&&callback=initMap" async defer></script>
    <%-- <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCDoZwHDtJ0GKx-U9Y-SZwgL_5vNDeDBKs&libraries=places&&callback=initMap" async defer></script> --%>

</asp:Content>
