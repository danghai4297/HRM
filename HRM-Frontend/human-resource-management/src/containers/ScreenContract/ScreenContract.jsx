import React, { useContext, useEffect, useRef, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenContract.scss";
import { NVCOLUMNSHD } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import productApi from "../../api/productApi";
import { Link } from "react-router-dom";
import { useReactToPrint } from "react-to-print";
import { ComponentToPrint } from "../../components/ToPrint/ComponentToPrint";
import { Button } from "react-bootstrap";
import { useDocumentTitle } from "../../hook/TitleDocument";

function ScreenContract(props) {
  const link = "/contract/detail/";
  const fileName = "Danhsachhopdong";
  const [dataAllHd, setdataAllHd] = useState([]);
  useDocumentTitle("Hợp đồng");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await productApi.getAllHd();
        // console.log(responseNv);
        setdataAllHd(responseNv);
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
            <h2 className="">Danh sách hợp đồng</h2>
          </div>
          <div className="button">
            <Link to="/contract/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>

            {/* export excel */}
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tableHd"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataAllHd} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            ma="maHopDong"
            link={link}
            tid="tableHd"
            columns={NVCOLUMNSHD}
            data={dataAllHd}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenContract;
