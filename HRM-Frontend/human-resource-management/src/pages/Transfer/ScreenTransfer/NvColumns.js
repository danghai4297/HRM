import { format } from "date-fns";
import SelectColumnFilter from "../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    Filter: SelectColumnFilter,
    minWidth: 200,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    sticky: "left",
    maxWidth: 190,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Họ tên",
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Ngày Hiệu lực",
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
    Header: "Phòng ban",
    accessor: "phongBan",
    minWidth: 348,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tổ",
    accessor: "to",
    minWidth: 250,
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
    Header: "Trạng thái",
    accessor: (row) => {
      return row.trangThai === "Kích hoạt" ? (
        <img src="/Images/greenC.png" width={20} alt="" />
      ) : (
        <img src="/Images/orangeC.png" width={20} alt="" />
      );
    },
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Trạng thái",

    accessor: "trangThai",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: false,
    show: false,
  },
];
