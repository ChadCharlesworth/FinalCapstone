import axios from 'axios';

export default {

  getPlaydates() {
    return axios.get('api/playdate');
  },

  addPlaydate(playdate) {
    return axios.post('api/playdate', playdate)
  },

  updatePlaydate(playdateID, playdate) {
    return axios.put(`api/playdate/${playdateID}`, playdate)
  },

  updatePlaydateByPetID(playdateID, playdate, petID) {
    return axios.put(`api/playdate/${playdateID}/pet/${petID}`, playdate)
  },

  deletePlaydate(playdateID) {
    return axios.post(`api/playdate/${playdateID}`)
  },

  getPlaydatesByOwnerID(ownerID) {
    return axios.get(`api/playdate/owner/${ownerID}`)
  }

}
