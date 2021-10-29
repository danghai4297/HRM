import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const SideBarData = [
  {
    title: "Tổng quan",
    icon: <FontAwesomeIcon icon={["fas", "home"]} />,
    link: "/home",
    roles: ["user"]
  },
  {
    title: "Hồ sơ",
    icon: <FontAwesomeIcon icon={["fas", "user-circle"]} />,
    link: "/profile",
    roles: ["user"]
  },
  {
    title: "Hợp đồng",
    icon: <FontAwesomeIcon icon={["fas", "address-book"]} />,
    link: "/contract",
    roles: ["user"]
  },
  {
    title: "Danh sách lương",
    icon: <FontAwesomeIcon icon={["fas", "file-invoice-dollar"]} />,
    link: "/salary",
    roles: ["user"]
  },
  {
    title: "Danh mục",
    icon: <FontAwesomeIcon icon={["fas", "list-alt"]} />,
    link: "/category",
    roles: ["admin"]
  },
  {
    title: "Thuyên chuyển",
    icon: <FontAwesomeIcon icon={["fas", "exchange-alt"]} />,
    link: "/transfer",
    roles: ["user"]
  },
  {
    title: "Nghỉ việc",
    icon: <FontAwesomeIcon icon={["fas", "user-times"]} />,
    link: "/resign",
    roles: ["user"]
  },
  {
    title: "Khen thưởng",
    icon: <FontAwesomeIcon icon={["fas", "award"]} />,
    link: "/reward",
    roles: ["user"]
  },
  {
    title: "Kỉ luật",
    icon: <FontAwesomeIcon icon={["fas", "ban"]} />,
    link: "/discipline",
    roles: ["user"]
  },
  {
    title: "Báo cáo",
    icon: <FontAwesomeIcon icon={["fas", "file-alt"]} />,
    link: "/report",
    roles: ["user"]
  },
  {
    title: "Danh sách tài khoản",
    icon: <FontAwesomeIcon icon={["fas", "file-alt"]} />,
    link: "/account",
    roles: ["admin"]
  },
  {
    title: "Hoạt động của tài khoản",
    icon: <FontAwesomeIcon icon={["fas", "file-alt"]} />,
    link: "/activity",
    roles: ["user","admin"]
  },
];
