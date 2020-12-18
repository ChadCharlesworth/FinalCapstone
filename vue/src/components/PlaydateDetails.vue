<template>
  <div id="playdate">
    <google-map style="height: 800px; width: 800px" />
    <br />

    <h3>Your Upcoming Playdates:</h3>

    <table>
      <tr>
        <th>Location</th>
        <th>Date and Time</th>
        <th>Pet</th>
        <th>Private / Public</th>
        <th>Attending / Pending Invitation</th>
        <th>Join in the fun?</th>
      </tr>
      <tr v-for="playdate in playdatesToDecline" :key="playdate.playdate_ID">
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
          {{
            playdate.approval_Status == "Attending"
              ? "Attending"
              : "Pending your acceptance"
          }}
        </td>
        <td>
          <button
            type="submit"
            @click.prevent="acceptInvite(playdate.playdate_ID, playdate.pet_ID)"
            v-if="playdate.approval_Status == 'Pending'"
          >
            I'll be there!
          </button>
          <button
            type="submit"
            @click.prevent="
              declineInvite(playdate.playdate_ID, playdate.pet_ID)
            "
            v-if="playdate.approval_Status =='Attending' || playdate.approval_Status == 'Pending'"
          >
            Bummer, I can't make it.
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
    playdatesToDecline() {
      return this.playdates.filter((playdate) => {
        return playdate.approval_Status != "Declined";
      });
    },
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
          for (let i = 0; i < this.playdates.length; i++) {
            this.playdates[i].date_Time = null;
          }
        }
      })
      .catch((error) => console.log(error));
  },
  methods: {
    acceptInvite(playdate_ID, pet_ID) {
      playdateService
        .acceptPlaydateByPetID(playdate_ID, pet_ID)
        .then((response) => {
          if (response.status === 204) {
            this.$store.commit("ACCEPT_PLAYDATE", playdate_ID, pet_ID);
          }
        })
        .catch((error) => console.log(error));
    },
    declineInvite(playdate_ID, pet_ID) {
      playdateService
        .declinePlaydateByPetID(playdate_ID, pet_ID)
        .then((response) => {
          if (response.status === 204) {
            this.$store.commit("DECLINE_PLAYDATE", playdate_ID, pet_ID);
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
  background-color: #dddddd;
}
</style>