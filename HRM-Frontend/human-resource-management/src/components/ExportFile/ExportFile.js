import React from "react";
import "./Export.scss";

import * as FileSaver from "file-saver";

import * as XLSX from "xlsx";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import jwt_decode from "jwt-decode";
import ProductApi from "../../api/productApi";

export const ExportCSV = ({ ful, csvData, fileName }) => {
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const fileType =
    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8";

  const fileExtension = ".xlsx";

  const exportToCSV = (csvData, fileName) => {
    const ws = XLSX.utils.json_to_sheet(csvData);

    const wb = { Sheets: { data: ws }, SheetNames: ["data"] };

    const excelBuffer = XLSX.write(wb, { bookType: "xlsx", type: "array" });

    const data = new Blob([excelBuffer], { type: fileType });

    FileSaver.saveAs(data, fileName + fileExtension);
  };

  const handleClick = async (csvData, fileName) => {
    exportToCSV(csvData, fileName);
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tải về file ${fileName}`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  return (
    <button
      onClick={(e) => handleClick(csvData, fileName)}
      className="btn-export"
      type="submit"
    >
      <FontAwesomeIcon icon={["fas", "file-excel"]} /> All
    </button>
    // <button onClick={(e) => exportToCSV(csvData, fileName)}>Export</button>
  );
};
