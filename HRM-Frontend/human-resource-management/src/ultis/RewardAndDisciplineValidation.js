import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
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
  noiDung: yup
    .string()
    .matches(notAllowNull, "Nội dung không được là khoảng trống.")
    .max(100, "Nội dung không được vượt quá 100 kí tự")
    .nullable()
    .required("Nội dung không được bỏ trống."),
  lyDo: yup
    .string()
    .matches(notAllowNull, "Lý do không được là khoảng trống.")
    .max(150, "Lý do không được vượt quá 150 kí tự")
    .nullable()
    .required("Lý do không được bỏ trống."),
  loai: yup.boolean(),
});
