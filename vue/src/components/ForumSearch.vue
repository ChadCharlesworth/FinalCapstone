<template>
    <div>
        <select name="search" v-model="search">
        <option disabled >Choose a User </option>
        <option v-for="user in this.$store.state.userProfiles" :value="user.user_id" :key="user.user_id">{{user.username}}</option>
        </select>
        <button type='submit' @click.prevent="searchBy()">Search</button>
    </div>
</template>

<script>
export default {
    name: 'forum-search',
    data() {
        return {
            search: 0
        }
    }
}
</script>

<style>

</style>