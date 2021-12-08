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
    Header: "Mã hợp đồng",
    accessor: "maLoaiHopDong",
    sticky: "left",
    minWidth: 380,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tên hợp đồng",
    accessor: "tenLoaiHopDong",
    sticky: "left",
    minWidth: 500,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
