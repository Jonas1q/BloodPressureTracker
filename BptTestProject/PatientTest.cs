using Patient.Models;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace BptTestProject
{
    public class PatientTest
    {
        [Fact]
        public async Task PostTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            PatientModel patient = new PatientModel
            {
                SSN = "1234",
                Mail = "Test@Test.com",
                Name = "Test",
            };

            // Act
            var response = await mockHttpClient.Object.PostAsync("http://localhost:5002", new StringContent(JsonConvert.SerializeObject(patient)));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            // Act
            var response = await mockHttpClient.Object.GetAsync("http://localhost:5002/1234");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PutTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            PatientModel patient = new PatientModel
            {
                SSN = "1234",
                Mail = "Test@Test.com",
                Name = "Test",
            };

            // Act
            var response = await mockHttpClient.Object.PutAsync("http://localhost:5002", new StringContent(JsonConvert.SerializeObject(patient)));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task DeleteTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            // Act
            var response = await mockHttpClient.Object.DeleteAsync("http://localhost:5002/1234");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}