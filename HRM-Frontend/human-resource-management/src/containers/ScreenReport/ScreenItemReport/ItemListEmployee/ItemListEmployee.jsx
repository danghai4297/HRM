import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button, DatePicker } from "antd";
import { format } from "date-fns";
import React, { useEffect, useRef, useState } from "react";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../../api/productApi";
import { ComponentToPrint } from "../../../../components/ToPrint/ComponentToPrint";

import "./ItemListEmployee.scss";
import ListItems from "./ListItem";

function ItemListEmployee() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const [dataDmpb, setDataDmpb] = useState([]);
  const [startDate, setStartDate] = useState(null);
  const [endDate, setEndDate] = useState(null);
  const [gender, setGender] = useState("Tất cả");
  const [status, setStatus] = useState("Tất cả");
  const [department, setDepartment] = useState(1);
  const [check, setCheck] = useState("Tất cả");
  const [checkPb, setCheckPb] = useState(true);
  const [checkHd, setCheckHd] = useState(true);
  const [dataRp, setDataRp] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMPB();
        setDataDmpb(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  function handelCheck(value) {
    if (value === "Tất cả") {
      setCheck("Tất cả");
      setCheckHd(true);
      setCheckPb(true);
    } else if (value === "Phòng ban") {
      setCheck("Phòng ban");
      setCheckHd(false);
      setCheckPb(true);
      setStartDate(null);
      setEndDate(null);
    } else if (value === "Năm hợp đồng") {
      setCheck("Năm hợp đồng");
      setCheckPb(false);
      setCheckHd(true);
      setDepartment("Tất cả");
    }
  }

  const handelReport = async () => {
    if (
      (check === "Phòng ban") &
      (gender === "Tất cả") &
      (status === "Tất cả")
    ) {
      const respb = await ProductApi.getRPPb(department);
      setDataRp(respb);
      console.log(dataRp);
    } else if (
      (check === "Năm hợp đồng") &
      (gender === "Tất cả") &
      (status === "Tất cả")
    ) {
      let sdate = format(new Date(startDate), "yyyy-MM-dd");
      let edate = format(new Date(endDate), "yyyy-MM-dd");
      const respb = await ProductApi.getRPHd(sdate, edate);
      setDataRp(respb);
    }
  };

  return (
    <>
      <div className="select-info">
        <div className="roww">
          <div className="select-row2">
            <label>Theo</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => handelCheck(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value="Phòng ban">Phòng ban</option>
                <option value="Năm hợp đồng">Năm hợp đồng</option>
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Trạng thái</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => setStatus(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value={true}>Đang làm việc</option>
                <option value={false}>Đã nghỉ việc</option>
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Phòng ban</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => setDepartment(e.target.value)}
                disabled={checkPb === false}
              >
                {dataDmpb.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.tenPhongBan}{" "}
                  </option>
                ))}
              </select>
            </div>
          </div>
        </div>
        <div className="roww">
          <div className="select-row2">
            <label>Từ ngày</label>
            <div>
              <DatePicker
                placeholder="DD/MM/YYYY"
                disabled={checkHd === false}
                selected={startDate}
                onChange={(date) => setStartDate(date)}
              />
            </div>
          </div>
          <div className="select-row2">
            <label>Đến ngày</label>
            <div>
              <DatePicker
                placeholder="DD/MM/YYYY"
                disabled={checkHd === false}
                selected={endDate}
                onChange={(date) => setEndDate(date)}
              />
            </div>
          </div>
          <div className="select-row2">
            <label>Giới tính</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => setGender(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value={true}>Nam</option>
                <option value={false}>Nữ</option>
              </select>
            </div>
          </div>
        </div>
        <div className="roww row-btn">
          <input
            className="btn btn-primary"
            type="button"
            value="Hiển thị báo cáo"
            onClick={handelReport}
          />
          <button className="button-pdf" onClick={handlePrint}>
            <FontAwesomeIcon icon={["fas", "file-pdf"]} />
          </button>
        </div>
      </div>
      <div className="report-emp">
        <ComponentToPrint ref={componentRef}>
          <div className="rp-herder">
            <b>HRM</b>
            <p>-------------------------</p>
            <h2>Danh sách nhân viên</h2>
          </div>
          <div className="rp-herder-left">
            <h5>Phòng ban: {department}</h5>
            <h6>
              Hà Nội Ngày: {today.getDate()} Tháng: {today.getMonth() + 1} Năm:{" "}
              {today.getFullYear()}
            </h6>
          </div>
          <div className="rp-table">
            <table className="table">
              <thead>
                <tr>
                  <th scope="col">Mã Nhân Viên</th>
                  <th scope="col">Họ Tên</th>
                  <th scope="col">Ngày sinh</th>
                  <th scope="col">Giới tính</th>
                  <th scope="col">Điện thoại</th>
                  <th scope="col">Phòng ban</th>
                  <th scope="col">Trạng thái</th>
                </tr>
              </thead>
              <tbody>
                {dataRp.map((item) => (
                  <ListItems user={item} key={item.id} />
                ))}
              </tbody>
            </table>
          </div>
        </ComponentToPrint>
      </div>
    </>
  );
}

export default ItemListEmployee;
