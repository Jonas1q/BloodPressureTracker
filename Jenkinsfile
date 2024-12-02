pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0'
    }

    stages {
        stage('Setup') {
            steps {
                script {
                    // Install .NET SDK
                    sh 'wget https://dot.net/v1/dotnet-install.sh'
                    sh 'chmod +x dotnet-install.sh'
                    sh './dotnet-install.sh --version $DOTNET_VERSION'
                    sh 'export PATH=$PATH:$HOME/.dotnet'
                }
            }
        }

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

        stage('Test') {
            steps {
                script {
                    
                    sh 'dotnet test --configuration Release'
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    /
                    sh 'dotnet publish --configuration Release --output ./publish'
                }
            }
        }
    }

    post {
        always {
            
            cleanWs()
        }
    }
}
