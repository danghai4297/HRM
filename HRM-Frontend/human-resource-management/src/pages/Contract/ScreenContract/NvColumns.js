import { format } from "date-fns";
import NumberFormat from "react-number-format";
import SelectColumnFilter from "../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSHD = [
  {
    Header: "Mã Nhân Viên",
    accessor: "maNhanVien",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Và Tên",
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 180,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Mã Hợp Đồng",
    accessor: "id",
    minWidth: 130,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
  {
    Header: "Loại Hợp Đồng",
    accessor: "loaiHopDong",
    minWidth: 218,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },

  {
    Header: "Chức Danh",
    accessor: "chucDanh",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Phụ Cấp Chức Danh",
    accessor: "phuCapChucDanh",
    minWidth: 170,
    Filter: SelectColumnFilter,
    disableFilters: true,
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
    show: true,
  },
  {
    Header: "Chức Vụ",
    accessor: "chucVu",
    minWidth: 80,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Phụ Cấp Chức Vụ",
    accessor: "phuCapChucVu",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
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
    show: true,
  },
  {
    Header: "Từ Ngày",
    accessor: "hopDongTuNgay",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },

    show: true,
  },
  {
    Header: "Đến Ngày",
    accessor: "hopDongDenNgay",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },

    show: true,
  },
  {
    Header: "Trạng thái",
    accessor: (row) => {
      return row.trangThai === "Kích hoạt" ? (
        <img src="/Images/greenC.png" width={20} alt="" />
      ) : (
        <img src="/Images/orangeC.png" width={20} alt="" />
      );
    },
    minWidth: 20,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Trạng thái",

    accessor: "trangThai",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: false,
    show: false,
  },
  {
    Header: "Ghi chú",
    accessor: "ghiChu",
    minWidth: 400,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: false,
  },
];
