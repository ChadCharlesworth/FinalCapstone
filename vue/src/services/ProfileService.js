import axios from 'axios';

export default {

  getProfiles() {
    return axios.get('api/profiles');
  },

  getProfileByID(userID) {
    return axios.get(`api/profiles/${userID}`)
  },

  updateProfile(userID, user) {
    return axios.put(`api/profiles/${userID}`, user)
  },

  deleteProfile(userID) {
    return axios.delete(`api/profiles/${userID}`)
  }

}
