import React from "react";
import "./SideBarLeft.scss";
import { SideBarData } from "./SideBarDate";
import { Link, useRouteMatch } from "react-router-dom";

function SideBarDemo() {
  function Menu({ val }) {
    let match = useRouteMatch({
      path: val.link,
    });
    return (
      <li
        className="row"
        id={match ? "active" : ""}
        // onClick={() => {
        //   window.location.pathname = val.link;
        // }}
      >
        <Link to={val.link}>
          <div id="icon">{val.icon}</div>
          <div id="title">{val.title}</div>
        </Link>
      </li>
    );
  }

  return (
    <div className="Sidebar">
      <ul className="SidebarList sticky-top">
        {SideBarData.map((val, key) => {
          return <Menu val={val} key={key} />;
        })}
      </ul>
    </div>
  );
}

export default SideBarDemo;
