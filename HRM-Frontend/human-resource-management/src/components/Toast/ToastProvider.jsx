import React, { useState } from "react";
import { ToastContext } from "./Toast";
import Snackbar from '@mui/material/Snackbar';
import MuiAlert from '@mui/material/Alert';
const Alert = React.forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
  });
function ToastProvider(props) {
    const vertical = "top";
    const horizontal = "center"
  const { children } = props;
  const [state, setState] = useState({ isOpen: false });

  const show = (message) => {
    setState({ isOpen: true, message });
  };

  const hide = () => setState({ isOpen: false });

  const error = (message) => {
    show({ type: "error", text: message });
  };

  const warn = (message) => {
    show({ type: "warning", text: message });
  };

  const info = (message) => {
    show({ type: "info", text: message });
  };

  const success = (message) => {
    show({ type: "success", text: message });
  };
  const { isOpen, message } = state;
  return (
    <ToastContext.Provider
      value={{
        error: error,
        warn: warn,
        info: info,
        success: success,
        hide: hide
      }}>
      {children}
      {message && (
        <Snackbar open={isOpen} autoHideDuration={3000} onClose={hide} anchorOrigin={{ vertical, horizontal }}>
          <Alert elevation={6} variant="filled" onClose={hide} severity={message.type}>
            {message.text}
          </Alert>
        </Snackbar>
      )}
    </ToastContext.Provider>
  );
}

export default ToastProvider;
