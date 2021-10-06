import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenTableNV.scss";
import { ListContext } from "../../Contexts/ListContext";
import { NVCOLUMNS2 } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import productApi from "../../api/productApi";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const link = "/profile/";
  const fileName = "DSNV";
  const { list } = useContext(ListContext);
  const [dataAllNv, setdataAllNv] = useState([]);
  console.log(dataAllNv);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await productApi.getAllNv();
        // console.log(responseNv);
        setdataAllNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataAllNv);

  return (
    <>
      {/* <Route path="/profile/:id" component={Detail} /> */}
      <div className="screen-table-nv">
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
            columns={NVCOLUMNS2}
            data={dataAllNv}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenTableNV;
