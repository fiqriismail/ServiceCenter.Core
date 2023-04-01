import React from "react";

import MainLayout from "../Layout/MainLayout";
import ServicesTable from "./components/ServicesTable";

function ServiceHome() {
    return (
        <MainLayout>
            <h3 className="mt-2">Available Services</h3>
            <ServicesTable />
        </MainLayout>
    )
}

export default ServiceHome;