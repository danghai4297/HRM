import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "Ảnh",
    accessor: "anh",
    sticky: "left",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Mã nhân viên",
    accessor: "maNhanVien",
    sticky: "left",
    minWidth: 200,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Họ Tên",
    accessor: "hoTen",
    sticky: "left",
    minWidth: 250,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },

  {
    Header: "Mục Khen thưởng",
    accessor: "idDanhMucKhenThuong",
    minWidth: 408,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Nội dung",
    accessor: "noiDung",
    minWidth: 440,
    Filter: SelectColumnFilter,
    disableFilters: true,

    show: true,
  },
  {
    Header: "Kỷ luật",
    accessor: () => {
      return <img src="/Images/redcard.png" width={20} alt="" />;
    },
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Kỷ luật K2",
    accessor: "loai",
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
  {
    Header: "Lý do",
    accessor: "lyDo",
    minWidth: 500,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: false,
  },
];
