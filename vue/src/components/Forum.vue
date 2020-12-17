<template>
  <div>
    <paginate name="messages"
    :list="messages"
    :per="8">
      <div class="container" v-for="messages in paginated('messages')" v-bind:key="messages.messageID">
        <h5><router-link :to="{name: 'forum-message', params: {messageID: messages.messageID}}">{{messages.message_Title}}</router-link></h5>
        <h6 > Comments <span class="badge text-light bg-success">{{forumResponses(messages).length}}</span></h6>
      </div>
    </paginate>
      <div>
        <button href='#' @click.prevent="showForm = !showForm">{{showForm ? "Hide Form" : "Add New Message"}}</button>
      <forum-message-form @submit="showForm = !showForm" v-show="showForm"/>
      </div>
      <paginate-links
      :show-step-links="true"
      :classes="{
        'ul': 'pagination',
        'li': 'page-item',
        'a': 'page-link',
        'ul.paginate-links > li.active > a': 'active'
        }" for="messages"></paginate-links>
  </div>
</template>

<script>

import ForumMessageForm from './ForumMessageForm.vue';


export default {
    name: "forum",
    data() {
      return {
        showForm: false,
        messages: this.$store.state.forumMessages,
        paginate: ['messages']
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