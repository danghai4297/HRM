import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    minWidth: 80,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tên nhân viên",
    accessor: "tenNhanVien",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: false,
    show: true,
  },
  {
    Header: "Tên tài khoản",
    accessor: "tenTaiKhoan",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Thao tác",
    accessor: "thaoTac",
    minWidth: 580,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Thời gian",
    accessor: "ngayThucHien",
    minWidth: 268,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy-hh:mm:ss");
    },

    show: true,
  },
];
