import React, { useContext } from "react";
import "./DashBoard.scss";
import Header from "../Header/Header";
import ItemDashBoard from "../ItemDashBoard/ItemDashBoard";
import ItemExcel from "../ItemExcel/ItemExcel";

import SideBarLeft from "../SideBarLeft/SideBarLeft";

DashBoard.propTypes = {};

function DashBoard(props) {
  return (
    <div className="dash-board">
      <div className="header sticky-top">
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
          <div className="two-table"></div>
        </div>
      </div>
      //{" "}
    </div>
  );
}

export default DashBoard;
