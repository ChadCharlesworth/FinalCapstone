<template>
  <div>
      <login v-if="$store.state.token == ''"/>
      <pet-container v-if="$store.state.profile.first_Name != null && $store.state.token!= ''"/> 
  </div>
</template>

<script>
import Login from '@/components/Login.vue';
import PetContainer from '@/components/PetContainer.vue'
export default {
components: { Login, PetContainer }
}
</script>

<style>

</style>