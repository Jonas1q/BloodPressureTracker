from Model.measurement import Measurements
from app import db

class MeasurementRepository:
    async def add_measurement(self, measurement_data):
        measurement = Measurements(**measurement_data)
        db.session.add(measurement)
        await db.session.commit()
        return measurement

    async def update_measurement(self, measurement_id, measurement_data):
        measurement = await Measurements.query.get(measurement_id)
        if measurement:
            measurement.date = measurement_data.get('date', measurement.date)
            measurement.systolic = measurement_data.get('systolic', measurement.systolic)
            measurement.diastolic = measurement_data.get('diastolic', measurement.diastolic)
            measurement.seen = measurement_data.get('seen', measurement.seen)
            await db.session.commit()
        return measurement
