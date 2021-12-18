import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenTableNV.scss";
import { NVCOLUMNS2, NVCOLUMNSRESIZE } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../../components/ExportFile/ExportFile";
import TablePagination from "../../../components/TablePagination/TablePagination";
import { Link } from "react-router-dom";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

import jwt_decode from "jwt-decode";
import ProductApi from "../../../api/productApi";
import useWindowDimensions from "../../../hook/useWindowDimensions";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const link = "/profile/detail/";
  const fileName = "DSNV";
  const [dataAllNv, setdataAllNv] = useState([]);
  const [columns, setColumns] = useState([]);
  const [open, setOpen] = useState(false);

  useDocumentTitle("Hồ sơ");

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

  const handleClick = async () => {
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tải về file ${fileName}`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllNv();
        setdataAllNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataAllNv]);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Tất cả nhân viên</h2>
          </div>
          <div className="button">
            <Link to="/profile/add" className="link-item">
              <input type="submit" className="btn btn-primary" value="Thêm" />
            </Link>
            <div onClick={(e) => handleClick()}>
              <ReactHTMLTableToExcel
                id="test-table-xls-button"
                className="download-table-xls-button"
                table="tablenv"
                filename="Danh sach nhan vien"
                sheet="tablexls"
                buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
              />
            </div>
            <ExportCSV csvData={dataAllNv} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tablenv"
            columns={columns}
            data={dataAllNv}
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

export default ScreenTableNV;
