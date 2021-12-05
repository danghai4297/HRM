import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenChucDanh: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên chức danh không được chỉ là khoảng trống")
    .required("Tên chức danh không được bỏ trống."),
  phuCap: yup.number().typeError("Phụ cấp không được bỏ trống và là số."),
});
