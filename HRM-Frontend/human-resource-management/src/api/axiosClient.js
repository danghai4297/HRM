// api/axiosClient.js
import axios from "axios";
import queryString from "query-string";
// Set up default config for http requests here
// Please have a look at here `https://github.com/axios/axios#requestconfig` for the full list of configs
const axiosClient = axios.create({
  baseURL: "https://localhost:5001/api",
  headers: {
    "content-type": "application/json multipart/form-data",
    
  },
  paramsSerializer: (params) => queryString.stringify(params),
});
axiosClient.interceptors.request.use(async (config) => {
  // Handle token here ...
  config.headers["Authorization"] = "Bearer " + localStorage.getItem("resultObj");
  return config;
});
axiosClient.interceptors.response.use(
  (response) => {
    if (response && response.data) {
      return response.data;
    }
    return response;
  },
  (error) => {
    // Handle errors
    throw error;
  }
);
export default axiosClient;
