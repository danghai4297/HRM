import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenHinhThuc: yup
    .string()
    .nullable()
    .matches(notOnlySpace, "Tên hình thức không được chỉ là khoảng trống.")
    .required("Tên hình thức không được bỏ trống."),
});
