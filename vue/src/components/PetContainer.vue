<template>
<div>
  <h1 class="text-center">My Pets</h1>
    <pet-profile v-for="pet in profilePets" :key="pet.pet_ID" :pet="pet"/>
</div>
</template>

<script>
import PetProfile from '@/components/PetProfile.vue';
export default {
    components: {PetProfile},
  name: "pet-container",
   computed: 
   {currentProfile() {
      return this.$store.state.profile;
    },

   profilePets() {
      let allProfilePets = [];
      let tempProfilePets = [];
      const profile = this.currentProfile;
      const pets = this.$store.state.pets;
      for (let i = 0; i < profile.pet_Ids.length; i++) {
        tempProfilePets = pets.filter((pet) => {
          return pet.pet_ID === profile.pet_Ids[i];
        });
        allProfilePets = allProfilePets.concat(tempProfilePets);
        tempProfilePets = [];
      }
      return allProfilePets;
    },
    
   }
}
    </script>