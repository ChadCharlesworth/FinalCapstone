<template>
    <div class="container" v-bind="setCurrentMessage()">
        <h4>{{message.message_Title}}</h4>
        <p>{{getThisProfile(message.userID).username}}  {{message.createdDate}}</p>
        <p>{{message.message_Body}}</p>

            
        <h6><a href=# @click.prevent="showComments = !showComments ">{{showComments ? "Hide Comments" : "Show Comments"}} ({{theseForumResponses(message.messageID).length}})</a></h6>
        <div v-show="showComments" id="Responses" v-for="response in theseForumResponses(message.messageID)" :key="response.messageID">
                {{response.body}}
        <p>{{getThisProfile(response.userID).username}}  {{response.createdDate}}</p>
        </div>
        <button class="btn btn-light" href='#' @click.prevent="showForm = !showForm">{{showForm ? "Hide Form" : "Add New Comment"}}</button>
        <forum-response-form v-show="showForm" :messageID="message.messageID"/>
            
    </div>
</template>

<script>
import ForumResponseForm from './ForumResponseForm.vue';

export default {
  components: { ForumResponseForm },
    name: 'message-details',
    data() {
        return {
            message: {},
            showComments: false,
            showForm: false
        }
    },
    methods: {
        getThisProfile(userID) {
            return this.$store.state.userProfiles.find(profile => {
                return profile.user_id == userID;
            })
        },
        getThisMessage(messageID) {
            return this.$store.state.forumMessages.find(message => {
                return message.messageID == messageID;
            });
        },
        setCurrentMessage() {
            this.message = this.getThisMessage(this.$route.params.messageID)
        },
        theseForumResponses(messageID) {
            return this.$store.state.forumResponses.filter(response => {
                return response.messageID == messageID;
            })
        }
    }   
}
</script>

<style>

</style>