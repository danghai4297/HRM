import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
const phoneRegex = /(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})/g;
export const schema = yup.object({
  idDanhMucNguoiThan: yup
    .number()
    .typeError("Danh mục người thân không được bỏ trống."),
  tenNguoiThan: yup
    .string()
    .matches(notAllowNull, "Tên người thân không được là khoảng trống.") 
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
    .nullable()
    .required("Quan hệ không được bỏ trống."),
  ngheNghiep: yup
    .string()
    .matches(notAllowNull, "Nghề nghiệp không được là khoảng trống.")
    .nullable()
    .required("Nghề nghệp không được bỏ trống."),
  diaChi: yup
    .string()
    .matches(notAllowNull, "Địa chỉ không được là khoảng trống.")
    .nullable()
    .required("Địa chỉ không được bỏ trống."),
  dienThoai: yup
    .string()
    .matches(phoneRegex, "Điện thoại phải là số")
    .nullable()
    .required("Điện thoại không được bỏ trống."),
    khac:yup
    .string()
    .matches(allNull, "Thông tin khác không thể là khoảng trống.")
    .nullable()
    .notRequired(),
});