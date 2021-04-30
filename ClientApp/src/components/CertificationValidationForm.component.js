import React from "react";

class CertificationValidationForm extends React.Component {
    
    constructor(props) {
        super(props);

        this.state = {
            enquirytype: "graduated",
            firstName : "",
            lastName : "",
            DOB : "",
            institutionID : "",
            yearOfAward: "",
            courseName: "",
            qualificationType: "",
            classification: "",

        }
    }

    onFormInputChange = (name) => (event) => {   
        this.setState({ [name]: event.target.value });
        console.log(event.target.value);       
    };

    onFormSubmit = () => (event) => {
        event.preventDefault();

        fetch("http://localhost:5000/api/user", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.state)
        })
            .then(response => response.text())
            .then(text => console.log(text));

    };

    render() {
        return (
            <form date-testid="PersonalDetailsForm" onSubmit={this.onFormSubmit()}>
                <div className="mb-20 row form-group">
                    <div className="col-md-6">
                        <input id="firstName" onChange={this.onFormInputChange('firstName')} name="firstName" placeholder="FIRST NAME" data-testid="firstName" type="" className="form-control" aria-invalid="false" value={this.state.firstName}></input>
                    </div>
                    <div className="col-md-6">
                        <input id="lastName" onChange={this.onFormInputChange('lastName')} name="lastName" placeholder="SURNAME" data-testid="lastName" type="" className="form-control" aria-invalid="false" value={this.state.lastName}></input>
                    </div>
                    <div className="col-md-6"></div>
                </div>
                <div className="form-group mb-20">
                    {/* TODO: needs lable */}
                    <input id="DOB" name="DOB" placeholder="DATE OF BIRTH"  data-testid="DOB" type="date" className="form-control" aria-invalid="false" value={this.state.DOB} onChange={this.onFormInputChange('DOB')}></input>
                </div>
                <div className="mb-20 row form-group">
                    <div className="col">
                        <input id="institutionID" name="institutionID" data-testid="institutionID" placeholder="INSTITUTION ID" type="text" className="form-control" aria-invalid="false" value={this.state.institutionID} onChange={this.onFormInputChange('institutionID')}></input>
                    </div>
                </div>
                <div className="form-group mb-20">
                    {/* TODO: needs lable */}
                    <input id="yearOfAward" name="yearOfAward" placeholder="GRADUATION YEAR"  data-testid="yearOfAward" type="date" className="form-control" aria-invalid="false" value={this.state.yearOfAward} onChange={this.onFormInputChange('yearOfAward')}></input>
                </div>
                <div className="mb-20 row form-group">
                    <div className="col">
                        <input id="courseName" name="courseName" data-testid="courseName" placeholder="COURSE NAME" type="text" className="form-control" aria-invalid="false" value={this.state.courseName} onChange={this.onFormInputChange('courseName')}></input>
                    </div>
                </div>
                <div className="mb-20 row form-group">
                    <div className="col">
                        <input id="qualificationType" name="qualificationType" data-testid="qualificationType" placeholder="QUALIFICATION TYPE" type="text" className="form-control" aria-invalid="false" value={this.state.qualificationType} onChange={this.onFormInputChange('qualificationType')}></input>
                    </div>
                </div>
                <div className="mb-20 row form-group">
                    <div className="col">
                        <input id="classification" name="classification" data-testid="classification" placeholder="CLASSIFICATION TYPE" type="text" className="form-control" aria-invalid="false" value={this.state.classification} onChange={this.onFormInputChange('classification')}></input>
                    </div>
                </div>
                <div className="form-group mb-20 justify-content-center">
                    {/* TODO: needs lable */}
                    <input className="form-control" type="submit" value="Submit" />
                </div>
            </form>
        );
    }
}

export default  CertificationValidationForm;