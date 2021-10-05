import React from 'react';
import PropTypes from 'prop-types';
import AddNationForm from '../../../components/AddCategoryForm/AddNationForm/AddNationForm';

ScreenAddNation.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryNation:", profile);
  };
function ScreenAddNation(props) {
    return (
        <AddNationForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddNation;