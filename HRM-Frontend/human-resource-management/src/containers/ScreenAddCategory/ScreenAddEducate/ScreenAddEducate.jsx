import React from 'react';
import PropTypes from 'prop-types';
import AddEducateForm from '../../../components/AddCategoryForm/AddEducateForm/AddEducateForm';

ScreenAddEducate.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryEducate:", profile);
  };
function ScreenAddEducate(props) {
    return (
       <AddEducateForm objectData={onHandleAdd} />
    );
}

export default ScreenAddEducate;