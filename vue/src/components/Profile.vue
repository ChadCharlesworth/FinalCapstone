<template>
  <div></div>
</template>

<script>
export default {
  name: "profile",
  computed: {
    currentProfile() {
      return this.$store.state.profile;
    },
    profileAddresses() {
      const allProfileAddresses = [];
      for(let i = 0; i < this.currentProfile.address_Ids.length; i++) {
        allProfileAddresses = allProfileAddresses.concat(this.$store.state.addresses.filter(address => {
          address.address_ID === this.currentProfile.address_Ids[i];
        })
      }
return allProfileAddresses;
  }
}
}
</script>

<style>
</style>