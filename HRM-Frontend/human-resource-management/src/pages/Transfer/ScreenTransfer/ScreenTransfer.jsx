import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../../components/ExportFile/ExportFile";
import TablePagination from "../../../components/TablePagination/TablePagination";
import productApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function ScreenTransfer(props) {
  const link = "/transfer/detail/";
  let fileName = "danhsachdieuchuyen";
  const [dataDCAll, setDataDCAll] = useState([]);
  const [open, setOpen] = useState(false);
  useDocumentTitle("Quá trình công tác");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await productApi.getAllDCNV();
        setDataDCAll(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataDCAll]);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Quá trình công tác</h2>
          </div>
          <div className="button">
            <Link to="/transfer/add" className="link-item">
              <input
                type="submit"
                className="btn btn-primary addTable"
                value="Thêm"
              />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tableHd"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataDCAll} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tableHd"
            columns={NVCOLUMNS}
            data={dataDCAll}
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

export default ScreenTransfer;
