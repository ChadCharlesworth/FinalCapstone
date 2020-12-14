<template>
  <div>
    <h1>{{ pet.pet_Name }}</h1>
    <h3>{{ pet.species }}</h3>
    <h4>Breed: {{ pet.breed }}</h4>
    <h4>Personality: {{ pet.personality }}</h4>
    <h4>Size: {{pet.size}}</h4>
  </div>
</template>

<script>
export default {
  name: "pet-profile",
  props: { pet: Object },
};
</script>