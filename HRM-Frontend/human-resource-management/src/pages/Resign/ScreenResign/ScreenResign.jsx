import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { NVCOLUMNS2, NVCOLUMNSRESIZE } from "./NvColumns";

import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import useWindowDimensions from "../../../hook/useWindowDimensions";
import ProductApi from "../../../api/productApi";
import TablePagination from "../../../components/TablePagination/TablePagination";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function ScreenResign(props) {
  const link = "/profile/detail/";
  const fileName = "DSnhanviennguviec";
  const [dataAllNvnv, setDataAllNvnv] = useState([]);
  const [columns, setColumns] = useState([]);
  const [open, setOpen] = useState(false);

  useDocumentTitle("Nghỉ việc");

  const { width } = useWindowDimensions();

  useEffect(() => {
    const reSizeTable = () => {
      if (width < 1025) {
        setColumns(NVCOLUMNSRESIZE);
      } else {
        setColumns(NVCOLUMNS2);
      }
    };
    reSizeTable();
  }, [width]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllNvnv();
        setDataAllNvnv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataAllNvnv]);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Tất cả nhân viên nghỉ việc</h2>
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
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tableHd"
            columns={columns}
            data={dataAllNvnv}
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

export default ScreenResign;
