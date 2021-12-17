import NumberFormat from "react-number-format";
import SelectColumnFilter from "../../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã Chức Danh",
    accessor: "maChucDanh",
    sticky: "left",
    minWidth: 350,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tên Chức Danh",
    accessor: "tenChucDanh",
    sticky: "left",
    minWidth: 310,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },

  {
    Header: "Phụ Cấp",
    accessor: "phuCap",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return (
        <NumberFormat
          value={value}
          displayType="text"
          type="text"
          thousandSeparator={true}
        />
      );
    },
  },
];
