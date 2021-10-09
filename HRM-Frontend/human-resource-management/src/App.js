// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListProvider } from "./Contexts/ListContext";
import ScreenProject from "./containers/ScreenProject/ScreenProject";
import LogIn from "./containers/ScreenLoginCom/loginn";
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from "react-router-dom";
function App() {
  return (
    <ListProvider>
      <Router>
        <Switch>
          <Route exact path="/">
            <Redirect to="/login" />
          </Route>
          <Route exact path="/login" component={LogIn} />
          <ScreenProject />
        </Switch>
      </Router>
    </ListProvider>
  );
}

export default App;
