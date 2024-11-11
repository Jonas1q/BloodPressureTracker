class Config:
    DEBUG = True
    SQLALCHEMY_DATABASE_URI = 'mysql+pymysql://username:password@localhost/measurement_db'
    SQLALCHEMY_TRACK_MODIFICATIONS = False