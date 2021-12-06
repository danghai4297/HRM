import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenLaoDong: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên lao động không được bỏ trống.")
    .required("Tên lao động không được bỏ trống."),
});
