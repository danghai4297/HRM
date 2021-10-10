// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListProvider } from "./Contexts/ListContext";
import ScreenProject from "./containers/ScreenProject/ScreenProject";
import LogIn from "./containers/ScreenLoginCom/loginn";
import { AccountContext } from "./Contexts/StateContext";
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from "react-router-dom";
import { useState } from "react";
function App() {
  const [account, setAccount] = useState(false);
  return (
    <ListProvider>
      <Router>
        <Switch>
          <Route exact path="/">
            <Redirect to="/login" />
          </Route>
          <Route exact path="/login" component={LogIn} />
          <AccountContext.Provider value={{account, setAccount}}>
            <ScreenProject />
          </AccountContext.Provider>
        </Switch>
      </Router>
    </ListProvider>
  );
}

export default App;
