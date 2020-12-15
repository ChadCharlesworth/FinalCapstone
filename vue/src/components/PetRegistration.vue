<template>
  <div id="Your Pet" class="text-align-right">

    <form class="form-signin" @submit.prevent="pet">
      <label for="petname">Pet Name: </label><br>
      <input type="text" id="petname" name="petname" v-model="pet.name"/><br>

      <label for="species">Species:</label><br>
      <select name="species" v-model="pet.species">
        <option disabled value="">Select One</option>
        <option value="Dog">Dog</option>
        <option value="Cat">Cat</option>
        </select><br>

      <label for="petbreed">Breed: </label><br>
      <input type="text" id="petbreed" name="petbreed" v-model="pet.breed"/><br>

      <h3>Personality</h3>
      <input type="checkbox" @checked="addPersonality('Calm')"/>
      <label for ="personality1"> Calm</label><br>
      <input type="checkbox" @checked="addPersonality('Playful')"/>
      <label for ="personality2"> Playful</label><br>
      <input type="checkbox" @checked="addPersonality('Skittish')" />
      <label for ="personality1"> Skittish</label><br>
      <input type="checkbox" @checked="addPersonality('Mischievous')"/>
      <label for ="personality1"> Mischievous</label><br>
      <input type="checkbox" @checked="addPersonality('Friendly')"/>
      <label for ="personality1"> Friendly</label><br>
      


      <label for="size">Size: </label><br>
      <select name="size" v-model="pet.size">
        <option disabled value="">Select One</option>
        <option value="Small">Small 20lbs or Less</option>
        <option value="Medium">Medium 21-50lbs</option>
        <option value="Large">Large 51-100lbs</option>
        <option value="Giant">Giant 100+lbs</option>
        </select><br>
     
    <br><input type="button" onclick="alert('Thank you for registering your pet!')" value="Pet Registration" />
    </form>
  </div>
</template>

<script>
export default {
  name: "pet-registration",
  methods: {
    addPersonality(personality){
      this.pet.personality.push(personality);
    }
  },
  data() {
    return {
      pet: {
        name: null, 
        species: null,
        breed: null,
        personality: null,
        size: null,

      }
    }
  }
}
</script>