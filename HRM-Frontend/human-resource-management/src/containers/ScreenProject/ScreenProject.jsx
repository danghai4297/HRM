import React from "react";
import "./ScreenProject.scss";

import Header from "../../components/Header/Header";
import SideBarLeft from "../../components/SideBarLeft/SideBarLeft";
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from "react-router-dom";
import DashBoard from "../ScreenDashBoard/DashBoard";
import ScreenTableNV from "../ScreenTableNV/ScreenTableNV";
import Detail from "../../components/Detail/Detail";
import ScreenContract from "../ScreenContract/ScreenContract";
import ScreenSalary from "../ScreenSalary/ScreenSalary";
import ScreenCategory from "../ScreenCategory/ScreenCategory";
import ScreenResign from "../ScreenResign/ScreenResign";
import ScreenReward from "../ScreenReward/ScreenReward";
import ScreenDiscipline from "../ScreenDiscipline/ScreenDiscipline";
import ScreenReport from "../ScreenReport/ScreenReport";
import ScreenNotFound from "./ScreenNotFound";
import ScreenTransfer from "../ScreenTransfer/ScreenTransfer";
import AddProfile from "../ScreenAddProfile/ScreenAddProfile";

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
              <Route exact path="/">
                <Redirect to="/home" />
              </Route>
              <Route exact path="/home" component={DashBoard} />

              <Route exact path="/profile" component={ScreenTableNV} />
              <Route path="/profile/:id" component={Detail} />
              
              <Route exact path="/contract" component={ScreenContract} />

              <Route exact path="/salary" component={ScreenSalary} />

              <Route path="/category" component={ScreenCategory} />

              <Route exact path="/transfer" component={ScreenTransfer}/>

              <Route exact path="/resign" component={AddProfile} />

              <Route exact path="/reward" component={ScreenReward} />

              <Route exact path="/discipline" component={ScreenDiscipline} />

              <Route exact path="/report" component={ScreenReport} />
              <Route path="*" component={ScreenNotFound} />
            </Switch>
          </div>
        </div>
      </div>
    </Router>
  );
}

export default ScreenProject;
