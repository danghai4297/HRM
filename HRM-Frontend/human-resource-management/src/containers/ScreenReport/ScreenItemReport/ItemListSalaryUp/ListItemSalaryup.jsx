import { format } from "date-fns";
import React from "react";

function ListItemSalaryup(props) {
  const { user } = props;
  return (
    <tr>
      <th scope="row">{user.id}</th>
      <td>{user.hoTen}</td>
      <td>{user.maHopDong}</td>
      <td>{user.tenHopDong}</td>
      <td>{user.luongCoBan}</td>
      <td>{user.tongLuong}</td>
      <td>{format(new Date(user.thoiGianLenLuong), "dd/MM/yyyy")}</td>
      <td>{user.tenPhongBan}</td>
    </tr>
  );
}
export default ListItemSalaryup;
