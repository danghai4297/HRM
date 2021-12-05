import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenLoaiHopDong: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên loại hợp đồng không được chỉ là khoảng trống"
    )
    .required("Tên loại hợp đồng không được bỏ trống."),
});
