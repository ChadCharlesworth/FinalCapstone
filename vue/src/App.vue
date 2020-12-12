<template>
  <div id="app">
    <h1 class="display-1 text-center"> Pet Play Pals </h1>
    <div id="nav" class="navbar bg-info navbar-light sticky-top">
      <router-link class="nav-item nav-link" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link class="nav-item nav-link" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      
    </div>
    <div class="container-fluid">
      <div class="row">
        <div class="col-2 left-column border border-dark" style="height:100vh;"> PLACEHOLDER </div>
        <div class="col-8 main"><router-view /></div>
        <div class="col-2 right-column border border-dark">PLACEHOLDER</div>
      </div>
    </div>
  </div>
</template>
