<template>
  <div id="playdate">
    <google-map style="height: 800px; width: 800px" />
    <br />


    <h3 class="display-6">Your Upcoming Playdates:</h3>

    <table class="table table-sm">
      <tr>
        <th>Location</th>
        <th>Date and Time</th>
        <th>Pet</th>
        <th>Private / Public</th>
        <th>Attending / Pending Invitation</th>
        <th>Action</th>
      </tr>
      <tr v-for="playdate in playdates" :key="playdate.playdate_ID">
        <td>
          {{ playdate.street_Address_1 }}
          {{ playdate.street_Address_2 }}<br />
          {{ playdate.city }},&nbsp; {{ playdate.state }}&nbsp;
          {{ playdate.zip }}
        </td>
        <td>{{ playdate.date_Time_String }}</td>
        <td>{{ playdate.pet_Name }}</td>
        <td>{{ playdate.is_Private ? "Private" : "Public" }}</td>
        <td>
          {{ playdate.approval_Status == "Attending" ? "Attending" : "Pending your acceptance" }}
        </td>
        <td>
          <button class="btn btn-secondary"
            type="submit"
            @click.prevent="
              acceptInvite(playdate.playdate_ID, playdate, playdate.pet_ID)
            "
            v-if="playdate.approval_Status == 'Pending'"
          >
            Going
          </button>
          <button class="btn btn-light" type="submit" @click.prevent="declineInvite(playdate.playdate_ID, playdate, playdate.pet_ID)">
            Not Going
          </button>
        </td>
      </tr>
    </table>
  </div>
</template>

<script>
import playdateService from "../services/PlaydateService.js";
// import googleMap from "../components/GoogleMap.vue";

export default {
  name: "playdate",
  computed: {
    currentProfile() {
      return this.$store.state.profile;
    },
    playdateDate() {
      let dates = [];
      for (let i = 0; i < this.playdates.length; i++) {
        dates.push(this.playdates[i].date_Time_String.substring(0, 11));
      }
      return dates;
    },
    playdateTime() {
      let times = [];
      for (let i = 0; i < this.playdates.length; i++) {
        times.push(this.playdates[i].date_Time_String.substring(12).trim());
      }
      return times;
    },
  },
  created() {
    playdateService
      .getPlaydatesByOwnerID(this.$store.state.profile.user_id)
      .then((response) => {
        if (response.status === 200) {
          this.playdates = response.data;
        }
      })
      .catch((error) => console.log(error));
  },
  methods: {
    acceptInvite(playdate_ID, playdate, pet_ID) {
      if (playdate.pending.includes(pet_ID)) {
        delete playdate.pending[playdate.pending.indexOf(pet_ID)];
      }
      if (playdate.declined.includes(pet_ID)) {
        delete playdate.declined[playdate.pending.indexOf(pet_ID)];
      }
      playdate.attending.push(pet_ID);

      playdateService
        .updatePlaydateByPetID(playdate_ID, playdate, pet_ID)
        .then((response) => {
          if (response.status === 200) {
            this.$store.commit("UPDATE_PLAYDATE", response.data);
          }
        })
        .catch((error) => console.log(error));
    },
    declineInvite(playdate_ID, playdate, pet_ID) {
      if (playdate.pending.includes(pet_ID)) {
        delete playdate.pending[playdate.pending.indexOf(pet_ID)];
      }
      if (playdate.attending.includes(pet_ID)) {
        delete playdate.declined[playdate.pending.indexOf(pet_ID)];
      }
      playdate.declined.push(pet_ID);

      playdateService
        .updatePlaydateByPetID(playdate_ID, playdate, pet_ID)
        .then((response) => {
          if (response.status === 200) {
            this.$store.commit("UPDATE_PLAYDATE", response.data);
          }
        })
        .catch((error) => console.log(error));
    },
  },
  data() {
    return {
      showForm: false,
      playdates: [],
    };
  },
};
</script>

<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td,
th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #9b78ec;
}
</style>