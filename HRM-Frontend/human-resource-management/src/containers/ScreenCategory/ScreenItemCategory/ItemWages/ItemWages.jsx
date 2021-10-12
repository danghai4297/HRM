import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import TablePagination from "../../../../components/TablePagination/TablePagination";
import ProductApi from "../../../../api/productApi";

function ItemWages(props) {
  const link = "/category/wages/";
  const fileName = "Danhmucnhomluong";
  const [dataDmnl, setDataDmnl] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllDMNL();
        setDataDmnl(responseNv);
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
            <h4 className="">Danh mục nhóm lương</h4>
          </div>
          <div className="button">
            <Link to="/category/wages/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="dmnlc"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataDmnl} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="dmnlc"
            columns={NVCOLUMNS}
            data={dataDmnl}
          />
        </div>
      </div>
    </>
  );
}

export default ItemWages;
