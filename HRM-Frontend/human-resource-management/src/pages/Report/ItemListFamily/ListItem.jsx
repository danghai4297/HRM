import { format } from "date-fns";
import React from "react";

function ListItems(props) {
  const { user } = props;
  return (
    <tr>
      <th scope="row">{user.id}</th>
      <td>{user.hoTen}</td>
      <td>{user.dienThoai}</td>
      <td>{user.tenPhongBan}</td>
      <td>{user.nt_tenNguoiThan}</td>
      <td>{user.nt_gioiTinh}</td>
      <td>{format(new Date(user.nt_ngaySinh), "dd/MM/yyyy")}</td>
      <td>{user.nt_quanHe}</td>
      <td>{user.nt_ngheNghiep}</td>
      <td>{user.nt_diaChi}</td>
      <td>{user.nt_dienThoai}</td>
    </tr>
  );
}
export default ListItems;
