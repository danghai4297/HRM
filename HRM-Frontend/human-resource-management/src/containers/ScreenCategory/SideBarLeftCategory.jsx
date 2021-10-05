import React from "react";
import { SideBarLeftCategoryData } from "./SideBarLeftCategoryData";
import { Link, useRouteMatch } from "react-router-dom";
import "./SideBarLeftCategory.scss"
function SideBarLeftCategory() {
  function ListMenu({ val }) {
    let match = useRouteMatch({
      path: val.link,
      exact: true
    });
    console.log(match)
    return <Link to={val.link} className="category-link">
    <li className="category-row" id={match ? "actives" : ""}>
        <div><h5 className="name-title">{val.title}</h5></div>
    </li>
    </Link>;
  }
  return (
    <div>
      <div className="Sidebar-left-Category">
        <ul className="Sidebar-left-list">
          {SideBarLeftCategoryData.map((val, key) => {
            return <ListMenu val={val} key={key} />;
          })}
        </ul>
      </div>
    </div>
  );
}

export default SideBarLeftCategory;
