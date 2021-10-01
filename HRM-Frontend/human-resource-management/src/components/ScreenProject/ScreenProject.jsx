import React from "react";
import "./ScreenProject.scss";

import Header from "../Header/Header";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
import {BrowserRouter as Router, Route } from "react-router-dom";

import Detail from "../Detail/Detail";
import ScreenProfile from "../ScreenProfile/ScreenProfile";
import ScreenContract from "../ScreenContract/ScreenContract";
import ScreenSalary from "../ScreenSalary/ScreenSalary";
import ScreenCategory from "../ScreenCategory/ScreenCategory";
import ScreenTransfer from "../ScreenTransfer/ScreenTransfer";
import ScreenResign from "../ScreenResign/ScreenResign";
import ScreenReward from "../ScreenReward/ScreenReward";
import ScreenDiscipline from "../ScreenDiscipline/ScreenDiscipline";
import ScreenReport from "../ScreenReport/ScreenReport";
function ScreenProject() {
  return (
    <Router>
      <div className="body-screen">
        <div className="header">
          <Header />
        </div>
        <div className="body-contents">
          <div className="menu-bar">
            <SideBarLeft />
          </div>
          <div className="content">
            <Route exact path="/" component={Detail} />
            <Route path="/profile" component={ScreenProfile} />
            <Route path="/contract" component={ScreenContract} />
            <Route path="/salary" component={ScreenSalary} />
            <Route path="/category" component={ScreenCategory} />
            <Route path="/transfer" component={ScreenTransfer} />
            <Route path="/resign" component={ScreenResign} />
            <Route path="/reward" component={ScreenReward} />
            <Route path="/discipline" component={ScreenDiscipline} />
            <Route path="/report" component={ScreenReport} />
          </div>
        </div>
      </div>
     </Router>
  );
}

export default ScreenProject;
