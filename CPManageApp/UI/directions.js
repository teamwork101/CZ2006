let map;
let marker;
let infoWindow;
let oDir;
let oTraf;
let oDisp;
let oReq;
let destination = { lat: 1.3001639 , lng: 103.7855246 };


const modes = {
    walk: 'WALKING',
    bike: 'BICYCLING',
    car: 'DRIVING',
    pub: 'TRANSIT'
};
const advReqOptions = {
    provideRouteAlternatives: true,
    optimizeWaypoints: true,
    avoidFerries: true,
    avoidHighways: false,
    avoidTolls: false
};



function initMap() {
    /* utility to add a new marker and assign listeners to it */
    const addmarker = function (pos, type, colour) {
        marker = new google.maps.Marker({
            icon: '//maps.google.com/mapfiles/ms/icons/' + colour + '-pushpin.png',
            type: type,
            draggable: true,
            position: pos,
            map: map
        });
        google.maps.event.addListener(marker, 'click', function (e) {
            infoWindow.getContent().style.display = 'block';
            infoWindow.setPosition(this.getPosition());
            infoWindow.open(map);
        });
        google.maps.event.addListener(marker, 'dragend', calculateroute);
    };

    /* callback function when markers are dragged and the route is re-calculated */
    const calculateroute = function (e) {
        oReq = {
            origin: this.type == 'start' ? e.latLng : oReq.origin,
            destination: this.type == 'finish' ? e.latLng : oReq.destination,
            travelMode: modes.car
        };
        oDir.route(Object.assign(oReq, advReqOptions), callback);
    };

    /* process the route response */
    const callback = function (r, s) {
        if (s === 'OK') oDisp.setDirections(r);
        else evtGeoFailure(s);
    }

    /* Main callback invoked when the user's location has been identified */
    const evtGeoSuccess = function (p) {
        /* create the map */
        let location = {
            lat: parseFloat(p.coords.latitude),
            lng: parseFloat(p.coords.longitude)
        };
        let options = {
            zoom: 16,
            center: location,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        let routeoptions = {
            suppressMarkers: true,
            draggable: true,
            map: map
        };

        /* create the map object */
        map = new google.maps.Map(document.getElementById('map'), options);

        /* add draggable markers to the start and end of pre-defined route */
        addmarker(location, 'start', 'grn');
        addmarker(destination, 'finish', 'red');

        /* display the textual directions in an infowindow which opens on marker click */
        infoWindow = new google.maps.InfoWindow({ maxWidth: 450, disableAutoPan: false });
        infoWindow.setContent(document.getElementById('info'));


        /* create the objects required for the directions calculations */
        oDir = new google.maps.DirectionsService();
        oDisp = new google.maps.DirectionsRenderer(routeoptions);
        oTraf = new google.maps.TrafficLayer();


        /* construct the initial request */
        oReq = {
            origin: location,
            destination: destination,
            travelMode: modes.car
        };

        /* go get the directions... */
        oDisp.setMap(map);
        oTraf.setMap(map);
        oDisp.setPanel(infoWindow.getContent());
        oDir.route(Object.assign(oReq, advReqOptions), callback);
    };


    const evtGeoFailure = function (e) { console.info('you broke the internets: %s', e) };
    const config = { maximumAge: 60000, timeout: 5000, enableHighAccuracy: true };

    if (navigator.geolocation) navigator.geolocation.getCurrentPosition(evtGeoSuccess, evtGeoFailure, config);
}