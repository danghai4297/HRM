import React, { useState } from "react";
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

function TableLog(props) {
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
    //Collumns hiding
    allColumns,
    getToggleHideAllColumnsProps,
    prepareRow,
  } = useTable(
    {
      columns,
      data,
      initialState: {
        pageIndex: 0,
        hiddenColumns: columns
          .filter((col) => col.show === false)
          .map((col, key) => ((key = { key }), col.accessor)),
        filters: [
          {
            id: "trangThai",
            value: "Kích hoạt",
          },
        ],
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

  const { pageIndex, pageSize, globalFilter, selectedRowIds } = state;

  const [chooseCol, setChooseCol] = useState(false);

  function disableChooseCol() {
    setChooseCol((value) => !value);
  }

  return (
    <>
      <div className="herder-table">
        <div className="check-col">
          <div>
            <div className="select-fillter">
              {/* ẩn hiện bảng chọn cột */}
              <button className="btn-fil" onClick={disableChooseCol}>
                <FontAwesomeIcon icon={["fas", "filter"]} />
              </button>
              {/* dropdownlist */}
              <div className="select">
                {allColumns.map((column, key) => (
                  <div className="select" key={key}>
                    {column.canFilter && (
                      <div className="select">
                        {column.render("Header")}&nbsp;{" "}
                        {column.render("Filter")}&emsp;&emsp;&emsp;
                      </div>
                    )}
                  </div>
                ))}
              </div>
            </div>
            {/* bảng chọn cột */}
            {chooseCol && (
              <div className="choose-col form-check">
                <label
                  className="form-check-label item-chooseCol"
                  style={{ marginLeft: "20px", marginRight: "0.8rem" }}
                >
                  <input
                    type="checkbox"
                    className="form-check-input"
                    {...getToggleHideAllColumnsProps()}
                  />
                  Tất cả
                </label>
                {allColumns.map((column) => (
                  <div className="item-chooseCol form-check" key={column.id}>
                    <label className="form-check-label">
                      <input
                        className="form-check-input"
                        type="checkbox"
                        {...column.getToggleHiddenProps()}
                      />{" "}
                      {column.Header}
                    </label>
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
        {/* tìm kiếm */}
        <div className="search-table">
          <input
            className="search-input"
            placeholder="Search"
            aria-label="true"
            value={globalFilter || ""}
            onChange={(e) => setGlobalFilter(e.target.value)}
          />
          <span className="icon-search">
            <FontAwesomeIcon icon={["fas", "search"]} />
          </span>
        </div>
      </div>

      {/* bảng */}
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
                      {column.isSorted ? (
                        column.isSortedDesc ? (
                          <img src="/Images/ascending.png" width={15} alt="" />
                        ) : (
                          <img src="/Images/descending.png" width={15} alt="" />
                        )
                      ) : (
                        ""
                      )}
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
                    </tr>{" "}
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
            {[10, 25, 50, 100, rows.length].map((pageSize, index) => (
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
              style={{ border: "none", height: "1.6rem", width: "50px" }}
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

export default TableLog;
