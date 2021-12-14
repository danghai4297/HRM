import axiosClient from "./axiosClient";

const PutApi = {
  //Sửa danh mục dân tộc
  PutDMDT: (data, id) => {
    const url = `/NationCategory/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục chức danh
  PutDMCD: (data, id) => {
    const url = `/TitleCategory/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục chức vụ
  PutDMCV: (data, id) => {
    const url = `/PositionCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục chuyên môn
  PutDMCM: (data, id) => {
    const url = `/SpecializeCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục hôn nhân
  PutDMHN: (data, id) => {
    const url = `/MarriageCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục loại hợp đồng
  PutDMLHD: (data, id) => {
    const url = `/TypeOfContractCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục ngạch công chức
  PutDMNCC: (data, id) => {
    const url = `/CSRCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục ngoại ngữ
  PutDMNN: (data, id) => {
    const url = `/LanguageCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục người thân
  PutDMNT: (data, id) => {
    const url = `/RelationCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục nhóm lương
  PutDMNL: (data, id) => {
    const url = `/SalaryGroupCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục phòng ban
  PutDMPB: (data, id) => {
    const url = `/DepartmentCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục tính chất lao động
  PutDMTCLD: (data, id) => {
    const url = `/LaborCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục tổ
  PutDMT: (data, id) => {
    const url = `/NestCategory/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục hình thức đào tạo
  PutDMHTDT: (data, id) => {
    const url = `/EducateCategory/${id}`;
    return axiosClient.put(url, data);
  },

  //Sửa danh mục tôn giáo
  PutDMTG: (data, id) => {
    const url = `/ReligionCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục trình độ
  PutDMTD: (data, id) => {
    const url = `/LevelCategory/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa danh mục khen thưởng và kỉ luật
  PutDMKTvKL: (data, id) => {
    const url = `/RewardDiscipLineCategory/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa trình độ văn hoá
  PutTDVH: (data, id) => {
    const url = `/EducationLevel/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa ngoại ngữ
  PutNN: (data, id) => {
    const url = `/Language/${id}`;
    return axiosClient.put(url, data);
  },

  // Sửa người thân
  PutNT: (data, id) => {
    const url = `/FamilyRelationship/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa ảnh nhân viên
  PutIMG: (data, id) => {
    const url = `/Employee/image/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa hợp đồng
  PutHD: (data, id) => {
    const url = `/LaborContract/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa bằng chứng hợp đồng
  PutAHD: (data, id) => {
    const url = `/LaborContract/bangChung/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa lương
  PutL: (data, id) => {
    const url = `/Salary/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa bằng chứng lương
  PutAL: (data, id) => {
    const url = `/Salary/bangChung/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa điều chuyển
  PutDC: (data, id) => {
    const url = `/WorkingProcess/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa trạng thái lương
  PutTLL: (id) => {
    const url = `/Salary/trang-thai/${id}`;
    return axiosClient.put(url);
  },
  // Sửa trạng thái hợp đồng
  PutTLHD: (id) => {
    const url = `/LaborContract/trang-thai/${id}`;
    return axiosClient.put(url);
  },
  // Sửa khen thưởng và kỷ luật
  PutKTvKL: (data, id) => {
    const url = `/RewardDiscipline/${id}`;
    return axiosClient.put(url, data);
  },
  // Sửa bằng chứng khen thưởng và kỷ luật
  PutAKTvKL: (data, id) => {
    const url = `/RewardDiscipline/image/${id}`;
    return axiosClient.put(url, data);
  },
  //Sửa nhân viên
  PutNV: (data, id) => {
    const url = `/Employee/${id}`;
    return axiosClient.put(url, data);
  },
};
export default PutApi;
