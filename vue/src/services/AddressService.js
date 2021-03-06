import axios from 'axios';

export default {

  getAddresses() {
    return axios.get('api/address');
  },

  addAddress(address) {
    return axios.post('api/address/', address)
  },

  addAddressWithUser(userID,address) {
    return axios.post(`api/address/user/${userID}`, address)
  },

  updateAddress(addressID, address) {
    return axios.put(`api/address/${addressID}`, address)
  },

  deleteAddress(addressID) {
    return axios.delete(`api/address/${addressID}`)
  }

}
