<template>
  <div class="container-fluid">
    <div>
    <h1>{{ currentProfile.first_Name }} {{ currentProfile.last_Name }}</h1>
    <h6 v-for="address in profileAddresses" :key="address.address_ID">{{address.street_Address_1}} {{address.street_Address_2}}<br />{{address.city}}, {{address.state}} {{address.zip}}</h6>
    <h2>My Pets:</h2>
<pet-profile v-for="pet in profilePets" :key="pet.pet_ID" :pet="pet" style="display: inline-block;"/>
<a href="#" @click.stop.prevent="showPetForm=!showPetForm">{{showPetForm ? 'Hide form': 'Add a pet'}}</a>
    </div><br>
    <div><pet-registration v-if="showPetForm" /></div>

  </div>
</template>

<script>
import PetProfile from '@/components/PetProfile.vue';
import PetRegistration from './PetRegistration.vue';

export default {
  name: "profile",
  components: { PetProfile, PetRegistration },
  data() {
    return{
    showPetForm: false 
    }
  },
  computed: {
    currentProfile() {
      return this.$store.state.profile;
    },
    profileAddresses() {
      let allProfileAddresses = [];
      let tempProfileAddresses = [];
      const profile = this.currentProfile;
      const addresses = this.$store.state.addresses;
      for (let i = 0; i < profile.address_Ids.length; i++) {
        tempProfileAddresses = addresses.filter((address) => {
          return address.address_ID === profile.address_Ids[i];
        });
        allProfileAddresses = allProfileAddresses.concat(tempProfileAddresses);
        tempProfileAddresses = [];
      }
      return allProfileAddresses;
    },
    profilePets() {
      let allProfilePets = [];
      let tempProfilePets = [];
      const profile = this.currentProfile;
      const pets = this.$store.state.pets;
      for (let i = 0; i < profile.pet_Ids.length; i++) {
        tempProfilePets = pets.filter((address) => {
          return address.pet_ID === profile.pet_Ids[i];
        });
        allProfilePets = allProfilePets.concat(tempProfilePets);
        tempProfilePets = [];
      }
      return allProfilePets;
    },
    profilePlaydates() {
      let profPlaydates = [];

      for (let i = 0; i < this.$store.state.playdates.length; i++) {
        let tempPlaydate = this.$store.state.playdates[i];
        for (let j = 0; j < this.$store.state.profile.pet_Ids.length; j++) {
          let tempID = this.$store.state.profile.pet_Ids[j];
          if(tempPlaydate.attending.includes(tempID) || tempPlaydate.pending.includes(tempID)) {
            profPlaydates.push(tempPlaydate);
          }
        }
      }
      return profPlaydates;
    },
  },
};
</script>

<style>
</style>