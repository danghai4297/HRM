import axiosClient from "./axiosClient";

// api/productApi.js
const ProductApi = {
  //tất cả nhân viên
  getAllNv: () => {
    const url = "/Employee";
    return axiosClient.get(url);
  },

  //tất cả nhân viên mã tên
  getAllNvMT: () => {
    const url = "/Employee/ma-ten";
    return axiosClient.get(url);
  },

  //tất cả nhân viên nghi viec
  getAllNvnv: () => {
    const url = "/Employee/nghiviec";
    return axiosClient.get(url);
  },

  //thêm nhân viên
  postNv: (data) => {
    const url = "/Employee";
    return axiosClient.post(url, data);
  },
  postFile: (data) => {
    const url = "/Anh";
    return axiosClient.post(url, data);
  },
  //detail nhân viên
  getNvDetail: (maNv) => {
    const url = `/Employee/${maNv}`;
    return axiosClient.get(url);
  },
  // add trình độ văn hoá
  PostTDVH: (data) => {
    const url = "/EducationLevel";
    return axiosClient.post(url, data);
  },
  //detail trình độ văn hóa
  getTDDetail: (id) => {
    const url = `/EducationLevel/${id}`;
    return axiosClient.get(url);
  },
  //add ngoại ngữ
  PostNN: (data) => {
    const url = "/Language";
    return axiosClient.post(url, data);
  },
  //detail ngoại ngữ
  getNNDetail: (id) => {
    const url = `/Language/${id}`;
    return axiosClient.get(url);
  },
  //thêm người thân
  postNT: (data) => {
    const url = `/FamilyRelationship`;
    return axiosClient.post(url, data);
  },
  //detail người thân
  getNTDetail: (id) => {
    const url = `/FamilyRelationship/${id}`;
    return axiosClient.get(url);
  },
  // Thêm hợp đồng
  postHD: (data) => {
    const url = "/LaborContract";
    return axiosClient.post(url, data);
  },
  //tất cả hợp đồng
  getAllHd: () => {
    const url = "/LaborContract";
    return axiosClient.get(url);
  },

  //detail hợp đồng
  getHdDetail: (maHd) => {
    const url = `/LaborContract/detail/${maHd}`;
    return axiosClient.get(url);
  },

  //All danh sách lương nv
  getAllL: () => {
    const url = "/Salary";
    return axiosClient.get(url);
  },

  //Detail lương
  getLDetail: (id) => {
    const url = `/Salary/${id}`;
    return axiosClient.get(url);
  },
  // Add lương
  PostL: (data) => {
    const url = "/Salary";
    return axiosClient.post(url, data);
  },
  //all khen thưởng nv
  getAllKTNV: () => {
    const url = "/RewardDiscipline/khen-thuong";
    return axiosClient.get(url);
  },
  //add khen thưởng và kỷ luật
  PostKTvKL: (data) => {
    const url = "/RewardDiscipline";
    return axiosClient.post(url, data);
  },
  //detail kt
  // getKTDetail: (id) => {
  //   const url = `/RewardDiscipline/khen-thuong/${id}`;
  //   return axiosClient.get(url);
  // },

  //detail khen thưởng và kỉ luật
  getKTvKLDetail: (id) => {
    const url = `/RewardDiscipline/detail/${id}`;
    return axiosClient.get(url);
  },

  //all kỷ luật nv
  getAllKLNV: () => {
    const url = "/RewardDiscipline/ky-luat";
    return axiosClient.get(url);
  },

  //all điều chuyển nv
  getAllDCNV: () => {
    const url = "/WorkingProcess";
    return axiosClient.get(url);
  },
  //add điều chuyển
  PostDC: (data) => {
    const url = "/WorkingProcess";
    return axiosClient.post(url, data);
  },
  //detail DC
  getDCDetail: (id) => {
    const url = `/WorkingProcess/qua-trinh-cong-tac/${id}`;
    return axiosClient.get(url);
  },

  //tất cả dm chức danh
  getAllDMCD: () => {
    const url = "/TitleCategory";
    return axiosClient.get(url);
  },

  //tất cả danh muc chức vụ
  getAllDMCV: () => {
    const url = "/PositionCategory";
    return axiosClient.get(url);
  },

  //tất cả danh muc chuyên môn
  getAllDMCM: () => {
    const url = "/SpecializeCategory";
    return axiosClient.get(url);
  },

  //all danh mục dân tộc
  getAllDMDT: () => {
    const url = "/NationCategory";
    return axiosClient.get(url);
  },

  //all dm hôn nhân
  getAllDMHN: () => {
    const url = "/MarriageCategory";
    return axiosClient.get(url);
  },
  //all dm HTDT
  getAllDMHTDT: () => {
    const url = "/EducateCategory";
    return axiosClient.get(url);
  },

  //all dm khen thưởng
  getAllDMKT: () => {
    const url = "/RewardDiscipLineCategory/khen-thuong";
    return axiosClient.get(url);
  },

  //all dm kỷ luật
  getAllDMKL: () => {
    const url = "/RewardDiscipLineCategory/ky-luat";
    return axiosClient.get(url);
  },

  //all dm loại hợp đồng
  getAllDMLHD: () => {
    const url = "/TypeOfContractCategory";
    return axiosClient.get(url);
  },

  //all dm ngạch công chức
  getAllDMNCC: () => {
    const url = "/CSRCategory";
    return axiosClient.get(url);
  },

  //all dm ngoại ngữ
  getAllDMNN: () => {
    const url = "/LanguageCategory";
    return axiosClient.get(url);
  },

  //all dm người thân
  getAllDMNT: () => {
    const url = "/RelationCategory";
    return axiosClient.get(url);
  },

  //all dm nhóm lương
  getAllDMNL: () => {
    const url = "/SalaryGroupCategory";
    return axiosClient.get(url);
  },

  //all dm phòng ban
  getAllDMPB: () => {
    const url = "/DepartmentCategory";
    return axiosClient.get(url);
  },

  //all dm tính chất lao động
  getAllDMTCLD: () => {
    const url = "/LaborCategory";
    return axiosClient.get(url);
  },

  //all danh mục tổ
  getAllDMT: () => {
    const url = "/NestCategory";
    return axiosClient.get(url);
  },

  //all danh mục tôn giáo
  getAllDMTG: () => {
    const url = "/ReligionCategory";
    return axiosClient.get(url);
  },

  //all dm trình độ
  getAllDMTD: () => {
    const url = "/LevelCategory";
    return axiosClient.get(url);
  },

  //add danh mục dân tộc
  PostDMDT: (data) => {
    const url = "/NationCategory";
    return axiosClient.post(url, data);
  },

  //add danh mục chức danh
  PostDMCD: (data) => {
    const url = "/TitleCategory";
    return axiosClient.post(url, data);
  },

  //add danh mục chức vụ
  PostDMCV: (data) => {
    const url = "/PositionCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục chuyên môn
  PostDMCM: (data) => {
    const url = "/SpecializeCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục hôn nhân
  PostDMHN: (data) => {
    const url = "/MarriageCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục loại hợp đồng
  PostDMLHD: (data) => {
    const url = "/TypeOfContractCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục ngạch công chức
  PostDMNCC: (data) => {
    const url = "/CSRCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục ngoại ngữ
  PostDMNN: (data) => {
    const url = "/LanguageCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục người thân
  PostDMNT: (data) => {
    const url = "/RelationCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục nhóm lương
  PostDMNL: (data) => {
    const url = "/SalaryGroupCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục khen thưởng và kỉ luật
  PostDMKTvKL: (data) => {
    const url = "/RewardDiscipLineCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục phòng ban
  PostDMPB: (data) => {
    const url = "/DepartmentCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục tính chất lao động
  PostDMTCLD: (data) => {
    const url = "/LaborCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục tổ
  PostDMT: (data) => {
    const url = "/NestCategory";
    return axiosClient.post(url, data);
  },

  //add danh mục hình thức đào tạo
  PostDMHTDT: (data) => {
    const url = "/EducateCategory";
    return axiosClient.post(url, data);
  },

  //add danh mục tôn giáo
  PostDMTG: (data) => {
    const url = "/ReligionCategory";
    return axiosClient.post(url, data);
  },
  //add danh mục trình độ
  PostDMTD: (data) => {
    const url = "/LevelCategory";
    return axiosClient.post(url, data);
  },

  //Detail dm chức danh
  getDetailDMCD: (id) => {
    const url = `/TitleCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh muc chức vụ
  getDetailDMCV: (id) => {
    const url = `/PositionCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh muc chuyên môn
  getDetailDMCM: (id) => {
    const url = `/SpecializeCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh mục dân tộc
  getDetailDMDT: (id) => {
    const url = `/NationCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm hôn nhân
  getDetailDMHN: (id) => {
    const url = `/MarriageCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm khen thưởng và kỷ luật
  getDetailDMKTvKL: (id) => {
    const url = `/RewardDiscipLineCategory/${id}`;
    return axiosClient.get(url);
  },

  // //Detail dm kỷ luật
  // getDetailDMKL: (id) => {
  //   const url = `/RewardDiscipLineCategory/ky-luat/${id}`;
  //   return axiosClient.get(url);
  // },

  //Detail dm loại hợp đồng
  getDetailDMLHD: (id) => {
    const url = `/TypeOfContractCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm ngạch công chức
  getDetailDMNCC: (id) => {
    const url = `/CSRCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm ngoại ngữ
  getDetailDMNN: (id) => {
    const url = `/LanguageCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm người thân
  getDetailDMNT: (id) => {
    const url = `/RelationCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm nhóm lương
  getDetailDMNL: (id) => {
    const url = `/SalaryGroupCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm phòng ban
  getDetailDMPB: (id) => {
    const url = `/DepartmentCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm tính chất lao động
  getDetailDMTCLD: (id) => {
    const url = `/LaborCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh mục tổ
  getDetailDMT: (id) => {
    const url = `/NestCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail danh mục tôn giáo
  getDetailDMTG: (id) => {
    const url = `/ReligionCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm trình độ
  getDetailDMTD: (id) => {
    const url = `/LevelCategory/${id}`;
    return axiosClient.get(url);
  },

  //Detail dm hình thức đào tạo
  getDetailDMHTDT: (id) => {
    const url = `/EducateCategory/${id}`;
    return axiosClient.get(url);
  },

  //all lịch sử
  getAllLS: () => {
    const url = "/History";
    return axiosClient.get(url);
  },

  //thêm ls
  PostLS: (data) => {
    const url = "/History";
    return axiosClient.post(url, data);
  },

  //all rp pb
  getRPPb: (id) => {
    const url = `/Report/bao-cao-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //all rp pb hợp đồng
  getRPPbHd: (id, sdate, edate) => {
    const url = `/Report/bao-cao-phong-ban-hop-dong/${id}/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //all rp pb hợp đồng giới tính
  getRPPbHdGt: (id, sdate, edate, gender) => {
    const url = `/Report/bao-cao-phong-ban-hop-dong-gioi-tinh/${id}/${sdate}/${edate}/${gender}`;
    return axiosClient.get(url);
  },

  //all rp pb hợp đồng trạng thái
  getRPPbHdTt: (id, sdate, edate, status) => {
    const url = `/Report/bao-cao-phong-ban-hop-dong-trang-thai/${id}/${sdate}/${edate}/${status}`;
    return axiosClient.get(url);
  },

  //rp pb giới tính
  getRPPbGt: (id, gender) => {
    const url = `/Report/bao-cao-phong-ban-gioi-tinh/${id}/${gender}`;
    return axiosClient.get(url);
  },

  //rp pb trang thai
  getRPPbTt: (id, status) => {
    const url = `/Report/bao-cao-phong-ban-trang-thai/${id}/${status}`;
    return axiosClient.get(url);
  },

  //rp pb gioi tinh trang thai
  getRPPbTtGt: (id, status, gender) => {
    const url = `/Report/bao-cao-phong-ban-trang-thai-gioi-tinh/${id}/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày
  getRPHd: (sdate, edate) => {
    const url = `/Report/bao-cao-hop-dong/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày giới tính
  getRPHdGt: (sdate, edate, gender) => {
    const url = `/Report/bao-cao-hop-dong-gioi-tinh/${sdate}/${edate}/${gender}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày trang thai
  getRPHdTt: (sdate, edate, status) => {
    const url = `/Report/bao-cao-hop-dong-trang-thai/${sdate}/${edate}/${status}`;
    return axiosClient.get(url);
  },

  //all rp hp từ ngày đến ngày trang thai gioi tinh
  getRPHdTtGt: (sdate, edate, status, gender) => {
    const url = `/Report/bao-cao-hop-dong-trang-thai-gioi-tinh/${sdate}/${edate}/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv
  getRpAll: () => {
    const url = `/Report/bao-cao`;
    return axiosClient.get(url);
  },

  //Rp all Nv giới tính
  getRpAllGt: (gender) => {
    const url = `/Report/bao-cao-gioi-tinh/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv trang thai
  getRpAllTt: (status) => {
    const url = `/Report/bao-cao-trang-thai/${status}`;
    return axiosClient.get(url);
  },

  //Rp all Nv trang thai giới tính
  getRpAllTtGt: (status, gender) => {
    const url = `/Report/bao-cao-trang-thai-gioi-tinh/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv pb và hd giới tính trang thai
  getRpAllPbHdTtGt: (id, sdate, edate, status, gender) => {
    const url = `/Report/bao-cao-phong-ban-hop-dong-trang-thai-gioi-tinh/${id}/${sdate}/${edate}/${status}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all Nv lên luong từ ngày --> ngày
  getRpAllLg: (sdate, edate) => {
    const url = `/Report/bao-cao-len-luong/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //Rp all Nv lên luong phong ban từ ngày --> ngày
  getRpAllLgPb: (id, sdate, edate) => {
    const url = `/Report/bao-cao-len-luong-phong-ban/${id}/${sdate}/${edate}`;
    return axiosClient.get(url);
  },

  //Rp all Nv có sinh nhật trong tháng
  getRpAllSn: (mmoth) => {
    const url = `/Report/bao-cao-sinh-nhat/${mmoth}`;
    return axiosClient.get(url);
  },

  //Rp all Nv có sinh nhật trong tháng theo PB
  getRpAllSnPb: (id, mmoth) => {
    const url = `/Report/bao-cao-sinh-nhat-phong-ban/${id}/${mmoth}`;
    return axiosClient.get(url);
  },

  //Rp all con nhà chính sách
  getRpAllCncs: () => {
    const url = `/Report/bao-cao-chinh-sach`;
    return axiosClient.get(url);
  },

  //Rp all con nhà chính sách theo PB
  getRpAllCncsPb: (id) => {
    const url = `/Report/bao-cao-chinh-sach-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all BHXH
  getRpAllBhxh: () => {
    const url = `/Report/bao-cao-bhxh`;
    return axiosClient.get(url);
  },

  //Rp all BHXH theo PB
  getRpAllBhxhPb: (id) => {
    const url = `/Report/bao-cao-bhxh-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all đảng viên
  getRpAllDv: () => {
    const url = `/Report/bao-cao-dang-vien`;
    return axiosClient.get(url);
  },

  //Rp all đảng viên Pb
  getRpAllDvPb: (id) => {
    const url = `/Report/bao-cao-dang-vien-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all nhóm lương nv
  getRpAllNlg: () => {
    const url = `/Report/bao-cao-nhom-luong`;
    return axiosClient.get(url);
  },

  //Rp all nhóm lương theo pb
  getRpAllNlgPb: (id) => {
    const url = `/Report/bao-cao-nhom-luong-phong-ban/${id}`;
    return axiosClient.get(url);
  },

  //Rp all người thân nv
  getRpAllNtn: (ageX, ageY) => {
    const url = `/Report/bao-cao-nguoi-than/${ageX}/${ageY}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo quan hệ
  getRpAllNtDm: (ageX, ageY, idDm) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc/${ageX}/${ageY}/${idDm}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo phong ban
  getRpAllNtPb: (ageX, ageY, idPb) => {
    const url = `/Report/bao-cao-nguoi-than-phong-ban/${ageX}/${ageY}/${idPb}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo nhan viên
  getRpAllNtNv: (ageX, ageY, idNv) => {
    const url = `/Report/bao-cao-nguoi-than-nhan-vien/${ageX}/${ageY}/${idNv}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo gioi tính
  getRpAllNtGt: (ageX, ageY, gender) => {
    const url = `/Report/bao-cao-nguoi-than-gioi-tinh/${ageX}/${ageY}/${gender}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo trạng thái
  getRpAllNtTt: (ageX, ageY, status) => {
    const url = `/Report/bao-cao-nguoi-than-trang-thai/${ageX}/${ageY}/${status}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo danh mục phòng ban
  getRpAllNtDmPb: (ageX, ageY, idDm, idPb) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-phong-ban/${ageX}/${ageY}/${idDm}/${idPb}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo danh mục mã nhân viên
  getRpAllNtDmNv: (ageX, ageY, idDm, idNv) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-nhan-vien/${ageX}/${ageY}/${idDm}/${idNv}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo danh mục giới tính
  getRpAllNtDmGt: (ageX, ageY, idDm, gender) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-gioi-tinh/${ageX}/${ageY}/${idDm}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo danh mục trang thai
  getRpAllNtDmTt: (ageX, ageY, idDm, status) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-trang-thai/${ageX}/${ageY}/${idDm}/${status}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo phòng ban nhân viên
  getRpAllNtPbNv: (ageX, ageY, idPb, idNv) => {
    const url = `/Report/bao-cao-nguoi-than-phong-ban-nhan-vien/${ageX}/${ageY}/${idPb}/${idNv}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo phòng ban giới tính
  getRpAllNtPbGt: (ageX, ageY, idPb, gender) => {
    const url = `/Report/bao-cao-nguoi-than-phong-ban-gioi-tinh/${ageX}/${ageY}/${idPb}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo phòng ban trạng thái
  getRpAllNtPbTt: (ageX, ageY, idPb, status) => {
    const url = `/Report/bao-cao-nguoi-than-phong-ban-trang-thai/${ageX}/${ageY}/${idPb}/${status}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo nhân viên giới tính
  getRpAllNtNvGt: (ageX, ageY, idNv, gender) => {
    const url = `/Report/bao-cao-nguoi-than-nhan-vien-gioi-tinh/${ageX}/${ageY}/${idNv}/${gender}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo nhân viên trang thai
  getRpAllNtNvTt: (ageX, ageY, idNv, status) => {
    const url = `/Report/bao-cao-nguoi-than-nhan-vien-trang-thai/${ageX}/${ageY}/${idNv}/${status}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo giới tính trang thai
  getRpAllNtGtTt: (ageX, ageY, gender, status) => {
    const url = `/Report/bao-cao-nguoi-than-gioi-tinh-trang-thai/${ageX}/${ageY}/${gender}/${status}`;
    return axiosClient.get(url);
  },

  //Rp all người thân theo danh mục phòng ban nhân viên
  getRpAllNtDmPbNv: (ageX, ageY, idDm, idPb, idNv) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-phong-ban-nhan-vien/${ageX}/${ageY}/${idDm}/${idPb}/${idNv}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo danh mục phòng ban giới tính
  getRpAllNtDmPbGt: (ageX, ageY, idDm, idPb, gender) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-phong-ban-gioi-tinh/${ageX}/${ageY}/${idDm}/${idPb}/${gender}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo danh mục phòng ban trạng thái
  getRpAllNtDmPbTt: (ageX, ageY, idDm, idPb, status) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-phong-ban-trang-thai/${ageX}/${ageY}/${idDm}/${idPb}/${status}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo danh mục nhân viên trạng thái
  getRpAllNtDmNvTt: (ageX, ageY, idDm, idNv, status) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-nhan-vien-trang-thai/${ageX}/${ageY}/${idDm}/${idNv}/${status}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo phòng ban nhân viên giới tính
  getRpAllNtPbNvGt: (ageX, ageY, idPb, idNv, gender) => {
    const url = `/Report/bao-cao-nguoi-than-phong-ban-nhan-vien-gioi-tinh/${ageX}/${ageY}/${idPb}/${idNv}/${gender}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo phòng ban giới tính trạng thái
  getRpAllNtPbGtTt: (ageX, ageY, idPb, gender, status) => {
    const url = `/Report/bao-cao-nguoi-than-phong-ban-gioi-tinh-trang-thai/${ageX}/${ageY}/${idPb}/${gender}/${status}`;
    return axiosClient.get(url);
  },
  //Rp all người thân theo danh mục phòng ban giới tính trạng thái
  getRpAllNtDmPbGtTt: (ageX, ageY, idDm, idPb, gender, status) => {
    const url = `/Report/bao-cao-nguoi-than-danh-muc-phong-ban-gioi-tinh-trang-thai/${ageX}/${ageY}/${idDm}/${idPb}/${gender}/${status}`;
    return axiosClient.get(url);
  },
  //Rp hồ sơ lương
  getRpHSL: (id) => {
    const url = `/Report/bao-cao-luong/${id}`;
    return axiosClient.get(url);
  },
  //get all nhân viên phòng nhân sự
  getAllNS: () => {
    const url = `/Employee/ma-ten-account`;
    return axiosClient.get(url);
  },
};

export default ProductApi;
