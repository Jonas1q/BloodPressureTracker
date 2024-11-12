
from flask import Flask
from flask_sqlalchemy import SQLAlchemy
import os

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = os.getenv('DATABASE_URI', 'sqlite:///measurements.db')
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
db = SQLAlchemy(app)


if not app.debug:
    import logging
    from logging.handlers import RotatingFileHandler
    handler = RotatingFileHandler('errors.log', maxBytes=10000, backupCount=3)
    handler.setLevel(logging.ERROR)
    app.logger.addHandler(handler)

@app.before_first_request
def create_tables():
    db.create_all()

ENABLE_MEASUREMENT_UPDATES = os.getenv("ENABLE_MEASUREMENT_UPDATES", "true") == "true"
ENABLE_PATIENT_CREATION = os.getenv("ENABLE_PATIENT_CREATION", "true") == "true"


import measurement_service.Service.measurement_controller
import patient_service.controller.patient_controller

if __name__ == "__main__":
    app.run()
