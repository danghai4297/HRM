import React from "react";
import { Route, Redirect } from "react-router-dom";
import jwt_decode from "jwt-decode";
function ProtectedRoute({ component: Component, ...res }) {
  const token = localStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  return (
    <Route
      {...res}
      render={(props) => {
        return localStorage.getItem('resultObj') && decoded.role === "user" ? (
          <Component {...props} />
        ) : (
          <Redirect to="/category" />
        );
      }}
    />
  );
}

export default ProtectedRoute;
