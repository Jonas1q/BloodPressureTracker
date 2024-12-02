using Measurement.Models;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace BptTestProject
{
    public class MeasurementTest
    {
        [Fact]
        public async Task PostTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            MeasurementModel measurement = new MeasurementModel
            {
                Id = 1234,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Systolic = 1,
                Diastolic = 1,
                Seen = true
            };

            // Act
            var response = await mockHttpClient.Object.PostAsync("http://localhost:5000", new StringContent(JsonConvert.SerializeObject(measurement)));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            // Act
            var response = await mockHttpClient.Object.GetAsync("http://localhost:5000/1234");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PutTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            MeasurementModel measurement = new MeasurementModel
            {
                Id = 1234,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Systolic = 1,
                Diastolic = 1,
                Seen = true
            };

            // Act
            var response = await mockHttpClient.Object.PutAsync("http://localhost:5000", new StringContent(JsonConvert.SerializeObject(measurement)));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task DeleteTestSuccess()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();

            // Act
            var response = await mockHttpClient.Object.DeleteAsync("http://localhost:5000/1234");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}