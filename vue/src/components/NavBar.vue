<template>
<div style="position: relative">
    <h1 class="display-2 text-light text-center bg-success pb-2 mb-0"> Pet Play Pals </h1>
    <b-navbar class="navbar bg-success navbar-light">
        <b-navbar-nav>
            <b-navbar-brand v-bind:to="{ name: 'home' }">Home</b-navbar-brand>
            <b-nav-item v-bind:to="{ name: 'playdate' }">My Playdates</b-nav-item>
            <b-nav-item v-bind:to="{ name: 'forum-search' }">Forum Search</b-nav-item>
        </b-navbar-nav>
        <b-navbar-nav class="ml-auto">
            <b-nav-item-dropdown  v-if="$store.state.token != ''" text="Account" right>
            <b-dropdown-item class="dropdown-item" :to="{name: 'profile'}">Your Profile</b-dropdown-item>
            <b-dropdown-item class="dropdown-item" v-bind:to="{ name: 'logout' }">Logout</b-dropdown-item> 
            </b-nav-item-dropdown>
        </b-navbar-nav>
    </b-navbar>
</div>
</template>

<script>
export default {

}
</script>

<style>

</style>