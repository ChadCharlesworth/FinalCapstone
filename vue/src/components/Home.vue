<template>
  <div class="home">
    
      <div>New Playdate</div>
      <div>Search All Playdates</div>
      <div>

  <!-- <iframe
    type="iframe"
    aspect="16by9"
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA43QR2uCNr0ZiF_wZfecB1UkcXc0S6aJk&callback=initMap&libraries=&v=weekly"
      defer
  ></iframe> -->

      </div>
      <div>
        <h3>Playdates</h3>

        </div>
      <div>
        <b-table sticky-header :items="items" head-variant="light"></b-table>
      </div>
      
    
  </div>
</template>

<script>
export default {
  name: "home",
//   computed: {publicPlaydates() {
//   return this.$store.state.playdates.filter(playdate => {
//     return playdate.is_Private == false;
//   })
// },
// playdateLocation(playdate) {
//   let location = this.$store.state.addresses.filter(address => {
//     return address.address_ID == playdate.address_ID;
//   });
//   return location;
// },
// displayPlaydates() {
//   let display = [];
//   this.publicPlaydates.forEach(playdate => {
// display.push( {location: this.playdateLocation(playdate)[0].street_Address_1, date_and_time: playdate.date_Time} )
//   }) 
//   return display;

  data() {
      return {
        fields: ["location", "date_and_time"],
        items: [
          // this.displayPlaydates
          { location: "Frick Park", date_and_time: "01/01/21" },
          { location: "Schenley Park", date_and_time: "01/02/21" },
          { location: "Point State Park", date_and_time: "01/03/21" },
          { location: "Highland Park", date_and_time: "01/04/21" },
          { location: "Frick Park", date_and_time: "01/01/21" },
          { location: "Schenley Park", date_and_time: "01/02/21" },
          { location: "Point State Park", date_and_time: "01/03/21" },
          { location: "Highland Park", date_and_time: "01/04/21" }
        ]
      }
    }
  }

</script>
