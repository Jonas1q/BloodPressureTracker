from patient_service.model.patient import Patient
from patient_service.app import db


class PatientRepository:
    async def add_patient(self, patient_data):
        patient = Patient(**patient_data)
        db.session.add(patient)
        await db.session.commit()
        return patient

    async def get_patient_by_ssn(self, patient_ssn):
        return await Patient.query.filter_by(ssn=patient_ssn).first()
