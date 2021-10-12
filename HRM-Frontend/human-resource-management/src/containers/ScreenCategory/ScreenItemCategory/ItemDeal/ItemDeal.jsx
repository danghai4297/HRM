import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import TablePagination from "../../../../components/TablePagination/TablePagination";
import ProductApi from "../../../../api/productApi";

function ItemDeal(props) {
  const link = "/profile/";
  const fileName = "Cacloaihopdong";
  const [dataClhd, setDataClhd] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllDMLHD();
        setDataClhd(responseNv);
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
            <h4 className="">Các loại hợp đồng</h4>
          </div>
          <div className="button">
            <Link to="/category/deal/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="Lhd"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataClhd} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="Lhd"
            columns={NVCOLUMNS}
            data={dataClhd}
          />
        </div>
      </div>
    </>
  );
}

export default ItemDeal;
