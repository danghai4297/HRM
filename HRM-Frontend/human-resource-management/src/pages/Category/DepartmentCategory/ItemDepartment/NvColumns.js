import SelectColumnFilter from "../../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 380,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã Phòng ban",
    accessor: "maPhongBan",
    sticky: "left",
    minWidth: 380,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Phòng ban",
    accessor: "tenPhongBan",
    sticky: "left",
    minWidth: 500,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
