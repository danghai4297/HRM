import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenNhomLuong: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên nhóm lương không được chỉ là khoảng trống"
    )
    .required("Tên nhóm lương không được bỏ trống."),
});
