import React from "react";

function ServicesTableItem({ serviceId, title, description, stype, deleteClick }) {
    return (
        <tr>
            <td>{title}</td>
            <td>{description}</td>
            <td>{stype}</td>
            <td><button
                className="btn btn-danger"
                onClick={() => deleteClick(serviceId)}>Delete</button></td>
        </tr>
    )
}

export default ServicesTableItem;