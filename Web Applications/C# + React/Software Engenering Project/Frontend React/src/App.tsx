import React from 'react';
import './App.css';
import Sidebar from "./components/SidebarContainer";

const BrowserRouter = require("react-router-dom").BrowserRouter;

function App() {
  return (
    <BrowserRouter>
      <Sidebar/>
    </BrowserRouter>
  );
}

export default App;
