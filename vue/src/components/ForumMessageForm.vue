<template>
  <div>
      <b-card>
      <b-form-group
      label="New Message"
      label-class="font-weight-bold">
      <b-form-group
      label="Category"
      label-for="message-category">
        <b-form-select v-model="$store.forumMessages.message.Category_ID" placeholder="Title" id="message-category">
          <b-form-select-option v-for="category in forumCategories" :key="category.Category_ID">{{category.Category_Name}}</b-form-select-option>
        </b-form-select>
        </b-form-group>
        <b-form-group
      label="Title"
      label-for="message-title">
        <b-form-input v-model="$store.forumMessages.message.Message_Title" placeholder="Title" id="message-title"></b-form-input>
        </b-form-group>
        <b-form-group
      label="Body"
      label-for="message-body">
        <b-form-textarea 
        v-model="$store.forumMessages.message.Message_Body" 
        placeholder="Enter your message.."  
        id="message-body"
        rows="3"
        max-rows="6"></b-form-textarea>
        </b-form-group>
        <b-form-group>
          <b-button v-on:click.prevent="addNewMessage(newMessage)">Submit</b-button>
      </b-card>
  </div>
</template>

<script>
import ForumService from "../services/ForumService.js"

export default {
  name: "MessageForm",
  data() {
    return {
      newMessage: {
        CategoryID: Number,
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