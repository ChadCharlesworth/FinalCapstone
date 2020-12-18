<template>
  <div class="card">
    <div class="card-body">
    <h3 class="text-center card-title">{{ pet.pet_Name }}
      <i v-bind:class="pet.species == 'Dog' ? 'fas fa-dog' : 'fas fa-cat'"></i></h3> 
    <h6>Breed: {{ pet.breed }}</h6>
    <h6>Personality: {{ pet.personality }}</h6>
    <h6>Size: {{pet.size}}</h6>
    </div>
  </div>
</template>

<script>
export default {
  name: "pet-profile",
  props: { pet: Object },
};
</script>