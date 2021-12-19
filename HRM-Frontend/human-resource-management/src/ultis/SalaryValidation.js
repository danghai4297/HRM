import * as yup from "yup";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
export const schema = yup.object({
  maHopDong: yup
    .string()
    .matches(notAllowNull, "Mã hợp đồng không được là khoảng trống.")
    .nullable()
    .required("Mã hợp đồng không được bỏ trống."),
  idNhomLuong: yup
    .number()
    .nullable()
    .required("Nhóm lương không được bỏ trống."),
  heSoLuong: yup
    .number()
    .positive("Hệ số lương không thể là số âm.")
    .typeError("Hệ số lương không được bỏ trống."),
  bacLuong: yup
    .string()
    .matches(notAllowNull, "Bậc lương không được là khoảng trống.")
    .max(10, "Bậc lương không được vượt quá 10 kí tự")
    .nullable()
    .required("Bậc lương không được bỏ trống."),
  ngayHieuLuc: yup
    .date()
    .nullable()
    .required("Ngày hiệu lực không được bỏ trống."),
  ngayKetThuc: yup
    .date()
    .nullable()
    .required("Ngày kết thúc không được bỏ trống."),
  luongCoBan: yup
    .number()
    .positive("Lương cơ bản không thể là số âm.")
    .typeError("Lương cơ bản không được bỏ trống và phải là số."),
  phuCapTrachNhiem: yup
    .number()
    .moreThan(-1, "Phụ cấp trách nhiêm không thể là số âm.")
    .typeError("Phụ cấp trách nhiệm không được bỏ trống và phải là số."),
  phuCapKhac: yup
    .number()
    .positive("Phụ cấp khác không thể là số âm.")
    .typeError("Phụ cấp khác không được bỏ trống và phải là số."),
  tongLuong: yup.number(),
  thoiHanLenLuong: yup
    .string()
    .matches(notAllowNull, "Thời hạn lên lương không được là khoảng trống.")
    .max(10, "Thời hạn lên lương không được vượt quá 10 kí tự")
    .nullable()
    .required("Thời hạn lên lương không được bỏ trống."),
  trangThai: yup.boolean(),
  ghiChu: yup
    .string()
    .matches(allNull, "Ghi chú không thể là khoảng trống.")
    .max(100, "Ghi chú không được vượt quá 100 kí tự")
    .nullable()
    .notRequired(),
});
