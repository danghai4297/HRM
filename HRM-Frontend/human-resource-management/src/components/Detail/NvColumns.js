import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSTDVH = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tên trường",
    accessor: "tdvhTenTruong",
    sticky: "left",
    minWidth: 264,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Chuyên môn",
    accessor: "tdvhChuyenMon",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Bắt đầu",
    accessor: "tdvhtuThoiGian",
    minWidth: 180,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Kết thúc",
    accessor: "tdvhdenThoiGian",
    minWidth: 180,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Hình thức đào tạo",
    accessor: "tdvhHinhThucDaoTao",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tốt nghiệp loại",
    accessor: "tdvhTrinhDo",
    minWidth: 140,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSHD = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Lương cơ bản",
    accessor: "luongCoBan",
    sticky: "left",
    minWidth: 205,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Chức danh",
    accessor: "chucDanh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Bắt đầu",
    accessor: "hdHopDongTuNgay",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Kết thúc",
    accessor: "hdHopDongDenNgay",
    minWidth: 194,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Hình thức đào tạo",
    accessor: "hdGhiChu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tốt nghiệp loại",
    accessor: "trangThai",
    minWidth: 175,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSDC = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Phòng",
    accessor: "dcPhong",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tổ",
    accessor: "dcTo",
    minWidth: 224,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày hiệu lực",
    accessor: "dcNgayHieuLuc",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Chi tiết",
    accessor: "dcChiTiet",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Chức vụ",
    accessor: "dcChucVu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSNN = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngoại ngữ",
    accessor: "nnDanhMucNgoaiNgu",
    sticky: "left",
    minWidth: 289,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày cấp",
    accessor: "nnNgayCap",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Trình độ",
    accessor: "nnTrinhDo",
    minWidth: 270,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Nơi cấp",
    accessor: "nnNoiCap",
    minWidth: 265,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSNT = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Tên",
    accessor: "ntTenNguoiThan",
    sticky: "left",
    minWidth: 205,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Giới tính",
    accessor: "ntGioiTinh",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày sinh",
    accessor: "ntNgaySinh",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Quan hệ",
    accessor: "ntQuanHe",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Nghề nghiệp",
    accessor: "ntNgheNghiep",
    minWidth: 219,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Địa chỉ",
    accessor: "ntDiaChi",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Điên thoại",
    accessor: "ntDienThoai",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSKTvKL = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Danh mục",
    accessor: "ktklDanhMucKhenThuong",
    sticky: "left",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Nội dung",
    accessor: "ktklNoiDung",
    sticky: "left",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Lý do",
    accessor: "ktklLyDo",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Loại",
    accessor: "ktklloai",
    minWidth: 224,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
export const NVCOLUMNSL = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Mã hợp đồng",
    accessor: "maHopDong",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tổng lương",
    accessor: "tongLuong",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Nhóm lương",
    accessor: "nhomLuong",
    minWidth: 155,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Hệ số lương",
    accessor: "heSoLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Bậc lương",
    accessor: "bacLuong",
    minWidth: 219,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Lương cơ bản",
    accessor: "luongCoBan",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Phụ cấp trách nhiệm",
    accessor: "phuCapTrachNhiem",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
