using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPManageApp.App_Code.BLL;
using CPManageApp.App_Code.DAL;

namespace CPManageApp.UI
{
    public partial class Map : System.Web.UI.Page
    {
        BLLCarparkInfo carparkInfo = new BLLCarparkInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //**** NEED TO PUT IN FOR FINAL PRESENTATION***

                //if the session is null
                //if (string.IsNullOrEmpty(Session["login"] as string))
                //{
                //    Response.Redirect("Login.aspx");
                //
                //}                
                bindAll();
            }
        }

        protected void initializeMap(string markers)
        {
             mapjs.Text = @"
var map;
var geocoder;
// Initialize and add the map
function initMap() {
  if(navigator.geolocation){
        navigator.geolocation.getCurrentPosition(function(position){
            var pos={
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            var mapOptions = {
            zoom:15,
            center:pos,
            disableDefaultUI:true
            }
            map = new google.maps.Map(document.getElementById('map'), mapOptions);
            " + markers+@"
        })
    }
}";
        }
        protected void bindAll()
        {
            string carparkId = "";
            if(Request.QueryString.Keys.Count > 0)
            {
                carparkId = Request.QueryString["carparkName"].ToString();
                CarparkInfo carpark = carparkInfo.getCarpark(carparkId);
                if (int.Parse(Request.QueryString["dir"]) == 0)
                {
                    List<CarparkInfo> c = carparkInfo.getAllCarpark();
                    string content = getContent(carpark);
                    mapjs.Text = @"
var map;
// Initialize and add the map
var geocoder;
function initMap() {
        navigator.geolocation.getCurrentPosition(function(position){
            var pos={
                lat: " + carpark.Latitude+@",
                lng: "+carpark.Longtitude+@"
            };

            var mapOptions = {
            zoom:15,
            center:pos,
            disableDefaultUI:true
            }
            map = new google.maps.Map(document.getElementById('map'), mapOptions);
            " + getMapInfo(c) + @"
        })
}";
                    carparkjs.Text = @"
                    document.getElementById('direction-panel').innerHTML = """ + content + @""";
                ";
                    return;
                }
                else
                {
                    mapjs.Text = @"
                var map;
// Initialize and add the map
function initMap() {
                      if(navigator.geolocation){
                        navigator.geolocation.getCurrentPosition(function(position){
                        var pos={
                            lat: position.coords.latitude,
                            lng: position.coords.longitude
                        };
                        var mapOptions = {
                                    zoom:15,
                                    center:pos,
                                    disableDefaultUI:true
                                    }
                        map = new google.maps.Map(document.getElementById('map'), mapOptions);
                        var rendererOptions = {
                          map:map
                        }
                        var directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions)
                        directionsDisplay.setPanel(document.getElementById('direction-panel'));
                        var request ={
                            origin : pos,
                            destination: {lat:" + carpark.Latitude+ @",lng:"+carpark.Longtitude+@"},
                            travelMode: 'DRIVING'
                        }
                        var directionsService = new google.maps.DirectionsService()
                        directionsService.route(request, function(result, status){
                            if(status=='OK'){
                                directionsDisplay.setDirections(result);
                            }
                        })

                        });
                      }
}
                    ";
                    return;
                }
                
            }
              List<CarparkInfo> carparks = carparkInfo.getAllCarpark();
              initializeMap(getMapInfo(carparks));

        }

        protected void btn_SearchMall_Click(object sender, EventArgs e)
        {
            List<CarparkInfo> carparkSearch = carparkInfo.searchCarpark(txtMallName.Text, "All");
            if (txtMallName.Text == "")
            {
                List<CarparkInfo> carparks = carparkInfo.getAllCarpark();
                initializeMap(getMapInfo(carparks));
                return;
            }
            int i = 0;
            Boolean hasCoords = false;
            for (i = 0; i < carparkSearch.Count; i++)
            {
                if (carparkSearch[i].Latitude != 0)
                {
                    hasCoords = true;
                    break;
                }
            }
            if (i > 0 || carparkSearch.Count == 1)
            {
                string content = "";
                if (carparkSearch.Count==1)
                {
                    content = getContent(carparkSearch[0]);
                    if (hasCoords)
                    {
                        mapjs.Text = @"
var map;
// Initialize and add the map
var geocoder;
function initMap() {
            var pos={
                lat: " + carparkSearch[0].Latitude + @",
                lng: " + carparkSearch[0].Longtitude + @"
            };

            var mapOptions = {
            zoom:15,
            center:pos,
            disableDefaultUI:true
            }
            map = new google.maps.Map(document.getElementById('map'), mapOptions);
            " + getMapInfo(carparkSearch) + @"
}";
                    }
                    else
                    {
                        initializeMap("");
                    }
                    carparkjs.Text = @"
                    document.getElementById('direction-panel').innerHTML = """ + content + @""";
                ";
                }
                else
                {
                    content = getContent(carparkSearch[i]);
                    if (hasCoords)
                    {
                        mapjs.Text = @"
var map;
// Initialize and add the map
var geocoder;
function initMap() {
            var pos={
                lat: " + carparkSearch[i].Latitude + @",
                lng: " + carparkSearch[i].Longtitude + @"
            };

            var mapOptions = {
            zoom:15,
            center:pos,
            disableDefaultUI:true
            }
            map = new google.maps.Map(document.getElementById('map'), mapOptions);
            " + getMapInfo(carparkSearch) + @"
}";
                    }
                    else
                    {
                        initializeMap("");
                    }
                }
                carparkjs.Text = @"
                    document.getElementById('direction-panel').innerHTML = """ + content + @""";
                ";
            }
            else
            {
                initializeMap("");
                carparkjs.Text = @"document.getElementById('direction-panel').innerHTML = 'No carpark found!'";
            }

        }

        protected string getMapInfo(List<CarparkInfo> carparks)
        {
            string markers = "";
            for (int i = 0; i < carparks.Count; i++)
            {
                int available = carparks[i].TotalSlots - carparks[i].SlotTaken;
                string content = getContent(carparks[i]);
                if(carparks[i].Latitude != 0){
                    markers += @"

var marker" + i + @" = new google.maps.Marker({
position:{lat: " + carparks[i].Latitude + @", lng: " + carparks[i].Longtitude + @"},
map:map,
title:""" + carparks[i].CarparkName + @"""
});
marker" + i + @".addListener('click', function(){
document.getElementById('direction-panel').innerHTML = """ + content + @""";
});
";
                }
                else
                {
                    markers += @"
geocoder = new google.maps.Geocoder();
geocoder.geocode( { 'address': '" + carparks[i].CarparkLocation+ @"'}, function(results, status) {
if (status == 'OK') {
var marker" + i + @" = new google.maps.Marker({
position:results[0].geometry.location,
map:map,
title:""" + carparks[i].CarparkName + @"""
});
marker" + i + @".addListener('click', function(){
document.getElementById('direction-panel').innerHTML = """ + content + @""";
});
}
});
";
                }
                
            }
            return markers;
        }

        protected string getContent(CarparkInfo carpark)
        {
            string content = @"<a href = 'CarparkView.aspx?carparkName=" + carpark.CarparkID +
                             @"' style='text-decoration:none; color: inherit;'> " +
                             carpark.CarparkID + "<br/>" +
                             "<img src='/UI/MallImages/" + carpark.Image + @"' style='width: 300px; height: 300px;'> " +
                             "</a><br/> " +
                             "             <p>Carpark Availability: " + carpark.CarparkStatus + "<p/>"
//                             + "<p>Latitude: " + carpark.Latitude + "<p/>"
//                             + "<p>Longitude: " + carpark.Longtitude + "<p/>"
                             + "<p>Starting Hour: " + carpark.StartHour + "<p/>"
                             + "<p>Ending Hour: " + carpark.EndHour + "<p/>"
                             + "<p>Address: " + carpark.CarparkLocation + "<p/>"
                             + "<p>Slots Taken: " + carpark.SlotTaken + "<p/>"
                             + "<p>Total Slots: " + carpark.TotalSlots + "<p/>"
//                    + "<p> Carpark Image URL: "+carpark.Image+"<p/>"
                             + "<a class='button' href = 'Map.aspx?CarparkName=" + carpark.CarparkID + @"&dir=1'>Get directions</a>";
            return content;
        }

    }
}