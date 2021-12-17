import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenChucVu: yup
    .string()
    .matches(notOnlySpace, "Tên chức vụ không được chỉ là khoảng trống")
    .max(50, "Tên chức vụ không được vượt quá 50 kí tự")
    .required("Tên chức vụ không được bỏ trống."),
  phuCap: yup.number().typeError("Phụ cấp không được bỏ trống và là số."),
});
