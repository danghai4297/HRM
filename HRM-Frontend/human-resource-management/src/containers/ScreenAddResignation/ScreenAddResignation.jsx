import React from 'react';
import AddResignationForm from "../../components/AddResignationForm/AddResignationForm";
ScreenAddResignation.propTypes = {
    
};
const onHandleAdd = (profile) => {
    console.log("addResignation:", profile);
  };
function ScreenAddResignation(props) {
    return (
        <AddResignationForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddResignation;