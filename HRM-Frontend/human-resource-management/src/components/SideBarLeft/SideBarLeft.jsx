import React, { useContext, useState } from "react";
import "./SideBarLeft.scss";
import { SideBarData } from "./SideBarDate";
import { Link, useRouteMatch } from "react-router-dom";
import jwt_decode from "jwt-decode";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { SideBarContext } from "../../Contexts/StateContext";
function SideBarLeft() {
  // const [changeForm, setChangeForm] = useState(true);
  const { sideBar, setSiderBar } = useContext(SideBarContext);
  function Menu({ val }) {
    let match = useRouteMatch({
      path: val.link,
    });
    return (
      <Link to={val.link} className="link-item" id={match ? "actived" : ""}>
        <li
          className={sideBar !== false ? "row" : "row changes"}
          id={match ? "active" : ""}
        >
          <div id="icon">{val.icon}</div>
          {sideBar !== false && <div className="title">{val.title}</div>}
          {/* <span className="tooltip">{val.title}</span> */}
        </li>
      </Link>
    );
  }

  return (
    <>
      <ul
        className={
          sideBar === false
            ? "SidebarList sticky-top change"
            : "SidebarList sticky-top"
        }
      >
        <li className="title-project">
          <div>
            <h1 className={sideBar === false ? "title-name2" : "title-names"}>
              HRM
            </h1>
          </div>
          <button
            className={sideBar === false ? "btnmenu-change" : "btnmenu"}
            onClick={() => setSiderBar(!sideBar)}
          >
            <FontAwesomeIcon icon={["fas", "bars"]} />
          </button>
        </li>

        {SideBarData.filter(
          (val) =>
            val.roles.filter((element) =>
              jwt_decode(sessionStorage.getItem("resultObj"))
                .role.split(";")
                .includes(element)
            ).length !== 0
        ).map((val, key) => {
          return <Menu val={val} key={key} />;
        })}

        <img className="Side-img" src="/Images/pcr.jpg" alt="" />
      </ul>
    </>
  );
}

export default SideBarLeft;
