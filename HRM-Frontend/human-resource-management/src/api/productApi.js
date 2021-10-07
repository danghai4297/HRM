import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {
  getAllNv: () => {
    const url = "/NhanVien";
    return axiosClient.get(url);
  },

  getNvDetail: (maNv) => {
    const url = `/NhanVien/${maNv}`;
    return axiosClient.get(url);
  },

  getAllHd: () => {
    const url = "/HopDong";
    return axiosClient.get(url);
  },
};
export default ProductApi;
