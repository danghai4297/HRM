import React from "react";
import AddContractForm from "../../components/AddContractForm/AddContractForm";

const onHandleAdd = (profile) => {
  console.log("addProfile:", profile);
};
function ScreenAddContract(props) {
 
  return <AddContractForm objectData={onHandleAdd} />;
}

export default ScreenAddContract;
