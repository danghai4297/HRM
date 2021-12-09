import React from "react";
import Switch from "react-bootstrap/esm/Switch";
import { Redirect, Route } from "react-router";
import "./ScreenReport.scss";
import ItemDecisionSalaryUp from "../../pages/Report/ItemDecisionSalaryUp/ItemDecisionSalaryUp";
import ItemListBirthday from "../../pages/Report/ItemListBirthday/ItemListBirthday";
import ItemListEmployee from "../../pages/Report/ItemListEmployee/ItemListEmployee";
import ItemListFamily from "../../pages/Report/ItemListFamily/ItemListFamily";
import ItemListInsuranceBook from "../../pages/Report/ItemListInsuranceBook/ItemListInsuranceBook";
import ItemListPartyMember from "../../pages/Report/ItemListPartyMember/ItemListPartyMember";
import ItemListPolicyFront from "../../pages/Report/ItemListPolicyFront/ItemListPolicyFront";
import ItemListSalaryGroup from "../../pages/Report/ItemListSalaryGroup/ItemListSalaryGroup";
import ItemListSalaryUp from "../../pages/Report/ItemListSalaryUp/ItemListSalaryUp";
import ItemSalaryProfile from "../../pages/Report/ItemSalaryProfile/ItemSalaryProfile";
import SidebarLeftReport from "../../components/SidebarReport/SidebarLeftReport";
function ScreenReport() {
  return (
    <>
      <div className="main-all">
        <div className="first-main">
          <div className="title-first">
            <h1>Báo cáo</h1>
          </div>
          <div className="cate-sidebar">
            <SidebarLeftReport />
          </div>
        </div>
        <div className="second-main">
          <Switch>
            <Route exact path="/report/">
              <Redirect to="/report/profileEmployee" />
            </Route>
            <Route
              exact
              path="/report/profileEmployee"
              component={ItemListEmployee}
            />
            <Route exact path="/report/salaryUp" component={ItemListSalaryUp} />
            <Route
              exact
              path="/report/decisionSalaryUp"
              component={ItemDecisionSalaryUp}
            />
            <Route
              exact
              path="/report/salaryProfile"
              component={ItemSalaryProfile}
            />
            <Route exact path="/report/birthday" component={ItemListBirthday} />
            <Route
              exact
              path="/report/partyMember"
              component={ItemListPartyMember}
            />
            <Route
              exact
              path="/report/salaryGroup"
              component={ItemListSalaryGroup}
            />
            <Route exact path="/report/family" component={ItemListFamily} />
            <Route
              exact
              path="/report/policy"
              component={ItemListPolicyFront}
            />
            <Route
              exact
              path="/report/insuranceBook"
              component={ItemListInsuranceBook}
            />
          </Switch>
        </div>
      </div>
    </>
  );
}

export default ScreenReport;
