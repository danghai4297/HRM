import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenNgach: yup
    .string()
    .matches(
      notOnlySpace,
      "Tên ngạch công chức không được chỉ là khoảng trống."
    )
    .nullable()
    .required("Tên ngạch công chức không được bỏ trống."),
});
