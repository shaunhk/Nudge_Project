import React from "react";

class CertificationValidationForm extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            enquirytype: "graduated",
            firstName: "",
            lastName: "",
            DOB: "",
            institution: { id: "" },
            yearOfAward: "",
            courseName: "",
            qualificationType: "",
            classification: "",
            documents: []
        }
    }

    getBase64(file, cb) {
        let reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function () {
            cb(reader.result)
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
    }

    onFormInputChange = (name) => (event) => {
        if (name == "institution") {
            this.setState({ institution: { id: event.target.value } })
        } else if (name == "file") {
            let selectedFile = event.target.files[0];
            this.getBase64(selectedFile, (result) => {

                this.state.documents.push(
                    {
                        name: selectedFile.name,
                        type: "consent-form",
                        content: result.split("data:application/pdf;base64,")[1],
                        format: "PDF"
                    }
                )
            });

        } else {
            this.setState({ [name]: event.target.value });
        }
        //console.log(event.target.value);
        //console.log(name)

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
                    <p>Date of Birth</p>
                    <input id="DOB" name="DOB" placeholder="DATE OF BIRTH" data-testid="DOB" type="date" className="form-control" aria-invalid="false" value={this.state.DOB} onChange={this.onFormInputChange('DOB')}></input>
                </div>
                <div className="mb-20 row form-group">
                    <div className="col">
                        <input id="institution" name="institution" data-testid="institution" placeholder="INSTITUTION ID" type="text" className="form-control" aria-invalid="false" value={this.state.institution.id} onChange={this.onFormInputChange('institution')}></input>
                    </div>
                </div>
                <div className="form-group mb-20">
                    {/* TODO: needs lable */}
                    <p>Year Awarded</p>
                    <input id="yearOfAward" name="yearOfAward" placeholder="YEAR AWARDED" data-testid="yearOfAward" type="number" className="form-control" aria-invalid="false" value={this.state.yearOfAward} onChange={this.onFormInputChange('yearOfAward')}></input>
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
                <div className="mb-20 row form-group">
                    <div className="col">
                        <input type="file" name="file" onChange={this.onFormInputChange('file')} />
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

export default CertificationValidationForm;