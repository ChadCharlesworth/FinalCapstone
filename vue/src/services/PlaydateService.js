import axios from 'axios';

export default {

  getPlaydates() {
    return axios.get('api/playdate');
  },

  getPlaydate(playdateID) {
    return axios.get(`api/playdate/${playdateID}`)
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
  
  declinePlaydateByPetID(playdateID, petID) {
    return axios.delete(`api/playdate/${playdateID}/decline/pet/${petID}`)
  },
  acceptPlaydateByPetID(playdateID, petID) {
    return axios.delete(`api/playdate/${playdateID}/accept/pet/${petID}`)
  },
  pendingPlaydateByPetID(playdateID, petID) {
    return axios.delete(`api/playdate/${playdateID}/pending/pet/${petID}`)
  },

  deletePlaydate(playdateID) {
    return axios.delete(`api/playdate/${playdateID}`)
  },

  getPlaydatesByOwnerID(ownerID) {
    return axios.get(`api/playdate/owner/${ownerID}`)
  }

}
