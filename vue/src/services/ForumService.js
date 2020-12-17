import axios from 'axios';

export default {

  getMessages() {
    return axios.get('api/forum/message');
  },
  getMessagesByUser(userID) {
    return axios.get(`api/forum/message/user/${userID}`)
  },

  getMessage(id) {
    return axios.get(`api/forum/message/${id}`)
  },

  addMessage(message) {
    return axios.post('api/forum/message', message)
  },

  updateMessage(messageID,message) {
    return axios.put(`api/forum/message/${messageID}`,message)
  },

  deleteMessage(messageID) {
    return axios.delete(`api/forum/message/${messageID}`)
  },

  getResponses() {
    return axios.get('api/forum/response');
  },
  getResponse(id) {
    return axios.get(`api/forum/response/${id}`);
  },
  getResponsesByUser(userID) {
    return axios.get(`api/forum/response/user/${userID}`)
  },

  addResponse(response) {
    return axios.post('api/forum/response', response)
  },

  updateResponse(responseID,response) {
    return axios.put(`api/forum/response/${responseID}`,response)
  },

  deleteResponse(responseID) {
    return axios.delete(`api/forum/response/${responseID}`)
  }

}
