<template>
  <div>
      <form v-if="$store.state.token != ''" v-bind="setThisMessage()">
        <textarea rows="6" cols="50" placeholder="Write your comment here" v-model="response.body" required/>
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
        userID: this.$store.state.user.userId,
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
          ForumService.getResponse(promise.data.responseID)
          .then(responsePromise => {
            if(responsePromise.status == 200)
            {
              this.$store.commit('LOAD_RESPONSE', responsePromise.data);
              this.clearForm();
            }
          })
          
          
        }
      })
      .catch(error => console.log(error.response))
    }
  }
}
</script>

<style>

</style>