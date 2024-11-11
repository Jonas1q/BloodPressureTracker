from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from config import Config
from Service import measurement_controller
from Model import Measurements

app = Flask(__name__)
app.config.from_object(Config)


db = SQLAlchemy(app)


app.register_blueprint(measurement_controller)



if __name__ == '__main__':
    app.run(debug=True)
