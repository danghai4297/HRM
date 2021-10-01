import React from "react";
import PropTypes from "prop-types";
import AddSalaryForm from "../AddSalaryForm/AddSalaryForm";
ScreenAddSalary.propTypes = {};
const onHandleAdd = (profile) => {
  console.log("addProfile:", profile);
};
function ScreenAddSalary(props) {
  return <AddSalaryForm objectData={onHandleAdd}/>;
}

export default ScreenAddSalary;
