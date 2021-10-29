import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const SideBarData = [
  {
    title: "Tổng quan",
    icon: <FontAwesomeIcon icon={["fas", "home"]} />,
    link: "/home",
    role: "user",
  },
  {
    title: "Hồ sơ",
    icon: <FontAwesomeIcon icon={["fas", "user-circle"]} />,
    link: "/profile",
    role: "user",
  },
  {
    title: "Hợp đồng",
    icon: <FontAwesomeIcon icon={["fas", "address-book"]} />,
    link: "/contract",
    role: "user",
  },
  {
    title: "Danh sách lương",
    icon: <FontAwesomeIcon icon={["fas", "file-invoice-dollar"]} />,
    link: "/salary",
    role: "user",
  },
  {
    title: "Danh mục",
    icon: <FontAwesomeIcon icon={["fas", "list-alt"]} />,
    link: "/category",
    role: "admin",
  },
  {
    title: "Thuyên chuyển",
    icon: <FontAwesomeIcon icon={["fas", "exchange-alt"]} />,
    link: "/transfer",
    role: "user",
  },
  {
    title: "Nghỉ việc",
    icon: <FontAwesomeIcon icon={["fas", "user-times"]} />,
    link: "/resign",
    role: "user",
  },
  {
    title: "Khen thưởng",
    icon: <FontAwesomeIcon icon={["fas", "award"]} />,
    link: "/reward",
    role: "user",
  },
  {
    title: "Kỉ luật",
    icon: <FontAwesomeIcon icon={["fas", "ban"]} />,
    link: "/discipline",
    role: "user",
  },
  {
    title: "Báo cáo",
    icon: <FontAwesomeIcon icon={["fas", "file-alt"]} />,
    link: "/report",
    role: "user",
  },
  {
    title: "Danh sách tài khoản",
    icon: <FontAwesomeIcon icon={["fas", "file-alt"]} />,
    link: "/account",
    role: "admin",
  },
];
