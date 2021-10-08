import React, { useState } from "react";
import "./ScreenProject.scss";

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
import ScreenTransfer from "../ScreenTransfer/ScreenTransfer";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../../components/Header/Header.scss";
import ScreenDetailSalary from "../ScreenDetailSalary/ScreenDetailSalary";
import AddProfileForm from "../../components/AddProfileForm/addProfileForm";
import ScreenDetailContract from "../ScreenDetailContract/ScreenDetailContract";
import AddContractForm from "../../components/AddContractForm/AddContractForm";
import AddSalaryForm from "../../components/AddSalaryForm/AddSalaryForm";
import ScreenDetailTransfer from "../ScreenDetailTransfer/ScreenDetailTransfer";
import AddTransferForm from "../../components/AddTransferForm/AddTransferForm";
import ScreenDetailResign from "../ScreenDetailResign/ScreenDetailResign";
import AddResignationForm from "../../components/AddResignationForm/AddResignationForm";
import AddRewardForm from "../../components/AddRewardForm/AddRewardForm";
import AddDisciplineForm from "../../components/AddDisciplineForm/AddDisciplineForm";
import ScreenDetailReward from "../ScreenDetailReward/ScreenDetailReward";
import ScreenDetailDiscipline from "../ScreenDetailDiscipline/ScreenDetailDiscipline";

function ScreenProject() {
  const [account, setAccount] = useState(false);
  const visionHandleClick = () => {
    setAccount(!account);
  };
  const closeHandleClick = () => {
    if (account !== false) {
      setAccount(false);
    }
  };
  return (
    <Router>
      <div className="body-screen" onClick={closeHandleClick}>
        <div className="header">
          <div className="header-com">
            <div className="name">
              <div className="title-project">
                <h1>3HMD</h1>
              </div>
            </div>
            <div className="account">
              <button className="button-top" onClick={visionHandleClick}>
                <div className="screen-account">
                  <div className="header-icon">
                    <FontAwesomeIcon
                      icon={["fas", "user-circle"]}
                      className="detail-icon"
                    />
                  </div>
                  <div className="account-name">
                    <h5 className="account-style">DangHai</h5>
                  </div>
                </div>
              </button>

              {account && (
                <div className="detail-information">
                  <div className="first-information">
                    <div className="detail-second-icon">
                      <FontAwesomeIcon icon={["fas", "user-circle"]} />
                    </div>
                    <div>
                      <h5>DangHai</h5>
                    </div>
                    <div>
                      <button className="button-account">
                        <FontAwesomeIcon icon={["fas", "key"]} /> Đổi mật khẩu
                      </button>
                    </div>
                  </div>
                  <div>
                    <button className="button-account">
                      <FontAwesomeIcon icon={["fas", "sign-out-alt"]} /> Đăng
                      xuất
                    </button>
                  </div>
                </div>
              )}
            </div>
          </div>
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
              <Route exact path="/profile/detail/:id" component={Detail} />
              <Route exact path="/profile/add" component={AddProfileForm} />

              <Route exact path="/contract" component={ScreenContract} />
              <Route
                exact
                path="/contract/detail/:id"
                component={ScreenDetailContract}
              />
              <Route exact path="/contract/add" component={AddContractForm} />

              <Route exact path="/salary" component={ScreenSalary} />
              <Route
                exact
                path="/salary/detail/:id"
                component={ScreenDetailSalary}
              />
              <Route exact path="/salary/add" component={AddSalaryForm} />

              <Route path="/category" component={ScreenCategory} />

              <Route exact path="/transfer" component={ScreenTransfer} />
              <Route
                exact
                path="/transfer/detail/:id"
                component={ScreenDetailTransfer}
              />
              <Route exact path="/transfer/add" component={AddTransferForm} />

              <Route exact path="/resign" component={ScreenResign} />
              <Route
                exact
                path="/resign/detail/:id"
                component={ScreenDetailResign}
              />

              
              <Route exact path="/reward" component={ScreenReward} />
              <Route
                exact
                path="/reward/detail/:id"
                component={ScreenDetailSalary}
              />
              <Route exact path="/reward/add" component={AddRewardForm} />

              <Route exact path="/discipline" component={ScreenDiscipline} />
              <Route
                exact
                path="/discipline/detail/:id"
                component={ScreenDetailDiscipline}
              />
              <Route
                exact
                path="/discipline/add"
                component={AddDisciplineForm}
              />

              <Route exact path="/report" component={ScreenReport} />
            </Switch>
            {/* <Detail /> */}
          </div>
        </div>
      </div>
    </Router>
  );
}

export default ScreenProject;
