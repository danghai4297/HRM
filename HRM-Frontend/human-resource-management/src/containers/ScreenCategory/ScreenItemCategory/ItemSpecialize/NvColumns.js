import { format } from "date-fns";
import SelectColumnFilter from "../../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "First Name",
    accessor: "firstName",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Last Name",
    accessor: "lastName",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },

  {
    Header: "Gender",
    // accessor: (row) => {
    //   return row.gender ? "Nam" : "Nữ";
    // },
    accessor: "gender",
    minWidth: 200,
    Filter: SelectColumnFilter,
    // Cell: ({ value }) => {
    //   return value === true ? "Male" : "Female";
    // },
    show: true,
  },
  {
    Header: "Email",
    accessor: "email",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Birthday",
    accessor: "birthday",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Salary",
    accessor: "salary",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Phone",
    accessor: "phone",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNS2 = [
  {
    Header: "Ảnh",
    accessor: "anh",
    sticky: "left",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => <img src={value} width={50} />,

    show: true,
  },
  {
    Header: "Mã Nhân Viên",
    accessor: "maNhanVien",
    sticky: "left",
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Và Tên",
    accessor: "hoTen",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Quốc Tịnh",
    accessor: "quocTich",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngày Sinh",
    accessor: "ngaySinh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Giới Tính",
    // accessor: (row) => {
    //   return row.gender ? "Nam" : "Nữ";
    // },
    accessor: "gioiTinh",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,
    // Cell: ({ value }) => {
    //   return value === true ? "Male" : "Female";
    // },
    show: true,
  },
  {
    Header: "Điện Thoại Nhà",
    accessor: "dienThoai",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Di Động",
    accessor: "diDong",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Điện Thoại khác",
    accessor: "dienThoaiKhac",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Facebook",
    accessor: "facebook",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Skype",
    accessor: "skype",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Mã Số Thuế",
    accessor: "maSoThue",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "CCCD",
    accessor: "cccd",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Nơi Cấp CCCD",
    accessor: "noiCapCCCD",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngày Cấp CCCD",
    accessor: "ngayCapCCCD",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Hết Hạn CCCD",
    accessor: "ngayHetHanCCCD",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },

    show: false,
  },
  {
    Header: "Hộ Chiếu",
    accessor: "hoChieu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Nơi Cấp Hộ Chiếu",
    accessor: "noiCapHoChieu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Cấp Hộ Chiếu",
    accessor: "ngayCapHoChieu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Hết Hạn Hộ Chiếu",
    accessor: "ngayHetHanHoChieu",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },

    show: false,
  },
  {
    Header: "Nơi Sinh",
    accessor: "noiSinh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Quê Quán",
    accessor: "queQuan",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Thường Trú",
    accessor: "thuongTru",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Tạm Trú",
    accessor: "tamTru",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Nghề Nghiệp",
    accessor: "ngheNghiep",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Chức Vụ Hiện Tại",
    accessor: "chucVuHienTai",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày Tuyển Dụng",
    accessor: "ngayTuyenDung",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Ngày Thử Việc",
    accessor: "ngayThuViec",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Công Việc Chính",
    accessor: "congViecChinh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngày Vào Ban",
    accessor: "ngayVaoBan",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Ngày Chính Thức",
    accessor: "ngayChinhThuc",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Cơ Quan Tuyển Dụng",
    accessor: "coQuanTuyenDung",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngạch Công Chức",
    accessor: "ngachCongChucNoiDung",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngày Vào Đảng",
    accessor: "ngayVaoDang",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Vào Đảng Chính Thức",
    accessor: "ngayVaoDangChinhThuc",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Ngày Nhập Ngũ",
    accessor: "ngayNhapNgu",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Ngày Xuất Ngũ",
    accessor: "ngayXuatNgu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Quân Hàm Cao Nhất",
    accessor: "quanHamCaoNhat",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Danh Hiệu Cao Nhất",
    accessor: "danhHieuCaoNhat",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Ngày Vào Đoàn",
    accessor: "ngayVaoDoan",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Nơi Tham Gia",
    accessor: "noiThamGia",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Là Thương Binh",
    accessor: "laThuongBinh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Là Con Chính Sách",
    accessor: "laConChinhSach",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },

  {
    Header: "BHXH",
    accessor: "bhxh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "BHYT",
    accessor: "bhyt",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Tài Khoản Ngân Hàng",
    accessor: "atm",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngân Hàng",
    accessor: "nganHang",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },

  {
    Header: "Ngày Nghỉ Việc",
    accessor: "ngayNghiViec",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: false,
  },
  {
    Header: "Lý do Nghỉ Việc",
    accessor: "lyDoNghiViec",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },

  {
    Header: "Tính Chất Lao Động",
    accessor: "tinhChatLaoDong",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Hôn Nhân",
    accessor: "danhMucHonNhan",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Dân Tộc",
    accessor: "danToc",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Tôn Giáo",
    accessor: "tonGiao",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ban",
    accessor: "phongBan",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: false,

    show: true,
  },
  {
    Header: "Tổ",
    accessor: "to",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Ngạch Công Chức",
    accessor: "ngachCongChuc",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Trạng Thái Lao Động",
    accessor: "trangThaiLaoDong",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: false,

    show: true,
  },
];
