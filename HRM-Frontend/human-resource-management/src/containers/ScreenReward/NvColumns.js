import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "Ảnh",
    accessor: "anh",
    sticky: "left",
    minWidth: 60,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    sticky: "left",
    minWidth: 60,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Họ Tên",
    accessor: "hoTen",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },

  {
    Header: "Mục Khen thưởng",
    accessor: "idDanhMucKhenThuong",
    minWidth: 320,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Nội dung",
    accessor: "noiDung",
    minWidth: 340,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Lý do",
    accessor: "lyDo",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    disableFilters: true,
    show: true,
  },
];
