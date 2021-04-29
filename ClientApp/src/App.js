import React, { Component } from 'react'
import './App.css'
import './scss/tools.scss';
import 'bootstrap/dist/css/bootstrap.min.css';

// Components
import NavBar from './components/Nav.component';
import  WelcomeMessage from "./components/WelcomeMessage.component";
import CertificationForm from "./components/CertificationValidationForm.component";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div className="page_style">
          <div className="container-fluid">
            <div className="row">
              <div className="pb-100 col-11 col-sm-11 col-md-11">
                <NavBar />
                <div className="col-md-5 offset-md-4">
                  <WelcomeMessage/>
                  <CertificationForm/>
                </div>
              </div>
            </div>
          </div>
      </div>
    );
  }
}
