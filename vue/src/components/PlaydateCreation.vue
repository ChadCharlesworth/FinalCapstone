<template>
  <div id="playdateCreation">
    <br />
<a href="#" v-on:click.prevent="showForm = !showForm">Create New Playdate</a>
    <form @submit="onSubmit" @reset="onReset">
      <input
        id="input-3"
        v-model="address.street_Address_1"
        required
        placeholder="Street"
      /><br />
      <input
        id="input-4"
        v-model="address.street_Address_2"
        placeholder="Street 2 (Optional)"
      /><br />
      <input
        id="input-5"
        v-model="address.city"
        required
        placeholder="City"
      /><br />
      <select v-model="address.state" required placeholder="State">
        <option disabled value="">State</option>
        <option v-for="state in states" v-bind:key="state" v-bind:value="state">
          {{ state }}
        </option></select
      ><br />
      <input
        id="input-6"
        v-model="address.zip"
        required
        placeholder="Zip Code"
      /><br />
      <input id="input-7" type="datetime-local" v-model="date_Time" /><br />

      <input id="input-8" type="radio" name="isPrivate" value="public" />
      <label for="public">Public</label>&nbsp;
      <input id="input-8" type="radio" name="isPrivate" value="private" />
      <label for="private">Private</label><br />

      <button type="submit" variant="primary">Submit</button>
      <button type="reset" variant="danger">Reset</button>
    </form>
  </div>
</template>

<script>
import PlaydateService from "../services/PlaydateService.js";
import AddressService from "../services/AddressService.js";

export default {
  name: "playdateCreation",
  data() {
    return {
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
      show: true,
      date: "",
      time: "",
      playdate: {
        address_ID: Number,
        creator_User_Id: Number,
        number_Of_Attendees: Number,
        is_Private: this.isPrivate,
        date_Time: "",
      },
    };
  },
  computed: {
    combineDatetime() {
      return this.date + " " + this.time + ".000";
    },
    isPrivate() {
      if (this.playdate.is_Private == "Private") {
        return true;
      } else return false;
    },
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      alert.JSON.stringify(this.form);
    },
    onReset() {
      this.address.street_Address_1 = "";
      this.address.street_Address_2 = "";
      this.address.city = "";
      this.address.state = null;
      this.address.zip = "";
      this.date_Time = "";
    },
    createNewPlaydate(playdate) {
      PlaydateService.addPlaydate(playdate)
        .then((response) => {
          if (response.status == 201) {
            this.$store.commit("LOAD_PLAYDATE", response.data);
          }
        })
        .catch((error) => console.log(error.response));
    },
    addNewPlaydateAddress(address) {
      AddressService.addAddress(address)
        .then((response) => {
          if (response.status == 201) {
            this.$store.commit("LOAD_ADDRESS", response.data);
            this.playdate.address_ID = response.data.address_ID;
            this.createNewPlaydate(this.playdate);
          }
        })
        .catch((error) => console.log(error.response));
    },
  },
};
</script>

<style>
</style>