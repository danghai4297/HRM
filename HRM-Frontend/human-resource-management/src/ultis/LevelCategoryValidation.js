import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenTrinhDo: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên trình độ không được chỉ là khoảng trống")
    .required("Tên trình độ không được bỏ trống."),
});
