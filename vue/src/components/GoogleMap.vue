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
import MapService from "@/services/MapService.js";

export default {
  components: { gmapsMap, gmapsMarker },
  props: ["playdateAddress"],
  mounted() {
    this.getLocation();
  },
  created() {
    this.playdateAddress.forEach((address) => {
      MapService.getLatLong(
        address.street_Address_1,
        address.city,
        address.state
      ).then((response) => {
        if (response.status == 200) {
          response.data.forEach((gLatLong) => {
            this.latLong.push(gLatLong.geometry.location);
          });
        }
      });
    });
  },
  computed: {
    options() {
      let latLngArray = [];
      
      for (let i = 0; i < this.playdateAddress.length; i++) {
        if(this.playdateAddress[i].latitude && this.playdateAddress[i].longitude)
        {
          latLngArray.push(
            {
              options: {
                position: {
                  lat: this.playdateAddress[i].latitude,
                  lng: this.playdateAddress[i].longitude
                }
              }
            }
          )
        }
      }

      return latLngArray;
    },
  },
  data() {
    return {
      mapOptions: {
        center: { lat: 40.44062479999999, lng: -79.9958864 },
        zoom: 12,
        fullscreenControl: false,
        mapTypeControl: false,
        rotateControl: false,
        scaleControl: false,
        streetViewControl: false,
        zoomControl: true,
      },
      latLong: [],
    };
  },
};
</script>

<style>
</style>