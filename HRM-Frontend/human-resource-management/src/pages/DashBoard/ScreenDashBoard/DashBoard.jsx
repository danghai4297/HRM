import React, { useEffect, useState } from "react";
import "./DashBoard.scss";

import ItemDashBoard from "../ItemDashBoard/ItemDashBoard";
import ItemExcel from "../ItemExcel/ItemExcel";
import TableBasic from "../../../components/TablePagination/TableBasic";
import ProductApi from "../../../api/productApi";
import { NVCOLUMNSHD, NVCOLUMNSSALARY } from "./NvColumns";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

DashBoard.propTypes = {};

function DashBoard() {
  let link1 = "/contract/detail/";
  let link2 = "/salary/detail/";
  let fileName = "DSNV";
  let fileName2 = "DSLNV";
  const [dataAllNv, setDataAllNv] = useState([]);
  const [dataAllHd, setDataAllHd] = useState([]);
  const [dataAllLNV, setDataAllLNV] = useState([]);
  const [dataAllNVnv, setDataAllNVnv] = useState([]);
  useDocumentTitle("Tổng quan");

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllNv();
        const responseHd = await ProductApi.getAllHd();
        const responseLNV = await ProductApi.getAllL();
        const responseNVnv = await ProductApi.getAllNvnv();
        setDataAllNv(responseNv);
        setDataAllHd(responseHd);
        setDataAllLNV(responseLNV);
        setDataAllNVnv(responseNVnv);
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
              title="Nhân viên"
              link="/profile"
              color="rgba(27, 92, 173,1)"
              colorBot="rgb(26, 115, 232)"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees={dataAllHd.length}
              fontIcon="file-signature"
              title="hợp đồng"
              link="/contract"
              color="rgb(67, 160, 71)"
              colorBot="rgba(47, 185, 47,1)"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees={dataAllLNV.length}
              fontIcon="money-check-alt"
              title="lương nhân viên"
              link="/salary"
              color="rgb(255, 167, 38)"
              colorBot="rgba(249, 201, 86,1)"
            />
          </div>
          <div className="item-da">
            <ItemDashBoard
              totalEmployees={dataAllNVnv.length}
              fontIcon="users-slash"
              title="N.viên nghỉ việc"
              link="/resign"
              color="rgb(236, 64, 122)"
              colorBot="rgb(216, 27, 96)"
            />
          </div>
        </div>
        <div className="excel-item">
          <div className="item-da">
            <ItemExcel
              dataXp={dataAllNv}
              fileName={fileName}
              title="nhân viên"
            />
          </div>
          <div className="item-da">
            <ItemExcel
              dataXp={dataAllLNV}
              fileName={fileName2}
              title="lương nhân viên"
            />
          </div>
        </div>
        <div className="two-table">
          <div className="tablex table-one">
            <h3>Danh sách hợp đồng</h3>
            <TableBasic
              link={link1}
              tid="tablenv"
              columns={NVCOLUMNSHD}
              data={dataAllHd}
            />
          </div>
          <div className="tablex table-two">
            <h3>Danh sách lương</h3>
            <TableBasic
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
