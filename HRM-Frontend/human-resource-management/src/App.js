// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import { ListProvider } from "./Contexts/ListContext";
import ScreenProject from "./containers/ScreenProject/ScreenProject";

function App() {
  return (
    <div>
      <ListProvider>
        <ScreenProject />
      </ListProvider>
    </div>
  );
}

export default App;
