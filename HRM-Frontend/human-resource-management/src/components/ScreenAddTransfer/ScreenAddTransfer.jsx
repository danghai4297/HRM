import React from "react";
import AddTransferForm from "../AddTransferForm/AddTransferForm";

const onHandleAdd = (profile) => {
  console.log("addTransfer:", profile);
};
function ScreenAddTransfer(props) {
  return <AddTransferForm objectData={onHandleAdd} />;
}

export default ScreenAddTransfer;
