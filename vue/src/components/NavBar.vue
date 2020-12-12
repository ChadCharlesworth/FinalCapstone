<template>
<div>
    <h1 class="display-2 text-light text-center bg-success pb-2 mb-0"> Pet Play Pals </h1>
    <b-navbar class="navbar bg-success navbar-dark sticky-top">
    <b-navbar-nav>
    <b-navbar-brand><router-link class="nav-link" v-bind:to="{ name: 'home' }">Home</router-link></b-navbar-brand>
    <b-nav-item><router-link class="nav-link" v-bind:to="{name: 'playdate' }">Playdates</router-link></b-nav-item>
    <b-nav-item><router-link class="nav-link" v-bind:to="{name: 'forum' }">Forum</router-link></b-nav-item>
    <b-nav-item v-if="$store.state.token != ''"><router-link class="nav-link" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></b-nav-item> 
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