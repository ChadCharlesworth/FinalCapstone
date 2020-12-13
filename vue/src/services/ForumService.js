import axios from 'axios';

export default {

  getCategories() {
    return axios.get('api/forum/category');
  },

  addCategory(category) {
    return axios.post('api/forum/category', category)
  },

  updateCategory(categoryID,category) {
    return axios.put(`api/forum/category/${categoryID}`,category)
  },

  deleteCategory(categoryID) {
    return axios.post(`api/forum/category/${categoryID}`)
  },

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
    return axios.put(`api/forum/category/${responseID}`,response)
  },

  deleteResponse(responseID) {
    return axios.post(`api/forum/category/${responseID}`)
  }

}
