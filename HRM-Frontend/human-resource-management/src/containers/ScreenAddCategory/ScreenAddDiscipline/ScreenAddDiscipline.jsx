import React from "react";
import PropTypes from "prop-types";
import AddDisciplineForm from "../../../components/AddCategoryForm/AddDisciplineForm/AddDisciplineForm";

ScreenAddDiscipline.propTypes = {};
const onHandleAdd = (profile) => {
  console.log("AddCategoryDiscipline:", profile);
};
function ScreenAddDiscipline(props) {
  return <AddDisciplineForm objectData={onHandleAdd} />;
}

export default ScreenAddDiscipline;
