<template>
  <div id="playdateCreation">
    <br />
    <a href="#" v-on:click.prevent="showForm = !showForm"
      >Click here to create a new playdate</a
    >
    <form v-show="showForm === true" @submit="onSubmit" @reset="onReset">
      <br /><label for="input-1"><b>Where</b> is this playdate?</label><br />
      <input
        id="input-1"
        v-model="address.street_Address_1"
        required
        placeholder="Street"
      /><br />
      <input
        id="input-2"
        v-model="address.street_Address_2"
        placeholder="Street 2 (Optional)"
      /><br />
      <input
        id="input-3"
        v-model="address.city"
        required
        placeholder="City"
      /><br />
      <select v-model="address.state" required placeholder="State">
        <option value="" disabled selected>State</option>
        <option v-for="state in states" v-bind:key="state" v-bind:value="state">
          {{ state }}
        </option></select
      ><br />
      <input
        id="input-4"
        v-model="address.zip"
        required
        placeholder="Zip Code"
      /><br />

      <br /><label for="input-5"><b>When</b> is this playdate?</label><br />
      <input
        id="input-5"
        type="datetime-local"
        v-model="playdate.date_Time"
      /><br />

      <br /><label for="input-6"
        >What <b>pet</b> are you taking to this playdate?</label
      ><br />
      <select placeholder="Your Pets" v-model="petID">
        <option v-for="pet in profilePets" v-bind:key="pet" v-bind:value="pet.pet_ID" >
          {{ pet.pet_Name }}
        </option></select
      ><br />

      <br /><label for="input-7"
        >Is this playdate <b>public</b> or <b>private</b>?</label
      ><br />
      <input
        id="input-7"
        type="radio"
        name="isPrivate"
        :value="false"
        v-model="playdate.is_Private"
      />
      <label for="public">Public (visible to anyone)</label><br />
      <input
        id="input-7"
        type="radio"
        name="isPrivate"
        :value="true"
        v-model="playdate.is_Private"
      />
      <label for="private">Private (by invitation only)</label><br />

      <br /><button type="submit" variant="primary">Submit</button>
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
      showForm: false,
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
      petID: Number,
      date: "",
      time: "",
      playdate: {
        address_ID: Number,
        creator_User_Id: Number,
        number_Of_Attendees: Number,
        is_Private: false,
        date_Time: "",
        pet_Approval_Status: {
          [this.petID]:"Attending"
        }
      },
    };
  },
  computed: {
    currentProfile() {
      return this.$store.state.profile;
    },
    profilePets() {
      let allProfilePets = [];
      let tempProfilePets = [];
      const profile = this.currentProfile;
      const pets = this.$store.state.pets;
      for (let i = 0; i < profile.pet_Ids.length; i++) {
        tempProfilePets = pets.filter((pet) => {
          return pet.pet_ID === profile.pet_Ids[i];
        });
        allProfilePets = allProfilePets.concat(tempProfilePets);
        tempProfilePets = [];
      }
      return allProfilePets;
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