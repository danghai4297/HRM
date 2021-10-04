import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenTableNV.scss";
import { ListContext } from "../../Contexts/ListContext";
import TablePagination from "../TablePagination/TablePagination";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { NVCOLUMNS } from "./NvColumns";
import { ExportCSV } from "../ExportFile/ExportFile";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const fileName = "DSNV";
  const { list } = useContext(ListContext);
  const [dataXp, setDataXp] = useState(list);

  useEffect(() => {
    const newData = [];
    dataXp.map((item) => {
      item.gender ? (item.gender = "nam") : (item.gender = "nu");
      newData.push(item);
    });
    setDataXp(newData);
    console.log(dataXp);
  }, []);

  return (
    <>
      <div className="herder-content sticky-top">
        <div>
          <h2 className="">Tất cả nhân viên</h2>
        </div>
        <div className="button">
          <input type="submit" className="btn btn-primary " value="Thêm" />
          <ExportCSV csvData={dataXp} fileName={fileName} />
        </div>
      </div>
      <div className="table-nv">
        <TablePagination tid="tablenv" columns={NVCOLUMNS} data={list} />
      </div>
    </>
  );
}

export default ScreenTableNV;
