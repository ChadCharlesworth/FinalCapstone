export default {

  getLatLong(street_Address_1,city,state) {
   return fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=${street_Address_1}%20${city}%20${state}&key=AIzaSyB7fzAv_EDdQNMkdieXPVaWF7z9xeVeIzE`)
    .then((gPromise) => {
        // call the method to get the actual data
        return gPromise.json();
    })
  }

}
