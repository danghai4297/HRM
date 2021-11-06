import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { DatePicker } from "antd";
import { format } from "date-fns";
import React, { useEffect, useRef, useState } from "react";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../../api/productApi";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import { useToast } from "../../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../../components/ToPrint/ComponentToPrint";

import ListItems from "./ListItem";

function ItemListFamily() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const { error, warn, info, success } = useToast();

  const [title, settitle] = useState("");

  const [dataDmpb, setDataDmpb] = useState([]);
  const [dataDmnt, setDataDmnt] = useState([]);
  const [dataNv, setDataNv] = useState([]);
  const [idNv, setIdNv] = useState("Tất cả");
  const [ageX, setAgeX] = useState(0);
  const [ageY, setAgeY] = useState(100);
  const [gender, setGender] = useState("Tất cả");
  const [status, setStatus] = useState("Tất cả");
  const [department, setDepartment] = useState("Tất cả");
  const [nexus, setNexus] = useState(0);
  const [dataRp, setDataRp] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMPB();
        const responseNn = await ProductApi.getAllDMNT();
        const responseNv = await ProductApi.getAllNvMT();
        setDataDmpb(response);
        setDataDmnt(responseNn);
        setDataNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const handelReport = async () => {
    if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtn(ageX, ageY);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus != 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtDm(ageX, ageY, nexus);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtPb(ageX, ageY, department);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv !== "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtNv(ageX, ageY, idNv);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender !== "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtGt(ageX, ageY, gender);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status !== "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtTt(ageX, ageY, status);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    }
  };

  return (
    <div className="reportEx">
      <div className="select-info">
        <div className="roww">
          <input
            type="text"
            placeholder="Nhập tiêu đề cho báo cáo"
            class="form-control"
            id="title"
            onChange={(e) => settitle(e.target.value)}
          />
        </div>
        <div className="roww">
          <div className="select-row2">
            <label>Người thân</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => setNexus(e.target.value)}
              >
                <option value={0}>Tất cả</option>
                {dataDmnt.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.tenDanhMuc}{" "}
                  </option>
                ))}
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
              >
                <option value="Tất cả">Tất cả</option>
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
            <label>Tên nhân viên</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => setIdNv(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                {dataNv.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.hoTen}{" "}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Mã nhân viên</label>
            <div>
              <input type="text" class="form-control" value={idNv} />
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
        <div className="roww">
          <div className="select-row2">
            <label>Từ ngày</label>
            <input
              type="number"
              min="0"
              onChange={(e) => setAgeX(e.target.value)}
              defaultValue={0}
            ></input>
          </div>
          <div className="select-row2">
            <label>Đến ngày</label>
            <input
              type="number"
              min="0"
              onChange={(e) => setAgeY(e.target.value)}
              defaultValue={100}
            ></input>
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
          <ExportCSV csvData={dataRp} fileName="Báo cáo danh sách nhân viên" />
        </div>
      </div>
      <div className="report-emp">
        <ComponentToPrint ref={componentRef}>
          <div className="rp-herder">
            <b>HRM</b>
            <p>-------------------------</p>
            <h2>{title}</h2>
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
                  <th scope="col">Điện thoại</th>
                  <th scope="col">Phòng ban</th>
                  <th scope="col">Tên người thân</th>
                  <th scope="col">Giới tính</th>
                  <th scope="col">Ngày sinh</th>
                  <th scope="col">Quan hệ</th>
                  <th scope="col">Nghề ngiệp</th>
                  <th scope="col">Địa chỉ</th>
                  <th scope="col">Đt người thân</th>
                </tr>
              </thead>
              <tbody>
                {dataRp.map((item, index) => (
                  <ListItems user={item} key={index} />
                ))}
              </tbody>
            </table>
          </div>
        </ComponentToPrint>
      </div>
    </div>
  );
}

export default ItemListFamily;
