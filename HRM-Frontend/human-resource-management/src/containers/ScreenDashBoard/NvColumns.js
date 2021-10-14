import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSSALARY = [
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    sticky: "left",
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Họ tên",
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tổng lương",
    accessor: "tongLuong",
    minWidth: 100,
    sticky: "left",
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã hợp đồng",
    accessor: "maHopDong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã Lương",
    accessor: "id",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },

  {
    Header: "Nhóm lương",
    accessor: "nhomLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
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
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Lương cơ bản",
    accessor: "luongCoBan",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Phụ cấp trách nhiệm",
    accessor: "phuCapTrachNhiem",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Phụ cấp khác",
    accessor: "phuCapKhac",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Thời hạn lên lương",
    accessor: "thoiHanLenLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Ngày hiệu lực",
    accessor: "ngayHieuLuc",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Ngày lên lương",
    accessor: "ngayKetThuc",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Ghi chú",
    accessor: "ghiChu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Trạng thái",
    accessor: "trangThai",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
];

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    minWidth: 189,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã Phòng ban",
    accessor: "maPhongBan",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Phòng ban",
    accessor: "tenPhongBan",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
