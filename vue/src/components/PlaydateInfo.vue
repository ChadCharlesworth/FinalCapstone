<template>
  <div>
    <h3>{{ playdateDate }} {{playdateTime}}</h3>
    <p>
      {{ playdateAddress.street_Address_1 }}
      {{ playdateAddress.street_Address_2 }}<br />
      {{ playdateAddress.city }}, {{ playdateAddress.state }}
      {{ playdateAddress.zip }}
    </p>
  </div>
</template>

<script>
export default {
  name: "playdate-info",
  props: { playdate: Object },
  computed: {
    playdateAddress() {
      let playdateAddress;
      let tempPlaydateAddress = [];
      const playdate = this.playdate;
      const addresses = this.$store.state.addresses;
      tempPlaydateAddress = addresses.filter((address) => {
        return address.address_ID === playdate.address_ID;
      });
      playdateAddress = tempPlaydateAddress[0];
      return playdateAddress;
    },
    playdateDate() {
        return this.playdate.date_Time.split("T")[0];
    },
    playdateTime() {
        let time = this.playdate.date_Time.split("T")[1];
        time = time.substring(0,5);
        if(time.startsWith('0')) {
            time = time.substring(1);
        }
        return time;
    }
  },
};
</script>

<style>
</style>