import React from "react";
import { useLocation } from "react-router-dom";
function ScreenNotFound() {
  let location = useLocation();
  return (
    <div>
      <h1>Page Not match for <code>{location.pathname}</code></h1>
    </div>
  );
}

export default ScreenNotFound;
