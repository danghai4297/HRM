import { format } from "date-fns";
import NumberFormat from "react-number-format";
import SelectColumnFilter from "../../../components/TablePagination/SelectColumnFilter";

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
    minWidth: 260,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Chuyên môn",
    accessor: "tdvhChuyenMon",
    minWidth: 249,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Bắt đầu",
    accessor: "tdvhtuThoiGian",
    minWidth: 180,
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
    minWidth: 120,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSHD = [
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
    Header: "Loại hợp đồng",
    accessor: "idLoaiHopDong",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Chức danh",
    accessor: "idChucDanh",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Bắt đầu",
    accessor: "hdHopDongTuNgay",
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
    accessor: "hdHopDongDenNgay",
    minWidth: 190,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Ghi trú",
    accessor: "hdGhiChu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
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
    minWidth: 179,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSDC = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Phòng",
    accessor: "dcPhong",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tổ",
    accessor: "dcTo",
    minWidth: 219,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày hiệu lực",
    accessor: "dcNgayHieuLuc",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Chi tiết",
    accessor: "dcChiTiet",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Chức vụ",
    accessor: "dcChucVu",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSNN = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngoại ngữ",
    accessor: "nnDanhMucNgoaiNgu",
    sticky: "left",
    minWidth: 280,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Ngày cấp",
    accessor: "nnNgayCap",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },

  {
    Header: "Trình độ",
    accessor: "nnTrinhDo",
    minWidth: 270,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Nơi cấp",
    accessor: "nnNoiCap",
    minWidth: 269,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSNT = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Họ Tên",
    accessor: "ntTenNguoiThan",
    sticky: "left",
    minWidth: 205,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Giới Tính",
    accessor: (row) => {
      return row.ntGioiTinh === "Nam" ? (
        <img src="/Images/male.png" width={20} alt="" />
      ) : (
        <img src="/Images/female.png" width={20} alt="" />
      );
    },
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },

  {
    Header: "Ngày sinh",
    accessor: "ntNgaySinh",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Quan hệ",
    accessor: "ntQuanHe",
    minWidth: 70,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Nghề nghiệp",
    accessor: "ntNgheNghiep",
    minWidth: 214,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Địa chỉ",
    accessor: "ntDiaChi",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Điên thoại",
    accessor: "ntDienThoai",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];

export const NVCOLUMNSKTvKL = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Danh mục",
    accessor: "ktklDanhMucKhenThuong",
    sticky: "left",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Nội dung",
    accessor: "ktklNoiDung",
    sticky: "left",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Lý do",
    accessor: "ktklLyDo",
    minWidth: 300,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Loại",
    accessor: (row) => {
      return row.ktklloai === "Khen Thưởng" ? (
        <img src="/Images/medal.png" width={20} alt="" />
      ) : (
        <img src="/Images/redcard.png" width={20} alt="" />
      );
    },
    minWidth: 219,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
];
export const NVCOLUMNSL = [
  {
    Header: "ID",
    accessor: "id",
    sticky: "left",
    maxWidth: 69,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Mã hợp đồng",
    accessor: "maHopDong",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Tổng lương",
    accessor: "tongLuong",
    sticky: "left",
    minWidth: 70,
    Filter: SelectColumnFilter,
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
    disableFilters: true,

    show: true,
  },
  {
    Header: "Nhóm lương",
    accessor: "nhomLuong",
    minWidth: 150,
    Filter: SelectColumnFilter,
    disableFilters: true,
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
    minWidth: 60,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Lương cơ bản",
    accessor: "luongCoBan",
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
    show: false,
  },
  {
    Header: "Phụ cấp trách nhiệm",
    accessor: "phuCapTrachNhiem",
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
    show: false,
  },

  {
    Header: "Ngày hiệu lực",
    accessor: "ngayHieuLuc",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Ngày kết thúc",
    accessor: "ngayKetThuc",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
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
