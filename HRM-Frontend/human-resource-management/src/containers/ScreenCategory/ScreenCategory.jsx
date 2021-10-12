import React, { Children } from "react";

import "./ScreenCategory.scss";
import SideBarLeftCategory from "./SideBarLeftCategory";
import ItemNation from "./ScreenItemCategory/ItemNation/ItemNation";
import ItemTitle from "./ScreenItemCategory/ItemTitle/ItemTitle";
import ItemSpecialize from "./ScreenItemCategory/ItemSpecialize/ItemSpecialize";
import ItemLevel from "./ScreenItemCategory/ItemLevel/ItemLevel";
import ItemLanguage from "./ScreenItemCategory/ItemLanguage/ItemLanguage";
import ItemNest from "./ScreenItemCategory/ItemNest/ItemNest";
import ItemBonus from "./ScreenItemCategory/ItemBonus/ItemBonus";
import ItemPunish from "./ScreenItemCategory/ItemPunish/ItemPunish";
import ItemDepartment from "./ScreenItemCategory/ItemDepartment/ItemDepartment";
import ItemDeal from "./ScreenItemCategory/ItemDeal/ItemDeal";
import ItemWages from "./ScreenItemCategory/ItemWages/ItemWages";
import ItemTraining from "./ScreenItemCategory/ItemTraining/ItemTraining";
import ItemCivil from "./ScreenItemCategory/ItemCivil/ItemCivil";
import { Button } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Route, Switch } from "react-router-dom";
import ScreenNotFound from "../ScreenProject/ScreenNotFound";
import ItemMarriage from "./ScreenItemCategory/ItemMarriage/ItemMarriage";
import ItemRelation from "./ScreenItemCategory/ItemRelation/ItemRelation";
import ItemReligion from "./ScreenItemCategory/ItemReligion/ItemReligion";
import ItemDuty from "./ScreenItemCategory/ItemDuty/ItemDuty";
import AddTitleForm from "../../components/AddCategoryForm/AddTitleForm/AddTitleForm";
import AddSpecializeForm from "../../components/AddCategoryForm/AddSpecializeForm/AddSpecializeForm";
import AddLevelForm from "../../components/AddCategoryForm/AddLevelForm/AddLevelForm";

import AddLanguageForm from "../../components/AddCategoryForm/AddLanguageForm/AddLanguageForm";
import AddReligionForm from "../../components/AddCategoryForm/AddReligionForm/AddReligionForm";
import AddBonusForm from "../../components/AddCategoryForm/AddBonusForm/AddBonusForm";
import AddDisciplineForm from "../../components/AddCategoryForm/AddDisciplineForm/AddDisciplineForm";
import AddDepartmentForm from "../../components/AddCategoryForm/AddDepartmentForm/AddDepartmentForm";
import AddTypeOfContractForm from "../../components/AddCategoryForm/AddTypeOfContractForm/AddTypeOfContractForm";
import AddSalaryGroupForm from "../../components/AddCategoryForm/AddSalaryGroupForm/AddSalaryGroupForm";
import AddEducateForm from "../../components/AddCategoryForm/AddEducateForm/AddEducateForm";
import AddRelationForm from "../../components/AddCategoryForm/AddRelationForm/AddRelationForm";
import AddMarriageForm from "../../components/AddCategoryForm/AddMarriageForm/AddMarriageForm";
import AddPositionForm from "../../components/AddCategoryForm/AddPositionForm/AddPositionForm";
import AddCSRForm from "../../components/AddCategoryForm/AddCSRForm/AddCSRForm";
import AddNestForm from "../../components/AddCategoryForm/AddNestForm/AddNestForm";
import AddNationForm from "../../components/AddCategoryForm/AddNationForm/AddNationForm";

