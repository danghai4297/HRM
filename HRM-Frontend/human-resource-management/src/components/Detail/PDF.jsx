import React, { useEffect, useState } from "react";
import font from "./Roboto-Medium.ttf";
import {
  Document,
  Page,
  View,
  Text,
  PDFDownloadLink,
  Font,
} from "@react-pdf/renderer";
import ProductApi from "../../api/productApi";
import { cmndTccHC, ttc } from "./Data";
import SubDetail from "./SubDetail";
import dateFormat from "dateformat";

Font.register({ family: "Roboto", src: font });
const styles = {
  title: {
    fontFamily: "Roboto",

  },
};

function PDF(props) {
  let { match, history } = props;
  let { id } = match.params;
  const [dataDetailNv, setdataDetailNv] = useState([]);
  console.log(id);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getNvDetail(id);
        setdataDetailNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const MyDoc = () => (
    <Document>
      <Page size="A4">
        <View style={[{flexDirection: "row"}, {width: "100%"}]}>
          {cmndTccHC.map((detail, key) => {
            return (
              <>
                <Text
                  style={[
                    styles.title,
                    { fontSize: "10px" },
                    { padding: "20px" },
                    {width: "50%"}
                  ]}
                >
                  {/* key={key} */}
                  {detail.title1}
                </Text>
                <Text
                  style={[
                    styles.title,
                    { fontSize: "10px" },
                    { padding: "20px" },
                    {width: "50%"}
                  ]}
                >
                  {/* key={key} */}
                  {detail.data1[1] === true &&
                  dataDetailNv[detail.data1[0]] !== null
                    ? dateFormat(dataDetailNv[detail.data1[0]], "dd/mm/yyyy")
                    : dataDetailNv[detail.data1[0]]}
                </Text>
                
                {/* <Text
                  style={[
                    styles.title,
                    { fontSize: "10px" },
                    { padding: "20px" },
                  ]}
                >
                  {detail.title2}
                  {detail.data2[1] === true &&
                  dataDetailNv[detail.data2[0]] !== null
                    ? dateFormat(dataDetailNv[detail.data2[0]], "dd/mm/yyyy")
                    : dataDetailNv[detail.data2[0]]}
                </Text> */}
              </>
            );
          })}
        </View>
        <View>
          <Text>
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailNv[detail.data1[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNv[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data2[0]]
                  }
                />
              );
            })}
          </Text>
        </View>
      </Page>
    </Document>
  );
  return (
    <>
      <PDFDownloadLink document={<MyDoc />} fileName="somename.pdf">
        {({ blob, url, loading, error }) =>
          loading ? "Loading document..." : "Download now!"
        }
      </PDFDownloadLink>
    </>
  );
}

export default PDF;
