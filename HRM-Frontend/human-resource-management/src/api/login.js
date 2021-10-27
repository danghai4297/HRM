import axiosClient from "./axiosClient";
const LoginApi = {
  PostLoginAccount: (data) => {
    const url = "/User/authenticate";
    return axiosClient.post(url, data).then((res) => {
      localStorage.setItem("resultObj", res.resultObj);
    });
  },
};

export default LoginApi;
