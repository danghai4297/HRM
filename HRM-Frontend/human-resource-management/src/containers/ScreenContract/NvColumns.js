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

export const NVCOLUMNSHD = [
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
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Mã Hợp Đồng",
    accessor: "maHopDong",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Loại Hợp Đồng",
    accessor: "idLoaiHopDong",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },

  {
    Header: "Chức Danh",
    accessor: "idChucDanh",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Từ Ngày",
    accessor: "hopDongTuNgay",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },

    show: true,
  },
  {
    Header: "Đến Ngày",
    accessor: "hopDongDenNgay",
    minWidth: 150,
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
    minWidth: 400,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
];
