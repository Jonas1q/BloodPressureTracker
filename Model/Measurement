from app import db
from datetime import datetime

class Measurements(db.Model):
    __tablename__ = 'measurements'

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.DateTime, default=datetime)
    systolic = db.Column(db.Integer, nullable=False)
    diastolic = db.Column(db.Integer, nullable=False)
    seen = db.Column(db.Boolean, default=False)
    patient_ssn = db.Column(db.String(11), db.ForeignKey('patients.ssn'), nullable=False)

    def __init__(self, date, systolic, diastolic, seen, patient_ssn):
        
        self.date = date
        self.systolic = systolic
        self.diastolic = diastolic
        self.seen = seen
        self.patient_ssn = patient_ssn

    def to_dict(self):
        return {
            'id': self.id,
            'date': self.date.isoformat(),
            'systolic': self.systolic,
            'diastolic': self.diastolic,
            'seen': self.seen,
            'patient_ssn': self.patient_ssn
        }
