import React from 'react';
import PropTypes from 'prop-types';
import AddLevelForm from '../../../components/AddCategoryForm/AddLevelForm/AddLevelForm';

ScreenAddLevel.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryLevel:", profile);
  };
function ScreenAddLevel(props) {
    return (
        <AddLevelForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddLevel;