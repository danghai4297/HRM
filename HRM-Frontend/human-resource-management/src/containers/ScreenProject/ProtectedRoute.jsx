import React from "react";
import { Route, Redirect } from "react-router-dom";
function ProtectedRoute({ component: Component, ...res }) {
  return (
    <Route
      {...res}
      render={(props) => {
        return localStorage.getItem('token') ? (
          <Component {...props} />
        ) : (
          <Redirect to="/" />
        );
      }}
    />
  );
}

export default ProtectedRoute;
