import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import productApi from "../../api/productApi";
import { Link } from "react-router-dom";

function ScreenSalary(props) {
  const link = "/salary/detail/";
  let fileName = "Danhsachluong";
  const [dataAllL, setDataAllL] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await productApi.getAllL();
        setDataAllL(response);
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
            <h2 className="">Danh sách lương</h2>
          </div>
          <div className="button">
            <Link to="/salary/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tabledc"
              fileName={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataAllL} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tabledc"
            columns={NVCOLUMNS}
            data={dataAllL}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenSalary;
