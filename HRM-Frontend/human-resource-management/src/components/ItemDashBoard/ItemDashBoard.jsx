import React from "react";
import PropTypes from "prop-types";
import "./ItemDashBoard.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

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
  const { totalEmployees, fontIcon, title } = props;

  return (
    <div class="container">
      <div className="top">
        <div className="left">
          <h3>{totalEmployees}</h3>
          <h5>{title}</h5>
        </div>
        <div className="right">
          <span className="big-icon">
            <FontAwesomeIcon icon={["fas", `${fontIcon}`]} />
          </span>
        </div>
      </div>
      <div className="bot">
        <h>Danh sach {title}</h>
        <span className="small-icon">
          <FontAwesomeIcon icon={["fas", "chevron-circle-right"]} />
        </span>
      </div>
    </div>
  );
}

export default ItemDashBoard;
