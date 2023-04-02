import React from "react";
import { Routes, Route } from "react-router-dom";

import ServiceHome from "./components/Service/ServiceHome";
import ServiceAddPage from "./components/Service/ServiceAddPage";


function App() {

  return (
    <>
      <Routes>
        <Route path="/" Component={ServiceHome} />
        <Route path="/serviceadd" Component={ServiceAddPage} />
      </Routes>
    </>

  )
}

export default App
