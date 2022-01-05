import axios from 'axios'

function api() {
  axios.defaults.withCredentials = true
  return axios.create({
    baseURL: 'http://localhost:5000/api/',
  })
}

export default { api }
