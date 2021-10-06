import React from "react";

import "./ScreenCategory.scss";
import SideBarLeftCategory from "./SideBarLeftCategory";
import ItemNation from "./ScreenItemCategory/ItemNation/ItemNation";
import ItemTitle from "./ScreenItemCategory/ItemTitle/ItemTitle";
import ItemSpecialize from "./ScreenItemCategory/ItemSpecialize/ItemSpecialize";
import ItemLevel from "./ScreenItemCategory/ItemLevel/ItemLevel";
import ItemLanguage from "./ScreenItemCategory/ItemLanguage/ItemLanguage";
import ItemNest from "./ScreenItemCategory/ItemNest/ItemNest";
import ItemReligion from "./ScreenItemCategory/ItemReligion/ItemReligion";
import ItemBonus from "./ScreenItemCategory/ItemBonus/ItemBonus";
import ItemPunish from "./ScreenItemCategory/ItemPunish/ItemPunish";
import ItemDepartment from "./ScreenItemCategory/ItemDepartment/ItemDepartment";
import ItemDeal from "./ScreenItemCategory/ItemDeal/ItemDeal";
import ItemWages from "./ScreenItemCategory/ItemWages/ItemWages";
import ItemTraining from "./ScreenItemCategory/ItemTraining/ItemTraining";
import ItemCivil from "./ScreenItemCategory/ItemCivil/ItemCivil";
import ItemRelation from "./ScreenItemCategory/ItemRelation/ItemRelation";
import { Button } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Route, Switch } from "react-router-dom";
import ScreenNotFound from "../ScreenProject/ScreenNotFound";
import ItemMarriage from "./ScreenItemCategory/ItemMarriage/ItemMarriage";
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
          <div className="button-first">
            <Button className="button-left">
              <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
            </Button>
            <Button className="button-left" variant="light">
              <FontAwesomeIcon icon={["fas", "download"]} />
            </Button>
          </div>
          <div className="table-category">
            <Switch>
              <Route exact path="/category/" component={ItemNation} />
              <Route path="/category/title" component={ItemTitle} />
              <Route path="/category/specialize" component={ItemSpecialize} />
              <Route path="/category/level" component={ItemLevel} />
              <Route path="/category/language" component={ItemLanguage} />
              <Route path="/category/nest" component={ItemNest} />
              <Route path="/category/religion" component={ItemReligion} />
              <Route path="/category/bonus" component={ItemBonus} />
              <Route path="/category/punish" component={ItemPunish} />
              <Route path="/category/department" component={ItemDepartment} />
              <Route path="/category/deal" component={ItemDeal} />
              <Route path="/category/wages" component={ItemWages} />
              <Route path="/category/training" component={ItemTraining} />
              <Route path="/category/civil" component={ItemCivil} />
              <Route path="/category/relation" component={ItemRelation} />
              <Route path="/category/marriage" component={ItemMarriage} />
              {/* <Route component={ScreenNotFound} /> */}
            </Switch>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenCategory;
