<template>
<div>
    <b-button v-b-toggle.sidebar-right>Toggle Sidebar</b-button>
    <b-sidebar id="sidebar-right" title="Sidebar" right shadow>
      <div class="px-3 py-2">
        <ul>
          <li>Name: <a href="input-group-1"></li>
          <li>Breed: <a href="input-group-2"></li>
          <li>Personality:  <a href="input-group-3"></li>
          <li>Size: <a href="input-group-4"></li>
        </ul>
        <b-img src="https://picsum.photos/id/237/200/300" fluid thumbnail></b-img>
      </div>
    </b-sidebar>
  </div>
</template>

<script>
import Home from "../components/Home.vue"
export default {

}
</script>

<style>

</style>