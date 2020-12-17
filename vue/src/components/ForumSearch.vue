<template>
    <div>
        <h2> Forum Search </h2>
        <select name="search" v-model="search">
        <option disabled >Choose a User </option>
        <option v-for="user in this.$store.state.userProfiles" :value="user.user_id" :key="user.user_id">{{user.username}}</option>
        </select>
        <button type='submit' @click.prevent="searchMessage(search)">Search Messages</button>
        <button type='submit' @click.prevent="searchResponse(search)">Search Comments</button>
        <div>
        <div v-if="searchMessageList != []">
            <h5>Messages</h5>
            <h6 v-for="message in searchMessageList" :key="message.messageID">
                <router-link :to="{name: 'forum-message', params: {messageID: message.messageID}}">
                    {{message.message_Title}}</router-link></h6>
        </div>
        <div v-if="searchResponseList != []">
            <h5>Comments</h5>
            <h6 v-for="response in searchResponseList" :key="response.responseID">
            <router-link :to="{name: 'forum-message', params: {messageID: response.messageID}}">
                {{response.body}}</router-link></h6>
        </div>
        </div>
    </div>
</template>

<script>
import ForumService from '../services/ForumService'
export default {
    name: 'forum-search',
    data() {
        return {
            search: 0,
            searchMessageList: [],
            searchResponseList: []
        }
    },
    methods: {
        searchMessage(search){
            ForumService.getMessagesByUser(search)
            .then(response => {
                if(response.status == 200)
                {
                    this.searchMessageList = response.data
                }
            })
            .catch(error => {console.log(error.response)})
        },
        searchResponse(search){
            ForumService.getResponsesByUser(search)
            .then(response => {
                if(response.status == 200)
                {
                    this.searchResponseList = response.data
                }
            })
            .catch(error => {console.log(error.response)})
        }
    }
}
</script>

<style>

</style>