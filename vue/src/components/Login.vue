<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class=" mb-3 h2 font-weight-normal">Please Sign In</h1>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >
        Thank you for registering, please sign in.
      </div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control mb-1"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control mb-2"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <button class="btn btn-light mr-2" type="submit">Sign in</button>
      <router-link :to="{ name: 'register' }">Need an account?</router-link>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";
import profileService from "@/services/ProfileService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            
            profileService
              .getProfileByID(this.$store.state.user.userId)
              .then((response) => {
                this.$store.commit("LOAD_CURRENT_PROFILE", response.data);
                if(this.$store.state.profile.first_Name == "")
                {
                  this.$router.push({name: 'create-profile'});
                }
                else {
                this.$router.push({name: 'home'});
                }
              })
              .catch(error => console.log(error.response));
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>
