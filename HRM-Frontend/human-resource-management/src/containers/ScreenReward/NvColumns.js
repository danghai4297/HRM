import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

export const NVCOLUMNS = [
  {
    Header: "Ảnh",
    accessor: (row) => {
      return row.anh === null ? (
        <img src="/Images/loginImage.png" width={60} alt="" />
      ) : (
        <img src={`https://localhost:5001${row.anh}`} width={60} alt="" />
      );
    },
    sticky: "left",
    minWidth: 50,
    Filter: SelectColumnFilter,
    disableFilters: true,
    // Cell: ({ value }) => <img src={value} width={50} />,

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
    Header: "Khen thưởng",
    accessor: () => {
      return <img src="/Images/medal.png" width={20} alt="" />;
    },
    minWidth: 100,
    Filter: SelectColumnFilter,
    disableFilters: true,
    show: true,
  },
  {
    Header: "Khen thưởng",
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
