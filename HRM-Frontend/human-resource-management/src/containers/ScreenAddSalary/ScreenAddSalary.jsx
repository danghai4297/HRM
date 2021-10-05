import React from "react";
import AddSalaryForm from "../../components/AddSalaryForm/AddSalaryForm";

const onHandleAdd = (profile) => {
  console.log("addSalary:", profile);
};
function ScreenAddSalary(props) {
  return <AddSalaryForm objectData={onHandleAdd} />;
}

export default ScreenAddSalary;
