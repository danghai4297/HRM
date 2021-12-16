import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenPhongBan: yup
    .string()
    .matches(notOnlySpace, "Tên phòng ban không được chỉ là khoảng trống.")
    .max(50, "Tên phòng ban không được vượt quá 50 kí tự")
    .required("Tên phòng ban không được bỏ trống."),
});
