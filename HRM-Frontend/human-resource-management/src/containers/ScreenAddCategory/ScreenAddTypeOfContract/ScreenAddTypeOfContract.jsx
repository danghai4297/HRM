import React from 'react';
import PropTypes from 'prop-types';
import AddTypeOfContractForm from '../../../components/AddCategoryForm/AddTypeOfContractForm/AddTypeOfContractForm';

ScreenAddTypeOfContract.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("AddCategoryTypeOfContract:", profile);
  };
function ScreenAddTypeOfContract(props) {
    return (
        <AddTypeOfContractForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddTypeOfContract;