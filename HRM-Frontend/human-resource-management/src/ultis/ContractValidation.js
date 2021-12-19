import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
export const schema = yup.object().shape({
  trangThai: yup.boolean(),
  maNhanVien: yup
    .string()
    .matches(notAllowNull, "Mã nhân viên không được là khoảng trống.")
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  idLoaiHopDong: yup.number().typeError("Loại hợp đồng không được bỏ trống."),
  idChucDanh: yup.number().typeError("Chức danh không được bỏ trống."),
  idChucVu: yup.number().typeError("Chức vụ không được bỏ trống."),
  hopDongTuNgay: yup
    .date()
    .nullable()
    .required("Ngày hiệu lực không được bỏ trống"),
  hopDongDenNgay: yup
    .date()
    .nullable()
    .required("Ngày hết hạn không được bỏ trống"),
  idCre: yup.number(),
  ghiChu: yup
    .string()
    .matches(allNull, "Ghi chú không thể là khoảng trống.")
    .max(300, "Ghi chú không được vượt quá 300 kí tự")
    .nullable()
    .notRequired(),
});
