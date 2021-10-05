import React from 'react';
import PropTypes from 'prop-types';
import AddMarriageForm from '../../../components/AddCategoryForm/AddMarriageForm/AddMarriageForm';

ScreenAddMarriage.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryMarriage:", profile);
  };
function ScreenAddMarriage(props) {
    return (
       <AddMarriageForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddMarriage;