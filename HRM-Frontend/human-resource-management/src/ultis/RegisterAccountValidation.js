import * as yup from "yup";

const passwordReg =
  /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$/g;
const notAllowNull = /^\s*\S.*$/g;
export const schema = yup.object({
  maNhanVien: yup
    .string()
    .matches(notAllowNull, "Mã nhân viên không được là khoảng trống.")
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  password: yup
    .string()
    .matches(passwordReg, "Mật khẩu không đúng định dạng.")
    .required("Mật khẩu hiện tại không được bỏ trống."),
  confirmPassword: yup
    .string()
    .matches(passwordReg, "Xác nhận mật khẩu không đúng định dạng.")
    .required("Mật khẩu mới không được bỏ trống."),
  userName: yup
    .string()
    .matches(notAllowNull, "Tài khoản không đúng định dạng")
    .nullable()
    .required("Tên đăng nhập không được bỏ trống."),
});
