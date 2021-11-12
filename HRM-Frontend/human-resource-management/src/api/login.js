import axiosClient from "./axiosClient";
const LoginApi = {
  PostLoginAccount: (data) => {
    const url = "/User/authenticate";
    return axiosClient.post(url, data).then((res) => {
      sessionStorage.setItem("resultObj", res.resultObj);
    });
  },

  //get all tài khoản
  getAllAcc: () => {
    const url = "/User";
    return axiosClient.get(url);
  },
  //Add account
  PostAcc: (data) => {
    const url = "/User/create";
    return axiosClient.post(url, data);
  },
  getTkDetail: (id) => {
    const url = `/User/${id}`;
    return axiosClient.get(url);
  },
};

export default LoginApi;
