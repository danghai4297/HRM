import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  idPhongBan: yup.number().typeError("Thuộc phòng ban không được bỏ trống."),
  tenTo: yup
    .string()
    .matches(dontAllowOnlySpace, "Tổ không được chỉ là khoảng trống")
    .required("Tổ không được bỏ trống."),
});
