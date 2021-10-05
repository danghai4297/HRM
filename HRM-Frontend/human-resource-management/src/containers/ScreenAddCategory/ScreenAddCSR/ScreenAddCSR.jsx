import React from 'react';
import PropTypes from 'prop-types';
import AddCSRForm from '../../../components/AddCategoryForm/AddCSRForm/AddCSRForm';

ScreenAddCSR.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryCSR:", profile);
  };
function ScreenAddCSR(props) {
    return (
        <AddCSRForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddCSR;