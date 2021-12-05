import React from "react";
import PropTypes from "prop-types";
import "./ItemExcel.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportDashBoard } from "../ExportFile/ExportDashBoard";
import { ExportCSV } from "../ExportFile/ExportFile";

ItemExcel.propTypes = {
  title: PropTypes.array,
};

ItemExcel.defaultProps = {
  title: null,
};

function ItemExcel(props) {
  const { dataXp, fileName, title } = props;

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
      <ExportDashBoard csvData={dataXp} fileName={fileName} title={title} />
      {/* <div className="bot-excel">
        <h>Danh sach {title}</h>
        <span className="small-icon">
          <FontAwesomeIcon icon={["fas", "chevron-circle-right"]} />
        </span>
      </div> */}
    </div>
  );
}

export default ItemExcel;
