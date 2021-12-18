import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../../components/ExportFile/ExportFile";
import productApi from "../../../api/productApi";
import TableLog from "../../../components/TablePagination/TableLog";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function ScreenAccountLog(props) {
  const fileName = "Lịch sử làm việc";
  const [dataAllLS, setdataAllLS] = useState([]);
  const [open, setOpen] = useState(false);
  useDocumentTitle("Lịch sử làm việc");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await productApi.getAllLS();
        setdataAllLS(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataAllLS]);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Lịch sử làm việc</h2>
          </div>
          <div className="button">
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tableHd"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataAllLS} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TableLog
            ma="maHopDong"
            tid="tableHd"
            columns={NVCOLUMNS}
            data={dataAllLS}
          />
        </div>
      </div>
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default ScreenAccountLog;
