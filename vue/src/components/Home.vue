<template>
  <div class="home">
    
      <div>New Playdate</div>
      <div>Search All Playdates</div>
      <div>Map</div>
      <div>Playdates</div>
      <div>
        <b-table sticky-header :items="items" head-variant="light"></b-table>
      </div>
      
    
  </div>
</template>

<script>
export default {
  name: "home",
  data() {
      return {
        items: [
          { open_slots: 2, location: "Frick Park", date: "01/01/21", going: "1", invited: "3" },
          { open_slots: 5, location: "Schenley Park", date: "01/02/21", going: "1", invited: "6" },
          { open_slots: 3, location: "Point State Park", date: "01/03/21", going: "2", invited: "5" },
          { open_slots: 10, location: "Highland Park", date: "01/04/21", going: "2", invited: "12" },
          { open_slots: 2, location: "Frick Park", date: "01/01/21", going: "1", invited: "3" },
          { open_slots: 5, location: "Schenley Park", date: "01/02/21", going: "1", invited: "6" },
          { open_slots: 3, location: "Point State Park", date: "01/03/21", going: "2", invited: "5" },
          { open_slots: 10, location: "Highland Park", date: "01/04/21", going: "2", invited: "12" }
        ]
      }
    }
  }

</script>
