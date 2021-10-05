import React from 'react';
import PropTypes from 'prop-types';
import AddSpecializeForm from '../../../components/AddCategoryForm/AddSpecializeForm/AddSpecializeForm';

ScreenAddSpecialize.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategorySpecialize:", profile);
  };
function ScreenAddSpecialize(props) {
    return (
        <AddSpecializeForm  objectData={onHandleAdd}/>
    );
}

export default ScreenAddSpecialize;