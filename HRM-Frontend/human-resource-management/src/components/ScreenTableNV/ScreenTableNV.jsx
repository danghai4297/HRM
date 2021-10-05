import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenTableNV.scss";
import { ListContext } from "../../Contexts/ListContext";
import TablePagination from "../TablePagination/TablePagination";
import { NVCOLUMNS } from "./NvColumns";
import { ExportCSV } from "../ExportFile/ExportFile";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Route } from "react-router";
import Detail from "../Detail/Detail";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const link = "/detail/";
  const fileName = "DSNV";
  const { list } = useContext(ListContext);
  // const [dataEp, setDataEp] = useState([]);
  // const newData = [];

  // useEffect(() => {
  //   dataEp.map((item) => {
  //     item.gender === true ? (item.gender = "Nam") : (item.gender = "Nữ");
  //     newData.push(item);
  //   });
  //   setDataEp(newData);
  //   // return () => {
  //   //   cleanup;
  //   // };
  // }, []);

  return (
    <>
      {/* <Route path="/profile/:id" component={Detail} /> */}
      <div className="herder-content sticky-top">
        <div>
          <h2 className="">Tất cả nhân viên</h2>
        </div>
        <div className="button">
          <input type="submit" className="btn btn-primary" value="Thêm" />
          <ReactHTMLTableToExcel
            id="test-table-xls-button"
            className="download-table-xls-button"
            table="tablenv"
            filename="Danh sach nhan vien"
            sheet="tablexls"
            buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
          />
          <ExportCSV csvData={list} fileName={fileName} />
        </div>
      </div>
      <div className="table-nv">
        <TablePagination
          link={link}
          tid="tablenv"
          columns={NVCOLUMNS}
          data={list}
        />
      </div>
    </>
  );
}

export default ScreenTableNV;
