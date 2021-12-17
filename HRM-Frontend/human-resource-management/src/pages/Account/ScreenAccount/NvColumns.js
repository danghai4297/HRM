import { format } from "date-fns";
import SelectColumnFilter from "../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSHD = [
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Và Tên",
    accessor: "fullName",
    minWidth: 280,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Điện thoại",
    accessor: "phoneNumber",
    minWidth: 250,
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
    minWidth: 350,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
];
