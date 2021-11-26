import React from "react";
import { Route, Redirect } from "react-router-dom";
import jwt_decode from "jwt-decode";
import { useToast } from "../../components/Toast/Toast";

function ProtectedRoute({ component: Component, roles, ...res }) {
  const { warn } = useToast();
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
          <Redirect to="/login">
            {sessionStorage.getItem("resultObj")
              ? warn(`Tài khoản của bạn không có quyền vào trang này`)
              : warn(`Bạn chưa đăng nhập tài khoản`)}
          </Redirect>
        );
      }}
    />
  );
}

export default ProtectedRoute;
