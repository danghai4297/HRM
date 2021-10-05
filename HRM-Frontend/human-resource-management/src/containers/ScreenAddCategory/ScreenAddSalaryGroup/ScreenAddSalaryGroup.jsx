import React from 'react';
import PropTypes from 'prop-types';
import AddSalaryGroupForm from '../../../components/AddCategoryForm/AddSalaryGroupForm/AddSalaryGroupForm';

ScreenAddSalaryGroup.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategorySalaryGroup:", profile);
  };
function ScreenAddSalaryGroup(props) {
    return (
       <AddSalaryGroupForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddSalaryGroup;