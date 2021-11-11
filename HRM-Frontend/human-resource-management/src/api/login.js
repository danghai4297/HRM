import axiosClient from "./axiosClient";
const LoginApi = {
  PostLoginAccount: (data) => {
    const url = "/User/authenticate";
    return axiosClient.post(url, data).then((res) => {
      localStorage.setItem("resultObj", res.resultObj);
    });
  },

  //get all tài khoản
  getAllAcc: () => {
    const url = "/User";
    return axiosClient.get(url);
  },
};

export default LoginApi;
