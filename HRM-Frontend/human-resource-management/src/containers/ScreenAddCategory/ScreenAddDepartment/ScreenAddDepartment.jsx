import React from 'react';
import PropTypes from 'prop-types';
import AddDepartmentForm from '../../../components/AddCategoryForm/AddDepartmentForm/AddDepartmentForm';

ScreenAddDepartment.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryBonus:", profile);
  };
function ScreenAddDepartment(props) {
    return (
      <AddDepartmentForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddDepartment;