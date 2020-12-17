<template>
  <div class="home container-fluid bg-secondary">
    
    <h1 class="text-center display-4"> Playdates in Your Area </h1>
    
    <google-map style="height: 600px; width: 100%;" v-bind:playdateAddress="playdateAddress" />
    
    
  <table class="table table-hover mt-5">
    <tbody>
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
    </tbody>
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
