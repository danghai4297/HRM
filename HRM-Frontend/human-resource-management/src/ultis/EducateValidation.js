import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenHinhThuc: yup
    .string()
    .nullable()
    .matches(notOnlySpace, "Tên hình thức không được chỉ là khoảng trống.")
    .max(50, "Tên hình thức không được vượt quá 50 kí tự")
    .required("Tên hình thức không được bỏ trống."),
});
