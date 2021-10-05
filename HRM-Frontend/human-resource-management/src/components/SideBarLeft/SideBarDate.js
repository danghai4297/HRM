import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
export const SideBarData = [
    {
        title: "Tổng quan",
        icon: <FontAwesomeIcon icon={["fas", "home"]}/>,
        link: "/home"
    },
    {
        title: "Hồ sơ",
        icon: <FontAwesomeIcon icon={["fas", "user-circle"]}/>,
        link: "/profile"
    },
    {
        title: "Hợp đồng",
        icon: <FontAwesomeIcon icon={["fas", "address-book"]}/>,
        link: "/contract"
    },
    {
        title: "Hồ sơ lương",
        icon: <FontAwesomeIcon icon={["fas", "file-invoice-dollar"]}/>,
        link: "/salary"
    },
    {
        title: "Danh mục",
        icon: <FontAwesomeIcon icon={["fas", "list-alt"]}/>,
        link: "/category"
    },
    {
        title: "Thuyên chuyển",
        icon: <FontAwesomeIcon icon={["fas", "exchange-alt"]}/>,
        link: "/transfer"
    },
    {
        title: "Nghỉ việc",
        icon: <FontAwesomeIcon icon={["fas", "user-times"]}/>,
        link: "/resign"
    },
    {
        title: "Khen thưởng",
        icon: <FontAwesomeIcon icon={["fas", "award"]}/>,
        link: "/reward"
    },
    {
        title: "Kỉ luật",
        icon: <FontAwesomeIcon icon={["fas", "thumbs-down"]}/>,
        link: "/discipline"
    },
    {
        title: "Báo cáo",
        icon: <FontAwesomeIcon icon={["fas", "file-alt"]}/>,
        link: "/report"
    },
]
    



