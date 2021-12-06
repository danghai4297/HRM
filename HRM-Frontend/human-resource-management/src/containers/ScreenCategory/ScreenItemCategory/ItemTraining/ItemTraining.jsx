import React, { useContext, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import { NVCOLUMNS } from "../ItemTraining/NvColumns";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import TablePagination from "../../../../components/TablePagination/TablePagination";
import ProductApi from "../../../../api/productApi";

function ItemTraining(props) {
  const link = "/category/training/";
  const fileName = "Hinhthucdaotao";
  const [dataDmHtdt, setDataDmHtdt] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMHTDT();
        setDataDmHtdt(response);
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
            <h4 className="">Hình thức đào tạo</h4>
          </div>
          <div className="button">
            <Link to="/category/training/add" className="link-item">
              <input
                type="submit"
                className="btn btn-primary addTable"
                value="Thêm"
              />
            </Link>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="htdt"
              filename={fileName}
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
            <ExportCSV csvData={dataDmHtdt} fileName={fileName} />
          </div>
        </div>
        <div className="table-nv">
          <TablePagination
            link={link}
            tid="htdt"
            columns={NVCOLUMNS}
            data={dataDmHtdt}
          />
        </div>
      </div>
    </>
  );
}

export default ItemTraining;
