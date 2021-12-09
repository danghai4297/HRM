import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenPhongBan: yup
    .string()
    .matches(notOnlySpace, "Tên phòng ban không được chỉ là khoảng trống.")
    .required("Tên phòng ban không được bỏ trống."),
});
