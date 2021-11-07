import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {
  //tất cả nhân viên
  getAllNv: () => {
    const url = "/NhanVien";
    return axiosClient.get(url);
  },

  //tất cả nhân viên mã tên
  getAllNvMT: () => {
    const url = "/NhanVien/ma-ten";
    return axiosClient.get(url);
  },

  //tất cả nhân viên nghi viec
  getAllNvnv: () => {
    const url = "/NhanVien/nghiviec";
    return axiosClient.get(url);
  },

  //thêm nhân viên
  postNv: (data) => {
    const url = "/NhanVien";
    return axiosClient.post(url, data);
  },
  postFile: (data) => {
    const url = "/Anh";
    return axiosClient.post(url, data);
  },
  //detail nhân viên
  getNvDetail: (maNv) => {
    const url = `/NhanVien/${maNv}`;
    return axiosClient.get(url);
  },
  // add trình độ văn hoá
  PostTDVH: (data) => {
    const url = "/TrinhDoVanHoa";
    return axiosClient.post(url, data);
  },
  //detail trình độ văn hóa
  getTDDetail: (id) => {
    const url = `/TrinhDoVanHoa/${id}`;
    return axiosClient.get(url);
  },
  //add ngoại ngữ
  PostNN: (data) => {
    const url = "/NgoaiNgu";
    return axiosClient.post(url, data);
  },
  //detail ngoại ngữ
  getNNDetail: (id) => {
    const url = `/NgoaiNgu/${id}`;
    return axiosClient.get(url);
  },
  //thêm người thân
  postNT: (data) => {
    const url = `/NguoiThan`;
    return axiosClient.post(url, data);
  },
  //detail người thân
  getNTDetail: (id) => {
    const url = `/NguoiThan/${id}`;
    return axiosClient.get(url);
  },
  // Thêm hợp đồng
  postHD: (data) => {
    const url = "/HopDong";
    return axiosClient.post(url, data);
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
  // Add lương
  PostL: (data) => {
    const url = "/Luong";
    return axiosClient.post(url, data);
  },
  //all khen thưởng nv
  getAllKTNV: () => {
    const url = "/KhenThuongKyLuat/khen-thuong";
    return axiosClient.get(url);
  },
  //add khen thưởng và kỷ luật
  PostKTvKL: (data) => {
    const url = "/KhenThuongKyLuat";
    return axiosClient.post(url, data);
  },
  //detail kt
  // getKTDetail: (id) => {
  //   const url = `/KhenThuongKyLuat/khen-thuong/${id}`;
  //   return axiosClient.get(url);
  // },

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
  //add điều chuyển
  PostDC: (data) => {
    const url = "/DieuChuyen";
    return axiosClient.post(url, data);
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

  //add danh mục chức danh
  PostDMCD: (data) => {
    const url = "/DanhMucChucDanh";
    return axiosClient.post(url, data);
  },

  //add danh mục chức vụ
  PostDMCV: (data) => {
    const url = "/DanhMucChucVu";
    return axiosClient.post(url, data);
  },
  //add danh mục chuyên môn
  PostDMCM: (data) => {
    const url = "/DanhMucChuyenMon";
    return axiosClient.post(url, data);
  },
  //add danh mục hôn nhân
  PostDMHN: (data) => {
    const url = "/DanhMucHonNhan";
    return axiosClient.post(url, data);
  },
  //add danh mục loại hợp đồng
  PostDMLHD: (data) => {
    const url = "/DanhMucLoaiHopDong";
    return axiosClient.post(url, data);
  },
  //add danh mục ngạch công chức
  PostDMNCC: (data) => {
    const url = "/DanhMucNgachCongChuc";
    return axiosClient.post(url, data);
  },
  //add danh mục ngoại ngữ
  PostDMNN: (data) => {
    const url = "/DanhMucNgoaiNgu";
    return axiosClient.post(url, data);
  },
  //add danh mục người thân
  PostDMNT: (data) => {
    const url = "/DanhMucNguoiThan";
    return axiosClient.post(url, data);
  },
  //add danh mục nhóm lương
  PostDMNL: (data) => {
    const url = "/DanhMucNhomLuong";
    return axiosClient.post(url, data);
  },
  //add danh mục khen thưởng và kỉ luật
  PostDMKTvKL: (data) => {
    const url = "/DanhMucKhenThuongKyLuat";
    return axiosClient.post(url, data);
  },
  //add danh mục phòng ban
  PostDMPB: (data) => {
    const url = "/DanhMucPhongBan";
    return axiosClient.post(url, data);
  },
  //add danh mục tính chất lao động
  PostDMTCLD: (data) => {
    const url = "/DanhMucTinhChatLaoDong";
    return axiosClient.post(url, data);
  },
  //add danh mục tổ
  PostDMT: (data) => {
    const url = "/DanhMucTo";
    return axiosClient.post(url, data);
  },

  //add danh mục hình thức đào tạo
  PostDMHTDT: (data) => {
    const url = "/DanhMucHinhThucDaoTao";
    return axiosClient.post(url, data);
  },

  //add danh mục tôn giáo
  PostDMTG: (data) => {
    const url = "/DanhMucTonGiao";
    return axiosClient.post(url, data);
  },
  //add danh mục trình độ
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

  //Detail dm khen thưởng và kỷ luật
  getDetailDMKTvKL: (id) => {
    const url = `/DanhMucKhenThuongKyLuat/${id}`;
    return axiosClient.get(url);
  },

  // //Detail dm kỷ luật
  // getDetailDMKL: (id) => {
  //   const url = `/DanhMucKhenThuongKyLuat/ky-luat/${id}`;
  //   return axiosClient.get(url);
  // },

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

  //Detail dm hình thức đào tạo
  getDetailDMHTDT: (id) => {
    const url = `/DanhMucHinhThucDaoTao/${id}`;
    return axiosClient.get(url);
  },

  //all lịch sử
  getAllLS: () => {
    const url = "/LichSu";
    return axiosClient.get(url);
  },

  //thêm ls
  PostLS: (data) => {
    const url = "/LichSu";
    return axiosClient.post(url, data);
  },

  //all rp pb
  getRPPb: (id) => {
    const url = `/NhanVien/bao-cao-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //all rp pb hợp đồng
  getRPPbHd: (id, sdate, edate) => {
    const url = `/NhanVien/bao-cao-phong-ban-hop-dong/${id}/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //all rp pb hợp đồng giới tính
  getRPPbHdGt: (id, sdate, edate, gender) => {
    const url = `/NhanVien/bao-cao-phong-ban-hop-dong-gioi-tinh/${id}/${sdate}/${edate}/${gender}`;
    return axiosClient.get(url);
  },

  //all rp pb hợp đồng trạng thái
  getRPPbHdTt: (id, sdate, edate, status) => {
    const url = `/NhanVien/bao-cao-phong-ban-hop-dong-trang-thai/${id}/${sdate}/${edate}/${status}`;
    return axiosClient.get(url);
  },

  //rp pb giới tính
  getRPPbGt: (id, gender) => {
    const url = `/NhanVien/bao-cao-phong-ban-gioi-tinh/${id}/${gender}`;
    return axiosClient.get(url);
  },

  //rp pb trang thai
  getRPPbTt: (id, status) => {
    const url = `/NhanVien/bao-cao-phong-ban-trang-thai/${id}/${status}`;
    return axiosClient.get(url);
  },

  //rp pb gioi tinh trang thai
  getRPPbTtGt: (id, status, gender) => {
    const url = `/NhanVien/bao-cao-phong-ban-trang-thai-gioi-tinh/${id}/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày
  getRPHd: (sdate, edate) => {
    const url = `/NhanVien/bao-cao-hop-dong/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày giới tính
  getRPHdGt: (sdate, edate, gender) => {
    const url = `/NhanVien/bao-cao-hop-dong-gioi-tinh/${sdate}/${edate}/${gender}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày trang thai
  getRPHdTt: (sdate, edate, status) => {
    const url = `/NhanVien/bao-cao-hop-dong-trang-thai/${sdate}/${edate}/${status}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày trang thai gioi tinh
  getRPHdTtGt: (sdate, edate, status, gender) => {
    const url = `/NhanVien/bao-cao-hop-dong-trang-thai-gioi-tinh/${sdate}/${edate}/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv
  getRpAll: () => {
    const url = `/NhanVien/bao-cao`;
    return axiosClient.get(url);
  },

  //Rp all Nv giới tính
  getRpAllGt: (gender) => {
    const url = `/NhanVien/bao-cao-gioi-tinh/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv trang thai
  getRpAllTt: (status) => {
    const url = `/NhanVien/bao-cao-trang-thai/${status}`;
    return axiosClient.get(url);
  },

  //Rp all Nv trang thai giới tính
  getRpAllTtGt: (status, gender) => {
    const url = `/NhanVien/bao-cao-trang-thai-gioi-tinh/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv pb và hd giới tính trang thai
  getRpAllPbHdTtGt: (id, sdate, edate, status, gender) => {
    const url = `/NhanVien/bao-cao-phong-ban-hop-dong-trang-thai-gioi-tinh/${id}/${sdate}/${edate}/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv lên luong từ ngày --> ngày
  getRpAllLg: (sdate, edate) => {
    const url = `/NhanVien/bao-cao-len-luong/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //Rp all Nv lên luong phong ban từ ngày --> ngày
  getRpAllLgPb: (id, sdate, edate) => {
    const url = `/NhanVien/bao-cao-len-luong-phong-ban/${id}/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //Rp all Nv có sinh nhật trong tháng
  getRpAllSn: (mmoth) => {
    const url = `/NhanVien/bao-cao-sinh-nhat/${mmoth}`;
    return axiosClient.get(url);
  },

  //Rp all Nv có sinh nhật trong tháng theo PB
  getRpAllSnPb: (id, mmoth) => {
    const url = `/NhanVien/bao-cao-sinh-nhat-phong-ban/${id}/${mmoth}`;
    return axiosClient.get(url);
  },

  //Rp all con nhà chính sách
  getRpAllCncs: () => {
    const url = `/NhanVien/bao-cao-chinh-sach`;
    return axiosClient.get(url);
  },

  //Rp all con nhà chính sách theo PB
  getRpAllCncsPb: (id) => {
    const url = `/NhanVien/bao-cao-chinh-sach-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all BHXH
  getRpAllBhxh: () => {
    const url = `/NhanVien/bao-cao-bhxh`;
    return axiosClient.get(url);
  },

  //Rp all BHXH theo PB
  getRpAllBhxhPb: (id) => {
    const url = `/NhanVien/bao-cao-bhxh-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all đảng viên
  getRpAllDv: () => {
    const url = `/NhanVien/bao-cao-dang-vien`;
    return axiosClient.get(url);
  },

  //Rp all đảng viên Pb
  getRpAllDvPb: (id) => {
    const url = `/NhanVien/bao-cao-dang-vien-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all nhóm lương nv
  getRpAllNlg: () => {
    const url = `/NhanVien/bao-cao-nhom-luong`;
    return axiosClient.get(url);
  },

  //Rp all nhóm lương theo pb
  getRpAllNlgPb: (id) => {
    const url = `/NhanVien/bao-cao-nhom-luong-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all người thân nv
  getRpAllNtn: (ageX, ageY) => {
    const url = `/NhanVien/bao-cao-nguoi-than/${ageX}/${ageY}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo quan hệ
  getRpAllNtDm: (ageX, ageY, idDm) => {
    const url = `/NhanVien/bao-cao-nguoi-than-danh-muc/${ageX}/${ageY}/${idDm}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo phong ban
  getRpAllNtPb: (ageX, ageY, idPb) => {
    const url = `/NhanVien/bao-cao-nguoi-than-phong-ban/${ageX}/${ageY}/${idPb}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo nhan viên
  getRpAllNtNv: (ageX, ageY, idNv) => {
    const url = `/NhanVien/bao-cao-nguoi-than-nhan-vien/${ageX}/${ageY}/${idNv}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo gioi tính
  getRpAllNtGt: (ageX, ageY, gender) => {
    const url = `/NhanVien/bao-cao-nguoi-than-gioi-tinh/${ageX}/${ageY}/${gender}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo trạng thái
  getRpAllNtTt: (ageX, ageY, status) => {
    const url = `/NhanVien/bao-cao-nguoi-than-gioi-tinh/${ageX}/${ageY}/${status}`;
    return axiosClient.get(url);
  },
};

export default ProductApi;
