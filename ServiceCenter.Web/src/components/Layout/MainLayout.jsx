import React from "react";

import NavBar from "./NavBar";

function MainLayout(props) {
    return (
        <>
            <NavBar />
            <div className="container">
                {props.children}
            </div>
        </>
    )
}

export default MainLayout;