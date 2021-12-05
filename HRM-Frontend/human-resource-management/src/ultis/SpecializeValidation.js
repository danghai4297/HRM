import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenChuyenMon: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên chuyên môn không được chỉ là khoảng trống"
    )
    .required("Tên chuyên môn không được bỏ trống."),
});
