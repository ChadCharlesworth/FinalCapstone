import axios from 'axios';

export default {

  getAddresses() {
    return axios.get('api/address');
  },

  addAddress(userID,address) {
    return axios.post(`api/address/user/${userID}`, address)
  },

  updateAddress(addressID, address) {
    return axios.put(`api/address/${addressID}`, address)
  },

  deleteAddress(addressID) {
    return axios.post(`api/address/${addressID}`)
  }

}
