import React from "react";
import { Route, Redirect } from "react-router-dom";
import jwt_decode from "jwt-decode";
function ProtectedRoute({ component: Component, roles, ...res }) {
  // const token = localStorage.getItem("resultObj");
  // const decoded = jwt_decode(token);
  return (
    <Route
      {...res}
      render={(props) => {
        return localStorage.getItem('resultObj') && roles.includes(jwt_decode(localStorage.getItem("resultObj")).role) ? (
          <Component {...props} />
        ) : (
          <Redirect to="/login" />
        );
      }}
    />
  );
}

export default ProtectedRoute;
