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
