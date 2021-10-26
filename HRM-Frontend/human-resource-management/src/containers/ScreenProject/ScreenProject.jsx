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
              <ProtectedRoute exact path="/home" component={DashBoard} />
              <ProtectedRoute path="/change" component={ChangePasswordForm} />
              <ProtectedRoute exact path="/profile" component={ScreenTableNV} />
              <ProtectedRoute
                exact
                path="/profile/detail/:id"
                component={Detail}
              />
              <ProtectedRoute
                exact
                path="/profile/add"
                component={AddProfileForm}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/level/add"
                component={AddLevelForm}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/level/:id"
                component={ScreenDetailLevel}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/level/update/:id"
                component={AddLevelForm}
              />

              <ProtectedRoute
                exact
                path="/profile/detail/language/add"
                component={AddLanguageForm}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/language/:id"
                component={ScreenDetailForeignLanguage}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/language/update/:id"
                component={AddLanguageForm}
              />

              <ProtectedRoute
                exact
                path="/profile/detail/family/add"
                component={AddFamilyForm}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/family/:id"
                component={ScreenDetailFamily}
              />
              <ProtectedRoute
                exact
                path="/profile/detail/family/update/:id"
                component={AddFamilyForm}
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
              <ProtectedRoute
                exact
                path="/contract/:id"
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
              <ProtectedRoute
                exact
                path="/salary/:id"
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
              <ProtectedRoute
                exact
                path="/transfer/:id"
                component={AddTransferForm}
              />

              <ProtectedRoute exact path="/resign" component={ScreenResign} />

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
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenProject;
