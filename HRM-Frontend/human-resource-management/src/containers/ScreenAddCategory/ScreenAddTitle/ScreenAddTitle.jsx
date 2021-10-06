import React from 'react';
import PropTypes from 'prop-types';
import AddTitleForm from '../../../components/AddCategoryForm/AddTitleForm/AddTitleForm';

ScreenAddTitle.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryTitle:", profile);
  };
function ScreenAddTitle(props) {
    return (
        <AddTitleForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddTitle;