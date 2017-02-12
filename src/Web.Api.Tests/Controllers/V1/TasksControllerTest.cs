using Data;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Web.Http;
using Web.Api.Controllers.V1;
using Web.Api.Models;

namespace Web.Api.Tests.Controllers.V1
{
    [TestFixture]
    public class TasksControllerTest
    {
        private TasksControllerDependencyBlockMock _mockBlock;
        private TasksController _controller;
       

        [SetUp]
        public void SetUp()
        {
            _mockBlock = new TasksControllerDependencyBlockMock();
            _controller = new TasksController(_mockBlock.Object);
        }


        public HttpRequestMessage CreateRequestMessage(HttpMethod method = null, string uriString = null)
        {
            method = method ?? HttpMethod.Get;

            var uri = string.IsNullOrWhiteSpace(uriString) ? new Uri("http://localhost:12345/api/whatever") : new Uri(uriString);

            var requestMessage = new HttpRequestMessage(method, uri);

            requestMessage.SetConfiguration(new HttpConfiguration());

            return requestMessage;
        }


        [Test]
        public void GetTasks_returns_correct_response()
        {
            // Arrange
            var requestMessage = HttpRequestMessageFactory.CreateRequestMessage();
            var request = new PagedDataRequest(1, 25);
            var response = new PagedDataInquiryResponse<Task>();

            _mockBlock.PagedDataRequestFactoryMock.Setup(x => x.Create(requestMessage.RequestUri)).Returns(request);
            _mockBlock.AllTasksInquiryProcessorMock.Setup(x => x.GetTasks(request)).Returns(response);

            // Act
            var actualResponse = _controller.GetTasks(requestMessage);

            // Assert
            Assert.AreSame(response, actualResponse);
        }
    }
}
