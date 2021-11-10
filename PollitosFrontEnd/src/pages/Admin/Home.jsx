import React from "react";
import { Link } from "react-router-dom";
import Cookies from "universal-cookie";
import Header from "../../components/Header";

export default function NotAuthorize(){

    const cookies = new Cookies();
    const name = localStorage.getItem('Nombre');
    return(
        <div style={{backgroundColor:"#DFD8CA", width:"100%", height:"1000px", margin:"0px"}}>
            <Header />
            <div className="text-center container" style={{margin:"auto auto", paddingTop:"10%"}}>
                <h3 style={{color:"#FFAA4C"}}>Bienvenido {name}</h3>
                
                
            </div>
        </div>
    );
}