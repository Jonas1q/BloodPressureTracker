

import pytest
from measurement_service.app import app, db
from measurement_service.Repository.measurement_repository import MeasurementRepository

measurement_repo = MeasurementRepository()

@pytest.fixture
def client():
    with app.test_client() as client:
        with app.app_context():
            db.create_all()
        yield client
        with app.app_context():
            db.drop_all()

def test_add_measurement(client):
    data = {
        "date": "2024-11-10T10:00:00",
        "systolic": 120,
        "diastolic": 80,
        "seen": False
    }
    response = client.post('/measurements', json=data)
    assert response.status_code == 201
