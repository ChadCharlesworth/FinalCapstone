<template>
  <div>
        <form>
      <label v-bind="getThisUser()">New Message</label>
      <div>
        <input v-model.trim="message.message_Title" placeholder="Title" id="message-title">
      </div>
        <textarea v-model.trim="message.message_Body" placeholder="Enter your message.." id="message-body"
        rows="3"
        max-rows="6"></textarea>
        <div>
          <button class="btn mr-2 mb-2 btn-success" v-on:click.prevent="addNewMessage(message)">Submit</button>
          <button class="btn mr-2 mb-2 btn-danger" v-on:click.prevent="clearForm">Clear</button>
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
        userID: "",
        message_Title: "",
        message_Body: ""
      }
    }
  },
  methods: {
    addNewMessage(message) {
      ForumService.addMessage(message)
      .then(response => {
        if(response.status == 201)
        {
          ForumService.getMessage(response.data.messageID)
          .then(messageResponse => {
            if(messageResponse.status == 200)
            {
              this.$store.commit('LOAD_MESSAGE', messageResponse.data);
              this.clearForm();
            }
          })
          
          
        }
      })
      .catch(error => console.log(error.response));
      
    },
    clearForm() {
      this.message.message_Title = "";
      this.message.message_Body = "";
    },
    getThisUser() {
      this.message.userID = this.$store.state.user.userId
    }
  }
  }

</script>

<style>

</style>