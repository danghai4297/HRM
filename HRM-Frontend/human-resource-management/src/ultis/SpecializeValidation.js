import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenChuyenMon: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên chuyên môn không được chỉ là khoảng trống"
    )
    .max(50, "Tên chuyên môn không được vượt quá 50 kí tự")
    .required("Tên chuyên môn không được bỏ trống."),
});
