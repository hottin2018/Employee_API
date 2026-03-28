using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_API.Repositories;
using Employee_API.Controllers;
using Employee_API.Services;
using Employee_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TestEmployeeAPI
{
    public class EmployeeControolerTests
    {
        private readonly Mock<IEmployeeService> _mockEmployeeService = new Mock<IEmployeeService>();
        private readonly EmployeesController _controller;
        public EmployeeControolerTests()
        {
            _controller = new EmployeesController(_mockEmployeeService.Object);
        }

        [Fact]
        public async Task GetAllEmployees_ReturnsOK_WithEmplloyees()
        {
            // Arrange
            var expectedEmployees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Som", Age = 53 },
                new Employee { Id = 2, Name = "Bhavana", Age = 18 }
            };

            // Setup mock to return Task<List<Employee>>
            _mockEmployeeService
                .Setup(s => s.GetEmployeesAsync())
                .ReturnsAsync(expectedEmployees);

            // Act
            var result = await _controller.GetAllEmployees();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualEmployees = Assert.IsType<List<Employee>>(okResult.Value);
            Assert.Equal(expectedEmployees, actualEmployees);
        }
        [Fact]
        public async Task GetEmployeeById_returnsOK_WithEmployee()
        {
            //Arrange
            var expectedEmployee = new Employee { Id=1, Name="Som",Age=53};
            _mockEmployeeService.Setup(s => s.GetEmploeeById(1)).ReturnsAsync(expectedEmployee);
            //Act
            var result = await _controller.GetEmployeeById(1);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualEmployee = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(expectedEmployee.Id, actualEmployee.Id);
        }
        [Fact]
        public async Task GetEmployeeById_ReturnsNotFound_WhenEmployeeNotFound()
        {
            //Arrange
            // Return a Task<Employee> that contains null while matching the non-nullable Task<Employee> signature.
            _mockEmployeeService
                .Setup(s => s.GetEmploeeById(It.IsAny<int>()))
                .Returns(Task.FromResult<Employee>(null!));
            //Act
            var result = await _controller.GetEmployeeById(999);
            //Assert
            //Assert.IsType<NotFoundResult>(result);
            Assert.IsType<NotFoundResult>(result);
        }

    }
}