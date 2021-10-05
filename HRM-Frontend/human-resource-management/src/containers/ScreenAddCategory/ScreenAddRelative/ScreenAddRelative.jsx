import React from 'react';
import PropTypes from 'prop-types';
import AddRelationForm from '../../../components/AddCategoryForm/AddRelationForm/AddRelationForm';

ScreenAddRelative.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryRelative:", profile);
  };
function ScreenAddRelative(props) {
    return (
        <AddRelationForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddRelative;