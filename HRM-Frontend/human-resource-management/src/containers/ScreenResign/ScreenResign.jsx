import React, { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { NVCOLUMNS2, NVCOLUMNSRESIZE } from "./NvColumns";

import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { ExportCSV } from "../../components/ExportFile/ExportFile";
import TablePagination from "../../components/TablePagination/TablePagination";
import productApi from "../../api/productApi";
import { useDocumentTitle } from "../../hook/TitleDocument";
import useWindowDimensions from "../../hook/useWindowDimensions";

function ScreenResign(props) {
  const link = "/profile/detail/";
  const fileName = "DSnhanviennguviec";
  const [dataAllNvnv, setDataAllNvnv] = useState([]);
  const [columns, setColumns] = useState([]);

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
        const responseNv = await productApi.getAllNvnv();
        setDataAllNvnv(responseNv);
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
            <ExportCSV csvData={dataAllNvnv} fileName={fileName} />
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
    </>
  );
}

export default ScreenResign;
