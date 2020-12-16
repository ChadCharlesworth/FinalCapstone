<template>
  <div id="playdate">
    <google-map style="height: 800px; width: 800px;" />
    <br />

    <h3>Your Upcoming Playdates:</h3>

    <table>
      <tr>
        <th>Location</th>
        <th>Date and Time</th>
        <th>Pet</th>
        <th>Private / Public</th>
      </tr>
      <tr
        v-for="(profilePlaydate, index) in profilePlaydates"
        :key="profilePlaydate.playdate_ID"
      >
        <td>
          {{ playdateAddress[index].street_Address_1 }}
          {{ playdateAddress[index].street_Address_2 }}<br />
          {{ playdateAddress[index].city }},&nbsp;
          {{ playdateAddress[index].state }}&nbsp;
          {{ playdateAddress[index].zip }}
        </td>
        <td>{{ playdateDate[index] }} {{ playdateTime[index] }}</td>
        <td>{{ profilePlaydatePet[index].pet_Name }}</td>
        <td>{{ profilePlaydate.is_Private ? "Private" : "Public" }}</td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: "playdate",
  computed: {
    currentProfile() {
      return this.$store.state.profile;
    },
    playdateDate() {
      let dates = [];
      for (let i = 0; i < this.profilePlaydates.length; i++) {
        dates.push(this.profilePlaydates[i].date_Time.substring(0, 11));
      }
      return dates;
    },
    playdateTime() {
      let times = [];
      for (let i = 0; i < this.profilePlaydates.length; i++) {
        times.push(
          this.profilePlaydates[i].date_Time.substring(12).trim()
        );
      }
      return times;
    },
    profilePets() {
      let allProfilePets = [];
      let tempProfilePets = [];
      const profile = this.currentProfile;
      const pets = this.$store.state.pets;
      for (let i = 0; i < profile.pet_Ids.length; i++) {
        tempProfilePets = pets.filter((address) => {
          return address.pet_ID === profile.pet_Ids[i];
        });
        allProfilePets = allProfilePets.concat(tempProfilePets);
        tempProfilePets = [];
      }
      return allProfilePets;
    },
    profilePlaydates() {
      let profPlaydates = [];
      for (let i = 0; i < this.$store.state.playdates.length; i++) {
        let tempPlaydate = this.$store.state.playdates[i];
        for (let j = 0; j < this.$store.state.profile.pet_Ids.length; j++) {
          let tempID = this.$store.state.profile.pet_Ids[j];
          if (
            tempPlaydate.attending.includes(tempID) ||
            tempPlaydate.pending.includes(tempID)
          ) {
            profPlaydates.push(tempPlaydate);
          }
        }
      }
      return profPlaydates;
    },
    playdateAddress() {
      let playdateAddresses = [];
      let tempPlaydateAddresses = [];
      const playdates = this.profilePlaydates;
      const addresses = this.$store.state.addresses;
      for (let i = 0; i < playdates.length; i++) {
        tempPlaydateAddresses = addresses.filter((address) => {
          return address.address_ID === playdates[i].address_ID;
        });
        playdateAddresses = playdateAddresses.concat(tempPlaydateAddresses);
      }
      return playdateAddresses;
    },
    profilePlaydatePet() {
      let allProfilePets = [];
      let tempProfilePets = [];
      const pets = this.profilePets;
      for (let j = 0; j < this.profilePlaydates.length; j++) {
        for (let i = 0; i < this.profilePlaydates[j].attending.length; i++) {
          tempProfilePets = pets.filter((pet) => {
            return pet.pet_ID === this.profilePlaydates[j].attending[i];
          });
          allProfilePets = allProfilePets.concat(tempProfilePets);
          tempProfilePets = [];
        }
      }
      for (let j = 0; j < this.profilePlaydates.length; j++) {
        for (let i = 0; i < this.profilePlaydates[j].pending.length; i++) {
          tempProfilePets = pets.filter((pet) => {
            return pet.pet_ID === this.profilePlaydates[j].pending[i];
          });
          allProfilePets = allProfilePets.concat(tempProfilePets);
          tempProfilePets = [];
        }
      }

      return allProfilePets;
    },
  },

  data() {
    return {
      showForm: false,
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