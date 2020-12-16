<template>
  <div>
      
  </div>
</template>

<script>
import ForumService from '../services/ForumService.js'

export default {
  data() {
    return {
      response: {
        body: "",
        userID: this.$store.state.profile.user_id,
        messageID: ""
      }
    }
  }
}
</script>

<style>

</style>