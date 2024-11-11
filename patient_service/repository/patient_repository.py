from patient_service.model.patient import Patient
from patient_service.app import db


class PatientRepository:
    @staticmethod
    def add_patient(self, patient_data):
        patient = Patient(
            ssn=patient_data['ssn'],
            mail=patient_data.get('mail'),
            name=patient_data['name']
        )
        db.session.add(patient)
        db.session.commit()
        return patient

    @staticmethod
    def get_patients(self):
        return Patient.query.all()

    @staticmethod
    def get_patient_by_ssn(self, patient_ssn):
        return Patient.query.filter_by(ssn=patient_ssn).first()
