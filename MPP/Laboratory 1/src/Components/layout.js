/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Link is used instead of an a href element, and also handles the '/' in the url. Overall, it is easier to use and to manage in React
import React from "react";
import { Link } from "react-router-dom";
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

export function Navbar() {
    return(
        <nav className="navbar navbar-expand bg-dark">
            <div className="container">
                <h4 style={{ color: "#00ff00", fontWeight: "bold" }}>Spotofyi🎧    </h4>
                <div className="collapse navbar-collapse">
                <ul className="navbar-nav me-auto mb-2 mb-lg-0">

                    <li className="nav-item">
                    <Link className="nav-link" aria-current="page" to="/" style={{color: "white"}}>Home</Link>
                    </li>

                    <li className="nav-item">
                    <Link className="nav-link" to="/melodies" style={{color: "white"}}>Melodies</Link>
                    </li> 

                </ul>
                </div>
            </div>
        </nav>
    );
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

export function Footer() {
    return(
        <footer className="fixed-bottom">
            <div>
                <div className="text-center p-3 text-light bg-dark" >
                    <p style={{ color: "#00ff00" }}>_____----A Music Library Manager----_____</p>
                </div>
            </div>
        </footer>
    );
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////