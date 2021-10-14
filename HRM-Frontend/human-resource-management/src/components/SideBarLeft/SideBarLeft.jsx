import React from "react";
import "./SideBarLeft.scss";
import { SideBarData } from "./SideBarDate";
import { Link, useRouteMatch } from "react-router-dom";
function SideBarLeft() {
  function Menu({ val }) {
    let match = useRouteMatch({
      path: val.link,
    });
    return (
      <Link to={val.link} className="link-item">
        <li className="row" id={match ? "active" : ""}>
          <div id="icon">{val.icon}</div>
          <div id="title">{val.title}</div>
        </li>
      </Link>
    );
  }

  return (
    <div className="Sidebar">
      <ul className="SidebarList sticky-top">
        <li className="title-project">
          <div className="title-names">
            <h1 style={{ color: "white" }}>HRM</h1>
          </div>
        </li>
        {SideBarData.map((val, key) => {
          return <Menu val={val} key={key} />;
        })}
      </ul>
    </div>
  );
}

export default SideBarLeft;
