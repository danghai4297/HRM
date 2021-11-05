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
  //Sửa danh mục khen thưởng và kỉ luật
  PutDMKTvKL: (data, id) => {
    const url = `/DanhMucKhenThuongKyLuat/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa trình độ văn hoá
  PutTDVH: (data,id) =>{
    const url =`/TrinhDoVanHoa/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa ngoại ngữ
  PutNN:(data,id) =>{
    const url =`/NgoaiNgu/${id}`;
    return axiosClient.put(url, data);
  },

  // Sửa người thân
  PutNT:(data,id)=>{
    const url =`/NguoiThan/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa ảnh nhân viên
  PutIMG:(data,id)=>{
    const url =`/NhanVien/image/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa hợp đồng
  PutHD:(data,id)=>{
    const url = `/HopDong/${id}`;
    return axiosClient.put(url,data)
  },
  // Sửa lương
  PutL:(data,id)=>{
    const url =`/luong/${id}`;
    return axiosClient.put(url,data)
  },
  // Sửa điều chuyển
  PutDC:(data,id)=>{
    const url =`/DieuChuyen/${id}`;
    return axiosClient.put(url,data)
  },
  // Sửa trạng thái lương
  PutTLL:(id) => {
    const url = `/Luong/trang-thai/${id}`;
    return axiosClient.put(url)
  },
  // Sửa trạng thái hợp đồng
  PutTLHD:(id) => {
    const url = `/HopDong/trang-thai/${id}`;
    return axiosClient.put(url)
  },
  // Sửa khen thưởng và kỷ luật
  PutKTvKL:(data,id)=>{
    const url =`/KhenThuongKyLuat/${id}`;
    return axiosClient.put(url,data)
  },
  //Sửa kỷ luật
  
};
export default PutApi;
