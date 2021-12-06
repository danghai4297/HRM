import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenChucVu: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên chức vụ không được chỉ là khoảng trống")
    .required("Tên chức vụ không được bỏ trống."),
  phuCap: yup.number().typeError("Phụ cấp không được bỏ trống và là số."),
});
