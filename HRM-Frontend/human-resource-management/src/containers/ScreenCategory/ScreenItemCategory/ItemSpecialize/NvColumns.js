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
    Header: "Mã Chuyên môn",
    accessor: "maChuyenMon",
    sticky: "left",
    minWidth: 500,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tên chuyên môn",
    accessor: "tenChuyenMon",
    sticky: "left",
    minWidth: 380,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
