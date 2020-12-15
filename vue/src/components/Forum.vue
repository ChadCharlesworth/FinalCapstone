<template>
  <div>
      <div v-for="message in forumMessages" v-bind:key="message.messageID">
        <h5><router-link :to="{name: 'forum-message', params: {messageID: message.messageID}}">{{message.message_Title}}</router-link></h5>
        <h6> Responses <span class="badge text-light bg-success">{{forumResponses(message).length}}</span></h6>
      </div>
      <forum-message-form/>
      <!-- <forum-response-form/> -->
  </div>
</template>

<script>

import ForumMessageForm from './ForumMessageForm.vue';


export default {
    name: "forum",
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