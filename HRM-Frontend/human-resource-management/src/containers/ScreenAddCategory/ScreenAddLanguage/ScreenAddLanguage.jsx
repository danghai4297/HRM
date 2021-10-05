import React from 'react';
import PropTypes from 'prop-types';
import AddLanguageForm from '../../../components/AddCategoryForm/AddLanguageForm/AddLanguageForm';

ScreenAddLanguage.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryLanguage:", profile);
  };
function ScreenAddLanguage(props) {
    return (
        <AddLanguageForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddLanguage;