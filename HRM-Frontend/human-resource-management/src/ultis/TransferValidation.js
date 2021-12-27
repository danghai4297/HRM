import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
export const schema = yup.object({
  maNhanVien: yup
    .string()
    .matches(notAllowNull, "Mã nhân viên không được là khoảng trống.")
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  idPhongBan: yup.number().typeError("Phòng ban không được bỏ trống."),
  to: yup.number().typeError("Tổ không được bỏ trống."),
  trangThai: yup.boolean(),
  chiTiet: yup
    .string()
    .matches(allNull, "Chi tiết không thể là khoảng trống.")
    .max(300, "Chi tiết không được vượt quá 300 kí tự")
    .nullable()
    .notRequired(),
  ngayHieuLuc: yup
    .date()
    .nullable()
    .required("Ngày hiệu lực không được bỏ trống."),
});
