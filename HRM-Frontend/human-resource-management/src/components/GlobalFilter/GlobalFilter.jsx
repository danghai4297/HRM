import React from "react";

function GlobalFilter(props) {
  const { filter, setFilter } = props;
  return (
    <span>
      Search: {""}
      <input value={filter || ""} onChange={(e) => setFilter(e.target.value)} />
    </span>
  );
}

export default GlobalFilter;
