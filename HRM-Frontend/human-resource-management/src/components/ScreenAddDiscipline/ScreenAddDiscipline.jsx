import React from "react";
import AddDisciplineForm from "../AddDisciplineForm/AddDisciplineForm";

const onHandleAdd = (profile) => {
  console.log("addDiscipline:", profile);
};

function ScreenAddDiscipline(props) {
  return <AddDisciplineForm objectData={onHandleAdd} />;
}

export default ScreenAddDiscipline;
