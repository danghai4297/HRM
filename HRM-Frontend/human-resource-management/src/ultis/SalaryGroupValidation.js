import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenNhomLuong: yup
    .string()
    .matches(notOnlySpace, "Tên nhóm lương không được chỉ là khoảng trống")
    .required("Tên nhóm lương không được bỏ trống."),
});
