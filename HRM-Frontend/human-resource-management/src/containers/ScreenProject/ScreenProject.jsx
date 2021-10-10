import React, { useState } from "react";
import "./ScreenProject.scss";

import SideBarLeft from "../../components/SideBarLeft/SideBarLeft";
import { Route, Switch, Redirect, useHistory } from "react-router-dom";
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
import ChangePasswordForm from "../../components/ChangePasswordForm/ChangePasswordForm";

import ProtectedRoute from "./ProtectedRoute";
import ScreenNotFound from "./ScreenNotFound";
function ScreenProject() {
  let history = useHistory();
  let logout = () => {
    localStorage.removeItem("accessToken");
    history.replace("/login");
  };
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
    <>
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
                    <button onClick={logout} className="button-account">
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
            {/* <Switch>
              
              <ProtectedRoute exact path="/home" component={DashBoard} />
              <ProtectedRoute exact path="/profile" component={ScreenTableNV} />
              <ProtectedRoute exact path="/profile/detail/:id" component={Detail} />
              <ProtectedRoute exact path="/profile/add" component={AddProfileForm} />

              <ProtectedRoute exact path="/contract" component={ScreenContract} />

              <ProtectedRoute exact path="/salary" component={ScreenSalary} />

              <ProtectedRoute path="/category" component={ScreenCategory} />

              <ProtectedRoute exact path="/transfer" component={ScreenTransfer} />

              <ProtectedRoute exact path="/resign" component={ScreenResign} />

              <ProtectedRoute exact path="/reward" component={ScreenReward} />

              <ProtectedRoute exact path="/discipline" component={ScreenDiscipline} />

              <ProtectedRoute exact path="/report" component={ScreenReport} />
            </Switch> */}
            <Switch>
              <ProtectedRoute exact path="/home" component={DashBoard} />

              <ProtectedRoute exact path="/profile" component={ScreenTableNV} />
              <ProtectedRoute
                exact
                path="/profile/detail/:id"
                component={Detail}
              />
              <ProtectedRoute
                exact
                path="/profile/add"
                component={ChangePasswordForm}
              />

              <ProtectedRoute
                exact
                path="/contract"
                component={ScreenContract}
              />
              <ProtectedRoute
                exact
                path="/contract/detail/:id"
                component={ScreenDetailContract}
              />
              <ProtectedRoute
                exact
                path="/contract/add"
                component={AddContractForm}
              />

              <ProtectedRoute exact path="/salary" component={ScreenSalary} />
              <ProtectedRoute
                exact
                path="/salary/detail/:id"
                component={ScreenDetailSalary}
              />
              <ProtectedRoute
                exact
                path="/salary/add"
                component={AddSalaryForm}
              />

              <ProtectedRoute path="/category" component={ScreenCategory} />

              <ProtectedRoute
                exact
                path="/transfer"
                component={ScreenTransfer}
              />
              <ProtectedRoute
                exact
                path="/transfer/detail/:id"
                component={ScreenDetailTransfer}
              />
              <ProtectedRoute
                exact
                path="/transfer/add"
                component={AddTransferForm}
              />

              <ProtectedRoute exact path="/resign" component={ScreenResign} />
              <ProtectedRoute
                exact
                path="/resign/detail/:id"
                component={ScreenDetailResign}
              />

              <ProtectedRoute exact path="/reward" component={ScreenReward} />
              <ProtectedRoute
                exact
                path="/reward/detail/:id"
                component={ScreenDetailReward}
              />
              <ProtectedRoute
                exact
                path="/reward/add"
                component={AddRewardForm}
              />

              <ProtectedRoute
                exact
                path="/discipline"
                component={ScreenDiscipline}
              />
              <ProtectedRoute
                exact
                path="/discipline/detail/:id"
                component={ScreenDetailDiscipline}
              />
              <ProtectedRoute
                exact
                path="/discipline/add"
                component={AddDisciplineForm}
              />

              <ProtectedRoute exact path="/report" component={ScreenReport} />
              {/* <Route component={ScreenNotFound}/> */}
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenProject;
