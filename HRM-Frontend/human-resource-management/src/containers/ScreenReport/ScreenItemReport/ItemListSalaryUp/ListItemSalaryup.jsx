import { format } from "date-fns";
import React from "react";
import NumberFormat from "react-number-format";

function ListItemSalaryup(props) {
  const { user } = props;
  return (
    <tr>
      <th scope="row">{user.id}</th>
      <td>{user.hoTen}</td>
      <td>{user.maHopDong}</td>
      <td>{user.tenHopDong}</td>
      <td>
        <NumberFormat
          value={user.luongCoBan}
          displayType="text"
          type="text"
          thousandSeparator={true}
        />
      </td>
      <td>
        <NumberFormat
          value={user.tongLuong}
          displayType="text"
          type="text"
          thousandSeparator={true}
        />
      </td>
      <td>{format(new Date(user.thoiGianLenLuong), "dd/MM/yyyy")}</td>
      <td>{user.tenPhongBan}</td>
    </tr>
  );
}
export default ListItemSalaryup;
