<template>
  <div class="home">
    <google-map style="height: 800px; width: 800px;" />
    <div>New Playdate</div>
    <div>Search All Playdates</div>
    <div>
      <!-- <iframe
    type="iframe"
    aspect="16by9"
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA43QR2uCNr0ZiF_wZfecB1UkcXc0S6aJk&callback=initMap&libraries=&v=weekly"
      defer
  ></iframe> -->
    </div>
  
  <table>
    <tr>
      <th>Street Address</th>
      <th>City</th>
      <th>Date and Time</th>

    </tr>
    <tr v-for="(publicPlaydate, index) in publicPlaydates" :key="publicPlaydate.playdate_ID">
      <td>{{playdateAddress[index].street_Address_1}} {{playdateAddress[index].street_Address_2}}</td>
      <td>{{playdateAddress[index].city}}</td>
      <td>{{publicPlaydate.date_Time}}</td>
    </tr>
     </table>
  </div>


 
</template>

<script>
import GoogleMap from '@/components/GoogleMap.vue';

export default {
  components: { GoogleMap },
  name: "home",
  computed: {
    publicPlaydates() {
      return this.$store.state.playdates.filter((playdate) => {
        return playdate.is_Private == false;
      });
    },
    playdateAddress() {
      let playdateAddresses = [];
      let tempPlaydateAddresses = [];
      const playdates = this.publicPlaydates;
      const addresses = this.$store.state.addresses;
      for (let i = 0; i < playdates.length; i++) {
        tempPlaydateAddresses = addresses.filter((address) => {
          return address.address_ID === playdates[i].address_ID;
        });
        playdateAddresses = playdateAddresses.concat(tempPlaydateAddresses);
      }
      return playdateAddresses;
    },
  },

 
    }
  
</script>
