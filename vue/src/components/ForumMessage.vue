<template>
    <div v-bind="setCurrentMessage()">
            <h4>{{message.message_Title}}</h4>
            <p>{{getThisProfile(message.userID).username}}</p>
            <p>{{message.message_Body}}</p>
    </div>
</template>

<script>
export default {
    name: 'message-details',
    data() {
        return {
            message: {}
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
        }
    }   
}
</script>

<style>

</style>