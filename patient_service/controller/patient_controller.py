from flask import Blueprint, jsonify, request
from patient_service.model.patient import Patient
from patient_service.repository.patient_repository import PatientRepository
from app import app, ENABLE_PATIENT_CREATION

repository = PatientRepository()
patient_controller = Blueprint('patient_controller', __name__)


@patient_controller.route('/patient/get', methods=['GET'])
def get_patient():
    args = request.args

    if 'ssn' not in args:
        return jsonify({'error': 'Missing parameter "SSN"'}), 404

    patient = repository.get_patient_by_ssn(args['ssn'])
    if patient is None:
        return jsonify({'error': 'Patient not found'}), 404

    return jsonify({'patient': patient}), 200


@patient_controller.route('/patients', methods=['POST'])
def add_patient():
    if not ENABLE_PATIENT_CREATION:
        return jsonify({"error": "Feature disabled"}), 503

    try:
        data = request.get_json()
        patient = repository.add_patient(data)
        return jsonify(patient.serialize()), 201
    except Exception as e:
        app.logger.error(f"Failed to add patient: {e}")
        return jsonify({"error": "Could not add patient"}), 500
