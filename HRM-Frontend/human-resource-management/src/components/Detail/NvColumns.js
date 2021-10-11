import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSTDVH = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tên trường",
    accessor: "tdvhTenTruong",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Chuyên môn",
    accessor: "tdvhChuyenMon",
    minWidth: 130,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Bắt đầu",
    accessor: "tdvhtuThoiGian",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Kết thúc",
    accessor: "tdvhdenThoiGian",
    minWidth: 180,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Hình thức đào tạo",
    accessor: "tdvhHinhThucDaoTao",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tốt nghiệp loại",
    accessor: "tdvhTrinhDo",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
