using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace assessment.ReadyForDispatchApp.Tests
{
    [TestFixture]
    public class ReadyForDispatchAppTests
    {
        private Mock<ILogger<ReadyForDispatchApp>> _loggerMock;
        private Mock<HttpClient> _httpClientMock;
        private ReadyForDispatchApp _functionApp;

        [SetUp]
        public void SetUp()
        {
            // Arrange: Initialize mocks and the function
            _loggerMock = new Mock<ILogger<ReadyForDispatchApp>>();
            _httpClientMock = new Mock<HttpClient>();
            _functionApp = new ReadyForDispatchApp(_loggerMock.Object, _httpClientMock.Object);
        }

        [Test]
        public async Task PostDispatchRequest_ValidRequest_ReturnsOkObjectResult()
        {
            // Arrange
            var mockRequestData = new Mock<HttpRequestData>();
            var context = new Mock<FunctionContext>();
            var requestBody = "{\"input\": \"valid input\"}";
            
            // Mock the behavior of HttpRequestData
            mockRequestData.Setup(req => req.ReadAsStringAsync()).ReturnsAsync(requestBody);

            // Mock the behavior of HttpClient's GetAsync method
            var mockHttpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"result\": \"success\"}", Encoding.UTF8, "application/json")
            };

            _httpClientMock.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync(mockHttpResponse);

            // Act
            var result = await _functionApp.PostDispatchRequest(mockRequestData.Object, context.Object);

            // Assert: Verify that the result is an OkObjectResult with the expected response body
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual("{\"result\": \"success\"}", okResult.Value);
        }

        [Test]
        public async Task PostDispatchRequest_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange: Simulate a request with an invalid body
            var mockRequestData = new Mock<HttpRequestData>();
            var context = new Mock<FunctionContext>();
            var requestBody = "{\"wrongField\": \"invalid input\"}";
            
            // Mock the behavior of HttpRequestData
            mockRequestData.Setup(req => req.ReadAsStringAsync()).ReturnsAsync(requestBody);

            // Act
            var result = await _functionApp.PostDispatchRequest(mockRequestData.Object, context.Object);

            // Assert: Verify that the result is not an OkObjectResult
            Assert.IsNotInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task PostDispatchRequest_ApiCallFails_LogsError()
        {
            // Arrange: Simulate an error when calling the API
            var mockRequestData = new Mock<HttpRequestData>();
            var context = new Mock<FunctionContext>();
            var requestBody = "{\"input\": \"valid input\"}";
            
            // Mock the behavior of HttpRequestData
            mockRequestData.Setup(req => req.ReadAsStringAsync()).ReturnsAsync(requestBody);

            // Mock HttpClient to simulate an error response
            var mockHttpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Error")
            };

            _httpClientMock.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync(mockHttpResponse);

            // Act
            var result = await _functionApp.PostDispatchRequest(mockRequestData.Object, context.Object);

            // Assert: Verify that logging occurred
            _loggerMock.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once); // Check for logging info
            _loggerMock.Verify(logger => logger.LogError(It.Is<string>(s => s.Contains("Error"))), Times.Once); // Check for logging error
        }
    }
}