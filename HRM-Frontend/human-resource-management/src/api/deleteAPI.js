import axiosClient from "./axiosClient";
const DeleteApi = {
  //delete dm chức danh
  deleteDMCD: (id) => {
    const url = `/TitleCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh muc chức vụ
  deleteDMCV: (id) => {
    const url = `/PositionCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh muc chuyên môn
  deleteDMCM: (id) => {
    const url = `/SpecializeCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh mục dân tộc
  deleteDMDT: (id) => {
    const url = `/NationCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm hôn nhân
  deleteDMHN: (id) => {
    const url = `/MarriageCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm khen thưởng và kỉ luật
  deleteDMKTvKL: (id) => {
    const url = `/RewardDiscipLineCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm loại hợp đồng
  deleteDMLHD: (id) => {
    const url = `/TypeOfContractCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm ngạch công chức
  deleteDMNCC: (id) => {
    const url = `/CRSCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm ngoại ngữ
  deleteDMNN: (id) => {
    const url = `/LanguageCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm người thân
  deleteDMNT: (id) => {
    const url = `/RelationCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm nhóm lương
  deleteDMNL: (id) => {
    const url = `/SalaryGroupCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm phòng ban
  deleteDMPB: (id) => {
    const url = `/DepartmentCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm tính chất lao động
  deleteDMTCLD: (id) => {
    const url = `/LaborCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh mục tổ
  deleteDMT: (id) => {
    const url = `/NestCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete danh mục tôn giáo
  deleteDMTG: (id) => {
    const url = `/ReligionCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm trình độ
  deleteDMTD: (id) => {
    const url = `/LevelCategory/${id}`;
    return axiosClient.delete(url);
  },

  //delete dm hình thức đào tạo
  deleteDMHTDT: (id) => {
    const url = `/EducateCategory/${id}`;
    return axiosClient.delete(url);
  },
  // delete trình độ văn hoá
  deleteTDVH: (id) => {
    const url = `/EducationLevel/${id}`;
    return axiosClient.delete(url);
  },
  // delete ngoại ngữ
  deleteNN: (id) => {
    const url = `/Language/${id}`;
    return axiosClient.delete(url);
  },
  // delete người thân
  deleteNT: (id) => {
    const url = `/FamilyRelationship/${id}`;
    return axiosClient.delete(url);
  },
  //delete hợp đồng
  deleteHD: (id) => {
    const url = `/LaborContract/${id}`;
    return axiosClient.delete(url);
  },
  //delete bằng chứng hợp đồng
  deleteAHD: (id) => {
    const url = `/LaborContract/bangChung/${id}`;
    return axiosClient.delete(url);
  },
  //delete lương
  deleteL: (id) => {
    const url = `/Salary/${id}`;
    return axiosClient.delete(url);
  },
  //delete bằng chứng lương
  deleteAL: (id) => {
    const url = `/Salary/bangChung/${id}`;
    return axiosClient.delete(url);
  },
  //delete điều chuyển
  deleteDC: (id) => {
    const url = `/WorkingProcess/${id}`;
    return axiosClient.delete(url);
  },
  //delete khen thưởng và kỷ luật
  deleteKTvKL: (id) => {
    const url = `/RewardDiscipline/${id}`;
    return axiosClient.delete(url);
  },
  //delete bằng chứng khen thưởng kỷ luật
  deleteAKTvKL: (id) => {
    const url = `/RewardDiscipline/image/${id}`;
    return axiosClient.delete(url);
  },
  //delete ảnh nhân viên
  deleteANV: (id) => {
    const url = `/Employee/image/${id}`;
    return axiosClient.delete(url);
  },
};

export default DeleteApi;
