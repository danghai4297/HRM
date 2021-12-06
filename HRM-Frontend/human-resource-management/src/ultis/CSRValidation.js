import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenNgach: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên ngạch công chức không được bỏ trống.")
    .required("Tên lao động không được bỏ trống."),
});
