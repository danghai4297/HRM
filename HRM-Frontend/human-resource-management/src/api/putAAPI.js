import axiosClient from "./axiosClient";

const PutApi = {
  //Sửa danh mục dân tộc
  PutDMDT: (data, id) => {
    const url = `/DanhMucDanToc/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMCD: (data, id) => {
    const url = `/DanhMucChucDanh/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMCV: (data, id) => {
    const url = `/DanhMucChucVu/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMCM: (data, id) => {
    const url = `/DanhMucChuyenMon/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMHN: (data, id) => {
    const url = `/DanhMucHonNhan/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMLHD: (data, id) => {
    const url = `/DanhMucLoaiHopDong/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNCC: (data, id) => {
    const url = `/DanhMucNgachCongChuc/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNN: (data, id) => {
    const url = `/DanhMucNgoaiNgu/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNT: (data, id) => {
    const url = `/DanhMucNguoiThan/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMNL: (data, id) => {
    const url = `/DanhMucNhomLuong/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMPB: (data, id) => {
    const url = `/DanhMucPhongBan/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMTCLD: (data, id) => {
    const url = `/DanhMucTinhChatLaoDong/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMT: (data, id) => {
    const url = `/DanhMucTo/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMHTDT: (data, id) => {
    const url = `/DanhMucHinhThucDaoTao/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục
  PutDMTG: (data, id) => {
    const url = `/DanhMucTonGiao/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục
  PutDMTD: (data, id) => {
    const url = `/DanhMucTrinhDo/${id}`;
    return axiosClient.put(url, data);
  },
};

export default PutApi;
