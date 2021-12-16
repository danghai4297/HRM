import * as yup from "yup";
const notOnlySpace = /^(?!\s+$).*/g;
export const schema = yup.object({
  tenNgach: yup
    .string()
    .matches(
      notOnlySpace,
      "Tên ngạch công chức không được chỉ là khoảng trống."
    )
    .max(50, "Tên ngạch công chức không được vượt quá 50 kí tự")
    .nullable()
    .required("Tên ngạch công chức không được bỏ trống."),
});
