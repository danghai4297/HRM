import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenDanhMuc: yup
    .string()
    .matches(notOnlySpace, "Tên danh mục không được chỉ là khoảng trống")
    .max(50, "Tên danh mục không được vượt quá 50 kí tự")
    .nullable()
    .required("Tên danh mục không được bỏ trống."),
});
