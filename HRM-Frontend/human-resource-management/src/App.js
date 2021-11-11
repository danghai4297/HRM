// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListProvider } from "./Contexts/ListContext";
import ScreenProject from "./containers/ScreenProject/ScreenProject";
import LogIn from "./containers/ScreenLoginCom/loginn";
import { AccountContext } from "./Contexts/StateContext";
import jwt_decode from "jwt-decode";

import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from "react-router-dom";
import { useState } from "react";
import ToastProvider from "./components/Toast/ToastProvider";
function App() {
  const [account, setAccount] = useState(false);
  console.log(localStorage.getItem("resultObj"));
  return (
    <ListProvider>
      <ToastProvider>
        <Router>
          <Switch>
            <Route exact path="/">
              <Redirect to="/login" />
            </Route>
            <Route exact path="/login">
              {() => {
                if (localStorage.getItem("resultObj") === null) {
                  return <LogIn />;
                } else if (
                  jwt_decode(localStorage.getItem("resultObj")).role === "user"
                ) {
                  return <Redirect to="/home" />;
                } else if (
                  jwt_decode(localStorage.getItem("resultObj")).role === "admin"
                ) {
                  return <Redirect to="/category" />;
                }
              }}
            </Route>
            <AccountContext.Provider value={{ account, setAccount }}>
              <ScreenProject />
            </AccountContext.Provider>
          </Switch>
        </Router>
      </ToastProvider>
    </ListProvider>
  );
}

export default App;
