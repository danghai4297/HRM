import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS, NVCOLUMNSMD } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../../components/ExportFile/ExportFile";
import TablePagination from "../../../components/TablePagination/TablePagination";
import { Link } from "react-router-dom";
import ProductApi from "../../../api/productApi";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

function ScreenReward(props) {
  const link = "/reward/detail/";
  const fileName = "DSkhenthuong";
  const [dataDskt, setDataDskt] = useState([]);
  const [columns, setColumns] = useState([]);
  useDocumentTitle("Khen thưởng");

  useEffect(() => {
    const reSizeTable = () => {
      if (window.innerWidth < 1025) {
        setColumns(NVCOLUMNSMD);
      } else {
        setColumns(NVCOLUMNS);
      }
    };
    reSizeTable();
  }, [window.innerWidth]);

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

  // const reSizeTable = () => {
  //   if ((w > 769) & (w < 1025)) {
  //     return (
  //       <TablePagination
  //         link={link}
  //         tid="tableHd"
  //         columns={NVCOLUMNS}
  //         data={dataDskt}
  //       />
  //     );
  //   } else if (w < 769) {
  //     return (
  //       <TablePagination
  //         link={link}
  //         tid="tableHd"
  //         columns={NVCOLUMNSMD}
  //         data={dataDskt}
  //       />
  //     );
  //   }
  // };

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
            columns={columns}
            data={dataDskt}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenReward;
