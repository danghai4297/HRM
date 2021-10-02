import React from "react";
import "./ScreenProject.scss";

import Header from "../Header/Header";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
import AddProfile from "../ScreenAddProfile/ScreenAddProfile";
import ScreenAddContract from "../ScreenAddContract/ScreenAddContract";
import ScreenAddSalary from "../ScreenAddSalary/ScreenAddSalary";
import ScreenAddTransfer from "../ScreenAddTransfer/ScreenAddTransfer";
import ScreenAddResignation from "../ScreenAddResignation/ScreenAddResignation";
function ScreenProject(props) {
  return (
    <div className="body-screen">
      <div className="header">
        <Header />
      </div>
      <div className="body-contents">
        <div className="menu-bar">
          <SideBarLeft />
        </div>
        <div className="content">
          {/* Noi dung trang */}
          {/* <AddProfile /> */}
          {/* <ScreenAddContract /> */}
          {/* <ScreenAddSalary /> */}
          {/* <ScreenAddTransfer /> */}
          <ScreenAddResignation/>
        </div>
      </div>
    </div>
  );
}

export default ScreenProject;
