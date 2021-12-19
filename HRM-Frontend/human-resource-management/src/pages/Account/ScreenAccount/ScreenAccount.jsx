import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { NVCOLUMNSHD } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../../components/ExportFile/ExportFile";
import TablePagination from "../../../components/TablePagination/TablePagination";
import { Link } from "react-router-dom";
import LoginApi from "../../../api/login";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function ScreenAccount(props) {
  const link = "/account/detail/";
  const fileName = "Danhsachhopdong";
  const [dataAllAcc, setdataAllAcc] = useState([]);
  const [open, setOpen] = useState(false);
  useDocumentTitle("Danh sách tài khoản");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await LoginApi.getAllAcc();
        setdataAllAcc(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataAllAcc]);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Danh sách tài khoản</h2>
          </div>
          <div className="button">
            <Link to="/account/add" className="link-item">
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
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default ScreenAccount;
