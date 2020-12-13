<template>
  <div>
    <forum v-if="$route.name!=='forum'"/>
  </div>
</template>

<script>
import Forum from "../components/Forum.vue"
export default {
  components: {Forum}
}
</script>

<style>

</style>