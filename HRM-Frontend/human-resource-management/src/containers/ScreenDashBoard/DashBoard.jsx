import React, { useContext } from "react";
import "./DashBoard.scss";

import { ListContext } from "../../Contexts/ListContext";
import ItemDashBoard from "../../components/ItemDashBoard/ItemDashBoard";
import ItemExcel from "../../components/ItemExcel/ItemExcel";
import TablePagination from "../../components/TablePagination/TablePagination";
import SelectColumnFilter from "../../components/TablePagination/SelectColumnFilter";

DashBoard.propTypes = {};

function DashBoard(props) {
  const columns = [
    {
      Header: "ID",
      accessor: "id",
      sticky: "left",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "First Name",
      accessor: "firstName",
      sticky: "left",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Last Name",
      accessor: "lastName",
      sticky: "left",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Email",
      accessor: "email",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Gender",
      accessor: "gender",
      Filter: SelectColumnFilter,
    },
    {
      Header: "Birthday",
      accessor: "birthday",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Salary",
      accessor: "salary",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Phone",
      accessor: "phone",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
  ];
  const fileName = "DSNV";
  const { list } = useContext(ListContext);
  // const [dataEp, setDataEp] = useState(list);
  // const newData = [];

  // useEffect(() => {
  //   list.map((item) => {
  //     item.gender === true ? (item.gender = "Nam") : (item.gender = "Nữ");
  //     newData.push(item);
  //   });
  //   setDataEp(newData);
  //   return () => {
  //     list.map((item) => {
  //       item.gender === "Nam" ? (item.gender = true) : (item.gender = false);
  //       newData.push(item);
  //     });
  //     setDataEp(newData);
  //   };
  // }, []);

  return (
    <>
      <div className="Screen-dash-board">
        <div className="item-dash-board">
          <div className="item-da">
            <ItemDashBoard
              totalEmployees="110"
              fontIcon="users"
              title="nhan vien"
              link="/profile"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees="11"
              fontIcon="building"
              title="Phong ban"
              link=""
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees="110"
              fontIcon="money-check-alt"
              title="Luong n.vien"
              link="/salary"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees="12"
              fontIcon="users-slash"
              title="N.vien nghi viec"
              link="/resign"
            />
          </div>
        </div>
        <div className="excel-item">
          <div className="item-da">
            <ItemExcel dataXp={list} fileName={fileName} title="nhan vien" />
          </div>
          <div className="item-da">
            <ItemExcel title="luong nhan vien" />
          </div>
        </div>
        <div className="two-table">
          <div className="tablex table-one">
            <TablePagination columns={columns} data={list} />
          </div>
          <div className="tablex table-two">
            <TablePagination columns={columns} data={list} />
          </div>
        </div>
      </div>
    </>
  );
}

export default DashBoard;
