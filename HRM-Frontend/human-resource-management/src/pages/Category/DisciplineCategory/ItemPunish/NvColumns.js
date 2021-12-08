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
    Header: "Tên Danh Mục",
    accessor: "tenDanhMuc",
    sticky: "left",
    minWidth: 500,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tiêu đề",
    accessor: "tieuDe",
    sticky: "left",
    minWidth: 380,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
