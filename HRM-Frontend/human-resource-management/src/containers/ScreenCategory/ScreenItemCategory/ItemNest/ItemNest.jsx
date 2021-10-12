import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import TablePagination from "../../../../components/TablePagination/TablePagination";
import ProductApi from "../../../../api/productApi";

function ItemNest(props) {
  const link = "/category/nest/";
  const fileName = "Danhmucto";
    const [dataAll, setDataAll] = useState([]);

    useEffect(() => {
      const fetchNvList = async () => {
        try {
          const response = await ProductApi.getAllDMT();
          setDataAll(response);
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
            <h4 className="">Danh sách các tổ</h4>
          </div>
          <div className="button">
            <Link to="/category/nest/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="dmttt"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataAll} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="dmttt"
            columns={NVCOLUMNS}
            data={dataAll}
          />
        </div>
      </div>
    </>
  );
}

export default ItemNest;
