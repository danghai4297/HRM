import React from "react";
import PropTypes from "prop-types";
import AddProfileForm from "../AddProfileForm/AddProfileForm";
import "bootstrap/dist/css/bootstrap.min.css";
import "./AddProfile.scss";
import SideBarLeft from "../SideBarLeft/SideBarLeft";
import Header from "../Header/Header";

AddProfile.propTypes = {};
const onHandleAdd = (profile) => {
  console.log("addProfile:", profile);
};
function AddProfile(props) {
  return (
    // <div className="container">
    //   <header className="header">
    //     <Header />
    //   </header>
    //   <div className="body-contents">
    //     <div className="menu-bar">
    //       <SideBarLeft />
    //     </div>
    //     <div className="content">

    //     </div>
    //   </div>
    // </div>
    <AddProfileForm objectData={onHandleAdd}></AddProfileForm>
  );
}

export default AddProfile;
