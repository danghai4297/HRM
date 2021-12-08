import { format } from "date-fns";
import SelectColumnFilter from "../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSHD = [
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Và Tên",
    accessor: "fullName",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Điện thoại",
    accessor: "phoneNumber",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tài khoản",
    accessor: "userName",
    minWidth: 238,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },

  {
    Header: "Email",
    accessor: "email",
    minWidth: 280,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày sinh",
    accessor: "dob",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },

    show: true,
  },
  {
    Header: "Chức vụ",
    accessor: "roles",
    minWidth: 280,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
];
