import React from "react";
import "./App.css";
import "./components/FontAwesomeIcons/index";
<<<<<<< HEAD
import "bootstrap/dist/css/bootstrap.min.css";
import ScreenProject from "./components/ScreenProject/ScreenProject.jsx";
=======
import { ListProvider } from "./Contexts/ListContext";

import "bootstrap/dist/css/bootstrap.min.css";
import ScreenProject from "./components/ScreenProject/ScreenProject";
>>>>>>> b8af7e35c05aa3527ca86e1bf1b80a4f0c3e37b1

function App() {
  return (
    <div>
<<<<<<< HEAD
      
      <ScreenProject></ScreenProject>

=======
      <ListProvider>
        <ScreenProject />
      </ListProvider>
>>>>>>> b8af7e35c05aa3527ca86e1bf1b80a4f0c3e37b1
    </div>
  );
}

export default App;
