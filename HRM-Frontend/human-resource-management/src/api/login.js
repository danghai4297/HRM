import axiosClient from "./axiosClient";
const LoginApi = {
  PostLoginAccount: (data) => {
    const url = "/User/authenticate";
    return axiosClient.post(url, data).then((res) => {
      sessionStorage.setItem("resultObj", res.resultObj);
    });
  },
};

export default LoginApi;
