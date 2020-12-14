<template>
<div>
    <pet-profile v-for="pet in profilePets" :key="pet" />
</div>
</template>

<script>
export default {
    
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