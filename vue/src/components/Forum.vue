<template>
  <div>
      
      <forum-message-form/>
      <forum-response-form/>
  </div>
</template>

<script>
import ForumMessageForm from "./ForumMessageForm.vue"
import ForumResponseForm from './ForumResponseForm.vue';



export default {
    name: "forum",
    components: { ForumMessageForm, ForumResponseForm}
};
</script>

<style>

</style>