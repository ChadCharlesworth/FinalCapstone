<template>
  <div>
      <login v-if="$store.state.token == ''"/>
  </div>
</template>

<script>
import Login from '@/components/Login.vue';
export default {
components: { Login }
}
</script>

<style>

</style>