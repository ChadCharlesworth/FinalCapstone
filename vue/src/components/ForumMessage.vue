<template>
    <div class="container" v-bind="setCurrentMessage()">
            <h4>{{message.message_Title}}</h4>
            <p>{{getThisProfile(message.userID).username}}  {{message.createdDate}}</p>
            <p>{{message.message_Body}}</p>

            
            <h6><a href=# @click.prevent="showComments = !showComments ">{{showComments ? "Hide Comments" : "Show Comments"}}</a></h6>
            <div v-show="showComments" id="Responses" v-for="response in theseForumResponses(message.messageID)" :key="response.messageID">
                {{response.body}}s
            <p>{{getThisProfile(response.userID).username}}</p>
            </div>
            <forum-response-form/>
    </div>
</template>

<script>
import ForumResponseForm from './ForumResponseForm.vue';

export default {
  components: { ForumResponseForm },
    name: 'message-details',
    props: ['messages'],
    data() {
        return {
            message: {},
            showComments: false
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