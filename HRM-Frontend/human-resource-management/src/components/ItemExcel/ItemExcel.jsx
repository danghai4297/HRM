import React from "react";
import PropTypes from "prop-types";
import "./ItemExcel.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

ItemExcel.propTypes = {
  title: PropTypes.array,
};

ItemExcel.defaultProps = {
  title: null,
};

function ItemExcel(props) {
  const { title } = props;

  return (
    <div class="container">
      <div className="top-excel">
        <div className="left">
          <h3>Excel</h3>
          <h5>xuất báo cáo</h5>
        </div>
        <div className="right">
          <span className="big-icon">
            <FontAwesomeIcon icon={["fas", "file-excel"]} />
          </span>
        </div>
      </div>
      <div className="bot-excel">
        <h>Danh sach {title}</h>
        <span className="small-icon">
          <FontAwesomeIcon icon={["fas", "chevron-circle-right"]} />
        </span>
      </div>
    </div>
  );
}

export default ItemExcel;
