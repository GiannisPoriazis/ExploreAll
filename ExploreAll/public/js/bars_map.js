
	(function(A) {
		if (!Array.prototype.forEach)
			A.forEach = A.forEach || function(action, that) {
				for (var i = 0, l = this.length; i < l; i++)
					if (i in this)
						action.call(that, this[i], i, this);
				};

	})(Array.prototype);

	function initMapObject() {
		var	mapObject,
		markers = [];		
		var mapOptions = {
			zoom: 11,
			center: new google.maps.LatLng(39.916663, 25.249999),
			mapTypeId: google.maps.MapTypeId.ROADMAP,

			mapTypeControl: false,
			mapTypeControlOptions: {
				style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
				position: google.maps.ControlPosition.LEFT_CENTER
			},
			panControl: false,
			panControlOptions: {
				position: google.maps.ControlPosition.TOP_RIGHT
			},
			zoomControl: true,
			zoomControlOptions: {
				style: google.maps.ZoomControlStyle.LARGE,
				position: google.maps.ControlPosition.RIGHT_BOTTOM
			},
			scrollwheel: false,
			scaleControl: false,
			scaleControlOptions: {
				position: google.maps.ControlPosition.TOP_LEFT
			},
			streetViewControl: true,
			streetViewControlOptions: {
				position: google.maps.ControlPosition.RIGHT_BOTTOM
			},
			styles: [
							{
				"featureType": "landscape",
				"stylers": [
					{
						"hue": "#FFBB00"
					},
					{
						"saturation": 43.400000000000006
					},
					{
						"lightness": 37.599999999999994
					},
					{
						"gamma": 1
					}
				]
			},
			{
				"featureType": "road.highway",
				"stylers": [
					{
						"hue": "#FFC200"
					},
					{
						"saturation": -61.8
					},
					{
						"lightness": 45.599999999999994
					},
					{
						"gamma": 1
					}
				]
			},
			{
				"featureType": "road.arterial",
				"stylers": [
					{
						"hue": "#FF0300"
					},
					{
						"saturation": -100
					},
					{
						"lightness": 51.19999999999999
					},
					{
						"gamma": 1
					}
				]
			},
			{
				"featureType": "road.local",
				"stylers": [
					{
						"hue": "#FF0300"
					},
					{
						"saturation": -100
					},
					{
						"lightness": 52
					},
					{
						"gamma": 1
					}
				]
			},
			{
				"featureType": "water",
				"stylers": [
					{
						"hue": "#0078FF"
					},
					{
						"saturation": -13.200000000000003
					},
					{
						"lightness": 2.4000000000000057
					},
					{
						"gamma": 1
					}
				]
			},
			{
				"featureType": "poi.business",
				"stylers": [
						{ visibility: "off" }
				]
			}
			]
		};
		var	marker;
		mapObject = new google.maps.Map(document.getElementById('map'), mapOptions);
		for (var key in markersData)
			markersData[key].forEach(function (item) {
				marker = new google.maps.Marker({
					position: new google.maps.LatLng(item.location_latitude, item.location_longitude),
					map: mapObject,
					icon: 'public/img/pins/' + key + '.png',
				});

				if ('undefined' === typeof markers[key])
					markers[key] = [];
				markers[key].push(marker);
				google.maps.event.addListener(marker, 'click', (function () {
					closeInfoBox();
					getInfoBox(item).open(mapObject, this);
					mapObject.setCenter(new google.maps.LatLng(item.location_latitude, item.location_longitude));
				}));

			});
	}
	function hideAllMarkers () {
		for (var key in markers)
			markers[key].forEach(function (marker) {
				marker.setMap(null);
			});
	};
	function closeInfoBox() {
		$('div.infoBox').remove();
	};

	function getInfoBox(item) {
		return new InfoBox({
			content:
			'<div class="marker_info" id="marker_info">' +
			'<img src="' + item.map_image_url + '" alt=""/>' +
			'<span>'+ 
				'<span class="infobox_rate">'+ item.rate +'</span>' +
				'<h3>'+ item.name_point +'</h3>' +
			'<em>'+ item.type_point +'</em>' +
			'<strong>'+ item.description_point +'</strong>' +
			'<a href="'+ item.url_detail + '" class="btn_infobox_detail"></a>' +
			'<form action="http://maps.google.com/maps" method="get" target="_blank"><input name="saddr" value="'+ item.get_directions_start_address +'" type="hidden"><input type="hidden" name="daddr" value="'+ item.location_latitude +',' +item.location_longitude +'"><button type="submit" value="Get directions" class="btn_infobox_get_directions">Get directions</button></form>' +
				'<a href="tel://'+ item.phone +'" class="btn_infobox_phone">'+ item.phone +'</a>' +
				'</span>' +
			'</div>',
			disableAutoPan: false,
			maxWidth: 0,
			pixelOffset: new google.maps.Size(10, 115),
			closeBoxMargin: '5px -28px 0 0',
			closeBoxURL: "img/close_infobox.png",
			isHidden: false,
			alignBottom: true,
			pane: 'floatPane',
			enableEventPropagation: true
		});
	};
	function onHtmlClick(location_type, key){
		google.maps.event.trigger(markers[location_type][key], "click");
	}
