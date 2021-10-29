import React from "react";
import Switch from "react-bootstrap/esm/Switch";
import { Redirect, Route } from "react-router";
import "./ScreenReport.scss";
import ItemDecisionSalaryUp from "./ScreenItemReport/ItemDecisionSalaryUp/ItemDecisionSalaryUp";
import ItemListBirthday from "./ScreenItemReport/ItemListBirthday/ItemListBirthday";
import ItemListCBCNVLevel from "./ScreenItemReport/ItemListCBCNVLevel/ItemListCBCNVLevel";
import ItemListEmployee from "./ScreenItemReport/ItemListEmployee/ItemListEmployee";
import ItemListFamily from "./ScreenItemReport/ItemListFamily/ItemListFamily";
import ItemListInsuranceBook from "./ScreenItemReport/ItemListInsuranceBook/ItemListInsuranceBook";
import ItemListPartyMember from "./ScreenItemReport/ItemListPartyMember/ItemListPartyMember";
import ItemListPolicyFront from "./ScreenItemReport/ItemListPolicyFront/ItemListPolicyFront";
import ItemListSalaryGroup from "./ScreenItemReport/ItemListSalaryGroup/ItemListSalaryGroup";
import ItemListSalaryUp from "./ScreenItemReport/ItemListSalaryUp/ItemListSalaryUp";
import ItemSalaryProfile from "./ScreenItemReport/ItemSalaryProfile/ItemSalaryProfile";
import SidebarLeftReport from "./SidebarLeftReport";
function ScreenReport() {
  return (
    <>
      <div className="main-all">
        <div className="first-main">
          <div className="title-first">
            <h2>Báo cáo</h2>
          </div>
          <div className="cate-sidebar">
            <SidebarLeftReport />
          </div>
        </div>
        <div className="second-main">
          <div className="table-category">
            <Switch>
              <Route exact path="/report/">
                <Redirect to="/report/profileEmployee" />
              </Route>
              <Route
                exact
                path="/report/profileEmployee"
                component={ItemListEmployee}
              />
              <Route
                exact
                path="/report/salaryUp"
                component={ItemListSalaryUp}
              />
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
              <Route
                exact
                path="/report/birthday"
                component={ItemListBirthday}
              />
              <Route
                exact
                path="/report/partyMember"
                component={ItemListPartyMember}
              />
              <Route
                exact
                path="/report/cbcnv"
                component={ItemListCBCNVLevel}
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
      </div>
    </>
  );
}

export default ScreenReport;
