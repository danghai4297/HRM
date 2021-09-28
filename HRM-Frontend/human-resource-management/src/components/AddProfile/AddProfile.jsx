import React from "react";
import PropTypes from "prop-types";
import AddProfileForm from "../AddProfileForm/addProfileForm";
import "bootstrap/dist/css/bootstrap.min.css";
import "./addProfile.scss";
AddProfile.propTypes = {};
const onHandleAdd = (profile) => {
  console.log("addProfile:", profile);
};
function AddProfile(props) {
  return (
    <div className="container">
      <AddProfileForm objectData={onHandleAdd}></AddProfileForm>
    </div>
  );
}

export default AddProfile;
