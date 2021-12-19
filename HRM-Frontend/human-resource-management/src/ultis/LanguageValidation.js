import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
export const schema = yup.object({
  idDanhMucNgoaiNgu: yup.number().typeError("Ngoại ngữ không được bỏ trống."),
  ngayCap: yup.date().nullable().required("Ngày cấp không được bỏ trống."),
  trinhDo: yup
    .string()
    .matches(notAllowNull, "Trình độ không thể là khoảng trống.")
    .max(50, "Trình độ không được vượt quá 50 kí tự")
    .nullable()
    .required("Trình độ không được bỏ trống."),
  noiCap: yup
    .string()
    .matches(notAllowNull, "Nơi cấp không thể là khoảng trống.")
    .max(50, "Nơi cấp không được vượt quá 50 kí tự")
    .nullable()
    .required("Nơi cấp không được bỏ trống."),
  maNhanVien: yup
    .string()
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
});
