import React from "react";
import { Link, useRouteMatch } from "react-router-dom";
import { SidebarLeftReportData } from "./SidebarLeftReportData";
import "./SidebarLeftReport.scss";
function SidebarLeftReport() {
  function ListMenu({ val }) {
    let match = useRouteMatch({
      path: val.link,
    });
    return (
      <Link to={val.link} className="category-link">
        <li className="category-row" id={match ? "actives" : ""}>
          <div>
            <h5 className="name-title">{val.title}</h5>
          </div>
        </li>
      </Link>
    );
  }
  return (
    <div>
      <div className="Sidebar-left-Category">
        <ul className="Sidebar-left-list">
          {SidebarLeftReportData.map((val, key) => {
            return <ListMenu val={val} key={key} />;
          })}
        </ul>
      </div>
    </div>
  );
}

export default SidebarLeftReport;
