import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Detail from "../Detail/Detail";
import ScreenReport from "../ScreenReport/ScreenReport";
import ScreenDiscipline from "../ScreenDiscipline/ScreenDiscipline";
import ScreenReward from "../ScreenReward/ScreenReward";
import ScreenResign from "../ScreenResign/ScreenResign";
import ScreenTransfer from "../ScreenTransfer/ScreenTransfer";
import ScreenCategory from "../ScreenCategory/ScreenCategory";
import ScreenSalary from "../ScreenSalary/ScreenSalary";
import DashBoard from "../ScreenDashBoard/DashBoard";
import ScreenTableNV from "../ScreenTableNV/ScreenTableNV";
import ScreenContract from "../ScreenContract/ScreenContract";
export const RouterLink = [
  //   {
  //     title: "Tổng quan",
  //     link: "/",
  //     comp: <DashBoard />,
  //   },
  {
    title: "Hồ sơ",
    path: "/profile",
    comp: <ScreenTableNV />,
  },
  {
    title: "Hợp đồng",
    path: "/contract",
    comp: <ScreenContract />,
  },
  {
    title: "Hồ sơ lương",
    path: "/salary",
    comp: <ScreenSalary />,
  },
  {
    title: "Danh mục",
    path: "/category",
    comp: <ScreenCategory />,
  },
  {
    title: "Thuyên chuyển",
    path: "/transfer",
    comp: <ScreenTransfer />,
  },
  {
    title: "Nghỉ việc",
    path: "/resign",
    comp: <ScreenResign />,
  },
  {
    title: "Khen thưởng",
    path: "/reward",
    comp: <ScreenReward />,
  },
  {
    title: "Kỉ luật",
    path: "/discipline",
    comp: <ScreenDiscipline />,
  },
  {
    title: "Báo cáo",
    path: "/report",
    comp: <ScreenReport />,
  },
  {
    path: "/detail/:id",
    comp: <Detail />,
  },
];
