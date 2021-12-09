import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS, NVCOLUMNSMD } from "./NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../../components/ExportFile/ExportFile";
import TablePagination from "../../../components/TablePagination/TablePagination";
import ProductApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import useWindowDimensions from "../../../hook/useWindowDimensions";

function ScreenDiscipline(props) {
  const link = "/discipline/detail/";
  const fileName = "DSkyluat";
  const [dataAllkl, setDataAllKl] = useState([]);
  const [columns, setColumns] = useState([]);

  useDocumentTitle("Kỷ luật");
  const { width } = useWindowDimensions();

  useEffect(() => {
    const reSizeTable = () => {
      if (width < 1025) {
        setColumns(NVCOLUMNSMD);
      } else {
        setColumns(NVCOLUMNS);
      }
    };
    reSizeTable();
  }, [width]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllKLNV();
        setDataAllKl(response);
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
            <h2 className="">Nhân viên bị kỷ luật</h2>
          </div>
          <div className="button">
            <Link to="/discipline/add" className="link-item">
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
            <ExportCSV csvData={dataAllkl} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="tableHd"
            columns={columns}
            data={dataAllkl}
          />
        </div>
      </div>
    </>
  );
}

export default ScreenDiscipline;
