import axiosClient from "./axiosClient";
const LoginApi = {
  PostLoginAccount: (data) => {
    const url = "/Authenticate/authenticate";
    return axiosClient.post(url, data).then((res) => {
      sessionStorage.setItem("resultObj", res.token);
    });
  },

  //get all tài khoản
  getAllAcc: () => {
    const url = "/Account";
    return axiosClient.get(url);
  },
  //Add account
  PostAcc: (data) => {
    const url = "/Account/create";
    return axiosClient.post(url, data);
  },
  getTkDetail: (id) => {
    const url = `/Account/${id}`;
    return axiosClient.get(url);
  },
  //Change password
  PutChangePassword: (data, id) => {
    const url = `/Account/change-password${id}`;
    return axiosClient.put(url, data);
  },

  //update role
  PutRole: (data, id) => {
    const url = `/Account/${id}/roles`;
    return axiosClient.put(url, data);
  },
  //Reset password
  getResetPassword: (id) => {
    const url = `/Account/reset-password/${id}`;
    return axiosClient.get(url);
  },
  //Delete account
  deleteAccount: (id) => {
    const url = `/Account/${id}`;
    return axiosClient.delete(url);
  },
};

export default LoginApi;
