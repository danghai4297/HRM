import * as yup from "yup";
const dontAllowOnlySpace = /^\s*\S.*$/g;
export const schema = yup.object({
  tenDanhMuc: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên danh mục không được chỉ là khoảng trống")
    .required("Tên danh mục không được bỏ trống."),
  tenNgach: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên danh mục không được chỉ là khoảng trống")
    .required("Tên ngạch công chức không được bỏ trống."),
  tenPhongBan: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên phòng ban không được chỉ là khoảng trống")
    .required("Tên phòng ban không được bỏ trống."),
  tenHinhThuc: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên hình thức không được chỉ là khoảng trống")
    .required("Tên hình thức không được bỏ trống."),
  tenLaoDong: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên lao động không được chỉ là khoảng trống")
    .required("Tên lao động không được bỏ trống."),
  tenTrinhDo: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên trình độ không được chỉ là khoảng trống")
    .required("Tên trình độ không được bỏ trống."),
  idPhongBan: yup.number().typeError("Thuộc phòng ban không được bỏ trống."),
  tenTo: yup
    .string()
    .matches(dontAllowOnlySpace, "Tổ không được chỉ là khoảng trống")
    .required("Tổ không được bỏ trống."),
  tenChucVu: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên chức vụ không được chỉ là khoảng trống")
    .required("Tên chức vụ không được bỏ trống."),
  phuCap: yup.number().typeError("Phụ cấp không được bỏ trống và là số."),
  tenNhomLuong: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên nhóm lương không được chỉ là khoảng trống"
    )
    .required("Tên nhóm lương không được bỏ trống."),
  tenChuyenMon: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên chuyên môn không được chỉ là khoảng trống"
    )
    .required("Tên chuyên môn không được bỏ trống."),
  tenChucDanh: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên chức danh không được chỉ là khoảng trống")
    .required("Tên chức danh không được bỏ trống."),
  tenLoaiHopDong: yup
    .string()
    .matches(
      dontAllowOnlySpace,
      "Tên loại hợp đồng không được chỉ là khoảng trống"
    )
    .required("Tên loại hợp đồng không được bỏ trống."),
});
