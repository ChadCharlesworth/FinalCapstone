<template>
  <div>
    <h1 class="text-center display-6">About You</h1>
    <form @submit.prevent="onSubmit" @reset="onReset">
      
      <input 
        id="input-1"
        v-model="profile.first_Name"
        required
        placeholder="First Name"
      />

      <input
        id="input-2"
        v-model="profile.last_Name"
        required
        placeholder="Last Name"
      />

      <input
        id="input-3"
        v-model="address.street_Address_1"
        required
        placeholder="Street"
      />

      <input
        id="input-4"
        v-model="address.street_Address_2"
        placeholder="Street 2 (Optional)"
      />

      <input id="input-5" v-model="address.city" required placeholder="City" />

      <select v-model="address.state">
        <option disabled value="">State</option>
        <option v-for="state in states" v-bind:key="state" v-bind:value="state">
          {{ state }}
        </option>
      </select>

      <input
        id="input-7"
        v-model="address.zip"
        required
        placeholder="Zip Code"
      /><br>

      <button class="btn btn-success mt-3 mr-3" type="submit">Submit</button>
      <button class="btn btn-danger mt-3" type="reset">Reset</button>
    </form>
  </div>
</template>

<script>
import AddressService from "@/services/AddressService.js";
import ProfileService from "@/services/ProfileService.js";
import MapService from "@/services/MapService.js";

export default {
  methods: {
    onReset() {
      this.profile.first_Name = "";
      this.profile.last_Name = "";
      this.address.street_Address_1 = "";
      this.address.street_Address_2 = "";
      this.address.city = "";
      this.address.state = null;
      this.address.zip = "";
    },
    onSubmit() {



      MapService.getLatLong(
        this.address.street_Address_1,
        this.address.city,
        this.address.state
      )
        .then((gResponse) => {
            this.address.latitude =
              gResponse.results[0].geometry.location.lat;
            this.address.longitude =
              gResponse.results[0].geometry.location.lng;
            AddressService.addAddressWithUser(
              this.profile.user_id,
              this.address
            ).then((response) => {
              this.$store.commit("LOAD_ADDRESS", response.data);
              ProfileService.updateProfile(
                this.profile.user_id,
                this.profile
              ).then((response) => {
                this.$store.commit("LOAD_CURRENT_PROFILE", response.data);
                this.$router.push({ name: "pet-registration" });
              });
            });
          }
        )
        .catch((error) => console.log(error.response));
    },
  },
  data() {
    return {
      profile: {
        first_Name: "",
        last_Name: "",
        user_id: this.$store.state.user.userId,
        user_role: this.$store.state.user.role,
        username: this.$store.state.user.username,
      },
      address: {
        street_Address_1: "",
        street_Address_2: "",
        city: "",
        state: null,
        zip: "",
      },
      states: [
        "AK",
        "AL",
        "AR",
        "AZ",
        "CA",
        "CO",
        "CT",
        "DE",
        "FL",
        "GA",
        "HI",
        "IA",
        "ID",
        "IL",
        "IN",
        "KS",
        "KY",
        "LA",
        "MA",
        "MD",
        "ME",
        "MI",
        "MN",
        "MO",
        "MS",
        "MT",
        "NC",
        "NE",
        "NH",
        "NJ",
        "NM",
        "ND",
        "NV",
        "NY",
        "OH",
        "OK",
        "OR",
        "PA",
        "RI",
        "SC",
        "SD",
        "TN",
        "TX",
        "UT",
        "VA",
        "VT",
        "WA",
        "WI",
        "WV",
        "WY",
      ],
    };
  },
};
</script>

<style>
</style>