import {React, useEffect} from 'react';
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCoffee, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { Button } from "react-bootstrap";
import Cookies from "universal-cookie";
import Axios from "axios";
import { useHistory } from "react-router-dom";
// import HeaderCliente from "./HeaderCliente";
import HeaderAdmin from "./HeaderAdmin";
import HeaderUsuario from "./HeaderUsuario";
library.add(faCoffee, faSignOutAlt);
export default function Header() {
    const history = useHistory();
    const baseUrl = "http://localhost:6281/api/AspNetUsers";
    const cookies = new Cookies();

    // useEffect(() => {
    //     const userCookie = localStorage.getItem('Id');
    //     console.log("este es el id "+userCookie);
    //     if(userCookie){
    //         Axios.get(baseUrl + `/${userCookie}`)
    //     .then(async (res) => {
    //         console.log("este es el res "+res.data)
    //         if (res.data === "") {
    //             localStorage.clear();
    //             history.push("/");
    //         }else{
    //             console.log("this is the header data "+ res)
    //             localStorage.setItem("userName", res.data.nombre + " " + res.data.primerApellido);
    //             localStorage.setItem("correo", res.data.email);
    //             localStorage.setItem("userId", res.data.id);
    //             localStorage.setItem("Cuenta", res.data.username);
    //         }
    //     });
    //     }
        
    // }, []);
    console.log("esta es la cuenta "+localStorage.getItem("Cuenta"));
    
    const logOut = () => {
       
        localStorage.clear();
        cookies.remove('id');
        cookies.remove('username');
        cookies.remove('nombre');
        cookies.remove('apellido');
        cookies.remove('telefono');
        history.push("/");

    };
    return (
        <nav className="navbar navbar-expand-lg navbar-dark fixed-top d-none d-sm-none d-md-block d-lg-block d-xl-block"
            id="mainNav">
            <div className="container">
                {/* {localStorage.getItem('tipoCuenta') === 'Cliente' ? <HeaderCliente /> : ''} */}
                {localStorage.getItem('Cuenta') === 'Administrador' ? <HeaderAdmin /> : ''}
                {localStorage.getItem('Cuenta') === 'Usuario' ? <HeaderUsuario /> : ''}
                <div className=" navbar-collapse mt-1">
                    <ul className="navbar-nav ml-auto">
                        <ul className="navbar-nav ml-auto">
                            <p style={{ color: "white", marginTop: "10px", fontSize: "18px", marginRight: "15px" }}>{localStorage.getItem('userName') ? "¡Hola " + localStorage.getItem('userName') + "!" : "Sin sesión activa..."}</p>
                        </ul>
                        <li>
                            <Button type="button" style={{ backgroundColor: "transparent", borderColor: "transparent", fontSize: "17px" }} onClick={logOut}><FontAwesomeIcon icon={faSignOutAlt} /> SALIR</Button>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

