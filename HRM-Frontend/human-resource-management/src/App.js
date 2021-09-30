import React from "react";
import "./App.css";
import "./components/FontAwesomeIcons/index";
import { ListProvider } from "./Contexts/ListContext";

import "bootstrap/dist/css/bootstrap.min.css";
import ScreenProject from "./components/ScreenProject/ScreenProject";

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
