import React from "react";
import AddTransferForm from "../../components/AddTransferForm/AddTransferForm";

const onHandleAdd = (profile) => {
  console.log("addTransfer:", profile);
};
function ScreenAddTransfer(props) {
  return <AddTransferForm objectData={onHandleAdd} />;
}

export default ScreenAddTransfer;
