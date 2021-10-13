import axiosClient from "./axiosClient";

const PutApi = {
  //Sửa danh mục dân tộc
  PutDMDT: (data, id) => {
    const url = `/DanhMucDanToc/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục chức danh
  PutDMCD: (data, id) => {
    const url = `/DanhMucChucDanh/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục chức vụ
  PutDMCV: (data, id) => {
    const url = `/DanhMucChucVu/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục chuyên môn
  PutDMCM: (data, id) => {
    const url = `/DanhMucChuyenMon/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục hôn nhân
  PutDMHN: (data, id) => {
    const url = `/DanhMucHonNhan/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục loại hợp đồng
  PutDMLHD: (data, id) => {
    const url = `/DanhMucLoaiHopDong/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục ngạch công chức
  PutDMNCC: (data, id) => {
    const url = `/DanhMucNgachCongChuc/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục ngoại ngữ
  PutDMNN: (data, id) => {
    const url = `/DanhMucNgoaiNgu/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục người thân
  PutDMNT: (data, id) => {
    const url = `/DanhMucNguoiThan/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục nhóm lương
  PutDMNL: (data, id) => {
    const url = `/DanhMucNhomLuong/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục phòng ban
  PutDMPB: (data, id) => {
    const url = `/DanhMucPhongBan/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục tính chất lao động
  PutDMTCLD: (data, id) => {
    const url = `/DanhMucTinhChatLaoDong/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục tổ
  PutDMT: (data, id) => {
    const url = `/DanhMucTo/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục hình thức đào tạo
  PutDMHTDT: (data, id) => {
    const url = `/DanhMucHinhThucDaoTao/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục tôn giáo
  PutDMTG: (data, id) => {
    const url = `/DanhMucTonGiao/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục trình độ
  PutDMTD: (data, id) => {
    const url = `/DanhMucTrinhDo/${id}`;
    return axiosClient.put(url, data);
  },
};

export default PutApi;
