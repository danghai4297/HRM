import React from "react";
import "./SideBarLeft.scss";
import { SideBarData } from "./SideBarDate";
import { Link, useRouteMatch } from "react-router-dom";
import jwt_decode from "jwt-decode";
function SideBarLeft() {
  function Menu({ val }) {
    let match = useRouteMatch({
      path: val.link,
    });
    return (
      <Link to={val.link} className="link-item" id={match ? "actived" : ""}>
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
        {SideBarData.filter(
          (val) =>
            val.roles.includes(
              jwt_decode(localStorage.getItem("resultObj")).role
            ) === true
        ).map((val, key) => {
          return <Menu val={val} key={key} />;
        })}
        <img className="Side-img" src="/Images/pcr.jpg" alt="" />
      </ul>
    </div>
  );
}

export default SideBarLeft;
