import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenChucDanh: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên chức danh không được chỉ là khoảng trống")
    .max(50, "Tên chức danh không được vượt quá 50 kí tự")
    .required("Tên chức danh không được bỏ trống."),
  phuCap: yup.number().typeError("Phụ cấp không được bỏ trống và là số."),
});
