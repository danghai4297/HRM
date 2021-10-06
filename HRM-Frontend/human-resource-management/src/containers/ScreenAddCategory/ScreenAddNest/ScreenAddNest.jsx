import React from 'react';
import PropTypes from 'prop-types';
import AddNestForm from '../../../components/AddCategoryForm/AddNestForm/AddNestForm';

ScreenAddNest.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryNest:", profile);
  };
function ScreenAddNest(props) {
    return (
       <AddNestForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddNest;