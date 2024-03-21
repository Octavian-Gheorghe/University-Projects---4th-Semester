import React, { useEffect, useState } from "react";
import { Link, Routes, Route, useNavigate, useLocation, useParams } from "react-router-dom";

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

export function Melodies() {
    //Handles The melody list along with managing the urls for every single of it's elements
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Declarations
    const [content, setContent] = useState(<MelodyList displayForm={displayForm} />);
    const navigate = useNavigate();

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function displayList() {
        setContent(<MelodyList displayForm={displayForm} />);
    }

    function displayForm(melody) {
        if (melody){
            navigate(`/melodies/edit/${melody.id}`, { state: { melody } });
        } else {
            navigate('/melodies/add', { state: { melody } });
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //SETTING UP ROUTES TO USE LATER ON
    return (
        <div className="container my-5">
        <Routes>
            <Route path="/" element={content} />
            <Route path="/add" element={<MelodyForm displayList={displayList} />} />
            <Route path="/edit/:id" element={<MelodyForm displayList={displayList} />} /> 
            <Route path="/:id" element={<MelodyDetails />} />
            <Route path="*">Not Found</Route>
        </Routes>
        </div>
    );

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

export function MelodyDetails() {
    //This part is strictly used to be rendered later on. It takes the id and sets the details of the melody at that id into our hook
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //DECLARATIONS
    const [melody, setMelody] = useState(null);
    const { id } = useParams();

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    useEffect(() => {
        //This apparently does not search for the url, it just takes the data that has that specific id
        fetch(`http://localhost:3004/melodies/${id}`)
            .then((response) => response.json())
            .then((data) => {
                setMelody(data);
            })
            .catch((error) => console.log(error));
    }, [id]);

    //If the id provided is not a valid one
    if (!melody) {
        return <div>There is no melody here..</div>;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    return (
        <div>
            <div style={{ display: 'flex', justifyContent: 'center',  height: '60vh' }}>
                <div style={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', alignItems: 'center', maxHeight: '500px', height: '100%', maxWidth: '500px', width: '100%', color: '#00ff00', background: '#212529', padding: '20px', borderRadius: '8px' }}>
                    <h1><b>Melody Details</b></h1>
                    <br></br>
                    <br></br>
                    <br></br>
                    <h4>Name: {melody.name}</h4>
                    <h4>Year of Release: {melody.year}</h4>
                    <h4>Album: {melody.creator}</h4>
                    <br></br>
                    <Link to="/melodies" className="btn btn-secondary">Exit</Link>
                </div>
            </div>
            
        </div>
    );

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

export function MelodyList(props) {

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //DECLARATIONS
    const [content, setContent] = useState([]);
    
    const [showConfirmation, setShowConfirmation] = useState(false);
    const [melodyToDelete, setMelodyToDelete] = useState(null);

    const [sortedMelodies, setSortedMelodies] = useState([]);
    const [isAscending, setIsAscending] = useState(true);

    const [fadeIn, setFadeIn] = useState(false); 

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //FETCHING THE DATA FROM THE JSON FILE
    function fetchMelodies() {
        fetch("http://localhost:3004/melodies")
            .then((response) => {
                if (!response.ok) {
                    throw new Error("Something's wrong...I can feel it! (fetching issue)");
                }
                return response.json()
            })
            .then((data) => {
                setContent(data);
                setSortedMelodies(data); 
                setFadeIn(true);
            })
            .catch(error => console.log(error));
    }

    useEffect(() => {
        fetchMelodies();
        return () => {
            setFadeIn(false);
        };
    }, []);

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Confirmation Pop-up modal used whenever a delete is about to occur
    function ConfirmationModal({ message, onConfirm, onCancel }) {
        return (
            <div className="modal fade show" style={{ display: "block", backgroundColor: "rgba(0, 0, 0, 0.5)" }}>
                <div className="modal-dialog modal-dialog-centered">
                    <div className="modal-content" style={{ backgroundColor: "#212529", color: "#ffffff" }}>
                        <div className="modal-header">
                            <h5 className="modal-title" style ={{color: "#00ff00"}}>Confirmation</h5>
                            <button type="button" className="btn-close" aria-label="Close" onClick={onCancel}></button>
                        </div>
                        <div className="modal-body">
                            <p>{message}</p>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" onClick={onCancel}>Cancel</button>
                            <button type="button" className="btn btn-danger" onClick={onConfirm}>Confirm</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    function showDeleteConfirmation(melodyId) {
        setMelodyToDelete(melodyId);
        setShowConfirmation(true);
    }

    function hideConfirmation() {
        setShowConfirmation(false);
        setMelodyToDelete(null);
    }

    //The delete itself
    function deleteMelody() {
        fetch(`http://localhost:3004/melodies/${melodyToDelete}`, {
            method: "DELETE"
        })
        .then(response => {
            if (!response.ok) {
                throw new Error("Something's wrong...I can feel it! (delete issue)");
            }
            return response.json();
        })
        .then(data => {
            fetchMelodies();
            hideConfirmation();
        })
        .catch(error => console.log(error));
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Sorting Attribute used whenever the button is clicked
    function sortMelodiesByCreator() {
        const sorted = [...sortedMelodies].sort((a, b) => {
            const creatorA = a.creator.toUpperCase();
            const creatorB = b.creator.toUpperCase();
            if (isAscending) {
                return creatorA.localeCompare(creatorB);
            } else {
                return creatorB.localeCompare(creatorA);
            }
        });
        setIsAscending(!isAscending); 
        setSortedMelodies(sorted);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    return (
        <div style={{backgroundColor: '#000000', opacity: fadeIn ? 1 : 0, transition: 'opacity 0.75s ease-in-out'}}>
            <h1 className="text-center mb-5" style={{color: "#00ff00", fontWeight: "bold"}}>~List of Melodies~</h1>
            <div className="btn-group me-2 mb-3" role="group" aria-label="Basic example">  
                <Link to="/melodies/add" className="btn btn-success me-2" style={{color: "white"}}>Add</Link>
                <button onClick={() => fetchMelodies()} className="btn btn-outline-success me-2" style={{color: "white"}}>Refresh</button>
                <button onClick={sortMelodiesByCreator} className="btn btn-success me-2" style={{color: "white"}}>Sort by Band</button>
            </div>
            <table className={`table table-dark text-center`}>
                <thead>
                    <tr>
                        <th className="text" style={{color: "#00ff00"}}>Name</th>
                        <th className="text" style={{color: "#00ff00"}}>Year of Release</th>
                        <th className="text" style={{color: "#00ff00"}}>Band</th>
                        <th className="text" >Actions</th>
                    </tr>
                </thead>
                <tbody className="text-center">
                    {sortedMelodies.map((melody) => (
                        <tr key={melody.id}>
                            <td>{melody.name}</td>
                            <td>{melody.year}</td>
                            <td>{melody.creator}</td>
                            <td style={{width: "3px", whiteSpace: "nowrap"}}>
                                <div className="btn-group me-2" role="group" aria-label="Basic example">
                                <button onClick={() => props.displayForm(melody)} className="btn btn-primary btn-sm me-2">Edit</button>
                                <button onClick={() => showDeleteConfirmation(melody.id)} type="button" className="btn btn-danger btn-sm me-2">Delete</button>
                                <Link to={`/melodies/${melody.id}`} className="btn btn-outline-success me-2"  style={{color: "#00ff00", fontWeight: "bold"}}>Details</Link>
                                </div>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            {showConfirmation && (
                <ConfirmationModal
                    message="Are you sure you want to delete this melody?"
                    onConfirm={deleteMelody}
                    onCancel={hideConfirmation}
                />
            )}
        </div>
    );
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    export function MelodyForm(props){
        //Handles the Form regarding the add/edit function. It chooses wether it is an add or an edit based on wether the melody has an id that is to be stored (if it exists) within melodyid
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //DECLARATIONS
        //formStyle and inputStyles are just custom used for the form and tbe inputs of the form

        const formStyle = {
            backgroundColor: "#212529",
            color: "#ffffff",
            padding: "20px", 
            borderRadius: "8px" 
          };
          
          const inputStyle = {
            backgroundColor: "#666",
            color:"#00ff00" 
          };

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //these messages appear whenever you mistype (as in you do not fill all the fields or you do not put a number in year, respectively)
        const [errorMessage, setErrorMessage] = useState("");
        const [successMessage, setSuccessMessage] = useState("");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        const [formData, setFormData] = useState({});
        console.log(formData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        const { state } = useLocation();
        const melody = state && state.melody;
        const melodyId = melody && melody.id;
       
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        const handleChange = (event) => {
            const name = event.target.name;
            const value = event.target.value;
            setFormData(values => ({...values, [name]: value}))
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //This lambda function takes the data filled in the form and checks it. It also sees wether there was a melody to be handled (with the help of melodyID) and chooses wether we execute an add or an edit

        const handleSubmit = (event) => {
            event.preventDefault();
        
            const formData = new FormData(event.target);
            const melody = Object.fromEntries(formData.entries());
        
            melody.year = parseInt(melody.year);
        
            if (!melody.name || isNaN(melody.year) || melody.year < 0 || !melody.creator) {
                setErrorMessage(
                    <div className="alert alert-warning alert-dismissible fade show" role="alert">
                        Fill all the fields correctly, please!
                        <button type="button" className="btn-close" data-bs-dismiss="alert" aria-label="Close" onClick={() => setErrorMessage("")}></button>
                    </div>
                );
                return;
            }
            //PATCH method <=> Edit function
            //POST method <=> Add function
            if (melodyId) {
                fetch(`http://localhost:3004/melodies/${melodyId}`, {
                    method: "PATCH",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(melody)
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error("Something's wrong...I can feel it! (edit)");
                        }
                        return response.json();
                    })
                    .then(data => {
                        props.displayList();
                        setSuccessMessage(
                            <div className="alert alert-success alert-dismissible p-3 m-3 fade show" role="alert">
                                Melody updated successfully!
                                <button
                                    type="button"
                                    className="btn-close"
                                    data-bs-dismiss="alert"
                                    aria-label="Close"
                                    onClick={() => setSuccessMessage("")}
                                ></button>
                            </div>
                        );
                    })
                    .catch(error => {
                        console.log(error)
                    });
            } else {
                fetch("http://localhost:3004/melodies", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(melody)
                })
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Something's wrong...I can feel it! (add)");
                    }
                    return response.json();
                }) 
                .then(data => {
                    props.displayList();
                       setSuccessMessage(
                        <div className="alert alert-success alert-dismissible p-3 m-3 fade show" role="alert">
                            Melody added successfully!
                            <button
                                type="button"
                                className="btn-close"
                                data-bs-dismiss="alert"
                                aria-label="Close"
                                onClick={() => setSuccessMessage("")}
                            ></button>
                        </div>
                    );
                })
                .catch(error => {
                    console.log(error)
                });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Wether the melody exists or not, we choose the words add or edit, the url is handled earlier
        
        return(
            <>
                <h2 className="text-center mb-3" style={{color: "#00ff00"}}>
                    {melody ? "Edit " : "Add"} Melody
                </h2>
                <Link to="/melodies" className="btn btn-secondary">Exit</Link>
                    <div className="row mt-3">
                    <div className="col-md-6">
                    {successMessage}
                    {errorMessage && errorMessage}
                    <form onSubmit={(event) => handleSubmit(event)} style={formStyle}>
                        <div className="mb-3">
                            <label className="col-sm-4 col-form-label">Name</label>
                            <div className="mb-3">
                                <input
                                    type="text" className="form-control" name="name" style={inputStyle} 
                                    placeholder={melody ? melody.name : "Enter name...."}
                                    defaultValue={melody ? melody.name : ""}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                                    
                        <div className="mb-3">
                            <label className="col-sm-4 col-form-label">Year of release</label>
                            <div className="mb-3">
                                <input 
                                    type="text" className="form-control" name="year" style={inputStyle}
                                    placeholder={melody ? melody.year : "Enter year...."}
                                    defaultValue={melody ? melody.year : ""}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>

                        <div className="mb-3">
                            <label className="col-sm-4 col-form-label">Band</label>
                            <div className="mb-3">
                                <input 
                                    type="text" className="form-control" name="creator" style={inputStyle}
                                    placeholder={melody ? melody.creator : "Enter band...."}
                                    defaultValue={melody ? melody.creator : ""}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                                
                        <button type="submit" className="btn btn-success sm-4">Save</button>
                        </form>
                        </div>
                </div>
            </>
        );
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////