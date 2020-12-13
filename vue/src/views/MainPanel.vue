<template>
  <div>
    <pet/>
          <router-view />
  </div>
</template>

<script>
import Pet from '@/components/Pet';
export default {
components: {
  Pet
}
}
</script>

<style>

</style>