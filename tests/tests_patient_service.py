

import pytest
from patient_service.app import app, db
from patient_service.repository.patient_repository import PatientRepository
from patient_service.model.patient import Patient

patient_repo = PatientRepository()

@pytest.fixture
def client():
    with app.test_client() as client:
        with app.app_context():
            db.create_all()
        yield client
        with app.app_context():
            db.drop_all()

def test_add_patient(client):
    patient_data = {
        "ssn": "123-45-6789",
        "name": "John Doe",
        "mail": "test@test.test"
    }
    new_patient = patient_repo.add_patient(patient_data)
    
    assert new_patient.ssn == patient_data["ssn"]
    assert new_patient.name == patient_data["name"]
    assert new_patient.mail == patient_data["mail"]

def test_get_patient_by_ssn(client):
    patient_data = {
        "ssn": "123-45-6789",
        "name": "Jane Doe",
        "mail": "test@test.test"
    }
    patient_repo.add_patient(patient_data)

    retrieved_patient = patient_repo.get_patient_by_ssn(patient_data["ssn"])
    
    assert retrieved_patient is not None
    assert retrieved_patient.ssn == patient_data["ssn"]
    assert retrieved_patient.name == patient_data["name"]
    assert retrieved_patient.mail == patient_data["mail"]
