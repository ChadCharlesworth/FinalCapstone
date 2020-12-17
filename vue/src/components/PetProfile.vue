<template>
  <div>
    <h3 class="text-center">{{ pet.pet_Name }}</h3>
    <h5>{{ pet.species }}</h5>
    <h6>Breed: {{ pet.breed }}</h6>
    <h6>Personality: {{ pet.personality }}</h6>
    <h6>Size: {{pet.size}}</h6>
  </div>
</template>

<script>
export default {
  name: "pet-profile",
  props: { pet: Object },
};
</script>