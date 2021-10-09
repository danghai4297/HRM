import SelectColumnFilter from "../../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 630,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tôn giáo",
    accessor: "tenDanhMuc",
    sticky: "left",
    minWidth: 630,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
