<template>
  <div id="Your Pet" class="text-align-right">

    <form class="form-signin" @submit.prevent="savePet">
      <label for="petname">Pet Name: </label><br>

      <input type="text" id="petname" name="petname" v-model="pet.pet_Name"/><br>

      <label for="species">Species:</label><br>
      <select name="species" v-model="pet.species">
        <option disabled value="">Select One</option>
        <option value="Dog">Dog</option>
        <option value="Cat">Cat</option>
        </select><br>

      <label for="petbreed">Breed: </label><br>
      <input type="text" id="petbreed" name="petbreed" v-model="pet.breed"/><br>

      <label for="personality">Personality: </label><br>
      <select name="personality" v-model="pet.personality">
        <option value="calm">Calm</option>
        <option value="playful">Playful</option>
        <option value="skittish">Skittish</option>
        <option value="mischievous">Mischievous</option>
        <option value="friendly">Friendly</option>
        </select><br>
        


      <label for="size">Size: </label><br>
      <select name="size" v-model="pet.size">
        <option disabled value="">Select One</option>
        <option value="Small">Small 20lbs or Less</option>
        <option value="Medium">Medium 21-50lbs</option>
        <option value="Large">Large 51-100lbs</option>
        <option value="Giant">Giant 100+lbs</option>
        </select><br>
     
    <br><input type="submit" onclick="alert('Thank you for registering your pet!')" value="Register Pet" />
    </form>
   
  </div>
</template>

<script>
import PetService from "../services/PetService.js";

export default {
  name: "pet-registration",
   data() {
    return {
      pet: {
        owner_ID: this.$store.state.profile.user_id,
        pet_Name: null, 
        species: null,
        breed: null,
        personality: null,
        size: null,
      }
    }
   },
  methods: {
    
    savePet() {
      PetService.addPet(this.pet)
      .then((response) => {
        if (response.status == 200) {
          this.$store.commit("LOAD_PET", response.data);
        }
      })
      .catch((error) => console.log(error.response));
    },
    },
  };

</script>