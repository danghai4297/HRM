import React from "react";
import AddSalaryForm from "../AddSalaryForm/AddSalaryForm";

const onHandleAdd = (profile) => {
  console.log("addProfile:", profile);
};
function ScreenAddSalary(props) {
  return <AddSalaryForm objectData={onHandleAdd} />;
}

export default ScreenAddSalary;
