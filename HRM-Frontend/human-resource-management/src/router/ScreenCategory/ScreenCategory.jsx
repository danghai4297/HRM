import React, { useEffect, useRef, useState } from "react";

import "./ScreenCategory.scss";
import SideBarLeftCategory from "../../components/SidebarCategory/SideBarLeftCategory";
import ItemNation from "../../pages/Category/NationCategory/ItemNation/ItemNation";
import ItemTitle from "../../pages/Category/TitleCategory/ItemTitle/ItemTitle";
import ItemSpecialize from "../../pages/Category/SpecializeCategory/ItemSpecialize/ItemSpecialize";
import ItemLevel from "../../pages/Category/LevelCategory/ItemLevel/ItemLevel";
import ItemLanguage from "../../pages/Category/LanguageCategory/ItemLanguage/ItemLanguage";
import ItemNest from "../../pages/Category/NestCategory/ItemNest/ItemNest";
import ItemBonus from "../../pages/Category/RewardCategory/ItemBonus/ItemBonus";
import ItemPunish from "../../pages/Category/DisciplineCategory/ItemPunish/ItemPunish";
import ItemDepartment from "../../pages/Category/DepartmentCategory/ItemDepartment/ItemDepartment";
import ItemDeal from "../../pages/Category/TypeOfContractCategory/ItemDeal/ItemDeal";
import ItemWages from "../../pages/Category/SalaryGroupCategory/ItemWages/ItemWages";
import ItemTraining from "../../pages/Category/EducateCategory/ItemTraining/ItemTraining";
import ItemCivil from "../../pages/Category/CSRCategory/ItemCivil/ItemCivil";
import {
  Route,
  Switch,
  Redirect,
  useHistory,
  useLocation,
} from "react-router-dom";
import ItemMarriage from "../../pages/Category/MarriageCategory/ItemMarriage/ItemMarriage";
import ItemRelation from "../../pages/Category/RelationCategory/ItemRelation/ItemRelation";
import ItemReligion from "../../pages/Category/ReligionCategory/ItemReligion/ItemReligion";
import ItemDuty from "../../pages/Category/PositionCategory/ItemDuty/ItemDuty";
import AddTitleForm from "../../pages/Category/TitleCategory/AddTitleForm/AddTitleForm";
import AddSpecializeForm from "../../pages/Category/SpecializeCategory/AddSpecializeForm/AddSpecializeForm";
import AddLevelForm from "../../pages/Category/LevelCategory/AddLevelForm/AddLevelForm";

import AddLanguageForm from "../../pages/Category/LanguageCategory/AddLanguageForm/AddLanguageForm";
import AddReligionForm from "../../pages/Category/ReligionCategory/AddReligionForm/AddReligionForm";
import AddBonusForm from "../../pages/Category/RewardCategory/AddBonusForm/AddBonusForm";
import AddDisciplineForm from "../../pages/Category/DisciplineCategory/AddDisciplineForm/AddDisciplineForm";
import AddDepartmentForm from "../../pages/Category/DepartmentCategory/AddDepartmentForm/AddDepartmentForm";
import AddTypeOfContractForm from "../../pages/Category/TypeOfContractCategory/AddTypeOfContractForm/AddTypeOfContractForm";
import AddSalaryGroupForm from "../../pages/Category/SalaryGroupCategory/AddSalaryGroupForm/AddSalaryGroupForm";
import AddEducateForm from "../../pages/Category/EducateCategory/AddEducateForm/AddEducateForm";
import AddRelationForm from "../../pages/Category/RelationCategory/AddRelationForm/AddRelationForm";
import AddMarriageForm from "../../pages/Category/MarriageCategory/AddMarriageForm/AddMarriageForm";
import AddPositionForm from "../../pages/Category/PositionCategory/AddPositionForm/AddPositionForm";
import AddCSRForm from "../../pages/Category/CSRCategory/AddCSRForm/AddCSRForm";
import AddNestForm from "../../pages/Category/NestCategory/AddNestForm/AddNestForm";
import AddNationForm from "../../pages/Category/NationCategory/AddNationForm/AddNationForm";
import ItemLabor from "../../pages/Category/LaborCategory/ItemLabor/ItemLabor";
import AddLaborForm from "../../pages/Category/LaborCategory/AddLaborForm/AddLaborForm";

function ScreenCategory() {
  const location = useLocation();
  const history = useHistory();
  const [state, setstate] = useState(location.pathname);
  console.log(state);
  console.log(location.pathname);
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
          <div className="table-category">
            <Switch>
              <Route exact path="/category/">
                <Redirect to="/category/nation" />
              </Route>
              <Route exact path="/category/nation" component={ItemNation} />
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
              <Route exact path="/category/nest/:id" component={AddNestForm} />

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

              <Route exact path="/category/labor" component={ItemLabor} />
              <Route
                exact
                path="/category/labor/add"
                component={AddLaborForm}
              />
              <Route
                exact
                path="/category/labor/:id"
                component={AddLaborForm}
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
              <Route exact path="/category/civil/:id" component={AddCSRForm} />

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
              <Route path="*">
                <Redirect to="/category/nation" />
              </Route>
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenCategory;
