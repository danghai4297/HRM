import React from "react";
import { Route, Redirect } from "react-router-dom";
import jwt_decode from "jwt-decode";
function ProtectedRoute({ component: Component, roles, ...res }) {
  return (
    <Route
      {...res}
      render={(props) => {
        return sessionStorage.getItem("resultObj") &&
          roles.filter((element) =>
            jwt_decode(sessionStorage.getItem("resultObj"))
              .role.split(";")
              .includes(element)
          ).length !== 0 ? (
          <Component {...props} />
        ) : (
          <Redirect to="/login" />
        );
      }}
    />
  );
}

export default ProtectedRoute;
