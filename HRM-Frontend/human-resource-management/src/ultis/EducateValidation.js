import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenHinhThuc: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên hình thức không được bỏ trống.")
    .required("Tên lao động không được bỏ trống."),
});
