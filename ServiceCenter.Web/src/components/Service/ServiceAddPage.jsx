import React from "react";

import MainLayout from "../Layout/MainLayout";
import { Link } from "react-router-dom";
import { Formik, Form, Field } from "formik";

function ServiceAddPage() {
  return (
    <MainLayout>
      <h3 className="mt-2">Add new Service</h3>
      <Link to="/" className="btn btn-primary m-2">
        Service List
      </Link>
      <Formik>
        <Form className="mt-4 border p-4">
          <div className="mb-3">
            <label htmlFor="title" className="form-label">
              Title
            </label>
            <Field
              id="title"
              name="title"
              placeholder="Service title"
              className="form-control"
            />
          </div>
          <div className="mb-3">
            <label htmlFor="description" className="form-label">
              Description
            </label>
            <Field
              id="description"
              name="description"
              placeholder="Description"
              className="form-control"
              as="textarea"
            />
          </div>
          <div className="mb-3">
            <label htmlFor="serviceType" className="form-label">
              Description
            </label>
            <Field
              id="serviceType"
              name="serviceType"
              className="form-select"
              as="select"
            >
              <option value="0">BodyWash</option>
              <option value="0">OilChange</option>
              <option value="0">InteriorCleaning</option>
              <option value="0">CutAndPolish</option>
            </Field>
          </div>
          <button className="btn btn-secondary" type="submit">
            Add Service
          </button>
        </Form>
      </Formik>
    </MainLayout>
  );
}

export default ServiceAddPage;
