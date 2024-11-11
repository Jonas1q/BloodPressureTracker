from flask import Flask, request
from flask_sqlalchemy import SQLAlchemy
from config import Config
from patient_service.controller import patient_controller

# Initialize app
app = Flask(__name__)
app.config.from_object(Config)

db = SQLAlchemy(app)

app.register_blueprint(patient_controller)

# Run app
if __name__ == '__main__':
    app.run(debug=True)
