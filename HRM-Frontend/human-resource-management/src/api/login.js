import axiosClient from "./axiosClient";
const LoginApi = {
  PostLoginAccount: (data) => {
    const url = "/User/authenticate";
    return axiosClient.post(url, data).then(res => {
        localStorage.setItem('token', res.token);
    });
  },
};

export default LoginApi;
