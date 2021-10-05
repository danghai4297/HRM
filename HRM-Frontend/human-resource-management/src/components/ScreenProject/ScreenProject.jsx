import React from "react";
import "./ScreenProject.scss";

import Header from "../Header/Header";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { RouterLink } from "./RouterLink";
import DashBoard from "../ScreenDashBoard/DashBoard";
import Detail from "../Detail/Detail";
import ScreenReport from "../ScreenReport/ScreenReport";
import ScreenDiscipline from "../ScreenDiscipline/ScreenDiscipline";
import ScreenReward from "../ScreenReward/ScreenReward";
import ScreenResign from "../ScreenResign/ScreenResign";
import ScreenTransfer from "../ScreenTransfer/ScreenTransfer";
import ScreenCategory from "../ScreenCategory/ScreenCategory";
import ScreenSalary from "../ScreenSalary/ScreenSalary";
import ScreenTableNV from "../ScreenTableNV/ScreenTableNV";
import ScreenContract from "../ScreenContract/ScreenContract";

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
            <Switch>
              <Route exact path="/" component={DashBoard} />

              <Route path="/profile" component={ScreenTableNV} />
              <Route path="/detail/:id" component={Detail} />

              <Route path="/contract" component={ScreenContract} />

              <Route path="/salary" component={ScreenSalary} />

              <Route path="/category" component={ScreenCategory} />

              <Route path="/transfer" component={ScreenTransfer} />

              <Route path="/resign" component={ScreenResign} />

              <Route path="/reward" component={ScreenReward} />

              <Route path="/discipline" component={ScreenDiscipline} />

              <Route path="/report" component={ScreenReport} />
            </Switch>
          </div>
        </div>
      </div>
    </Router>
  );
}

export default ScreenProject;
