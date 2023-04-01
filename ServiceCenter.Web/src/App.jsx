import React from "react";

import ServiceHome from "./components/Service/ServiceHome";
import ServiceAddPage from "./components/Service/ServiceAddPage";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" Component={ServiceHome} />
        <Route path="/serviceadd" Component={ServiceAddPage} />
      </Routes>
    </>
  );
}

export default App;
