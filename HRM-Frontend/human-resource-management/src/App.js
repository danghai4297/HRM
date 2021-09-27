import React from "react";
import "./App.css";
import SideBar from './components/SidebarLeft/SideBar'
import Header from "./components/Header/Header";
import './components/FontAwesomeIcons/index'

function App() {
  return (
    <div>
      <Header></Header>
      <SideBar></SideBar>
    </div>
  );
}

export default App;
