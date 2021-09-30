import React from "react";
import "./App.css";
import "./components/FontAwesomeIcons/index";
import { ListProvider } from "./Contexts/ListContext";

import "bootstrap/dist/css/bootstrap.min.css";
import ScreenTableNV from "./components/ScreenTableNV/ScreenTableNV";

function App() {
  return (
    <div>
      <ListProvider>
        <ScreenTableNV />
      </ListProvider>
    </div>
  );
}

export default App;
