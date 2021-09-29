import React, { useContext } from "react";
import PropTypes from "prop-types";
import "./DashBoard.scss";
import Header from "../Header/Header";
import ItemDashBoard from "../ItemDashBoard/ItemDashBoard";
import ItemExcel from "../ItemExcel/ItemExcel";

import { ListContext } from "../../Contexts/ListContext";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
import TablePagination from "../TablePagination/TablePagination";

DashBoard.propTypes = {};

function DashBoard(props) {
  const columns = [
    {
      Header: "ID",
      accessor: "id",
    },
    {
      Header: "First Name",
      accessor: "firstName",
    },
    {
      Header: "Last Name",
      accessor: "lastName",
    },
    {
      Header: "Email",
      accessor: "email",
    },
    {
      Header: "Gender",
      accessor: "gender",
    },
    // {
    //   Header: "Birthday",
    //   accessor: "birthday",
    // },
    {
      Header: "Salary",
      accessor: "salary",
    },
    {
      Header: "Phone",
      accessor: "phone",
    },
  ];

  const { list } = useContext(ListContext);
  console.log(list);

  return (
    <div className="dash-board">
      <div className="header">
        <Header />
      </div>
      <div className="body-contents">
        <div className="menu-bar">
          <SideBarLeft />
        </div>
        <div className="content">
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
        </div>
      </div>
    </div>
  );
}

export default DashBoard;
