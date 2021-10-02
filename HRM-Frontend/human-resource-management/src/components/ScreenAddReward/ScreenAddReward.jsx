import React from 'react';
import AddRewardForm from '../AddRewardForm/AddRewardForm';


const onHandleAdd = (profile) => {
    console.log("addReward:", profile);
  };
function ScreenAddReward(props) {
    return (
       <AddRewardForm objectData={onHandleAdd}/>
    );
}

export default ScreenAddReward;