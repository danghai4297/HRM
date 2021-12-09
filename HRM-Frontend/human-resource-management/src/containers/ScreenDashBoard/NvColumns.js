import { format } from "date-fns";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNSSALARY = [
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    sticky: "left",
    Filter: SelectColumnFilter,
    minWidth: 50,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Họ tên",
    accessor: "tenNhanVien",
    sticky: "left",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Tổng lương",
    accessor: "tongLuong",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã hợp đồng",
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
    Header: "Nhóm lương",
    accessor: "nhomLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    show: true,
  },

  {
    Header: "Hệ số lương",
    accessor: "heSoLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Bậc lương",
    accessor: "bacLuong",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Lương cơ bản",
    accessor: "luongCoBan",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Phụ cấp trách nhiệm",
    accessor: "phuCapTrachNhiem",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Phụ cấp khác",
    accessor: "phuCapKhac",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Thời hạn lên lương",
    accessor: "thoiHanLenLuong",
    minWidth: 180,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Ngày hiệu lực",
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
    Header: "Ngày lên lương",
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
    Header: "Trạng thái",
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
    minWidth: 150,
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
