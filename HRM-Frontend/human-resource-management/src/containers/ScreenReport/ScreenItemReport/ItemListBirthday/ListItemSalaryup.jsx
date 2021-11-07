import { format } from "date-fns";
import React from "react";

function ListItemSalaryup(props) {
  const { user } = props;
  return (
    <tr>
      <th scope="row">{user.id}</th>
      <td>{user.hoTen}</td>
      <td>{user.gioiTinh}</td>
      <td>{format(new Date(user.ngaySinh), "dd/MM/yyyy")}</td>
      <td>{user.tenPhongBan}</td>
    </tr>
  );
}
export default ListItemSalaryup;
