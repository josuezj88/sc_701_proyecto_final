import React, { useState, useRef } from "react";
import Footer from "../../components/Footer";
import md5 from 'md5';
import { Button, Alert, Label, Input, FormGroup } from "reactstrap";
import { Link } from "react-router-dom";
import Axios from "axios";
import Cookies from "universal-cookie";
import PollitoLogo from "../../images/pollitosHierro.png";
import { library } from '@fortawesome/fontawesome-svg-core';
import { faGoogle, faFacebookF } from '@fortawesome/free-brands-svg-icons';
import swal from 'sweetalert';
import img4 from "../../images/Vector-4.svg";
library.add(faGoogle, faFacebookF)

function Login() {
  const emailRef = useRef();
  const passwordRef = useRef();
  const [error, setError] = useState("");
  const baseUrl = "http://localhost:6281/api/AspNetUsers";

  const cookies = new Cookies();

  function setLogin(e) {
    e.preventDefault();
    setError("");
    const login = {
      username: emailRef.current.value,
      password: md5(passwordRef.current.value)
    };

    console.log("este es el login" + login);
    Axios.get(baseUrl + `/${login.username}/${login.password}`)
      .then(response => {
        if(response){
            console.log(response.data);
            cookies.set('id', response.id, {path:"/Home"});
            localStorage.setItem("Id", response.id);
            cookies.set('username', response.email, {path:"/Home"});
            localStorage.setItem("Cuenta", response.username);
            localStorage.setItem("Email", response.email);
            cookies.set('nombre', response.nombre, {path:"/Home"});
            localStorage.setItem("Nombre", response.nombre);
            cookies.set('apellido', response.primerApellido, {path:"/Home"});
            cookies.set('telefono', response.phoneNumber, {path:"/Home"});
           
            window.location = "/Home";
        }else{
            setError("Su contraseña o usuario estan incorrectos");
        }
        
      })
      .then(error => {
        console.log(error);
      });
  }

  const setGoogle = () => {
    alert("Not connected to API");
  }

  return (<div>
    <section className="get-a-membership-area fade-in-card">
      <div className="section-overlay-login">
        <div className="offset-md-1 col-xl-3 col-lg-4 col-md-4 p-5 mt-5" style={{ backgroundColor: "rgba(0,0,0,.5)", borderRadius: "20px", marginBottom: "55px" }}>
          <h3 className="mt" style={{ fontSize: 40 }}>
            <img src={PollitoLogo} alt="Energym-logo" />
          </h3>
          <p className="mb-3 " style={{ color: "#D6D2C4" }}>Bienvenido! Favor ingrese a su cuenta</p>
          {error && <Alert variant="danger" className="mt" style={{ width: "20%" }}>{error}</Alert>}
          <form className="mt" style={{ width: "20%", color: "#D6D2C4" }} onSubmit={setLogin}>
            <div className="form-group">
              <Label for="search-input1" style={{ color: "#D6D2C4" }}>Correo electrónico:</Label>
              <input
                className="form-control"
                style={{ background: "transparent", color:"#D6D2C4", borderRadius: "10px" }}
                defaultValue={""}
                ref={emailRef}
                required
                name="email"
                placeholder="Ingrese su correo electrónico"
              />
            </div>
            <div className="form-group mb-2">
              <Label for="search-input1" style={{ color: "#D6D2C4" }}>Contraseña:</Label>
              <input
                className="form-control"
                style={{ background: "transparent",color:"#D6D2C4", borderRadius: "10px" }}
                defaultValue={""}
                ref={passwordRef}
                type="password"
                required
                name="password"
                placeholder="Ingrese su contraseña"
              />
            </div>
           
            <Button
              type="submit"
              color="warning"
              className="w-100 btn-warning mt-4"
              style={{ borderRadius: "10px" }}
              size="sm"
            >
              Ingresar
            </Button>
            <br></br>

            <div className="d-flex align-items-center mt-4">
              No tiene cuenta?
              <Link to="/Registro" className="ml-1" style={{ color: "#D6D2C4", textDecoration: "none" }}>
                Registrarse
              </Link>
            </div>

           
            <Button
              
              color="danger"
              className="w-100 btn-danger mt-4"
              style={{ borderRadius: "10px" }}
              size="sm"
            >
              <Link to="/Registro" className="ml-1" style={{ color: "#D6D2C4", textDecoration: "none" }}>
                Registrarse
              </Link>
            </Button>
            
            
            
          </form>
        </div>
      </div>
    </section>
    <Footer />
  </div>);
}
export default Login;