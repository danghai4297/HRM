import React, { useContext } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import PropTypes from "prop-types";
import Header from "../Header/Header";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
import "./ScreenTableNV.scss";
import { ListContext } from "../../Contexts/ListContext";
import TablePagination from "../TablePagination/TablePagination";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const columns = [
    {
      Header: "ID",
      accessor: "id",
    },
    {
      Header: "First Name",
      accessor: "firstName",
    },
    {
      Header: "Last Name",
      accessor: "lastName",
    },
    {
      Header: "Email",
      accessor: "email",
    },
    {
      Header: "Gender",
      accessor: "gender",
    },
    {
      Header: "Birthday",
      accessor: "birthday",
    },
    {
      Header: "Salary",
      accessor: "salary",
    },
    {
      Header: "Phone",
      accessor: "phone",
    },
  ];

  const { list } = useContext(ListContext);
  console.log(list);
  return (
    <>
      <div className="herder-content sticky-top">
        <div>
          <h2 className="">Tất cả nhân viên</h2>
        </div>
        <div className="button">
          <input type="submit" className="btn btn-primary " value="Thêm" />
          <button className="btn-fil" type="submit">
            <FontAwesomeIcon icon={["fas", "download"]} />
          </button>
        </div>
      </div>
      <div className="table-nv">
        <TablePagination columns={columns} data={list} />
      </div>
    </>
  );
}

export default ScreenTableNV;
