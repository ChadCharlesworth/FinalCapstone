<template>
  <div id="Your Pet" class="text-align-right">
    <form class="form-signin" @submit.prevent="pet">
      <label for="petname">Pet Name: </label><br>
      <input type="text" id="petname" name="petname" /><br>
      <label for="petbreed">Breed: </label><br>
      <input type="text" id="petbreed" name="petbreed" /><br>
      <label for="petpersonality">Pet Personality:</label><br>
      <select name="petpersonality" id="petpersonality" multiple>
        <option value="athletic">Athletic</option>
        <option value="playful">Playful</option>
        <option value="chillin'">Chillin'</option>
        <option value="aggressive">Aggresive</option>
        <option value="shy">Shy</option>
      </select><br>
      <label for="petsize">Pet Size: </label><br>
      <input type="text" id="petsize" name="petsize" /><br>
    </form>
    <br><input type="button" onclick="alert('Thank you for registering your pet!')" value="Pet Registration" />
  </div>
</template>

<script>
export default {
  name: "petInfo",
  data() {
    return {
      items: [
        {age: 40, first_name: 'Dickerson', last_name: 'Testing'},
        {age: 28, first_name: 'Person', last_name: 'McPerson'},
        {age: 50, first_name: 'Joe', last_name: 'Schmoe'},
        {age: 30, first_name: 'John', last_name: 'Doe'}
      ]
    }
  }
}
</script>