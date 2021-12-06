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

import "./ItemListEmployee.scss";
import ListItems from "./ListItem";

function ItemListEmployee() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const { error, warn, info, success } = useToast();

  const [title, settitle] = useState("");

  const [dataDmpb, setDataDmpb] = useState([]);
  const [startDate, setStartDate] = useState(null);
  const [endDate, setEndDate] = useState(null);
  const [gender, setGender] = useState("Tất cả");
  const [status, setStatus] = useState("Tất cả");
  const [department, setDepartment] = useState("Tất cả");
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

  useDidMountEffect(() => {
    if (dataRp.length == 0) {
      info("không có thông tin");
    }
  }, [dataRp]);

  function handelCheck(value) {
    if (value === "Tất cả") {
      setCheck("Tất cả");
      setCheckHd(true);
      setCheckPb(true);
    } else if (value === "Phòng ban") {
      setCheck("Phòng ban");
      setCheckHd(false);
      setCheckPb(true);
    } else if (value === "Năm hợp đồng") {
      setCheck("Năm hợp đồng");
      setCheckPb(false);
      setCheckHd(true);
    }
  }

  const handelReport = async () => {
    if ((check === "Phòng ban") & (department === "Tất cả")) {
      error("Bạn chưa chọn phòng ban");
    } else if (
      (check === "Phòng ban") &
      (gender === "Tất cả") &
      (status === "Tất cả")
    ) {
      try {
        const respb = await ProductApi.getRPPb(department);
        setDataRp(respb);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Phòng ban") &
      (gender !== "Tất cả") &
      (status === "Tất cả")
    ) {
      try {
        const respb = await ProductApi.getRPPbGt(department, gender);
        setDataRp(respb);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Phòng ban") &
      (gender === "Tất cả") &
      (status !== "Tất cả")
    ) {
      try {
        const respb = await ProductApi.getRPPbTt(department, status);
        setDataRp(respb);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Phòng ban") &
      (gender !== "Tất cả") &
      (status !== "Tất cả")
    ) {
      try {
        const respb = await ProductApi.getRPPbTtGt(department, status, gender);
        setDataRp(respb);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Năm hợp đồng") &
      (gender === "Tất cả") &
      (status === "Tất cả")
    ) {
      try {
        if (startDate === null || endDate === null) {
          error("ngày không được để trống");
        } else {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPHd(sdate, edate);
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Năm hợp đồng") &
      (gender !== "Tất cả") &
      (status === "Tất cả")
    ) {
      try {
        if (startDate === null || endDate === null) {
          error("ngày không được để trống");
        } else {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPHdGt(sdate, edate, gender);
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Năm hợp đồng") &
      (gender === "Tất cả") &
      (status !== "Tất cả")
    ) {
      try {
        if (startDate === null || endDate === null) {
          error("ngày không được để trống");
        } else {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPHdTt(sdate, edate, status);
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Năm hợp đồng") &
      (gender !== "Tất cả") &
      (status !== "Tất cả")
    ) {
      try {
        if (startDate === null || endDate === null) {
          error("ngày không được để trống");
        } else {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPHdTtGt(
            sdate,
            edate,
            status,
            gender
          );
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender === "Tất cả") &
      (status === "Tất cả") &
      (department === "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          const respb = await ProductApi.getRpAll();
          setDataRp(respb);
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          warn("Bạn chọn phòng ban hoặc chọn theo năm hợp đồng");
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender !== "Tất cả") &
      (status === "Tất cả") &
      (department === "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          const respb = await ProductApi.getRpAllGt(gender);
          setDataRp(respb);
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          warn("Bạn chọn phòng ban hoặc chọn theo năm hợp đồng");
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender !== "Tất cả") &
      (status !== "Tất cả") &
      (department === "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          const respb = await ProductApi.getRpAllTtGt(status, gender);
          setDataRp(respb);
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          warn("Bạn chọn phòng ban hoặc chọn theo năm hợp đồng");
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender === "Tất cả") &
      (status !== "Tất cả") &
      (department === "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          const respb = await ProductApi.getRpAllTt(status);
          setDataRp(respb);
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          warn("Bạn chọn phòng ban hoặc chọn theo năm hợp đồng");
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender === "Tất cả") &
      (status === "Tất cả") &
      (department !== "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          warn("Bạn chọn ngày hoặc chọn theo phòng ban");
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPPbHd(department, sdate, edate);
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender !== "Tất cả") &
      (status === "Tất cả") &
      (department !== "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          warn("Bạn chọn ngày hoặc chọn theo phòng ban");
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPPbHdGt(
            department,
            sdate,
            edate,
            gender
          );
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender === "Tất cả") &
      (status !== "Tất cả") &
      (department !== "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          warn("Bạn chọn ngày hoặc chọn theo phòng ban");
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRPPbHdTt(
            department,
            sdate,
            edate,
            status
          );
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (check === "Tất cả") &
      (gender !== "Tất cả") &
      (status !== "Tất cả") &
      (department !== "Tất cả")
    ) {
      try {
        if ((startDate === null) & (endDate === null)) {
          warn("Bạn chọn ngày hoặc chọn theo phòng ban");
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respb = await ProductApi.getRpAllPbHdTtGt(
            department,
            sdate,
            edate,
            status,
            gender
          );
          setDataRp(respb);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    }
    // try {
    //   let sdate = format(new Date(startDate), "yyyy-MM-dd");
    //   let edate = format(new Date(endDate), "yyyy-MM-dd");
    //   const respb = await ProductApi.getRpAllPbHdTtGt(
    //     department,
    //     sdate,
    //     edate,
    //     status,
    //     gender
    //   );
    //   setDataRp(respb);
    // } catch (e) {
    //   error("Thực hiện không thành công");
    // }
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
            className="btn btn-primary addTable"
            type="button"
            value="Hiển thị báo cáo"
            onClick={handelReport}
          />
          <button className="pdfx" onClick={handlePrint}>
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
    </div>
  );
}

export default ItemListEmployee;
