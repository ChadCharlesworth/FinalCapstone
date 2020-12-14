<template>
  <div>
    <playdate-details />
    <playdate-creation />
  </div>
</template>

<script>
import playdateDetails from "../components/PlaydateDetails.vue";
import playdateCreation from "../components/PlaydateCreation.vue";

export default {
  name: "playdate",
  components: { playdateDetails, playdateCreation },
};
</script>

<style>
</style>