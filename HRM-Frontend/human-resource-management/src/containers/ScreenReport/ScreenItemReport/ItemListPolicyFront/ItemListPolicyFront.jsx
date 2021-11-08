import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { DatePicker } from "antd";
import { format } from "date-fns";
import React, { useEffect, useRef, useState } from "react";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../../api/productApi";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import { useToast } from "../../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../../components/ToPrint/ComponentToPrint";
import useDidMountEffect from "../../useDidMountEffect/useDidMountEffect";
import ListItems from "./ListItem";

function ItemListPolicyFront() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const { error, warn, info, success } = useToast();

  const [title, settitle] = useState("");

  const [dataDmpb, setDataDmpb] = useState([]);
  const [department, setDepartment] = useState("Tất cả");
  const [check, setCheck] = useState("Tất cả");
  const [checkPb, setCheckPb] = useState(false);
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

  useDidMountEffect(() => {
    if (dataRp.length == 0) {
      info("không có thông tin");
    }
  }, [dataRp]);

  function handelCheck(value) {
    if (value === "Tất cả") {
      setCheck("Tất cả");
      setCheckPb(false);
    } else if (value === "Phòng ban") {
      setCheck("Phòng ban");
      setCheckPb(true);
    }
  }

  const handelReport = async () => {
    if (check === "Tất cả") {
      try {
        const resp = await ProductApi.getRpAllCncs();
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (check === "Phòng ban") {
      if (department === "Tất cả") {
        error("Bạn chưa chọn phòng ban");
      } else {
        try {
          const resp = await ProductApi.getRpAllCncsPb(department);
          setDataRp(resp);
        } catch (e) {
          error("Thực hiện không thành công");
        }
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
            <label>Theo</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => handelCheck(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value="Phòng ban">Phòng ban</option>
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
                  <th scope="col">Giới tính</th>
                  <th scope="col">Ngày sinh</th>
                  <th scope="col">Chính sách</th>
                  <th scope="col">Tên phòng ban</th>
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
    </div>
  );
}

export default ItemListPolicyFront;
