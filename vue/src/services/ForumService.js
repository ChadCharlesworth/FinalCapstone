import axios from 'axios';

export default {

  getMessages() {
    return axios.get('api/forum/message');
  },

  addMessage(message) {
    return axios.post('api/forum/message', message)
  },

  updateMessage(messageID,message) {
    return axios.put(`api/forum/message/${messageID}`,message)
  },

  deleteMessage(messageID) {
    return axios.post(`api/forum/message/${messageID}`)
  },

  getResponses() {
    return axios.get('api/forum/response');
  },

  addResponse(response) {
    return axios.post('api/forum/response', response)
  },

  updateResponse(responseID,response) {
    return axios.put(`api/forum/response/${responseID}`,response)
  },

  deleteResponse(responseID) {
    return axios.post(`api/forum/response/${responseID}`)
  }

}
