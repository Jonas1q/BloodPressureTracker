from flask import Blueprint, jsonify, request
from Repository import measurement_repository

repository = measurement_repository()
measurement_controller = Blueprint('measurement_controller', __name__)

@measurement_controller.route('/measurements', methods=['POST'])
def create_measurement():
    data = request.json
    measurement = repository.add_measurement(data)
    return jsonify({'message': 'Measurement created', 'measurement': measurement.to_dict()}), 201

@measurement_controller.route('/measurements', methods=['GET'])
def get_measurements():
    measurements = repository.get_measurements()
    return jsonify([m.to_dict() for m in measurements])

@measurement_controller.route('/measurements/<int:measurement_id>', methods=['GET'])
def get_measurement(measurement_id):
    measurement = repository.get_measurement_by_id(measurement_id)
    if measurement:
        return jsonify(measurement.to_dict())
    return jsonify({'error': 'Measurement not found'}), 404

@measurement_controller.route('/measurements/<int:measurement_id>', methods=['DELETE'])
def delete_measurement(measurement_id):
    if repository.delete_measurement(measurement_id):
        return jsonify({'message': 'Measurement deleted'})
    return jsonify({'error': 'Measurement not found'}), 404

@measurement_controller.route('/measurements/<int:measurement_id>', methods=['PUT'])
def update_measurement(measurement_id):
    data = request.json
    measurement = repository.update_measurement(measurement_id, data)
    if measurement:
        return jsonify({'message': 'Measurement updated', 'measurement': measurement.to_dict()})
    return jsonify({'error': 'Measurement not found'}), 404
