import React from 'react';
import PropTypes from 'prop-types';
import AddPositionForm from '../../../components/AddCategoryForm/AddPositionForm/AddPositionForm';

ScreenAddPosition.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryNest:", profile);
  };
function ScreenAddPosition(props) {
    return (
        <AddPositionForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddPosition;