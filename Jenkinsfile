pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0'
    }

    stages {
        stage('Restore') {
            steps {
                script {
                    
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                script {
                    
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        /*stage('Test') {
            steps {
                script {
                    
                    sh 'dotnet test --configuration Release'
                }
            }
        }*/
    }

    post {
        always {
            
            cleanWs()
        }
    }
}
