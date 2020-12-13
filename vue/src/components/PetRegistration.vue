<template>
  <div id="Your Pet" class="text-align-right">
    <form class="form-signin" @submit.prevent="pet">
      <b-form @submit="onSubmit" @reset="onReset" v-if="logged_in">
      <b-form-group id="input-group-1" label="Your Pet's Name:" label-for="input-2">
        <b-form-input
          id="input-1"
          v-model="form.name"
          required
          placeholder="Enter name"
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="Pet Breed:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.breed"
          required
          placeholder="Enter breed"
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-3" label="Pet Personality:" label-for="input-3">
        <b-form-input
          id="input-3"
          v-model="form.personality"
          required
          placeholder="Enter personality"
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-4" label="Pet Size:" label-for="input-4">
        <b-form-input
          id="input-4"
          v-model="form.size"
          required
          placeholder="Enter size"
        ></b-form-input>
      </b-form-group></b-form>
    </form>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering your pet, please sign in.</div></div>
</template>
<script>
export default {
  name: "petInfo",
  data() {
    return {
      items: [
        {age: 40, first_name: 'Dickerson', last_name: 'Testing'},
        {age: 28, first_name: 'Person', last_name: 'McPerson'},
        {age: 50, first_name: 'Joe', last_name: 'Schmoe'},
        {age: 40, first_name: 'John', last_name: 'Doe'}
      ]
    }
  }
}
</script>