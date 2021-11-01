import { format } from "date-fns";
import React from "react";

function ListItems(props) {
  const { user } = props;
  return (
    <tr>
      <th scope="row">{user.id}</th>
      <td>{user.hoTen}</td>
      <td>{format(new Date(user.ngaySinh), "dd/MM/yyyy")}</td>
      <td>{user.gioiTinh}</td>
      <td>{user.dienThoai}</td>
      <td>{user.tenPhongBan}</td>
      <td>{user.trangThai}</td>
    </tr>
  );
}
export default ListItems;
