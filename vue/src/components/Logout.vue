<template>
  <h1>Logout</h1>
</template>

<script>
import profileService from "@/services/ProfileService";
import addressService from "@/services/AddressService";
import forumService from "@/services/ForumService";
import petService from "@/services/PetService";
import playdateService from "@/services/PlaydateService";


export default {
  created() {
    this.$store.commit("LOGOUT");
    this.$router.push("/login");

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
    
    forumService.getCategories()
    .then(response => {
      if(response.status == 200) {
      response.data.forEach(category => {
        this.$store.commit('LOAD_CATEGORY',category);
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
};
</script>
