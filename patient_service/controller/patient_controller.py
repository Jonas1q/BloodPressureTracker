from flask import Blueprint, jsonify, request
from patient_service.model.patient import Patient
from patient_service.repository.patient_repository import PatientRepository

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


@patient_controller.route('/patient/post', methods=['POST'])
def post_patient():
    args = request.args

    try:
        patient = Patient(
            ssn=args['ssn'],
            mail=args['mail'],
            name=args['name'],
        )

        repository.add_patient(patient)
        return jsonify({'patient': patient}), 200
    except Exception as e:
        return jsonify({'error': 'Patient not found'}), 404
