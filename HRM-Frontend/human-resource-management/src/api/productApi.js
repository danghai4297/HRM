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
  //detail kt
  getKTDetail: (id) => {
    const url = `/KhenThuongKyLuat/khen-thuong/${id}`;
    return axiosClient.get(url);
  },

  //detail khen thưởng và kỉ luật
  getKTvKLDetail: (id) => {
    const url = `/KhenThuongKyLuat/detail/${id}`;
    return axiosClient.get(url);
  },

  //all kỷ luật nv
  getAllKLNV: () => {
    const url = "/KhenThuongKyLuat/ky-luat";
    return axiosClient.get(url);
  },

  //all điều chuyển nv
  getAllDCNV: () => {
    const url = "/DieuChuyen";
    return axiosClient.get(url);
  },

  //detail DC
  getDCDetail: (id) => {
    const url = `/DieuChuyen/dieu-chuyen/${id}`;
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
  //all dm HTDT
  getAllDMHTDT: () => {
    const url = "/DanhMucHinhThucDaoTao";
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
  PostDMHTDT: (data) => {
    const url = "/DanhMucHinhThucDaoTao";
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

  //Detail dm chức danh
  getDetailDMCD: (id) => {
    const url = `/DanhMucChucDanh/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh muc chức vụ
  getDetailDMCV: (id) => {
    const url = `/DanhMucChucVu/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh muc chuyên môn
  getDetailDMCM: (id) => {
    const url = `/DanhMucChuyenMon/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh mục dân tộc
  getDetailDMDT: (id) => {
    const url = `/DanhMucDanToc/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm hôn nhân
  getDetailDMHN: (id) => {
    const url = `/DanhMucHonNhan/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm khen thưởng
  getDetailDMKT: (id) => {
    const url = `/DanhMucKhenThuongKyLuat/khen-thuong/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm kỷ luật
  getDetailDMKL: (id) => {
    const url = `/DanhMucKhenThuongKyLuat/ky-luat/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm loại hợp đồng
  getDetailDMLHD: (id) => {
    const url = `/DanhMucLoaiHopDong/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm ngạch công chức
  getDetailDMNCC: (id) => {
    const url = `/DanhMucNgachCongChuc/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm ngoại ngữ
  getDetailDMNN: (id) => {
    const url = `/DanhMucNgoaiNgu/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm người thân
  getDetailDMNT: (id) => {
    const url = `/DanhMucNguoiThan/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm nhóm lương
  getDetailDMNL: (id) => {
    const url = `/DanhMucNhomLuong/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm phòng ban
  getDetailDMPB: (id) => {
    const url = `/DanhMucPhongBan/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm tính chất lao động
  getDetailDMTCLD: (id) => {
    const url = `/DanhMucTinhChatLaoDong/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh mục tổ
  getDetailDMT: (id) => {
    const url = `/DanhMucTo/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh mục tôn giáo
  getDetailDMTG: (id) => {
    const url = `/DanhMucTonGiao/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm trình độ
  getDetailDMTD: (id) => {
    const url = `/DanhMucTrinhDo/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm trình độ
  getDetailDMHTDT: (id) => {
    const url = `/DanhMucHinhThucDaoTao/${id}`;
    return axiosClient.get(url);
  },
};

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

  //delete dm khen thưởng
  deleteDMKT: (id) => {
    const url = `/DanhMucKhenThuongKyLuat/khen-thuong/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm kỷ luật
  deleteDMKL: (id) => {
    const url = `/DanhMucKhenThuongKyLuat/ky-luat/${id}`;
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

  //delete dm trình độ
  deleteDMHTDT: (id) => {
    const url = `/DanhMucHinhThucDaoTao/${id}`;
    return axiosClient.delete(url);
  },
};
export default ProductApi;
