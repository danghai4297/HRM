import React from "react";
import AddProfileForm from "../AddProfileForm/AddProfileForm";
import "bootstrap/dist/css/bootstrap.min.css";


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
