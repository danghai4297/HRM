import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    Filter: SelectColumnFilter,
    disableFilters: true,
  },
  {
    Header: "First Name",
    accessor: "firstName",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
  },
  {
    Header: "Last Name",
    accessor: "lastName",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
  },
  {
    Header: "Email",
    accessor: "email",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
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
  },
  {
    Header: "Birthday",
    accessor: "birthday",
    minWidth: 200,
    Filter: SelectColumnFilter,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Salary",
    accessor: "salary",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
  },
  {
    Header: "Phone",
    accessor: "phone",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
  },
];
