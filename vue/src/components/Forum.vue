<template>
  <div>
      <div class="container" v-for="message in forumMessages" v-bind:key="message.messageID">
        <h5><router-link :to="{name: 'forum-message', params: {messageID: message.messageID}}">{{message.message_Title}}</router-link></h5>
        <h6 > Comments <span class="badge text-light bg-success">{{forumResponses(message).length}}</span></h6>
      </div>
      <div>
        <button href='#' @click.prevent="showForm = !showForm">{{showForm ? "Hide Form" : "Add New Message"}}</button>
      <forum-message-form @submit="showForm = !showForm" v-show="showForm"/>
      </div>
  </div>
</template>

<script>

import ForumMessageForm from './ForumMessageForm.vue';


export default {
    name: "forum",
    data() {
      return {
        showForm: false
      }
    },
    props: {message: Object},
    components: { ForumMessageForm},
    methods: {
      forumResponses(message) {
        return this.$store.state.forumResponses.filter(response => {
          return response.messageID === message.messageID;
        })
      }
    },
    computed: {
      forumMessages() {
        return this.$store.state.forumMessages;
      }
      
    }
};
</script>

<style>

</style>