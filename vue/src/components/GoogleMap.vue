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
  props: ["playdateAddress"],
  mounted() {
    this.getLocation();
  },
  methods: {},
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