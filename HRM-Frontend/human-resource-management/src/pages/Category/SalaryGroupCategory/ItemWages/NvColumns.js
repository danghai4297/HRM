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
    Header: "Mã nhóm lương",
    accessor: "maNhomLuong",
    sticky: "left",
    minWidth: 380,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tên nhóm lương",
    accessor: "tenNhomLuong",
    sticky: "left",
    minWidth: 500,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
