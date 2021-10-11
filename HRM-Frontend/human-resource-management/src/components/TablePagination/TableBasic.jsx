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
          .map((col) => col.accessor),
      },
    },
    useFilters,
    useGlobalFilter,
    useSortBy,
    usePagination,
    useRowSelect,
    useBlockLayout,
    useSticky
    // (hooks) => {
    //   hooks.visibleColumns.push((columns) => [
    //     // Let's make a column for selection
    //     {
    //       id: "selection",
    //       // The header can use the table's getToggleAllRowsSelectedProps method
    //       // to render a checkbox
    //       Header: ({ getToggleAllRowsSelectedProps }) => (
    //         <IndeterminateCheckbox {...getToggleAllRowsSelectedProps()} />
    //       ),
    //       // The cell can use the individual row's getToggleRowSelectedProps method
    //       // to the render a checkbox
    //       Cell: ({ row }) => (
    //         <IndeterminateCheckbox {...row.getToggleRowSelectedProps()} />
    //       ),
    //     },
    //     ...columns,
    //   ]);
    // }
  );

  const { pageIndex, pageSize, globalFilter } = state;

  return (
    <>
      <div className="herder-table">
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
      <Styles>
        <div className="table-sticky">
          <table {...getTableProps()} className="tablee sticky" id={tid}>
            <thead className="headerr">
              {headerGroups.map((headerGroup) => (
                <tr {...headerGroup.getHeaderGroupProps()} className="tr">
                  {headerGroup.headers.map((column) => (
                    <th
                      {...column.getHeaderProps(column.getSortByToggleProps())}
                      className="th"
                    >
                      {column.render("Header")}
                      <span>
                        {column.isSorted
                          ? column.isSortedDesc
                            ? " 🔽"
                            : " 🔼"
                          : ""}
                      </span>
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
            <tbody {...getTableBodyProps()} className="bodyy">
              {page.map((row, i) => {
                prepareRow(row);
                // console.log(row);
                return (
                  <Link to={link + row.original.id} className="link-item">
                    <tr {...row.getRowProps()} className="tr">
                      {row.cells.map((cell) => {
                        return (
                          <td {...cell.getCellProps()} className="td">
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
            {[5, 10, rows.length].map((pageSize) => (
              <option key={pageSize} value={pageSize}>
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
