<template>
  <div>
    <h1>{{ currentProfile.first_Name }} {{ currentProfile.last_Name }}</h1>
    <h6 v-for="address in profileAddresses" :key="address.address_ID">{{address.street_Address_1}} {{address.street_Address_2}}<br />{{address.city}}, {{address.state}} {{address.zip}}</h6>
    <h2>My Pets:</h2>
<pet-profile v-for="pet in profilePets" :key="pet.pet_ID" :pet="pet" style="display: inline-block;"/>

  </div>
</template>

<script>
import PetProfile from '@/components/PetProfile.vue';

export default {
  name: "profile",
  components: { PetProfile },
  methods: {
    getKeyByValue(object, value) {
      return Object.keys(object).filter((key) => object[key] === value);
    },
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
        let keys = this.getKeyByValue(tempPlaydate.pet_Accepted_Status,true);
        for (let j = 0; j < this.$store.state.profile.pet_Ids.length; j++) {
          let tempID = this.$store.state.profile.pet_Ids[j];
          let IDIncluded = keys.includes(tempID.toString());
          if (IDIncluded) {
            profPlaydates.push(this.$store.state.playdates[i]);
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