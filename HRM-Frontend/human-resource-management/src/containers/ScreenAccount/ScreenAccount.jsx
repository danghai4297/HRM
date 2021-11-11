import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { NVCOLUMNSHD } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import { Link } from "react-router-dom";
import LoginApi from "../../api/login";

function ScreenAccount(props) {
  const link = "/User/";
  const fileName = "Danhsachhopdong";
  const [dataAllAcc, setdataAllAcc] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await LoginApi.getAllAcc();
        // console.log(responseNv);
        setdataAllAcc(response);
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
            <h2 className="">Danh sách hợp đồng</h2>
          </div>
          <div className="button">
            <Link to="/contract/add" className="link-item">
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
            <ExportCSV csvData={dataAllAcc} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            ma="maHopDong"
            link={link}
            tid="tableHd"
            columns={NVCOLUMNSHD}
            data={dataAllAcc}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenAccount;
