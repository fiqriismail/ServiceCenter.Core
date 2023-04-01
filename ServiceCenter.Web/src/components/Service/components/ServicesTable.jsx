import React from "react";

import ServicesTableItem from "./ServicesTableItem";

function ServicesTable() {

    const services = [
        {
            "id": "25cfe1e8-a764-46e5-8ef6-7b74ffc37c56",
            "title": "Jeep Body Wash",
            "description": "Small jeeps only",
            "serviceType": 0
        },
        {
            "id": "0b64c39f-c939-491c-bd00-0e03654de13e",
            "title": "Cars oil changinh",
            "description": "All cars",
            "serviceType": 1
        },
        {
            "id": "927ea1ef-cf97-4569-8700-485b2720318c",
            "title": "Jeeps oil changinh",
            "description": "All jeeps",
            "serviceType": 1
        }
    ];

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
                {tableItems}
            </tbody>
        </table>
    )
}

export default ServicesTable;