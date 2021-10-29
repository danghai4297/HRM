import React, { useContext, useEffect } from "react";
import "./ScreenProject.scss";

import SideBarLeft from "../../components/SideBarLeft/SideBarLeft";
import { Switch } from "react-router-dom";
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
import "../../components/Header/Header.scss";
import ScreenDetailSalary from "../ScreenDetailSalary/ScreenDetailSalary";
import AddProfileForm from "../../components/AddProfileForm/addProfileForm";
import ScreenDetailContract from "../ScreenDetailContract/ScreenDetailContract";
import AddContractForm from "../../components/AddContractForm/AddContractForm";
import AddSalaryForm from "../../components/AddSalaryForm/AddSalaryForm";
import ScreenDetailTransfer from "../ScreenDetailTransfer/ScreenDetailTransfer";
import AddTransferForm from "../../components/AddTransferForm/AddTransferForm";
import AddRewardForm from "../../components/AddRewardForm/AddRewardForm";
import AddDisciplineForm from "../../components/AddDisciplineForm/AddDisciplineForm";
import ScreenDetailReward from "../ScreenDetailReward/ScreenDetailReward";
import ScreenDetailDiscipline from "../ScreenDetailDiscipline/ScreenDetailDiscipline";
import ScreenDetailLevel from "../ScreenDetailLevel/ScreenDetailLevel";
import ScreenDetailForeignLanguage from "../ScreenDetailForeignLanguage/ScreenDetailForeignLanguage";
import ScreenDetailFamily from "../ScreenDetailFamily/ScreenDetailFamily";
import ChangePasswordForm from "../../components/ChangePasswordForm/ChangePasswordForm";

import ProtectedRoute from "./ProtectedRoute";
import Header from "../../components/Header/Header";
import { AccountContext } from "../../Contexts/StateContext";
import AddLevelForm from "../../components/AddLevelForm/AddLevelForm";
import AddLanguageForm from "../../components/AddLanguageForm/AddLanguageForm";
import AddFamilyForm from "../../components/AddFamilyForm/AddFamilyForm";
import ScreenAccount from "../ScreenAccount/ScreenAccount";
// import PDF from "../../components/Detail/PDF";
import ScreenAccountLog from "../ScreenAccountLog/ScreenAccountLog";
function ScreenProject() {
  const { setAccount } = useContext(AccountContext);
  useEffect(() => {
    localStorage.getItem('token')
  }, [])
  return (
    <>
      <div className="body-screen">
        <div className="header">
          <Header />
        </div>
        <div className="body-contents" onClick={() => setAccount(false)}>
          <div className="menu-bar">
            <SideBarLeft />
          </div>
          <div className="content">
            <Switch>
              <ProtectedRoute exact path="/home" component={DashBoard} roles={["user"]}/>
              <ProtectedRoute path="/change" component={ChangePasswordForm} roles={["user"]}/>
              <ProtectedRoute exact path="/profile" component={ScreenTableNV} roles={["user"]}/>
              <ProtectedRoute
                exact
                path="/profile/detail/:id"
                component={Detail}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/add"
                component={AddProfileForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/level/add"
                component={AddLevelForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/level/:id"
                component={ScreenDetailLevel}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/level/update/:id"
                component={AddLevelForm}
                roles={["user"]}
              />

              <ProtectedRoute
                exact
                path="/profile/detail/language/add"
                component={AddLanguageForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/language/:id"
                component={ScreenDetailForeignLanguage}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/language/update/:id"
                component={AddLanguageForm}
                roles={["user"]}
              />

              <ProtectedRoute
                exact
                path="/profile/detail/family/add"
                component={AddFamilyForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/family/:id"
                component={ScreenDetailFamily}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/family/update/:id"
                component={AddFamilyForm}
                roles={["user"]}
              />

              <ProtectedRoute
                exact
                path="/contract"
                component={ScreenContract}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/contract/detail/:id"
                component={ScreenDetailContract}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/contract/add"
                component={AddContractForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/contract/:id"
                component={AddContractForm}
                roles={["user"]}
              />

              <ProtectedRoute exact path="/salary" component={ScreenSalary} roles={["user"]}/>
              <ProtectedRoute
                exact
                path="/salary/detail/:id"
                component={ScreenDetailSalary}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/salary/add"
                component={AddSalaryForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/salary/:id"
                component={AddSalaryForm}
                roles={["user"]}
              />

              <ProtectedRoute path="/category" component={ScreenCategory} roles={["admin"]}/>
              <ProtectedRoute path="/account" component={ScreenAccount} roles={["admin"]}/>

              <ProtectedRoute
                exact
                path="/transfer"
                component={ScreenTransfer}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/transfer/detail/:id"
                component={ScreenDetailTransfer}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/transfer/add"
                component={AddTransferForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/transfer/:id"
                component={AddTransferForm}
                roles={["user"]}
              />

              <ProtectedRoute exact path="/resign" component={ScreenResign} roles={["user"]}/>

              <ProtectedRoute exact path="/reward" component={ScreenReward} roles={["user"]}/>
              <ProtectedRoute
                exact
                path="/reward/detail/:id"
                component={ScreenDetailReward}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/reward/add"
                component={AddRewardForm}
                roles={["user"]}
              />

              <ProtectedRoute
                exact
                path="/discipline"
                component={ScreenDiscipline}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/discipline/detail/:id"
                component={ScreenDetailDiscipline}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/discipline/add"
                component={AddDisciplineForm}
                roles={["user"]}
              />
              <ProtectedRoute path="/report" component={ScreenReport} roles={["user"]}/>
              <ProtectedRoute path="/activity" component={ScreenAccountLog} roles={["user", "admin"]}/>
              {/* <ProtectedRoute path="/pdf" component={PDF} roles="user"/> */}
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenProject;
