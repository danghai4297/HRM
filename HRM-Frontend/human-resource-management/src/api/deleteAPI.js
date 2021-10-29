import axiosClient from "./axiosClient";
const DeleteApi = {
  //delete dm chức danh
  deleteDMCD: (id) => {
    const url = `/DanhMucChucDanh/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh muc chức vụ
  deleteDMCV: (id) => {
    const url = `/DanhMucChucVu/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh muc chuyên môn
  deleteDMCM: (id) => {
    const url = `/DanhMucChuyenMon/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh mục dân tộc
  deleteDMDT: (id) => {
    const url = `/DanhMucDanToc/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm hôn nhân
  deleteDMHN: (id) => {
    const url = `/DanhMucHonNhan/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm khen thưởng và kỉ luật
  deleteDMKTvKL: (id) => {
    const url = `/DanhMucKhenThuongKyLuat/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm loại hợp đồng
  deleteDMLHD: (id) => {
    const url = `/DanhMucLoaiHopDong/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm ngạch công chức
  deleteDMNCC: (id) => {
    const url = `/DanhMucNgachCongChuc/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm ngoại ngữ
  deleteDMNN: (id) => {
    const url = `/DanhMucNgoaiNgu/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm người thân
  deleteDMNT: (id) => {
    const url = `/DanhMucNguoiThan/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm nhóm lương
  deleteDMNL: (id) => {
    const url = `/DanhMucNhomLuong/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm phòng ban
  deleteDMPB: (id) => {
    const url = `/DanhMucPhongBan/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm tính chất lao động
  deleteDMTCLD: (id) => {
    const url = `/DanhMucTinhChatLaoDong/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh mục tổ
  deleteDMT: (id) => {
    const url = `/DanhMucTo/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh mục tôn giáo
  deleteDMTG: (id) => {
    const url = `/DanhMucTonGiao/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm trình độ
  deleteDMTD: (id) => {
    const url = `/DanhMucTrinhDo/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm hình thức đào tạo
  deleteDMHTDT: (id) => {
    const url = `/DanhMucHinhThucDaoTao/${id}`;
    return axiosClient.delete(url);
  },
  // delete trình độ văn hoá
  deleteTDVH: (id) =>{
    const url = `/TrinhDoVanHoa/${id}`;
    return axiosClient.delete(url);
  },
  // delete ngoại ngữ
  deleteNN:(id) =>{
    const url = `/NgoaiNgu/${id}`;
    return axiosClient.delete(url);
  },
  // delete người thân
  deleteNT:(id) =>{
    const url = `/NguoiThan/${id}`;
    return axiosClient.delete(url);
  },
  //delete hợp đồng
  deleteHD:(id)=>{
    const url = `/HopDong/${id}`;
    return axiosClient.delete(url);
  }
};

export default DeleteApi;
