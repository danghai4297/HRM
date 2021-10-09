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

  //tất cả chức danh
  getAllDMCD: () => {
    const url = "/DanhMucChucDanh";
    return axiosClient.get(url);
  },

  //tất cả danh muc chức vụ
  getAllDMCV: () => {
    const url = "/DanhMucChucVu";
    return axiosClient.get(url);
  },

  //tất cả danh muc chuyên môn
  getAllDMCM: () => {
    const url = "/DanhMucChuyenMon";
    return axiosClient.get(url);
  },

  //all dm dân tộc
  getAllDMDT: () => {
    const url = "/DanhMucDanToc";
    return axiosClient.get(url);
  },

  //all dm hôn nhân
  getAllDMHN: () => {
    const url = "/DanhMucHonNhan";
    return axiosClient.get(url);
  },
};


export default ProductApi;
