import React, { useEffect, useState } from "react";

import ServicesTableItem from "./ServicesTableItem";

function ServicesTable() {

    const [services, setService] = useState([]);

    // fetch data from api
    const fetchServiceData = () => {
        const apiUrl = "http://localhost:5196/api/services";
        return fetch(apiUrl)
            .then((response) => response.json())
            .then((data) => setService(data));
    }
    useEffect(() => {
        fetchServiceData();
    }, []);

    const tableItems = services.map(service => {
        return (
            <ServicesTableItem
                key={service.id}
                title={service.title}
                description={service.description}
                stype={service.serviceType} />
        )
    })

    return (
        <table className="mt-1 table">
            <thead>
                <tr>
                    <th scope="col">Title</th>
                    <th scope="col">Description</th>
                    <th scope="col">Type</th>
                </tr>
            </thead>
            <tbody>
                {tableItems.length > 0 ? tableItems : <tr><td>Loading...</td></tr>}
            </tbody>
        </table>
    )
}

export default ServicesTable;