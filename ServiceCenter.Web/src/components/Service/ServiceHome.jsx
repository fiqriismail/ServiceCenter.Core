import React from "react";

import MainLayout from "../Layout/MainLayout";
import ServicesTable from "./components/ServicesTable";
import { Link } from 'react-router-dom';

function ServiceHome() {
    return (
        <MainLayout>
            <h3 className="mt-2">Available Services</h3>
            <Link to="/serviceadd" className='btn btn-primary m-2'>Add</Link>
            <ServicesTable />
        </MainLayout>
    )
}

export default ServiceHome;