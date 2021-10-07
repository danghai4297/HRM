import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { ListContext } from "../../../../Contexts/ListContext";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import TablePagination from "../../../../components/TablePagination/TablePagination";

function ItemNest(props) {
  const link = "/profile/";
  const fileName = "Danhmucto";
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
            <h4 className="">Danh sách các tổ</h4>
          </div>
          <div className="button">
            <Link to="/profile/edit" className="link-item">
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
            <ExportCSV csvData={list} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="dmttt"
            columns={NVCOLUMNS}
            data={list}
          />
        </div>
      </div>
    </>
  );
}

export default ItemNest;
