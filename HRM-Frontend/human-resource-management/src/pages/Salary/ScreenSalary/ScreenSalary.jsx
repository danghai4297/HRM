import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import TablePagination from "../../../components/TablePagination/TablePagination";
import productApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

import jwt_decode from "jwt-decode";
import ProductApi from "../../../api/productApi";

function ScreenSalary(props) {
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const link = "/salary/detail/";
  let fileName = "Danhsachluong";
  const [dataAllL, setDataAllL] = useState([]);
  const [open, setOpen] = useState(false);
  useDocumentTitle("Danh sách lương");

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
        const response = await productApi.getAllL();
        setDataAllL(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataAllL]);

  return (
    <>
      <div className="screen-table-nv">
        <div className="herder-content sticky-top">
          <div>
            <h2 className="">Danh sách lương</h2>
          </div>
          <div className="button">
            <Link to="/salary/add" className="link-item">
              <input
                type="submit"
                className="btn btn-primary addTable"
                value="Thêm"
              />
            </Link>
            <div onClick={(e) => handleClick()}>
              <ReactHTMLTableToExcel
                id="test-table-xls-button"
                className="download-table-xls-button"
                table="tabledc"
                fileName={fileName}
                sheet="tablexls"
                buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
              />
            </div>
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tabledc"
            columns={NVCOLUMNS}
            data={dataAllL}
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

export default ScreenSalary;
