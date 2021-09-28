import React from "react";
import "./App.css";
import "./components/FontAwesomeIcons/index";
import { ListProvider } from "./Contexts/ListContext";
import DashBoard from "./components/DashBoard/DashBoard";

import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  return (
    <div>
      <ListProvider>
        <DashBoard />
      </ListProvider>
    </div>
  );
}

export default App;
