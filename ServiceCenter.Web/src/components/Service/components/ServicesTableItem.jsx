import React from "react";

function ServicesTableItem({ title, description, stype }) {
    return (
        <tr>
            <td>{title}</td>
            <td>{description}</td>
            <td>{stype}</td>
        </tr>
    )
}

export default ServicesTableItem;