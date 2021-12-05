import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenPhongBan: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên phòng ban không được bỏ trống.")
    .required("Tên lao động không được bỏ trống."),
});
