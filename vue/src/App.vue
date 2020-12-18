<template>
  <div id="app">
    <header-panel id="nav" />
    <div class="container-fluid">
      <div class="row">
        <left-column
          class="col-2 left-column border-end border-dark"
          
        />
        <main-panel class="col-8 main" />
        <right-column
          class="col-2 right-column border-start border-dark"
        />
      </div>
      <footer/>
    </div>
  </div>
</template>

<script>
import HeaderPanel from './views/HeaderPanel.vue';
import LeftColumn from './views/LeftColumn.vue';
import MainPanel from './views/MainPanel.vue';
import RightColumn from './views/RightColumn.vue';
import profileService from "@/services/ProfileService";
import addressService from "@/services/AddressService";
import forumService from "@/services/ForumService";
import petService from "@/services/PetService";
import playdateService from "@/services/PlaydateService";
import Footer from './components/Footer.vue';


export default {
  components: { HeaderPanel, RightColumn, LeftColumn, MainPanel, Footer  },
  created() {
    this.$store.commit('LOGOUT');
    profileService.getProfiles()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(profile => {
        this.$store.commit('LOAD_PROFILE_TO_ARRAY',profile);
      })
      }})
      .catch(error => console.log(error.response));
    
    addressService.getAddresses()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(address => {
        this.$store.commit('LOAD_ADDRESS',address);
      })
      }})
      .catch(error => console.log(error.response));

      forumService.getMessages()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(message => {
        this.$store.commit('LOAD_MESSAGE',message);
      })
      }})
      .catch(error => console.log(error.response));

    forumService.getResponses()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(response => {
        this.$store.commit('LOAD_RESPONSE',response);
      })
      }})
      .catch(error => console.log(error.response));
      
    petService.getPets()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(pet => {
        this.$store.commit('LOAD_PET',pet);
      })
      }})
      .catch(error => console.log(error.response));

    playdateService.getPlaydates()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(playdate => {
        this.$store.commit('LOAD_PLAYDATE',playdate);
      })
      }})
      .catch(error => console.log(error.response));


}

    }
      
    
    
  

</script>
<style>
.main {
  background-color: #d8e2fe
  
}
.right-column {
  background-color: #d8e2fe
}
.left-column {
  background-color: #d8e2fe
}

</style>