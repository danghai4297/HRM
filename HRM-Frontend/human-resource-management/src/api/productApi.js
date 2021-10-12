import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {
  //tất cả nhân viên
  getAllNv: () => {
    const url = "/NhanVien";
    return axiosClient.get(url);
  },

  //thêm nhân viên
  postNv: (data) => {
    const url = "/NhanVien";
    return axiosClient.post(url, data);
  },

  //detail nhân viên
  getNvDetail: (maNv) => {
    const url = `/NhanVien/${maNv}`;
    return axiosClient.get(url);
  },

  //tất cả hợp đồng
  getAllHd: () => {
    const url = "/HopDong";
    return axiosClient.get(url);
  },

  //detail hợp đồng
  getHdDetail: (maHd) => {
    const url = `/HopDong/detail/${maHd}`;
    return axiosClient.get(url);
  },

  //All danh sách lương nv
  getAllL: () => {
    const url = "/Luong";
    return axiosClient.get(url);
  },

  //Detail lương
  getLDetail: (id) => {
    const url = `/Luong/${id}`;
    return axiosClient.get(url);
  },

  //all khen thưởng nv
  getAllKTNV: () => {
    const url = "/KhenThuongKyLuat/khen-thuong";
    return axiosClient.get(url);
  },

  //all kỷ luật nv
  getAllKLNV: () => {
    const url = "/KhenThuongKyLuat/ky-luat";
    return axiosClient.get(url);
  },

  //detail kl
  getKLDetail: (id) => {
    const url = `/KhenThuongKyLuat/ky-luat/${id}`;
    return axiosClient.get(url);
  },

  //tất cả dm chức danh
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

  //all danh mục dân tộc
  getAllDMDT: () => {
    const url = "/DanhMucDanToc";
    return axiosClient.get(url);
  },

  

  //all dm hôn nhân
  getAllDMHN: () => {
    const url = "/DanhMucHonNhan";
    return axiosClient.get(url);
  },

  //all dm khen thưởng
  getAllDMKT: () => {
    const url = "/DanhMucKhenThuongKyLuat/khen-thuong";
    return axiosClient.get(url);
  },

  //all dm kỷ luật
  getAllDMKL: () => {
    const url = "/DanhMucKhenThuongKyLuat/ky-luat";
    return axiosClient.get(url);
  },

  //all dm loại hợp đồng
  getAllDMLHD: () => {
    const url = "/DanhMucLoaiHopDong";
    return axiosClient.get(url);
  },

  //all dm ngạch công chức
  getAllDMNCC: () => {
    const url = "/DanhMucNgachCongChuc";
    return axiosClient.get(url);
  },

  //all dm ngoại ngữ
  getAllDMNN: () => {
    const url = "/DanhMucNgoaiNgu";
    return axiosClient.get(url);
  },

  //all dm người thân
  getAllDMNT: () => {
    const url = "/DanhMucNguoiThan";
    return axiosClient.get(url);
  },

  //all dm nhóm lương
  getAllDMNL: () => {
    const url = "/DanhMucNhomLuong";
    return axiosClient.get(url);
  },

  //all dm phòng ban
  getAllDMPB: () => {
    const url = "/DanhMucPhongBan";
    return axiosClient.get(url);
  },

  //all dm tính chất lao động
  getAllDMTCLD: () => {
    const url = "/DanhMucTinhChatLaoDong";
    return axiosClient.get(url);
  },

  //all danh mục tổ
  getAllDMT: () => {
    const url = "/DanhMucTo";
    return axiosClient.get(url);
  },

  //all danh mục tôn giáo
  getAllDMTG: () => {
    const url = "/DanhMucTonGiao";
    return axiosClient.get(url);
  },

  //all dm trình độ
  getAllDMTD: () => {
    const url = "/DanhMucTrinhDo";
    return axiosClient.get(url);
  },

  //add danh mục dân tộc
  PostDMDT: (data) => {
    const url = "/DanhMucDanToc";
    return axiosClient.post(url, data);
  },

   //add danh mục 
   PostDMCD: (data) => {
    const url = "/DanhMucChucDanh";
    return axiosClient.post(url, data);
  },

   //add danh mục 
   PostDMCV: (data) => {
    const url = "/DanhMucChucVu";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMCM: (data) => {
    const url = "/DanhMucChuyenMon";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMHN: (data) => {
    const url = "/DanhMucHonNhan";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMLHD: (data) => {
    const url = "/DanhMucLoaiHopDong";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMNCC: (data) => {
    const url = "/DanhMucNgachCongChuc";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMNN: (data) => {
    const url = "/DanhMucNgoaiNgu";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMNT: (data) => {
    const url = "/DanhMucNguoiThan";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMNL: (data) => {
    const url = "/DanhMucNhomLuong";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMPB: (data) => {
    const url = "/DanhMucPhongBan";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMTCLD: (data) => {
    const url = "/DanhMucTinhChatLaoDong";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMT: (data) => {
    const url = "/DanhMucTo";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMTG: (data) => {
    const url = "/DanhMucTonGiao";
    return axiosClient.post(url, data);
  },
   //add danh mục 
   PostDMTD: (data) => {
    const url = "/DanhMucTrinhDo";
    return axiosClient.post(url, data);
  },

  

};

export default ProductApi;
