import axiosClient from "./axiosClient";

const PutApi = {
  //Sửa danh mục dân tộc
  PutDMDT: (data) => {
    const url = "/DanhMucDanToc";
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMCD: (data) => {
    const url = "/DanhMucChucDanh";
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMCV: (data) => {
    const url = "/DanhMucChucVu";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMCM: (data) => {
    const url = "/DanhMucChuyenMon";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMHN: (data) => {
    const url = "/DanhMucHonNhan";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMLHD: (data) => {
    const url = "/DanhMucLoaiHopDong";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNCC: (data) => {
    const url = "/DanhMucNgachCongChuc";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNN: (data) => {
    const url = "/DanhMucNgoaiNgu";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNT: (data) => {
    const url = "/DanhMucNguoiThan";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNL: (data) => {
    const url = "/DanhMucNhomLuong";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMPB: (data) => {
    const url = "/DanhMucPhongBan";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMTCLD: (data) => {
    const url = "/DanhMucTinhChatLaoDong";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMT: (data) => {
    const url = "/DanhMucTo";
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMHTDT: (data) => {
    const url = "/DanhMucHinhThucDaoTao";
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMTG: (data) => {
    const url = "/DanhMucTonGiao";
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMTD: (data) => {
    const url = "/DanhMucTrinhDo";
    return axiosClient.put(url, data);
  },
};

export default PutApi;
