import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {
  getAllNv: () => {
    const url = "/NhanVien";
    return axiosClient.get(url);
  },
};
export default ProductApi;
