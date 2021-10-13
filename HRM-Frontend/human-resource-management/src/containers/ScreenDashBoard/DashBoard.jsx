import React, { useEffect, useState } from "react";
import "./DashBoard.scss";

import ItemDashBoard from "../../components/ItemDashBoard/ItemDashBoard";
import ItemExcel from "../../components/ItemExcel/ItemExcel";
import TablePagination from "../../components/TablePagination/TablePagination";
import ProductApi from "../../api/productApi";
import { NVCOLUMNS, NVCOLUMNSSALARY } from "./NvColumns";

DashBoard.propTypes = {};

function DashBoard() {
  const link1 = "/category/department/";
  const link2 = "/salary/detail/";
  const fileName = "DSNV";
  const fileName2 = "DSLNV";
  const [dataAllNv, setdataAllNv] = useState([]);
  const [dataAllPB, setdataAllPB] = useState([]);
  const [dataAllLNV, setdataAllLNV] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllNv();
        const responsePB = await ProductApi.getAllDMPB();
        const responseLNV = await ProductApi.getAllL();
        setdataAllNv(responseNv);
        setdataAllPB(responsePB);
        setdataAllLNV(responseLNV);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  return (
    <>
      <div className="Screen-dash-board">
        <div className="item-dash-board">
          <div className="item-da">
            <ItemDashBoard
              totalEmployees={dataAllNv.length}
              fontIcon="users"
              title="nhan vien"
              link="/profile"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees={dataAllPB.length}
              fontIcon="building"
              title="Phong ban"
              link="category/department"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees={dataAllLNV.length}
              fontIcon="money-check-alt"
              title="Luong n.vien"
              link="/salary"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees="12"
              fontIcon="users-slash"
              title="N.vien nghi viec"
              link="/resign"
            />
          </div>
        </div>
        <div className="excel-item">
          <div className="item-da">
            <ItemExcel
              dataXp={dataAllNv}
              fileName={fileName}
              title="nhan vien"
            />
          </div>
          <div className="item-da">
            <ItemExcel
              dataXp={dataAllLNV}
              fileName={fileName2}
              title="luong nhan vien"
            />
          </div>
        </div>
        <div className="two-table">
          <div className="tablex table-one">
            <TablePagination
              link={link1}
              tid="tablenv"
              columns={NVCOLUMNS}
              data={dataAllPB}
            />
          </div>
          <div className="tablex table-two">
            <TablePagination
              link={link2}
              tid="tablenv"
              columns={NVCOLUMNSSALARY}
              data={dataAllLNV}
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default DashBoard;
