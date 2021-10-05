// <<<<<<< HEAD
import "./App.css";
import "./components/FontAwesomeIcons/index";
import "bootstrap/dist/css/bootstrap.min.css";
import ScreenProject from "./components/ScreenProject/ScreenProject.jsx";
import { ListProvider } from "./Contexts/ListContext";

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
