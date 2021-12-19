import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "./TablePagination.scss";
import {
  useTable,
  useSortBy,
  useFilters,
  useGlobalFilter,
  usePagination,
  useRowSelect,
  useBlockLayout,
} from "react-table";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Styles } from "./TableStyles";
import { useSticky } from "react-table-sticky";

import { Link } from "react-router-dom";

function TableBasic(props) {
  const { link, tid, columns, data } = props;
  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    state,
    //seach table all col
    setGlobalFilter,
    //pagination table
    page,
    nextPage,
    previousPage,
    canNextPage,
    canPreviousPage,
    pageOptions,
    gotoPage,
    pageCount,
    setPageSize,

    prepareRow,
  } = useTable(
    {
      columns,
      data,
      initialState: {
        pageIndex: 0,
        pageSize: 5,
        hiddenColumns: columns
          .filter((col) => col.show === false)
          .map((col, key) => ((key = { key }), col.accessor)),
      },
    },
    useFilters,
    useGlobalFilter,
    useSortBy,
    usePagination,
    useRowSelect,
    useBlockLayout,
    useSticky
  );

  const { pageIndex, pageSize, globalFilter } = state;

  return (
    <>
      <Styles>
        <div className="table-sticky">
          <table {...getTableProps()} className="tablee sticky" id={tid}>
            <thead className="headerr">
              {headerGroups.map((headerGroup, index) => (
                <tr
                  {...headerGroup.getHeaderGroupProps()}
                  className="tr"
                  key={index}
                >
                  {headerGroup.headers.map((column, index) => (
                    <th
                      {...column.getHeaderProps(column.getSortByToggleProps())}
                      className="th"
                      key={index}
                    >
                      {column.render("Header")}
                      <span>
                        {column.isSorted ? (
                          column.isSortedDesc ? (
                            <img
                              src="/Images/ascending.png"
                              width={15}
                              alt=""
                            />
                          ) : (
                            <img
                              src="/Images/descending.png"
                              width={15}
                              alt=""
                            />
                          )
                        ) : (
                          ""
                        )}
                      </span>
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
            <tbody {...getTableBodyProps()} className="bodyy">
              {page.map((row, index) => {
                prepareRow(row);
                return (
                  <Link
                    to={link + row.original.id}
                    className="link-item"
                    key={index}
                  >
                    <tr {...row.getRowProps()} className="tr">
                      {row.cells.map((cell, index) => {
                        return (
                          <td
                            {...cell.getCellProps()}
                            className="td"
                            key={index}
                          >
                            {cell.render("Cell")}
                          </td>
                        );
                      })}
                    </tr>
                  </Link>
                );
              })}
            </tbody>
          </table>
        </div>
      </Styles>
      <div className="footer-table">
        <div className="f-table-left">
          {/* page */}
          <h6>
            Trang {pageIndex + 1} Tổng {pageOptions.length}
          </h6>
          {/* show item */}
          <select
            className="select-item custom-select"
            value={pageSize}
            onChange={(e) => setPageSize(Number(e.target.value))}
          >
            {[5, 10, 20, 50, rows.length].map((pageSize, index) => (
              <option key={pageSize} value={pageSize} key={index}>
                {pageSize}
              </option>
            ))}
          </select>
        </div>
        {/* next pre page */}
        <div className="f-table-right">
          {/* go to page */}
          <span>
            | Đến trang :{" "}
            <input
              type="number"
              defaultValue={pageIndex + 1}
              onChange={(e) => {
                const pageNumber = e.target.value
                  ? Number(e.target.value) - 1
                  : 0;
                gotoPage(pageNumber);
              }}
              style={{ width: "50px" }}
            />
          </span>{" "}
          <button
            className="btn-next-pre"
            onClick={() => gotoPage(0)}
            disabled={!canPreviousPage}
          >
            <FontAwesomeIcon icon={["fas", "angle-double-left"]} />
          </button>
          <button
            className="btn-next-pre"
            onClick={() => previousPage()}
            disabled={!canPreviousPage}
          >
            <FontAwesomeIcon icon={["fas", "angle-left"]} />
          </button>
          <button
            className="btn-next-pre"
            onClick={() => nextPage()}
            disabled={!canNextPage}
          >
            <FontAwesomeIcon icon={["fas", "angle-right"]} />
          </button>
          <button
            className="btn-next-pre"
            onClick={() => gotoPage(pageCount - 1)}
            disabled={!canNextPage}
          >
            <FontAwesomeIcon icon={["fas", "angle-double-right"]} />
          </button>
        </div>
      </div>
    </>
  );
}

export default TableBasic;
