import React from 'react';
import ReactDOM from 'react-dom';
import { Navbar, Footer } from './Components/layout';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Home } from './Components/homepage';
import { Melodies } from './Components/melodies.js';
import './index.css'; 

//If you wish to use this code, be sure to also copy my public index.html, as i have some bootstrap links that are associated to it and not part of the original project created with npx
//WARNING: This application uses json-server! Make sure you have it installed
//step 1. Run 'json-server --watch db.json --port 3004'
//step 2. Run 'npm start' on a different terminal

function App() {
  return (
    <Router>
      <div className="app">
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/melodies/*" element={<Melodies />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);