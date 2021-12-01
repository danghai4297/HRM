import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
export const schema = yup.object({
  idDanhMucKhenThuong: yup
    .number()
    .nullable()
    .required("Loại khen thưởng không được bỏ trống."),
  maNhanVien: yup
    .string()
    .matches(notAllowNull, "Mã nhân viên không được là khoảng trống.")
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  //thoiGian: yup.string().required("Thời gian không được bỏ trống."),
  noiDung: yup.string().matches(notAllowNull, "Nội dung không được là khoảng trống.").nullable().required("Nội dung không được bỏ trống."),
  lyDo: yup.string().matches(notAllowNull, "Lý do không được là khoảng trống.").nullable().required("Lý do không được bỏ trống."),
  loai: yup.boolean(),
});