<template>
  <div id="playdateCreation">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="street-address1"
        label="Playdate Address:"
        label-for="street-address"
      >
        <b-form-input
          id="street-address1"
          v-model="address.street_Address_1"
          required
          placeholder="Street Address"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="streetAddress2">
        <b-form-input
          id="street-address2"
          v-model="address.street_Address_2"
          placeholder="Street Address"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="city">
        <b-form-input
          id="city"
          v-model="address.city"
          required
          placeholder="City"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="state">
        <b-form-select
          id="state"
          v-model="address.state"
          :options="states"
          required
        ></b-form-select>
      </b-form-group>

      <b-form-group id="zip">
        <b-form-input
          id="zip"
          v-model="address.zip"
          required
          placeholder="Zip"
        ></b-form-input>
      </b-form-group>

      <label for="datepicker">Choose a date</label>
      <b-form-datepicker id="datepicker" v-model="date"></b-form-datepicker>

      <label for="timepicker">Choose a time</label>
      <b-form-timepicker
        id="timepicker"
        v-model="time"
        locale="en"
      ></b-form-timepicker>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
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
      date: "",
      time: "",
      playdate: {
        address_ID: Number,
        creator_User_Id: Number,
        number_Of_Attendees: Number,
        is_Private: false,
        date_Time: this.combineDatetime,
      },
      states: [
        { text: "State", value: null },
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
    };
  },
  computed: {
    combineDatetime() {
      return this.date + " " + this.time + ".000";
    },
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      alert.JSON.stringify(this.form);
    },
    onReset(evt) {
      evt.preventDeault();
      this.form.streetAddress = "";
      this.form.city = "";
      this.form.zip = "";
      this.show = false;
    },
  },
};
</script>

<style>
</style>