import React from 'react';
import PropTypes from 'prop-types';
import AddBonusForm from '../../../components/AddCategoryForm/AddBonusForm/AddBonusForm';

ScreenAddBonus.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryBonus:", profile);
  };
function ScreenAddBonus(props) {
    return (
       <AddBonusForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddBonus;