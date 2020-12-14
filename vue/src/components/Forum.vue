<template>
  <div>
      <div v-for="message in forumMessages" v-bind:key="message.message_ID">
        <h4><router-link :to="{name: 'forum-message', params: {messageID: message.message_ID}}">{{message.message_Title}}</router-link></h4>
      </div>
      <forum-message-form/>
      <forum-response-form/>
  </div>
</template>

<script>

import ForumResponseForm from './ForumResponseForm.vue';
import ForumMessageForm from './ForumMessageForm.vue';


export default {
    name: "forum",
    components: { ForumMessageForm, ForumResponseForm},
    computed: {
      forumMessages() {
        return this.$store.state.forumMessages;
      }
    }
};
</script>

<style>

</style>