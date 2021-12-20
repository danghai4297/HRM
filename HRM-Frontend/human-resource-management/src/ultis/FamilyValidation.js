import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
const phoneRegex = /([\|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})$\b/;
export const schema = yup.object({
  idDanhMucNguoiThan: yup
    .number()
    .typeError("Danh mục người thân không được bỏ trống."),
  tenNguoiThan: yup
    .string()
    .matches(notAllowNull, "Tên người thân không được là khoảng trống.")
    .max(40, "Tên người thân không được vượt quá 40 kí tự")
    .nullable()
    .required("Tên người thân không được bỏ trống."),
  gioiTinh: yup.boolean().nullable().required("Giới tính không được bỏ trống."),
  ngaySinh: yup.date().nullable().required("Ngày sinh được bỏ trống."),
  maNhanVien: yup
    .string()
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  quanHe: yup
    .string()
    .matches(notAllowNull, "Quan hệ không được là khoảng trống.")
    .max(50, "Quan hệ không được vượt quá 50 kí tự")
    .nullable()
    .required("Quan hệ không được bỏ trống."),
  ngheNghiep: yup
    .string()
    .matches(notAllowNull, "Nghề nghiệp không được là khoảng trống.")
    .max(50, "Nghề nghiệp không được vượt quá 50 kí tự")
    .nullable()
    .required("Nghề nghệp không được bỏ trống."),
  diaChi: yup
    .string()
    .matches(notAllowNull, "Địa chỉ không được là khoảng trống.")
    .max(150, "Địa chỉ không được vượt quá 150 kí tự")
    .nullable()
    .required("Địa chỉ không được bỏ trống."),
  dienThoai: yup
    .string()
    .matches(phoneRegex, "Điện thoại phải là số")
    .nullable()
    .required("Điện thoại không được bỏ trống."),
  khac: yup
    .string()
    .matches(allNull, "Thông tin khác không thể là khoảng trống.")
    .max(300, "Thông tin khác không được vượt quá 300 kí tự")
    .nullable()
    .notRequired(),
});
