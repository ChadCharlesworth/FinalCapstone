<template>
  <div id="playdate">
    <div>~ Map to be displayed here with pins for playdates ~</div>
    <div>|_____________________________________________________|</div>
    <div>|_____________________________________________________|</div>
    <div>|______this___________________________________________|</div>
    <div>|________________is___________________________________|</div>
    <div>|________________________the_________________________|</div>
    <div>|_________________________________map_______________|</div>
    <div>|________________________________________space_______|</div>
    <div>|_____________________________________________________|</div>
    <div>|_____________________________________________________|</div>
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
        <td>{{ profilePlaydate.date_Time }}</td>
        <td>{{ profilePets[index].pet_Name }}</td>
        <td>{{ profilePlaydate.is_Private ? "Private" : "Public" }}</td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: "playdate",
  methods: {
    getKeyByValue(object, value) {
      return Object.keys(object).filter((key) => object[key] === value);
    },
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
        let keys = this.getKeyByValue(
          tempPlaydate.pet_Approval_Status,
          "Attending"
        );
        for (let j = 0; j < this.$store.state.profile.pet_Ids.length; j++) {
          let tempID = this.$store.state.profile.pet_Ids[j];
          let IDIncluded = keys.includes(tempID.toString());
          if (IDIncluded) {
            profPlaydates.push(this.$store.state.playdates[i]);
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