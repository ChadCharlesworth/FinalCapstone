<template>
  <div>
        <form>
      <label>New Message</label>
      
      <div>
        <input v-model="message.Message_Title" placeholder="Title" id="message-title">
      </div>
        <textarea v-model="message.Message_Body" placeholder="Enter your message.." id="message-body"
        rows="3"
        max-rows="6"></textarea>
        <div>
        <label>
          <button v-on:click.prevent="addNewMessage(message)">Submit</button>
        </label>
        </div>
        </form>
      
  </div>
</template>

<script>
import ForumService from "../services/ForumService.js"

export default {
  name: "MessageForm",
  data() {
    return {
      message: {
        UserID: Number,
        Message_Title: "",
        Message_Body: ""
      }
    }
  },
  methods: {
    addNewMessage(message) {
      ForumService.addMessage(message)
      .then(response => {
        if(response.status == 201)
        {
          this.$store.commit('LOAD_MESSAGE', response.data)
        }
      })
      .catch(error => console.log(error.response));
      
    }
  }
}

</script>

<style>

</style>