function ScreenCategory() {
  return (
    <>
      <div className="main-all">
        <div className="first-main">
          <div className="title-first">
            <h2>Danh mục</h2>
          </div>
          <div className="cate-sidebar">
            <SideBarLeftCategory />
          </div>
        </div>
        <div className="second-main">
          {/* <div className="button-first">
            <Button className="button-left">
              <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
            </Button>
            <Button className="button-left" variant="light">
              <FontAwesomeIcon icon={["fas", "download"]} />
            </Button>
          </div> */}
          <div className="table-category">
            <Switch>
              <Route exact path="/category/" component={ItemNation} />
              <Route
                exact
                path="/category/nation/add"
                component={AddNationForm}
              />
              <Route
                exact
                path="/category/nation/:id"
                component={AddNationForm}
              />

              <Route exact path="/category/title" component={ItemTitle} />
              <Route
                exact
                path="/category/title/add"
                component={AddTitleForm}
              />
              <Route
                exact
                path="/category/title/:id"
                component={AddTitleForm}
              />

              <Route
                exact
                path="/category/specialize"
                component={ItemSpecialize}
              />
              <Route
                exact
                path="/category/specialize/add"
                component={AddSpecializeForm}
              />
              <Route
                exact
                path="/category/specialize/:id"
                component={AddSpecializeForm}
              />

              <Route exact path="/category/level" component={ItemLevel} />
              <Route
                exact
                path="/category/level/add"
                component={AddLevelForm}
              />
              <Route
                exact
                path="/category/level/:id"
                component={AddLevelForm}
              />

              <Route exact path="/category/language" component={ItemLanguage} />
              <Route
                exact
                path="/category/language/add"
                component={AddLanguageForm}
              />
              <Route
                exact
                path="/category/language/:id"
                component={AddLanguageForm}
              />

              <Route exact path="/category/nest" component={ItemNest} />
              <Route exact path="/category/nest/add" component={AddNestForm} />
              <Route
                exact
                path="/category/nest/:id"
                component={AddNestForm}
              />

              <Route exact path="/category/religion" component={ItemReligion} />
              <Route
                exact
                path="/category/religion/add"
                component={AddReligionForm}
              />
              <Route
                exact
                path="/category/religion/:id"
                component={AddReligionForm}
              />

              <Route exact path="/category/bonus" component={ItemBonus} />
              <Route
                exact
                path="/category/bonus/add"
                component={AddBonusForm}
              />
              <Route
                exact
                path="/category/bonus/:id"
                component={AddBonusForm}
              />

              <Route exact path="/category/punish" component={ItemPunish} />
              <Route
                exact
                path="/category/punish/add"
                component={AddDisciplineForm}
              />
              <Route
                exact
                path="/category/punish/:id"
                component={AddDisciplineForm}
              />

              <Route
                exact
                path="/category/department"
                component={ItemDepartment}
              />
              <Route
                exact
                path="/category/department/add"
                component={AddDepartmentForm}
              />
              <Route
                exact
                path="/category/department/:id"
                component={AddDepartmentForm}
              />

              <Route exact path="/category/deal" component={ItemDeal} />
              <Route
                exact
                path="/category/deal/add"
                component={AddTypeOfContractForm}
              />
              <Route
                exact
                path="/category/deal/:id"
                component={AddTypeOfContractForm}
              />

              <Route exact path="/category/wages" component={ItemWages} />
              <Route
                exact
                path="/category/wages/add"
                component={AddSalaryGroupForm}
              />
              <Route
                exact
                path="/category/wages/:id"
                component={AddSalaryGroupForm}
              />

              <Route exact path="/category/training" component={ItemTraining} />
              <Route
                exact
                path="/category/training/add"
                component={AddEducateForm}
              />
              <Route
                exact
                path="/category/training/:id"
                component={AddEducateForm}
              />

              <Route exact path="/category/civil" component={ItemCivil} />
              <Route exact path="/category/civil/add" component={AddCSRForm} />
              <Route
                exact
                path="/category/civil/:id"
                component={AddCSRForm}
              />

              <Route exact path="/category/relation" component={ItemRelation} />
              <Route
                exact
                path="/category/relation/add"
                component={AddRelationForm}
              />
              <Route
                exact
                path="/category/relation/:id"
                component={AddRelationForm}
              />

              <Route exact path="/category/marriage" component={ItemMarriage} />
              <Route
                exact
                path="/category/marriage/add"
                component={AddMarriageForm}
              />
              <Route
                exact
                path="/category/marriage/:id"
                component={AddMarriageForm}
              />

              <Route exact path="/category/duty" component={ItemDuty} />
              <Route
                exact
                path="/category/duty/add"
                component={AddPositionForm}
              />
              <Route
                exact
                path="/category/duty/:id"
                component={AddPositionForm}
              />
              {/* <Route component={ScreenNotFound} /> */}
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenCategory;
