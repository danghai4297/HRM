import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { ListContext } from "../../Contexts/ListContext";
import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import productApi from "../../api/productApi";
import { Link } from "react-router-dom";

function ScreenTransfer(props) {
  const link = "/transfer/detail/";
  const fileName = "danhsachdieuchuyen";
  const { list } = useContext(ListContext);
  //   const [dataAllNv, setdataAllNv] = useState([]);
  //   console.log(dataAllNv);

  //   useEffect(() => {
  //     const fetchNvList = async () => {
  //       try {
  //         const responseNv = await productApi.getAllNv();
  //         // console.log(responseNv);
  //         setdataAllNv(responseNv);
  //       } catch (error) {
  //         console.log("false to fetch nv list: ", error);
  //       }
  //     };
  //     fetchNvList();
  //   }, []);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Danh sách điều chuyển</h2>
          </div>
          <div className="button">
            <Link to="/transfer/add" className="link-item">
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
            <ExportCSV csvData={list} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tableHd"
            columns={NVCOLUMNS}
            data={list}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenTransfer;
