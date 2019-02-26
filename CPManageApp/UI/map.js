
function initMap() {
    var mapDiv = document.getElementById('map');
    // Bounds for Singapore
    var allowedBounds = new google.maps.LatLngBounds(
        new google.maps.LatLng(1.2310071515725387, 103.59436081438548),
        new google.maps.LatLng(1.4712844146613928, 104.11023204991352));
    var minZoomLevel = 11;
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: minZoomLevel,
        center: {lat: 1.290270, lng: 103.851959},
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

//    var kmlLayer = new google.maps.KmlLayer({
//        url: 'https://sites.google.com/site/sgzonemapkml/home/kml/version0.04.kml',
//        preserveViewport: true,
//        suppressInfoWindows: true,
//        map: map
//    });

    // Listen for the dragend event
    google.maps.event.addListener(map, 'dragend', function () {
        if (allowedBounds.contains(map.getCenter())) return;

        // Out of bounds - Move the map back within the bounds
        var c = map.getCenter(),
            x = c.lng(),
            y = c.lat(),
            maxX = allowedBounds.getNorthEast().lng(),
            maxY = allowedBounds.getNorthEast().lat(),
            minX = allowedBounds.getSouthWest().lng(),
            minY = allowedBounds.getSouthWest().lat();

        if (x < minX) x = minX;
        if (x > maxX) x = maxX;
        if (y < minY) y = minY;
        if (y > maxY) y = maxY;

        map.setCenter(new google.maps.LatLng(y, x));
    });

    // Limit the zoom level
    google.maps.event.addListener(map, 'zoom_changed', function () {
        if (map.getZoom() < minZoomLevel)
            map.setZoom(minZoomLevel);
    });

//    google.maps.event.addListener(kmlLayer, 'click', openIW);
    // google.maps.
    // google.maps.event.addListener(kmlLayer, "mouseover" ,function(layerEvt){
    //     console.log("test");
    //     layerEvt.featureData.setOptions({fillColor: "#00FF00"});
    // });
}
