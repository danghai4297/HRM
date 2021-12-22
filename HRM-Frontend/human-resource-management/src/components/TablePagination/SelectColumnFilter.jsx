import React from "react";

function SelectColumnFilter(props) {
  const { column } = props;
  const { filterValue, setFilter, preFilteredRows, id } = column;

  const options = React.useMemo(() => {
    const options = new Set();
    preFilteredRows.forEach((row) => {
      options.add(row.values[id]);
    });
    return [...options.values()];
  }, [id, preFilteredRows]);

  return (
    <select
      className="select-item custom-select"
      value={filterValue}
      onChange={(e) => {
        setFilter(e.target.value || undefined);
      }}
    >
      <option value="">Tất cả</option>
      {options.map((option, i) => (
        <option key={i} value={option}>
          {option}
        </option>
      ))}
    </select>
  );
}

export default SelectColumnFilter;
