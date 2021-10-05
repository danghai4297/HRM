import React from 'react';
import PropTypes from 'prop-types';
import AddReligionForm from '../../../components/AddCategoryForm/AddReligionForm/AddReligionForm';

ScreenAddReligion.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryReligion:", profile);
  };
function ScreenAddReligion(props) {
    return (
        <AddReligionForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddReligion;