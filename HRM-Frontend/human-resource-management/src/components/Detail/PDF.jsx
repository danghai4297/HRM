import React from "react";
import { usePDF, Document, Page, View, Text } from "@react-pdf/renderer";
const MyDoc = () => (
  <Document>
    <Page size="A4">
      <View>
        <Text>Section #1</Text>
      </View>
      <View>
        <Text>Section #2</Text>
      </View>
    </Page>
  </Document>
);
function PDF() {
  const [instance, updateInstance] = usePDF({ document: MyDoc });

  if (instance.loading) return <div>Loading ...</div>;

  if (instance.error) return <div>Something went wrong: </div>;

  return (
    <a href={instance.url} download="test.pdf">
      Download
    </a>
  );
}

export default PDF;
