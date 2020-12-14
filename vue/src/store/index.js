import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    profile: {

    },
    addresses: [],
    pets: [],
    playdates: [],
    userProfiles: [],
    forumMessages: [],
    forumResponses: []
  },
  mutations: {
    LOAD_CURRENT_PROFILE(state, profileUser) {
      state.profile = profileUser;
    },
    LOAD_ADDRESS(state, address) {
      state.addresses.push(address);
    },
    UPDATE_ADDRESS(state, updatedAddress) {
      state.addresses.forEach(address => {
        if (updatedAddress.Address_ID == address.Address_ID) {
          address.Street_Address_1 = updatedAddress.Street_Address_1;
          address.Street_Address_2 = updatedAddress.Street_Address_2;
          address.City = updatedAddress.City;
          address.State = updatedAddress.State;
          address.Zip = updatedAddress.Zip;
        }
      })
    },
    DELETE_ADDRESS(state, id) {
      state.addresses.filter(address => {
        return address.Address_ID != id;
      });
      if (state.profile.Address_Ids.includes(id)) {
        state.profile.Address_Ids.filter(address_ID => {
          return address_ID != id;
        });
      }
    },
    LOAD_PET(state, pet) {
      state.pets.push(pet);
    },
    UPDATE_PET(state, updatedPet) {
      state.pets.forEach(pet => {
        if (updatedPet.Pet_ID == pet.Pet_ID) {
          pet.Owner_ID = updatedPet.Owner_ID;
          pet.Pet_Name = updatedPet.Pet_Name;
          pet.Species = updatedPet.Species;
          pet.Breed = updatedPet.Breed;
          pet.Size = updatedPet.Size;
          pet.Personality = updatedPet.Personality;
        }
      })
    },
    DELETE_PET(state, id) {
      state.pets.filter(pet => {
        return pet.Pet_ID != id;
      });
      if (state.profile.Pet_Ids.includes(id)) {
        state.profile.Pet_Ids.filter(pet_ID => {
          return pet_ID != id;
        });
      }
    },
    LOAD_PLAYDATE(state, playdate) {
      state.playdates.push(playdate);
    },
    UPDATE_PLAYDATE(state, updatedPlaydate) {
      state.playdates.forEach(playdate => {
        if (updatedPlaydate.Playdate_ID == playdate.Playdate_ID) {
          playdate = updatedPlaydate;
        }
      })
    },
    DELETE_PLAYDATE(state, id) {
      state.playdates.filter(playdate => {
        return playdate.Playdate_ID != id;
      })
    },
    LOAD_PROFILE_TO_ARRAY(state, profile) {
      state.userProfiles.push(profile);
    },
    DELETE_PROFILE(state, id) {
      state.userProfiles.filter(profile => {
        return profile.user_id != id;
      })
    },
    LOAD_MESSAGE(state, message) {
      state.forumMessages.push(message);
    },
    UPDATE_MESSAGE(state, updatedMessage) {
      state.forumMessages.forEach(message => {
        if (updatedMessage.Message_ID == message.Message_ID) {
          message.Category_ID = updatedMessage.Category_ID;
          message.User_ID = updatedMessage.User_ID;
          message.Message_Title = updatedMessage.Message_Title;
          message.Message_Body = updatedMessage.Message_Body;
        }
      })
    },
    DELETE_MESSAGE(state, id) {
      state.forumMessages.filter(message => {
        return message.Message_ID != id;
      })
    },
    LOAD_RESPONSE(state, response) {
      state.forumResponses.push(response);
    },
    UPDATE_RESPONSE(state, updatedResponse) {
      state.forumResponses.forEach(response => {
        if (updatedResponse.Response_ID == response.Response_ID) {
          response.User_ID = updatedResponse.User_ID;
          response.Message_ID = updatedResponse.Message_ID;
          response.Response_Body = updatedResponse.Response_Body;
        }
      })
    },
    DELETE_RESPONSE(state, id) {
      state.forumResponses.filter(response => {
        return response.Response_ID != id;
      })
    },
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
      state.profile = {
      };
      state.addresses = [];
      state.pets = [];
      state.playdates = [];
      state.userProfiles = [];
      state.forumCategories = [];
      state.forumMessages = [];
      state.forumResponses = [];
    }
  }
})
