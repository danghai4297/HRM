import React from "react";
import PropTypes from "prop-types";
import "./ItemDashBoard.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";

ItemDashBoard.propTypes = {
  totalEmployees: PropTypes.number,
  fontIcon: PropTypes.array,
  title: PropTypes.array,
};

ItemDashBoard.defaultProps = {
  totalEmployees: null,
  fontIcon: null,
  title: null,
};

function ItemDashBoard(props) {
  const { totalEmployees, fontIcon, title, link, color, colorBot } = props;
  const style = {
    backgroundColor: color,
  };
  const styleBot = {
    backgroundColor: colorBot,
  };
  return (
    <div class="container">
      <div className="top" style={style}>
        <div className="left">
          <h3>{totalEmployees}</h3>
          <h5>{title}</h5>
        </div>
        <div className="right">
          <span className="big-icon">
            <FontAwesomeIcon className="icon" icon={["fas", `${fontIcon}`]} />
          </span>
        </div>
      </div>
      <Link to={link} className="link-item">
        <div style={styleBot} className="bot bot-slide">
          <h>Danh sach {title}</h>
          <span className="small-icon">
            <FontAwesomeIcon icon={["fas", "chevron-circle-right"]} />
          </span>
        </div>
      </Link>
    </div>
  );
}

export default ItemDashBoard;
