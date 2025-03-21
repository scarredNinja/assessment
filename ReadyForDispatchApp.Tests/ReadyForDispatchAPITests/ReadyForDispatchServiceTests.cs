using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using ReadyForDispatchAPI.Services.ReadyForDispatch;
using ReadyForDispatchAPI.ReadyForDispatch.Models;
using System;

namespace ReadyForDispatchAPI.Tests
{
    [TestFixture]
    public class ReadyForDispatchServiceTests
    {
        private Mock<ILogger<ReadyForDispatchService>> _loggerMock;
        private Mock<IDispatchValidation> _dispatchValidationMock;
        private ReadyForDispatchService _service;

        [SetUp]
        public void SetUp()
        {
            // Arrange: Initialize mocks and the service
            _loggerMock = new Mock<ILogger<ReadyForDispatchService>>();
            _dispatchValidationMock = new Mock<IDispatchValidation>();
            _service = new ReadyForDispatchService(_loggerMock.Object, _dispatchValidationMock.Object);
        }

        [Test]
        public void ProcessDispatchRequest_ValidRequest_LogsInformation()
        {
            // Arrange
            var dispatchRequest = new DispatchRequest(); // Create a valid DispatchRequest

            // Act
            _service.ProcessDispatchRequest(dispatchRequest);

            // Assert: Verify that logging occurs
            _loggerMock.Verify(logger => logger.LogInformation(It.Is<string>(s => s.Contains("Started Processing Dispatch Request"))), Times.Once);
        }

        [Test]
        public void ProcessDispatchRequest_ValidRequest_CallsValidateRequest()
        {
            // Arrange
            var dispatchRequest = new DispatchRequest(); // Create a valid DispatchRequest

            // Act
            _service.ProcessDispatchRequest(dispatchRequest);

            // Assert: Verify that ValidateRequest is called
            _dispatchValidationMock.Verify(validation => validation.ValidateRequest(dispatchRequest), Times.Once);
        }

        [Test]
        public void ProcessDispatchRequest_InvalidRequest_LogsError()
        {
            // Arrange: Set up an invalid request
            var dispatchRequest = new DispatchRequest();
            var exception = new Exception("Validation failed");

            // Mock the ValidateRequest method to throw an exception
            _dispatchValidationMock.Setup(validation => validation.ValidateRequest(dispatchRequest))
                                   .Throws(exception);

            // Act
            _service.ProcessDispatchRequest(dispatchRequest);

            // Assert: Verify that LogError was called with the exception message
            _loggerMock.Verify(logger => logger.LogError(It.Is<string>(s => s.Contains("Exception Thrown:"))), Times.Once);
        }

        [Test]
        public void ProcessDispatchRequest_ThrowsException_LogsError()
        {
            // Arrange: Set up the request and exception for unhandled errors
            var dispatchRequest = new DispatchRequest();
            var exception = new Exception("Unexpected error");

            // Make the ValidateRequest method throw a different exception
            _dispatchValidationMock.Setup(validation => validation.ValidateRequest(dispatchRequest))
                                   .Throws(exception);

            // Act
            _service.ProcessDispatchRequest(dispatchRequest);

            // Assert: Verify that LogError was called with the exception message
            _loggerMock.Verify(logger => logger.LogError(It.Is<string>(s => s.Contains("Exception Thrown:"))), Times.Once);
        }
    }
}
