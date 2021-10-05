import React from "react";
import AddContractForm from "../../components/AddContractForm/AddContractForm";

function ScreenAddContract(props) {
  const onHandleAdd = (profile) => {
    console.log("addProfile:", profile);
  };
  return <AddContractForm objectData={onHandleAdd} />;
}

export default ScreenAddContract;
