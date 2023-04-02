import React, { useEffect, useState } from "react";

import ServicesTableItem from "./ServicesTableItem";

function ServicesTable({ data }) {

    const [isDeleted, setIsDeleted] = useState(false);
    const [serviceId, setServiceId] = useState("");
    const [services, setService] = useState([]);

    // fetch data from api
    const fetchServiceData = () => {
        const apiUrl = "http://localhost:5196/api/services";
        const requestOptions = {
            method: 'GET',
            headers: {
                Authorization: "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUb2tlbkZvclRoZUFwaVdpdGhBdXRoIiwianRpIjoiMjYxYjNiMjItY2JiNS00ODFiLTg1YTMtMGFlNjI0YzNiNjljIiwiaWF0IjoiMDQvMDIvMjAyMyAxMTowMjo0NiIsIlVzZXJJZCI6ImE3NzY5YWI1LTEyZjEtNDIyNi1iYzYyLWMxZTRmNzNhZmUyYiIsIlVzZXJuYW1lIjoiZmlxcmlpc21haWwiLCJFbWFpbCI6ImZpcXJpQG1zbi5jb20iLCJleHAiOjE2ODA0MzUxNjYsImlzcyI6ImFwaVdpdGhBdXRoQmFja2VuZCIsImF1ZCI6ImFwaVdpdGhBdXRoQmFja2VuZCJ9.OvWNBJUnu-JBuKVUDDdhvE8tPGVK9HdEb77NaP2Nra8"
            }
        }
        return fetch(apiUrl, requestOptions)
            .then((response) => response.json())
            .then((data) => setService(data));
    }


    const deleteHandler = (id) => {
        setServiceId(id);
        setIsDeleted(true);
    }

    const tableItems = services.map(service => {
        return (
            <ServicesTableItem
                key={service.id}
                serviceId={service.id}
                title={service.title}
                description={service.description}
                stype={service.serviceType}
                deleteClick={deleteHandler} />
        )
    })

    const callDeleteApi = (id) => {
        const apiUrl = "http://localhost:5196/api/services/" + id;
        const requestOptions = {
            method: 'DELETE'
        }
        fetch(apiUrl, requestOptions)
            .then(response => response.json);
    }

    useEffect(() => {
        if (isDeleted) {
            callDeleteApi(serviceId);
            setIsDeleted(false);
            fetchServiceData();
        }
        fetchServiceData();


    }, [isDeleted]);

    return (
        <table className="mt-1 table">
            <thead>
                <tr>
                    <th scope="col">Title</th>
                    <th scope="col">Description</th>
                    <th scope="col">Type</th>
                    <th scope="col">&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                {tableItems.length > 0 ? tableItems : <tr><td>Loading...</td></tr>}
            </tbody>
        </table>
    )
}

export default ServicesTable;