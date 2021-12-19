import * as yup from "yup";

const notAllowNull = /^\s*\S.*$/g;
export const schema = yup.object({
  tenTruong: yup
    .string()
    .matches(notAllowNull, "Tên trường không được là khoảng trống.")
    .max(50, "Tên trường không được vượt quá 50 kí tự")
    .nullable()
    .required("Tên trường không được bỏ trống."),
  idChuyenMon: yup.number().typeError("Chuyên môn không được bỏ trống."),
  idHinhThucDaoTao: yup
    .number()
    .typeError("Hình thức đào tạo không được bỏ trống."),
  idTrinhDo: yup.number().typeError("Trình độ không được bỏ trống."),
  tuThoiGian: yup.date().nullable().required("Từ ngày không được bỏ trống"),
  denThoiGian: yup.date().nullable().required("Đến ngày không được bỏ trống"),
});
