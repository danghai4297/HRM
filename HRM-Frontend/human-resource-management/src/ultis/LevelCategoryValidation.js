import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenTrinhDo: yup
    .string()
    .nullable()
    .matches(notOnlySpace, "Tên trình độ không được chỉ là khoảng trống")
    .required("Tên trình độ không được bỏ trống."),
});
