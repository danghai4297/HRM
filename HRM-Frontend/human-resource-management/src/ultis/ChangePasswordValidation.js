import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const passwordReg = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$/g;
export const schema = yup.object({
  oldPassword: yup
    .string()
    .matches(notAllowNull, "Mật khẩu hiện tại không được là khoảng trống.")
    .required("Mật khẩu hiện tại không được bỏ trống."),
    newPassword: yup
    .string()
    .matches(passwordReg, "Mật khẩu mới không đúng định dạng.")
    .required("Mật khẩu mới không được bỏ trống."),
    confirmPassword: yup
    .string()
    .matches(passwordReg, "Xác nhận mật khẩu mới không đúng định dạng.")
    .required("Xác nhận mật khẩu mới không được bỏ trống."),
});