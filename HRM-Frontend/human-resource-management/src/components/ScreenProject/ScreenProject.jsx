import React from "react";
import "./ScreenProject.scss";

import Header from "../Header/Header";
import SideBarLeft from "../SideBarLeft/SideBarLeft";

import PropTypes from "prop-types";
import ScreenTableNV from "../ScreenTableNV/ScreenTableNV";

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
          <ScreenTableNV />
        </div>
      </div>
    </div>
  );
}

export default ScreenProject;
