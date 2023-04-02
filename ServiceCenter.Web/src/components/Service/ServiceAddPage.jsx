import React, { useEffect, useState } from "react";
import MainLayout from "../Layout/MainLayout";
import { Link, Navigate } from "react-router-dom";
import { Field, Form, Formik } from "formik";

function ServiceAddPage() {

    const [formErrors, setFormError] = useState({});
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [formValues, setFormValues] = useState({});

    const initialFormValues = {
        title: '',
        description: '',
        serviceType: '0'
    };

    const submitForm = (values) => {
        values['serviceType'] = parseInt(values.serviceType);
        setFormValues(JSON.stringify(values, null, 2));
        setIsSubmitting(true);
    }

    useEffect(() => {

        if (Object.keys(formErrors).length === 0 && isSubmitting) {
            // call the api
            const apiUrl = "http://localhost:5196/api/services";
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: formValues
            }

            fetch(apiUrl, requestOptions)
                .then(response => response.json);

            setIsSubmitting(false);

        }

    }, [isSubmitting])

    const handleErrors = (values) => {
        const errors = {};
        if (values.title == '') {
            errors.title = "Title is required"
        }
        setFormError(errors);

        return errors;
    }

    return (
        <MainLayout>
            <h3 className="mt-2">Add new service</h3>
            <Link to="/" className="btn btn-primary">Service List</Link>
            <Formik
                initialValues={initialFormValues}
                onSubmit={submitForm}
                validate={handleErrors}
            >
                <Form className="p-3 mt-4 border">
                    <div className="mb-3">
                        <label htmlFor="title" className="form-label">Title</label>
                        <Field
                            id="title"
                            name="title"
                            placeholder="Service Title"
                            className="form-control" />
                        <span className="small text-danger p-1">{formErrors.title}</span>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="description" className="form-label">Description</label>
                        <Field
                            id="description"
                            name="description"
                            as="textarea"
                            className="form-control" />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="serviceType" className="form-label">Select service type</label>
                        <Field
                            id="serviceType"
                            name="serviceType"
                            as="select"
                            className="form-select">
                            <option value="0">Body Wash</option>
                            <option value="1">Oil Change</option>
                            <option value="2">Interior Cleaning</option>
                            <option value="3">Cut and Polish</option>
                        </Field>
                    </div>
                    <div className="mb3">
                        <button type="submit" className="btn btn-secondary">Add Service</button>
                    </div>
                </Form>
            </Formik>
        </MainLayout>
    )
}

export default ServiceAddPage;