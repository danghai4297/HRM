import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  idPhongBan: yup.number().typeError("Thuộc phòng ban không được bỏ trống."),
  tenTo: yup
    .string()
    .matches(notOnlySpace, "Tổ không được chỉ là khoảng trống")
    .required("Tổ không được bỏ trống."),
});
