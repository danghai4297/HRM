import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenDanhMuc: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên danh mục không được chỉ là khoảng trống")
    .required("Tên danh mục không được bỏ trống."),
});
