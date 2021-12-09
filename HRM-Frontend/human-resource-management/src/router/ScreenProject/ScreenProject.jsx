import React, { useContext } from "react";
import "./ScreenProject.scss";

import SideBarLeft from "../../components/SideBarLeft/SideBarLeft";
import { Switch, Route, Redirect } from "react-router-dom";
import DashBoard from "../../pages/DashBoard/ScreenDashBoard/DashBoard";
import ScreenTableNV from "../../pages/Profile/ScreenTableNV/ScreenTableNV";
import Detail from "../../pages/Profile/Detail/Detail";
import ScreenContract from "../../pages/Contract/ScreenContract/ScreenContract";
import ScreenSalary from "../../pages/Salary/ScreenSalary/ScreenSalary";
import ScreenCategory from "../ScreenCategory/ScreenCategory";
import ScreenResign from "../../pages/Resign/ScreenResign/ScreenResign";
import ScreenReward from "../../pages/Reward/ScreenReward/ScreenReward";
import ScreenDiscipline from "../../pages/Discipline/ScreenDiscipline/ScreenDiscipline";
import ScreenReport from "../ScreenReport/ScreenReport";
import ScreenTransfer from "../../pages/Transfer/ScreenTransfer/ScreenTransfer";
import ScreenDetailSalary from "../../pages/Salary/ScreenDetailSalary/ScreenDetailSalary";
import AddProfileForm from "../../pages/Profile/ProfileForm/ProfileForm";
import ScreenDetailContract from "../../pages/Contract/ScreenDetailContract/ScreenDetailContract";
import AddContractForm from "../../pages/Contract/ContractForm/ContractForm";
import AddSalaryForm from "../../pages/Salary/SalaryForm/SalaryForm";
import ScreenDetailTransfer from "../../pages/Transfer/ScreenDetailTransfer/ScreenDetailTransfer";
import AddTransferForm from "../../pages/Transfer/TransferForm/TransferForm";
import AddRewardForm from "../../pages/Reward/RewardForm/RewardForm";
import AddDisciplineForm from "../../pages/Discipline/DisciplineForm/DisciplineForm";
import ScreenDetailReward from "../../pages/Reward/ScreenDetailReward/ScreenDetailReward";
import ScreenDetailDiscipline from "../../pages/Discipline/ScreenDetailDiscipline/ScreenDetailDiscipline";
import ScreenDetailLevel from "../../pages/Profile/Level/ScreenDetailLevel/ScreenDetailLevel";
import ScreenDetailForeignLanguage from "../../pages/Profile/Language/ScreenDetailForeignLanguage/ScreenDetailForeignLanguage";
import ScreenDetailFamily from "../../pages/Profile/Family/ScreenDetailFamily/ScreenDetailFamily";
import ChangePasswordForm from "../../pages/Account/ChangePasswordForm/ChangePasswordForm";

import ProtectedRoute from "../../auth/ProtectedRoute";
import Header from "../../components/Header/Header";
import { AccountContext, SideBarContext } from "../../Contexts/StateContext";
import AddLevelForm from "../../pages/Profile/Level/LevelForm/LevelForm";
import AddLanguageForm from "../../pages/Profile/Language/LanguageForm/LanguageForm";
import AddFamilyForm from "../../pages/Profile/Family/FamilyForm/FamilyForm";
import ScreenAccount from "../../pages/Account/ScreenAccount/ScreenAccount";
import ScreenAccountLog from "../../pages/WorkHistory/ScreenAccountLog/ScreenAccountLog";
import PDF from "../../pages/Profile/PDF/PDF";
import RegisterAccount from "../../pages/Account/ResgisterAccount/RegisterAccount";
import ScreenDetailAccount from "../../pages/Account/ScreenDetailAccount/ScreenDetailAccount";
import ScreenAddRole from "../../pages/Account/ScreenAddRole/ScreenAddRole";
import ScreenNotFound from "../../pages/Error/ScreenNotFound";

function ScreenProject() {
  const { setAccount } = useContext(AccountContext);
  const { sideBar, setSiderBar } = useContext(SideBarContext);

  window.onresize = resize;

  function resize() {
    let w = window.innerWidth;
    if (w < 1440) {
      setSiderBar(false);
    } else {
      setSiderBar(true);
    }
  }

  const notFoundPage = () => {
    if (sessionStorage.getItem("resultObj")) {
      return <ScreenNotFound />;
    } else {
      return <Redirect to="/login" />;
    }
  };

  return (
    <>
      <div className="body-screen">
        <div className="header">
          <Header />
        </div>
        <div className="body-contents" onClick={() => setAccount(false)}>
          <div
            className={
              sideBar !== false ? "menu-barss" : "menu-barss menu-bar2"
            }
          >
            <SideBarLeft />
          </div>
          <div className={sideBar !== false ? "content" : "content content2"}>
            <Switch>
              <ProtectedRoute
                exact
                path="/home"
                component={DashBoard}
                roles={["user"]}
              />
              <ProtectedRoute
                path="/change"
                component={ChangePasswordForm}
                roles={["user"]}
              />
              <ProtectedRoute
                exact
                path="/profile"
                component={ScreenTableNV}
                roles={["user"]}
              />
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
                path="/profile/:id"
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
                path="/profile/pdf/:id"
                component={PDF}
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

              <ProtectedRoute
                exact
                path="/salary"
                component={ScreenSalary}
                roles={["user"]}
              />
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

              <ProtectedRoute
                path="/category"
                component={ScreenCategory}
                roles={["admin"]}
              />

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

              <ProtectedRoute
                exact
                path="/resign"
                component={ScreenResign}
                roles={["user"]}
              />

              <ProtectedRoute
                exact
                path="/reward"
                component={ScreenReward}
                roles={["user"]}
              />
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
                path="/reward/:id"
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
              <ProtectedRoute
                exact
                path="/discipline/:id"
                component={AddDisciplineForm}
                roles={["user"]}
              />
              <ProtectedRoute
                path="/report"
                component={ScreenReport}
                roles={["user"]}
              />
              <ProtectedRoute
                path="/activity"
                component={ScreenAccountLog}
                roles={["user", "admin"]}
              />
              <ProtectedRoute
                exact
                path="/account"
                component={ScreenAccount}
                roles={["admin"]}
              />
              <ProtectedRoute
                exact
                path="/account/add"
                component={RegisterAccount}
                roles={["admin"]}
              />
              <ProtectedRoute
                exact
                path="/account/addRole/:id"
                component={ScreenAddRole}
                roles={["admin"]}
              />
              <ProtectedRoute
                exact
                path="/account/detail/:id"
                component={ScreenDetailAccount}
                roles={["admin"]}
              />
              <Route path="*">{notFoundPage}</Route>
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenProject;
