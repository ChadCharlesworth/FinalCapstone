<template>
  <div>
      <form v-if="$store.state.token != ''" v-bind="setThisMessage()">
        <textarea rows="6" cols="50" placeholder="Write your comment here" v-model="response.body"/>
        <div class="container" >
        <button type='submit' @click.prevent="sendIt(response)">Submit</button>
        <button type='reset'>Clear</button>
        </div>
      </form>
  </div>
</template>

<script>
import ForumService from '../services/ForumService.js'

export default {
  props: ['messageID'],
  data() {
    return {
      response: {
        body: "",
        userID: this.$store.state.profile.user_id,
        messageID: ""
      }
    }
  },
  methods: {
    setThisMessage() {
      this.response.messageID = this.messageID
    },
    clearForm() {
      this.response.body = ""
    },
    sendIt(response) {
      ForumService.addResponse(response)
      .then(promise => {
        if(promise.status == 201)
        {
          this.$store.commit('LOAD_RESPONSE',promise.data);
          this.clearForm();
        }
      })
      .catch(error => console.log(error.response))
    }
  }
}
</script>

<style>

</style>