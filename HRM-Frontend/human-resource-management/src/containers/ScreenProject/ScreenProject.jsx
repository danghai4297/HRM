import React, { useState } from "react";
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
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../../components/Header/Header.scss";
import ScreenDetailForeignLanguage from "../ScreenDetailForeignLanguage/ScreenDetailForeignLanguage";
import ScreenDetailLevel from "../ScreenDetailLevel/ScreenDetailLevel";
import ScreenDetailFamily from "../ScreenDetailFamily/ScreenDetailFamily";
import ScreenDetailSalary from "../ScreenDetailSalary/ScreenDetailSalary";
import ScreenDetailTransfer from "../ScreenDetailTransfer/ScreenDetailTransfer";
import ScreenDetailResign from "../ScreenDetailResign/ScreenDetailResign";
import ScreenDetailReward from "../ScreenDetailReward/ScreenDetailReward";
import ScreenDetailDiscipline from "../ScreenDetailDiscipline/ScreenDetailDiscipline";
import AddProfile from "../ScreenAddProfile/ScreenAddProfile";
import ScreenAddReward from "../ScreenAddReward/ScreenAddReward";

function ScreenProject() {
  const [account, setAccount] = useState(false);
  const visionHandleClick = () => {
    setAccount(!account);
  };
  const closeHandleClick = ()=>{
    if(account !== false){
      setAccount(false)
    }
  }
  return (
      <Router>
        <div className="body-screen" onClick={closeHandleClick}>
          <div className="header">
          <div className="header-com">
        <div className="name">
          <div className="title-project">
            <h1>HRM</h1>
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
                  <FontAwesomeIcon icon={["fas", "sign-out-alt"]} /> Đăng xuất
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
              <Route path="/profile/:id" component={Detail} />
              <Route path="/profile/edit" component={ScreenAddReward} />

              <Route exact path="/contract" component={ScreenContract} />

              <Route exact path="/salary" component={ScreenSalary} />

              <Route path="/category" component={ScreenCategory} />

              <Route exact path="/transfer" component={ScreenTransfer} />

              <Route exact path="/resign" component={AddProfile} />

              <Route exact path="/reward" component={ScreenReward} />

              <Route exact path="/discipline" component={ScreenDiscipline} />

              <Route exact path="/report" component={ScreenReport} />
              <Route path="/*" component={ScreenNotFound}/>
            </Switch>
              {/* <Detail /> */}
            </div>
          </div>
        </div>
      </Router>
  );
}

export default ScreenProject;
