// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListProvider } from "./Contexts/ListContext";
import ScreenProject from "./containers/ScreenProject/ScreenProject";
import LogIn from "./containers/ScreenLoginCom/loginn";
import { AccountContext, SideBarContext } from "./Contexts/StateContext";

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
  const [sideBar, setSiderBar] = useState(true);
  return (
    <ListProvider>
      <ToastProvider>
        <Router>
          <Switch>
            <Route exact path="/">
              <Redirect to="/login" />
            </Route>
            <Route exact path="/login">
              <LogIn />
            </Route>
            <AccountContext.Provider value={{ account, setAccount }}>
              <SideBarContext.Provider value={{ sideBar, setSiderBar }}>
                <ScreenProject />
              </SideBarContext.Provider>
            </AccountContext.Provider>
          </Switch>
        </Router>
      </ToastProvider>
    </ListProvider>
  );
}

export default App;
