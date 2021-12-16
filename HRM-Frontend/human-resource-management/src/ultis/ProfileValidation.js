import * as yup from "yup";
const phoneRex = /([\|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})$\b/;
const phoneRex1 = /^(([+|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})|)$/;
const phoneRexlandline = /^((02)+([0-9]{9})|)$/g;
// const number = /^\d+$/;
const tax = /((0)([0-7])([0-9]){8})$/g;
const cccdRegex = /((0)([0-9]))/g;
const atm = /^(?:[1-9]\d*|)$/g;
const bhyt =
  /^((DN|HX|CH|NN|DK|HC|XK|HT|DB|NO|CT|XB|TN|CS|QN|CA|CY|XN|MS|CC|CK|CB|KC|HD|TE|BT|HN|DT|DK|XD|TS|TC|TQ|TA|TY|HG|LS|PV|CN|HS|SV|GB|GD){1}([1-5]){1}([0-9]){2}([0-9]){10}|)$/g;
const bhxh = /^(([0-9]){10}|)$/g;
const hoChieu = /^(([A-Z]{1})([0-9]){7}|)$/g;
const email = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4}|)$/g;
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
export const schema = yup.object().shape({
  id: yup.string().nullable().required("Mã nhân viên không được bỏ trống."),
  hoTen: yup
    .string()
    .matches(notAllowNull, "Họ và tên không được là khoảng trống.")
    .max(50, "Họ tên không được vượt quá 50 kí tự")
    .nullable()
    .required("Họ và tên không được bỏ trống."),
  gioiTinh: yup.boolean().nullable().required("Giới tính không được bỏ trống."),
  idDanhMucHonNhan: yup.number().typeError("Hôn nhân không được bỏ trống."),
  ngaySinh: yup.date().nullable().required("Ngày sinh không được bỏ trống."),
  noiSinh: yup
    .string()
    .matches(notAllowNull, "Nơi sinh không được là khoảng trống.")
    .max(150, "Nơi sinh không được vượt quá 150 kí tự")
    .nullable()
    .required("Nơi sinh không được bỏ trống."),
  idDanToc: yup.number().typeError("Dân Tộc không được bỏ trống."),
  queQuan: yup
    .string()
    .matches(notAllowNull, "Quê quán không được là khoảng trống.")
    .max(150, "Quê quán không được vượt quá 150 kí tự")
    .nullable()
    .required("Nguyên quán không được bỏ trống."),
  idTonGiao: yup.number().typeError("Tôn giáo không được bỏ trống."),
  thuongTru: yup
    .string()
    .matches(notAllowNull, "HK thường trú không được là khoảng trống.")
    .max(150, "HK thường trú không được vượt quá 150 kí tự")
    .nullable()
    .required("HK thường trú không được bỏ trống."),
  quocTich: yup
    .string()
    .matches(notAllowNull, "Quốc tịch không được là khoảng trống.")
    .max(50, "Quốc tịch không được vượt quá 50 kí tự")
    .nullable()
    .required("Quốc tịch không được bỏ trống."),
  atm: yup
    .string()
    .matches(atm, "Tài khoản ngân hàng phải là dãy số.")
    .max(20, "Tài khoản ngân hàng không được vượt quá 20 kí tự")
    .nullable()
    .notRequired(),
  bhyt: yup
    .string()
    .matches(bhyt, "Bảo hiểm y tế phải đúng định dạng.")
    .nullable()
    .notRequired(),
  bhxh: yup
    .string()
    .matches(bhxh, "Bảo hiểm xã hội phải là dãy số và đúng định dạng.")
    .nullable()
    .notRequired(),
  email: yup
    .string()
    .matches(email, "Email cá nhân phải đúng định dạng.")
    .max(50, "Email cá nhân không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  lhkc_email: yup
    .string()
    .matches(email, "Email phải đúng định dạng.")
    .max(30, "Email không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  hoChieu: yup
    .string()
    .matches(hoChieu, "Số hộ chiếu phải đúng định dạng.")
    .nullable()
    .notRequired(),
  dienThoaiKhac: yup
    .string()
    .matches(phoneRex1, "Số điện thoại khác phải là dãy số.")
    .nullable()
    .notRequired(),
  dienThoai: yup
    .string()
    .matches(phoneRexlandline, "Số điện thoại nhà riêng phải là dãy số.")
    .nullable()
    .notRequired(),
  cccd: yup
    .string()
    .matches(cccdRegex, "CMND/CCCD phải là dãy số theo quy định")
    .max(12, "CMND/CCCD không được vượt quá 12 kí tự")
    .nullable()
    .required("CMND/CCCD không được bỏ trống"),
  ngayCapCCCD: yup
    .date()
    .nullable()
    .required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayCapHoChieu: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayChinhThuc: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // //ngayVaoDoan: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayThuViec: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayVaoBan: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayVaoDang: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayVaoDangChinhThuc: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayXuatNgu: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  noiCapCCCD: yup
    .string()
    .matches(notAllowNull, "Nơi cấp CMND/CCCD không được là khoảng trống.")
    .max(25, "Nơi cấp CMND/CCCD không được vượt quá 25 kí tự")
    .nullable()
    .required("Nơi cấp CMND/CCCD không được bỏ trống."),
  // ngayNhapNgu: yup.date().required("Nơi cấp CMND/CCCD không được bỏ trống."),
  // ngayHetHanHoChieu: yup.date().required("Nơi cấp CMND/CCCD không được bỏ trống."),
  ngayHetHanCCCD: yup
    .date()
    .nullable()
    .required("Ngày hết hạn CMND/CCCD không được bỏ trống."),
  diDong: yup
    .string()
    .nullable()
    .matches(phoneRex, "Số điện thoại không đúng định dạng")
    .required("Số điện thoại không được bỏ trống"),

  lhkc_hoTen: yup
    .string()
    .matches(notAllowNull, "Họ và tên không được là khoảng trống.")
    .max(30, "Họ tên không được vượt quá 30 kí tự")
    .nullable()
    .required("Họ và tên không được bỏ trống."),
  lhkc_quanHe: yup
    .string()
    .matches(notAllowNull, "Quan hệ không được là khoảng trống.")
    .max(30, "Quan hệ không được vượt quá 30 kí tự")
    .nullable()
    .required("Quan hệ không được bỏ trống."),
  lhkc_dienThoai: yup
    .string()
    .nullable()
    .matches(phoneRex, "Số điện thoại phải là số và đúng định dạng.")
    .required("Số điện thoại không được bỏ trống"),
  lhkc_diaChi: yup
    .string()
    .matches(notAllowNull, "Địa chỉ không được là khoảng trống.")
    .max(150, "Địa chỉ không được vượt quá 150 kí tự")
    .nullable()
    .required("Địa chỉ không được bỏ trống."),
  ngheNghiep: yup
    .string()
    .matches(notAllowNull, "Nghề nghiệp không được là khoảng trống.")
    .max(50, "Nghề nghiệp không được vượt quá 50 kí tự")
    .nullable()
    .required("Nghề nghiệp không được bỏ trống."),
  // ngayTuyenDung: yup.date().required("Ngày tuyển dụng không được bỏ trống."),
  coQuanTuyenDung: yup
    .string()
    .matches(notAllowNull, "Cơ quan tuyển dụng không được là khoảng trống.")
    .max(50, "Cơ quan tuyển dụng không được vượt quá 50 kí tự")
    .nullable()
    .required("Cơ quan tuyển dụng không được bỏ trống."),
  chucVuHienTai: yup
    .string()
    .matches(notAllowNull, "Chức vụ không được là khoảng trống.")
    .max(50, "Chức vụ không được vượt quá 50 kí tự")
    .nullable()
    .required("Chức vụ hiện tại không được bỏ trống."),
  trangThaiLaoDong: yup
    .boolean()
    .nullable()
    .required("Trạng thái lao động không được bỏ trống."),

  tinhChatLaoDong: yup
    .number()
    .nullable()
    .required("Tính chất lao động không được bỏ trống."),
  maSoThue: yup
    .string()
    .matches(tax, "Mã số thuế cá nhân phải là dãy số có 10 chữ số.")
    .nullable()
    .required("Mã số thuế cá nhân không được bỏ trống."),
  congViecChinh: yup
    .string()
    .matches(notAllowNull, "Công việc chính không được là khoảng trống.")
    .max(50, "Công việc chính không được vượt quá 50 kí tự")
    .nullable()
    .required("Công việc chính không được bỏ trống."),
  // //phongBan: yup.string().required("Phòng Ban động không được bỏ trống."),
  idNgachCongChuc: yup
    .number()
    .typeError("Ngạch công chức không được bỏ trống."),
  yt_chieuCao: yup
    .number()
    .positive("Chiều cao không thể là số âm.")
    .typeError("Chiều cao không được bỏ trống."),
  yt_canNang: yup
    .number()
    .positive("Cân nặng không thể là số âm")
    .typeError("Cân nặng không được bỏ trống."),
  lsbt_maNhanVien: yup
    .string()
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  yt_maNhanVien: yup
    .string()
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  lhkc_maNhanVien: yup
    .string()
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  nganHang: yup
    .string()
    .matches(allNull, "Ngân hàng không thể là khoảng trống.")
    .max(50, "Ngân hàng không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  tamTru: yup
    .string()
    .matches(allNull, "Tạm trú không thể là khoảng trống.")
    .max(150, "Tạm trú không được vượt quá 150 kí tự")
    .nullable()
    .notRequired(),
  noiCapHoChieu: yup
    .string()
    .matches(allNull, "Nơi cấp hộ chiếu không thể là khoảng trống.")
    .max(25, "Nơi cấp hộ chiếu không được vượt quá 25 kí tự")
    .nullable()
    .notRequired(),
  facebook: yup
    .string()
    .matches(allNull, "Facebook không thể là khoảng trống.")
    .max(50, "Facebook không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  skype: yup
    .string()
    .matches(allNull, "Skype không thể là khoảng trống.")
    .max(50, "Skype không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  noiThamGia: yup
    .string()
    .matches(allNull, "Nơi tham gia không thể là khoảng trống.")
    .max(50, "Nơi tham gia không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  ngachCongChucNoiDung: yup
    .string()
    .matches(allNull, "NCCND không thể là khoảng trống.")
    .max(50, "NCCND không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  yt_nhomMau: yup
    .string()
    .matches(allNull, "Nhóm máu không thể là khoảng trống.")
    .max(5, "Nhóm máu không được vượt quá 5 kí tự")
    .nullable()
    .notRequired(),
  yt_benhTat: yup
    .string()
    .matches(allNull, "Bệnh tật không thể là khoảng trống.")
    .max(50, "Bệnh tật không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  yt_luuY: yup
    .string()
    .matches(allNull, "Lưu ý không thể là khoảng trống.")
    .max(50, "Lưu ý không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  yt_tinhTrangSucKhoe: yup
    .string()
    .matches(allNull, "Tình trạng sức khoẻ không thể là khoảng trống.")
    .max(50, "Tình trạng sức khoẻ không được vượt quá 50 kí tự")
    .nullable()
    .notRequired(),
  lsbt_biBatDiTu: yup
    .string()
    .matches(allNull, "Lịch sử bản thân không thể là khoảng trống.")
    .max(500, "Lịch sử bản thân không được vượt quá 500 kí tự")
    .nullable()
    .notRequired(),
  lsbt_thamGiaChinhTri: yup
    .string()
    .matches(allNull, "Lịch sử bản thân không thể là khoảng trống.")
    .max(500, "Lịch sử bản thân không được vượt quá 500 kí tự")
    .nullable()
    .notRequired(),
  lsbt_thanNhanNuocNgoai: yup
    .string()
    .matches(allNull, "Lịch sử bản thân không thể là khoảng trống.")
    .max(500, "Lịch sử bản thân không được vượt quá 500 kí tự")
    .nullable()
    .notRequired(),
  vaoDang: yup.boolean(),
  ngayVaoDang: yup.date().when("vaoDang", {
    is: true,
    then: yup.date().nullable().required("Ngày vào Đảng không được để trống"),
    otherwise: yup.date().nullable().notRequired(),
  }),
  ngayVaoDangChinhThuc: yup.date().when("vaoDang", {
    is: true,
    then: yup.date().nullable().required("Ngày chính thức không được để trống"),
    otherwise: yup.date().nullable().notRequired(),
  }),
  quanNhan: yup.boolean(),
  ngayNhapNgu: yup.date().when("quanNhan", {
    is: true,
    then: yup.date().nullable().required("Ngày nhập ngũ không được để trống"),
    otherwise: yup.date().nullable().notRequired(),
  }),
  ngayXuatNgu: yup.date().when("quanNhan", {
    is: true,
    then: yup.date().nullable().required("Ngày xuất ngũ không được để trống"),
    otherwise: yup.date().nullable().notRequired(),
  }),
  laThuongBinh: yup.boolean(),
  thuongBinh: yup
    .string()
    .nullable()
    .when("laThuongBinh", {
      is: true,
      then: yup
        .string()
        .matches(notAllowNull, "Thương binh hạng không thể là khoảng trống.")
        .max(50, "Thương binh hạng không được vượt quá 50 kí tự")
        .nullable()
        .required("Thương binh hạng không được bỏ trống"),
    }),
  laConChinhSach: yup.boolean(),
  conChinhSach: yup
    .string()
    .nullable()
    .when("laConChinhSach", {
      is: true,
      then: yup
        .string()
        .matches(notAllowNull, "Con chính sách không thể là khoảng trống.")
        .max(50, "Con chính sách không được vượt quá 50 kí tự")
        .nullable()
        .required("Con chính sách không được bỏ trống"),
    }),
  quanHamCaoNhat: yup
    .string()
    .nullable()
    .when("quanNhan", {
      is: true,
      then: yup
        .string()
        .matches(allNull, "Quân hàm cao nhất không thể là khoảng trống.")
        .max(50, "Quân hàm cao nhất không được vượt quá 50 kí tự")
        .nullable()
        .notRequired(),
    }),
  danhHieuCaoNhat: yup
    .string()
    .nullable()
    .when("quanNhan", {
      is: true,
      then: yup
        .string()
        .matches(allNull, "Danh hiệu cao nhất không thể là khoảng trống.")
        .max(50, "Danh hiệu cao nhất không được vượt quá 50 kí tự")
        .nullable()
        .notRequired(),
    }),
});
