import google from 'axios';

export default {

  getLatLong(street_Address_1,city,state) {
    return google.get(`https://maps.googleapis.com/maps/api/geocode/json?address=${street_Address_1}%20${city}%20${state}&key=AIzaSyB7fzAv_EDdQNMkdieXPVaWF7z9xeVeIzE`)
  }

}
