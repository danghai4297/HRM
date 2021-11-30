import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import productApi from "../../api/productApi";
import { Link } from "react-router-dom";
import TableLog from "../../components/TablePagination/TableLog";
import { useDocumentTitle } from "../../hook/TitleDocument";

function ScreenAccountLog(props) {
  const fileName = "Lịch sử làm việc";
  const [dataAllLS, setdataAllLS] = useState([]);
  useDocumentTitle("Lịch sử làm việc");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await productApi.getAllLS();
        setdataAllLS(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Lịch sử làm việc</h2>
          </div>
          <div className="button">
            <Link to="/contract/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tableHd"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataAllLS} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TableLog
            ma="maHopDong"
            tid="tableHd"
            columns={NVCOLUMNS}
            data={dataAllLS}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenAccountLog;
