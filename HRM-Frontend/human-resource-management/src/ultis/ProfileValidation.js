import * as yup from "yup";
const phoneRex = /([\|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})$\b/;
const phoneRex1 = /^(([+|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})|)$/;
const phoneRexlandline = /^((02)+([0-9]{9})|)$/g;
const number = /^\d+$/;
const tax = /((0)([0-7])([0-9]){8})$/g;
const cccdRegex = /((0)([0-9]){2}([0-3]){1}([0-9]){8})$/g;
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
    .nullable()
    .required("Họ và tên không được bỏ trống."),
  gioiTinh: yup.boolean().nullable().required("Giới tính không được bỏ trống."),
  idDanhMucHonNhan: yup.number().typeError("Hôn nhân không được bỏ trống."),
  ngaySinh: yup.date().nullable().required("Ngày sinh không được bỏ trống."),
  noiSinh: yup
    .string()
    .matches(notAllowNull, "Nơi sinh không được là khoảng trống.")
    .nullable()
    .required("Nơi sinh không được bỏ trống."),
  idDanToc: yup.number().typeError("Dân Tộc không được bỏ trống."),
  queQuan: yup
    .string()
    .matches(notAllowNull, "Quê quán không được là khoảng trống.")
    .nullable()
    .required("Nguyên quán không được bỏ trống."),
  idTonGiao: yup.number().typeError("Tôn giáo không được bỏ trống."),
  thuongTru: yup
    .string()
    .matches(notAllowNull, "HK thường trú không được là khoảng trống.")
    .nullable()
    .required("HK thường trú không được bỏ trống."),
  quocTich: yup
    .string()
    .matches(notAllowNull, "Quốc tịch không được là khoảng trống.")
    .nullable()
    .required("Quốc tịch không được bỏ trống."),
  // tamTru: yup.string().required("Tạm trú không được bỏ trống."),
  atm: yup
    .string()
    .matches(atm, "Tài khoản ngân hàng phải là dãy số.")
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
    .nullable()
    .notRequired(),
  lhkc_email: yup
    .string()
    .matches(email, "Email phải đúng định dạng.")
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
    .matches(cccdRegex, "CMND/CCCD phải dãy số có 12 chữ số.")
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
    .matches(notAllowNull, "Nơi cấp không được là khoảng trống.")
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
    .matches(phoneRex, "Số điện thoại phải là dãy số.")
    .required("Số điện thoại không được bỏ trống"),

  lhkc_hoTen: yup
    .string()
    .matches(notAllowNull, "Họ và tên không được là khoảng trống.")
    .nullable()
    .required("Họ và tên không được bỏ trống."),
  lhkc_quanHe: yup
    .string()
    .matches(notAllowNull, "Quan hệ không được là khoảng trống.")
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
    .nullable()
    .required("Địa chỉ không được bỏ trống."),
  ngheNghiep: yup
    .string()
    .matches(notAllowNull, "Nghề nghiệp không được là khoảng trống.")
    .nullable()
    .required("Nghề nghiệp không được bỏ trống."),
  // ngayTuyenDung: yup.date().required("Ngày tuyển dụng không được bỏ trống."),
  coQuanTuyenDung: yup
    .string()
    .matches(notAllowNull, "Cơ quan tuyển dụng không được là khoảng trống.")
    .nullable()
    .required("Cơ quan tuyển dụng không được bỏ trống."),
  chucVuHienTai: yup
    .string()
    .matches(notAllowNull, "Chức vụ không được là khoảng trống.")
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
    .nullable()
    .required("Công việc chính không được bỏ trống."),
  // //phongBan: yup.string().required("Phòng Ban động không được bỏ trống."),
  idNgachCongChuc: yup
    .number()
    .typeError("Ngạch công chức không được bỏ trống."),
  // lsbt_biBatDiTu: yup
  //   .string()
  //   .required("Lịch sử bản thân không được bỏ trống."),
  // lsbt_thamGiaChinhTri: yup
  //   .string()
  //   .required("Lịch sử bản thân không được bỏ trống."),
  // lsbt_thanNhanNuocNgoai: yup
  //   .string()
  //   .required("Lịch sử bản thân không được bỏ trống."),
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
    .nullable()
    .notRequired(),
  tamTru: yup
    .string()
    .matches(allNull, "Tạm trú không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  NoiCapHoChieu: yup
    .string()
    .matches(allNull, "Nơi cấp hộ chiếu không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  facebook: yup
    .string()
    .matches(allNull, "Facebook không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  skype: yup
    .string()
    .matches(allNull, "Skype không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  noiThamGia: yup
    .string()
    .matches(allNull, "Nơi tham gia không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  ngachCongChucNoiDung: yup
    .string()
    .matches(allNull, "NCCND không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  yt_nhomMau: yup
    .string()
    .matches(allNull, "Nhóm máu không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  yt_benhTat: yup
    .string()
    .matches(allNull, "Bệnh tật không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  yt_luuY: yup
    .string()
    .matches(allNull, "Lưu ý không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  yt_tinhTrangSucKhoe: yup
    .string()
    .matches(allNull, "Tình trạng sức khoẻ không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  lsbt_biBatDiTu: yup
    .string()
    .matches(allNull, "Lịch sử bản thân không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  lsbt_thamGiaChinhTri: yup
    .string()
    .matches(allNull, "Lịch sử bản thân không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  lsbt_thanNhanNuocNgoai: yup
    .string()
    .matches(allNull, "Lịch sử bản thân không thể là khoảng trống.")
    .nullable()
    .notRequired(),
  vaoDang: yup.boolean(),
  ngayVaoDang: yup.date().when("vaoDang", {
    is: true,
    then: yup.date().nullable().required("Ngày vào Đảng không được để trống"),
  }),
  ngayVaoDangChinhThuc: yup.date().when("vaoDang", {
    is: true,
    then: yup.date().nullable().required("Ngày chính thức không được để trống"),
  }),
  // laThuongBinh:yup.boolean(),
  // thuongBinh: yup.string().when("laThuongBinh",{
  //   is:true,
  //   then: yup.string().nullable().required("Thương binh hạng không được bỏ trống"),
  //   otherwise:yup.string()
  //   .matches(allNull, "Không thể là khoảng trống.")
  //   .nullable()
  //   .notRequired(),
  // }),
});
