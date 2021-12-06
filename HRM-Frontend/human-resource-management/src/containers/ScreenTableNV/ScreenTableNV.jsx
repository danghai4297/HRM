import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenTableNV.scss";
import { NVCOLUMNS2 } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import productApi from "../../api/productApi";
import { Link } from "react-router-dom";
import { useDocumentTitle } from "../../hook/TitleDocument";

import jwt_decode from "jwt-decode";
import ProductApi from "../../api/productApi";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const link = "/profile/detail/";
  const fileName = "DSNV";
  const [dataAllNv, setdataAllNv] = useState([]);
  useDocumentTitle("Hồ sơ");

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
        const responseNv = await productApi.getAllNv();
        setdataAllNv(responseNv);
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
            <h2 className="">Tất cả nhân viên</h2>
          </div>
          <div className="button">
            <Link to="/profile/add" className="link-item">
              <input type="submit" className="btn addTable" value="Thêm" />
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
            columns={NVCOLUMNS2}
            data={dataAllNv}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenTableNV;
