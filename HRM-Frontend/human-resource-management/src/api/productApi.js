import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {
  getAllNv: () => {
    const url = "/products";
    return axiosClient.get(url, {
      baseURL: "https://localhost:3001/api",
    });
  },
};
export default ProductApi;
