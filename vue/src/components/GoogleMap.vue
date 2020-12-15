<template>
  <div>
    <gmaps-map :options="mapOptions">
      <gmaps-marker
        v-for="(option, i) in options"
        :key="i"
        :options="option.options"
      />
    </gmaps-map>
  </div>
</template>

<script>
import { gmapsMap, gmapsMarker } from "x5-gmaps";

export default {
  components: { gmapsMap, gmapsMarker },
  mounted() {
    this.getLocation();
  },
  methods: {
    getLocation() {
      if (navigator.geolocation)
        navigator.geolocation.getCurrentPosition(
          this.setLocation,
          this.locationError
        );
      else alert("Geolocation is not supported by this browser.");
    },

    setLocation(pos) {
      this.mapOptions = {
        ...this.mapOptions,
        center: { lat: pos.coords.latitude, lng: pos.coords.longitude },
      };
      this.center = { lat: pos.coords.latitude, lng: pos.coords.longitude };
    },
    locationError(error) {
      if (error.PERMISSION_DENIED)
        alert("User denied the request for Geolocation.");
      else if (error.POSITION_UNAVAILABLE)
        alert("Location information is unavailable.");
      else if (error.TIMEOUT)
        alert("The request to get user location timed out.");
      else alert("An unknown error occurred.");
    },
  },
  data() {
    return {
      mapOptions: {
        center: { lat: 39.390897, lng: -99.066067 },
        zoom: 12,
        fullscreenControl: false,
        mapTypeControl: false,
        rotateControl: false,
        scaleControl: false,
        streetViewControl: false,
        zoomControl: false,
      },
      options: [
        {
          options: { position: { lat: 40.496644, lng: -79.980158 } },
        },
        {
          options: { position: { lat: 40.45536, lng: -80.019531 } },
        },
      ],
    };
  },
};
</script>

<style>
</style>