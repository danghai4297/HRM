import React, { useContext, useEffect, useState } from "react";
import "./DashBoard.scss";
import ItemDashBoard from "../ItemDashBoard/ItemDashBoard";
import ItemExcel from "../ItemExcel/ItemExcel";

import { ListContext } from "../../Contexts/ListContext";
import TablePagination from "../TablePagination/TablePagination";
import SelectColumnFilter from "../TablePagination/SelectColumnFilter";

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
  const [dataXp, setDataXp] = useState(list);

  useEffect(() => {
    const newData = [];
    dataXp.map((item) => {
      item.gender === true ? (item.gender = "nam") : (item.gender = "nu");
      newData.push(item);
    });
    setDataXp(newData);
    console.log(dataXp);
  }, []);

  return (
    <>
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
          <ItemExcel dataXp={dataXp} fileName={fileName} title="nhan vien" />
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
    </>
  );
}

export default DashBoard;
