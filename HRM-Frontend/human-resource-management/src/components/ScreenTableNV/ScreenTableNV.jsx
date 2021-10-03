import React, { useContext } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

import "./ScreenTableNV.scss";
import { ListContext } from "../../Contexts/ListContext";
import TablePagination from "../TablePagination/TablePagination";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import SelectColumnFilter from "../TablePagination/SelectColumnFilter";
import { format } from "date-fns";

ScreenTableNV.propTypes = {};

function ScreenTableNV(props) {
  const columns = [
    {
      Header: "ID",
      accessor: "id",
      sticky: "left",
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "First Name",
      accessor: "firstName",
      sticky: "left",
      minWidth: 200,
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Last Name",
      accessor: "lastName",
      sticky: "left",
      minWidth: 200,
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Email",
      accessor: "email",
      minWidth: 300,
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Gender",
      accessor: (row) => {
        return row.gender === false ? "Nữ" : "Nam";
      },
      // accessor: "gender",
      minWidth: 200,
      Filter: SelectColumnFilter,
      // Cell: ({ value }) => {
      //   return value === true ? "Male" : "Female";
      // },
    },
    {
      Header: "Birthday",
      accessor: "birthday",
      minWidth: 200,
      Filter: SelectColumnFilter,
      Cell: ({ value }) => {
        return format(new Date(value), "dd/MM/yyyy");
      },
    },
    {
      Header: "Salary",
      accessor: "salary",
      minWidth: 150,
      Filter: SelectColumnFilter,
      disableFilters: true,
    },
    {
      Header: "Phone",
      accessor: "phone",
      minWidth: 200,
      Filter: SelectColumnFilter,
      disableFilters: true,
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
