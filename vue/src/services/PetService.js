import axios from 'axios';

export default {

  getPets() {
    return axios.get('/api/pet');
  },

  addPet(pet) {
    return axios.post('/api/pet', pet)
  },

  updatePet(petID, pet) {
    return axios.put(`/api/pet/${petID}`, pet)
  },

  deletePet(petID) {
    return axios.delete(`/api/pet/${petID}`)
  }

}
