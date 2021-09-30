import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "./TablePagination.scss";
import {
  useTable,
  useSortBy,
  useGlobalFilter,
  usePagination,
  useRowSelect,
} from "react-table";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

function TablePagination(props) {
  const { columns, data } = props;
  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    // rows,
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
    //row select data
    selectedFlatRows,
    //Collumns hiding
    allColumns,
    getToggleHideAllColumnsProps,
    prepareRow,
  } = useTable(
    {
      columns,
      data,
      initialState: { pageIndex: 0 },
    },
    useGlobalFilter,
    useSortBy,
    usePagination,
    useRowSelect
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
            <button className="btn-fil" onClick={disableChooseCol}>
              <FontAwesomeIcon icon={["fas", "filter"]} />
            </button>

            <label className="form-check-label" style={{ marginLeft: "1rem" }}>
              <input
                type="checkbox"
                className="form-check-input"
                {...getToggleHideAllColumnsProps()}
              />
              Hiển thị tất cả
            </label>
            {chooseCol && (
              <div className="choose-col form-check">
                {allColumns.map((column) => (
                  <div className="item-chooseCol form-check" key={column.id}>
                    <label className="form-check-label">
                      <input
                        className="form-check-input"
                        type="checkbox"
                        {...column.getToggleHiddenProps()}
                      />{" "}
                      {column.id}
                    </label>
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
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
      <table {...getTableProps()} className="tablee-nv table table-striped">
        <thead className="thead-dark">
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th {...column.getHeaderProps(column.getSortByToggleProps())}>
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
              <th></th>
            </tr>
          ))}
        </thead>
        <tbody {...getTableBodyProps()}>
          {page.map((row, i) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => {
                  return (
                    <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                  );
                })}
                <td>
                  <FontAwesomeIcon icon={["fas", "ellipsis-h"]} />
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
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
            {[10, 25, 50].map((pageSize) => (
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
      {/* <p>Selected Rows: {Object.keys(selectedRowIds).length}</p>
      <pre>
        <code>
          {JSON.stringify(
            {
              selectedRowIds: selectedRowIds,
              "selectedFlatRows[].original": selectedFlatRows.map(
                (d) => d.original
              ),
            },
            null,
            2
          )}
        </code>
      </pre> */}
    </>
  );
}

export default TablePagination;
