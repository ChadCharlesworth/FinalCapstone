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

    <table style="width: 100%">
      <tr>
        <th>When</th>
        <th>Where</th>
        <th>Private event?</th>
        <th>Number of Attendees</th>
      </tr>
      <tr>
        <td>filler dateTime</td>
        <td>filler address</td>
        <td>filler privacy status</td>
        <td>filler participant count</td>
      </tr>
      <tr>
        <td>filler dateTime</td>
        <td>filler address</td>
        <td>filler privacy status</td>
        <td>filler participant count</td>
      </tr>
      <tr>
        <td>filler dateTime</td>
        <td>filler address</td>
        <td>filler privacy status</td>
        <td>filler participant count</td>
      </tr>
      <tr>
        <td>filler dateTime</td>
        <td>filler address</td>
        <td>filler privacy status</td>
        <td>filler participant count</td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: "playdate",
  data() {
    return {
      showForm: false,
    }
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