
import React from "react";
import {Router, Switch, Route  } from "react-router-dom";
import history from "../history";
import '../css/App.css';
import '../css/style.css';
//---Cuenta
import Login from "../pages/Cuenta/Login";
import Registro from "../pages/Cuenta/Registro";
import Home from "../pages/Admin/Home";

function App() {
  return (
    <Router history={history}>
      <div className="App">
      <Switch>
        <Route path='/Registro' component={Registro}/>
        <Route path='/' exact component={Login}/>
        <Route path='/Home' component={Home}/>
      </Switch>
     
      </div>
        
     
    </Router> 
  );
}

export default App;
