import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {

  //tất cả nhân viên
  getAllNv: () => {
    const url = "/NhanVien";
    return axiosClient.get(url);
  },

  //detail nhân viên
  getNvDetail: (maNv) => {
    const url = `/NhanVienDetail/${maNv}`;
    return axiosClient.get(url);
  },

  //tất cả hợp đồng
  getAllHd: () => {
    const url = "/HopDong";
    return axiosClient.get(url);
  },
};


export default ProductApi;
