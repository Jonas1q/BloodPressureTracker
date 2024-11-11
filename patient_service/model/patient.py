from patient_service.app import db


class Patient(db.Model):
    __tablename__ = 'patients'

    ssn = db.Column(db.String(11), primary_key=False)
    mail = db.Column(db.String(128), nullable=False)
    name = db.Column(db.String(100), nullable=False)
    measurements = db.relationship('Measurements', backref='patient', lazy=True)

    def __init__(self, ssn: str, mail: str, name: str):
        self.ssn = ssn
        self.mail = mail
        self.name = name

    def to_dict(self):
        return {
            'ssn': self.ssn,
            'mail': self.mail,
            'name': self.name,
        }

