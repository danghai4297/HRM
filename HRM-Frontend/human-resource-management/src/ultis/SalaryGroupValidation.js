import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenNhomLuong: yup
    .string()
    .matches(notOnlySpace, "Tên nhóm lương không được chỉ là khoảng trống")
    .max(50, "Tên nhóm lương không được vượt quá 50 kí tự")
    .required("Tên nhóm lương không được bỏ trống."),
});
