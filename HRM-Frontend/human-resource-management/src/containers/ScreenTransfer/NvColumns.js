import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

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
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    sticky: "left",
    minWidth: 200,
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
    Header: "Ngày Hiệu lực",
    accessor: "ngayHieuLuc",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },

  {
    Header: "Phòng ban",

    accessor: "idPhongBan",
    minWidth: 200,
    Filter: SelectColumnFilter,

    show: true,
  },
  {
    Header: "Tổ",
    accessor: "to",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Chi tiết",
    accessor: "chiTiet",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Chức vụ",
    accessor: "idChucVu",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Trạng thái",
    accessor: "trangThai",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    disableFilters: true,
    show: true,
  },
];
