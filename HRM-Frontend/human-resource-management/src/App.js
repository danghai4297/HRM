// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListProvider } from "./Contexts/ListContext";
import ScreenProject from "./containers/ScreenProject/ScreenProject";

function App() {
  return (
    <ListProvider>
      <ScreenProject />
    </ListProvider>
  );
}

export default App;
