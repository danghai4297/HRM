import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import { Link } from "react-router-dom";
import ProductApi from "../../api/productApi";
import { useDocumentTitle } from "../../hook/TitleDocument";

function ScreenReward(props) {
  const link = "/reward/detail/";
  const fileName = "DSkhenthuong";
  const [dataDskt, setDataDskt] = useState([]);
  useDocumentTitle("Khen thưởng");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllKTNV();
        setDataDskt(responseNv);
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
            <h2 className="">Nhân viên được khen thưởng</h2>
          </div>
          <div className="button">
            <Link to="/reward/add" className="link-item">
              <input
                type="submit"
                className="btn btn-primary addTable"
                value="Thêm"
              />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tableHd"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataDskt} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tableHd"
            columns={NVCOLUMNS}
            data={dataDskt}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenReward;
