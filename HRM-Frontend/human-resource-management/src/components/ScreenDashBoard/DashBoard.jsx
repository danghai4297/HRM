import React, { useContext } from "react";
import PropTypes from "prop-types";
import "./DashBoard.scss";
import Header from "../Header/Header";
import ItemDashBoard from "../ItemDashBoard/ItemDashBoard";
import ItemExcel from "../ItemExcel/ItemExcel";

import { ListContext } from "../../Contexts/ListContext";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
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
  const { list } = useContext(ListContext);
  console.log(list);

  return (
    <>
      <div className="item-dash-board">
        <div className="item-da">
          <ItemDashBoard
            totalEmployees="110"
            fontIcon="users"
            title="nhan vien"
          />
        </div>
        <div className="item-da">
          <ItemDashBoard
            totalEmployees="11"
            fontIcon="building"
            title="Phong ban"
          />
        </div>
        <div className="item-da">
          <ItemDashBoard
            totalEmployees="110"
            fontIcon="money-check-alt"
            title="Luong n.vien"
          />
        </div>
        <div className="item-da">
          <ItemDashBoard
            totalEmployees="12"
            fontIcon="users-slash"
            title="N.vien nghi viec"
          />
        </div>
      </div>
      <div className="excel-item">
        <div className="item-da">
          <ItemExcel title="nhan vien" />
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
