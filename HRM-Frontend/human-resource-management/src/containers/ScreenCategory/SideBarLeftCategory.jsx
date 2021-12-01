import React from "react";
import { SideBarLeftCategoryData } from "./SideBarLeftCategoryData";
import { Link, useRouteMatch } from "react-router-dom";
import "./SideBarLeftCategory.scss";
import { useDocumentTitle } from "../../hook/TitleDocument";
function SideBarLeftCategory() {
  const [documentTitle, setDocumentTitle] =
    useDocumentTitle("Danh mục dân tộc");
  function ListMenu({ val }) {
    let match = useRouteMatch({
      path: val.link,
    });
    return (
      <Link
        to={val.link}
        className="category-link"
        onClick={() => setDocumentTitle(val.title)}
      >
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
          {SideBarLeftCategoryData.map((val, key) => {
            return <ListMenu val={val} key={key} />;
          })}
        </ul>
      </div>
    </div>
  );
}

export default SideBarLeftCategory;
