import { format } from "date-fns";
import NumberFormat from "react-number-format";
import SelectColumnFilter from "../../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSSALARY = [
  {
    Header: "Mã Nhân Viên",
    accessor: "maNhanVien",
    sticky: "left",
    Filter: SelectColumnFilter,
    minWidth: 50,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Họ Và Tên",
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tổng Lương",
    accessor: "tongLuong",
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
    Header: "Mã Hợp Đồng",
    accessor: "maHopDong",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã Lương",
    accessor: "id",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },

  {
    Header: "Nhóm Lương",
    accessor: "nhomLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    show: true,
  },

  {
    Header: "Hệ Số Lương",
    accessor: "heSoLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Bậc Lương",
    accessor: "bacLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Lương Cơ Bản",
    accessor: "luongCoBan",
    minWidth: 70,
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
    Header: "Phụ Cấp Trách Nhiệm",
    accessor: "phuCapTrachNhiem",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Phụ Cấp Khác",
    accessor: "phuCapKhac",
    minWidth: 70,
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
    show: false,
  },
  {
    Header: "Thời Hạn Lên Lương",
    accessor: "thoiHanLenLuong",
    minWidth: 180,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Ngày Hiệu Lực",
    accessor: "ngayHieuLuc",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Ngày Lên Lương",
    accessor: "ngayKetThuc",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
    show: true,
  },
  {
    Header: "Trạng Thái",
    accessor: (row) => {
      return row.trangThai === "Kích hoạt" ? (
        <img src="/Images/greenC.png" width={20} alt="" />
      ) : (
        <img src="/Images/orangeC.png" width={20} alt="" />
      );
    },
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSHD = [
  {
    Header: "Mã Nhân Viên",
    accessor: "maNhanVien",
    sticky: "left",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Và Tên",
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Mã Hợp Đồng",
    accessor: "id",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Loại Hợp Đồng",
    accessor: "loaiHopDong",
    minWidth: 200,
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
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
