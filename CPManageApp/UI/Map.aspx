<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CPMasterPage.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="CPManageApp.UI.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Page Content -->
    <style>
            .top{
                margin-top: -90px;
            }
            a {
                color:inherit;
                text-decoration: none;
            }
            #map{
                min-height: 80vh;
                max-height: 100%;
                margin-right:400px;
            }
            #direction-panel i {
                 font-size: 12px;
             }
            #direction-panel a{
                font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                font-weight:bold;
                font-size:25px;
            }
            #direction-panel {
                margin-left:50px;
                height: 80vh;
                float: right;
                width: 390px;
                overflow: auto;
            }
            #direction-panel p {
                font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
                font-size: 15px;
            }
            .button {
         background-color: #1c87c9;
         border: none;
         color: white;
         padding: 20px 34px;
         text-align: center;
         text-decoration: none;
         display: inline-block;
         font-size: 20px;
         margin: 4px 2px;
         cursor: pointer;
         }
        </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBNHvJn8yIInqkN3UN30WpNoj3H7gpwfYE&callback=initMap" async defer></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
        })
        function initMap() {

        }
    </script>
    <section class="py-5">
        <div class="container">
            <br />

            <h2 class="title">Map</h2>
        
            <div class="form-row align-items-center">
                <!--Mall Name Search-->
                <div class="form-group col-md-3">
                    <asp:Label ID="lblMallName" runat="server" Text="Mall Name"></asp:Label>
                    <asp:Panel ID="searchPanel" runat="server" DefaultButton="btn_SearchMall">
                    <asp:TextBox ID="txtMallName" runat="server" CssClass="form-control"></asp:TextBox>
                    </asp:Panel>
                </div>
                
                <!--Search Button-->
                <div class="form-group col-md-3">
                    <br />
                   <asp:Button class="btn btn-danger " runat="server" Text="Search" ID="btn_SearchMall" OnClick="btn_SearchMall_Click"/>
                </div>
            </div>

            
                <div id="direction-panel"></div>
                <div id="map"></div>
                <script type="text/javascript">
                    <asp:Literal ID="mapjs" runat="server"></asp:Literal >
                    <asp:Literal ID="carparkjs" runat="server"></asp:Literal >
                </script>
        </div>
    </section>
</asp:Content>
