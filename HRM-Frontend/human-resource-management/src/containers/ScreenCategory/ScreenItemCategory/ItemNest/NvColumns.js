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
    Header: "Mã tổ",
    accessor: "maTo",
    sticky: "left",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tên tổ",
    accessor: "tenTo",
    sticky: "left",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },

  {
    Header: "Mã Phòng ban",
    accessor: "idPhongBan",
    minWidth: 250,
    Filter: SelectColumnFilter,

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
