import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenLoaiHopDong: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên loại hợp đồng không được chỉ là khoảng trống"
    )
    .max(50, "Tên loại hợp đồng không được vượt quá 50 kí tự")
    .required("Tên loại hợp đồng không được bỏ trống."),
});
