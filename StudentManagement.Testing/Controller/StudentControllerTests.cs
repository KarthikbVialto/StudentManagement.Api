using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentManagement.Controllers;
using StudentManagement.Models.Domain;
using StudentManagement.Models.Dto;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Testing.Controller
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentRepository> studentRepositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly StudentController studentControllerMock;
        public StudentControllerTests()
        {
            studentRepositoryMock = new Mock<IStudentRepository>();
            mapperMock = new Mock<IMapper>();
            //dbcontext is not needed since we are mocking Repositories
            studentControllerMock = new StudentController(null, studentRepositoryMock.Object, mapperMock.Object);

        }

        [Fact]
        public async Task StudentController_GetAll_ReturnsOk()
        {
            //Arrange
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Karthik",
                    RollNo = "21r21a6273",
                    Email = "21r21a6273@mlrit.ac.in",
                    Address = new Address
                    {
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500072
                    },
                    Department = new Department
                    {
                        Name = "CSE",
                        Specialisation = "CyberSecurity"
                    }
                },

                new Student
                {
                    Id = 2,
                    Name = "Ravi",
                    RollNo = "22r22a7425",
                    Email = "22r22a7425@mlrit.ac.in",
                    Address = new Address
                    {
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500073
                    },
                    Department = new Department
                    {
                        Name = "ECE",
                        Specialisation = "Embedded Systems"
                    }
                }  
            };

            var studentDtos = new List<StudentDto>
            {
                 new StudentDto
                {
                    Name = "Karthik",
                    RollNo = "21r21a6273",
                    Email = "21r21a6273@mlrit.ac.in",
                    Address = new AddressDto
                    {
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500072
                    },
                    Department = new DepartmentDto
                    {
                        Name = "CSE",
                        Specialisation = "CyberSecurity"
                    }
                },

                new StudentDto
                {
                    Name = "Ravi",
                    RollNo = "22r22a7425",
                    Email = "22r22a7425@mlrit.ac.in",
                    Address = new AddressDto
                    {
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500073
                    },
                    Department = new DepartmentDto
                    {
                        Name = "ECE",
                        Specialisation = "Embedded Systems"
                    }
                }
            };
            //this mocks dbcontext getting all student domain models from db
            studentRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(students);
            mapperMock.Setup(m => m.Map<List<StudentDto>>(It.IsAny<List<Student>>())).Returns(studentDtos);

            //Act

            var result = await studentControllerMock.GetAll();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<StudentDto>>(okResult.Value);
            Assert.Equal(studentDtos.Count, returnValue.Count);
        }

        [Fact]
        public async Task StudentController_GetById_ReturnsOk()
        {
            //Arrange
            var student = new Student
            {
                Id = 1,
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new Address
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new Department
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };
            var studentDto = new StudentDto
            {
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new AddressDto
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new DepartmentDto
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };

            studentRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(student);
            mapperMock.Setup(m => m.Map<StudentDto>(student)).Returns(studentDto);
            //Act
            var result = await studentControllerMock.GetById(1);
            //Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<StudentDto>(okResult.Value);
            Assert.Equal("Karthik", resultValue.Name);
        }
        [Fact]
        public async Task StudentController_Create_ReturnOk()
        {
            //Arrange
            var addStudentDto = new AddStudentRequestDto
            {
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new AddressDto
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new DepartmentDto
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };

            var studentDomain = new Student
            {
                Id = 1,
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new Address
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new Department
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };

            mapperMock.Setup(m => m.Map<Student>(addStudentDto)).Returns(studentDomain);
            studentRepositoryMock.Setup(repo => repo.CreateAsync(studentDomain)).ReturnsAsync(studentDomain);
            mapperMock.Setup(m => m.Map<AddStudentRequestDto>(studentDomain)).Returns(addStudentDto);

            //Act
            var result = await studentControllerMock.Create(addStudentDto);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<AddStudentRequestDto>(okResult.Value);
            Assert.Equal("Karthik", resultValue.Name);
        }
        
        [Fact]
        public async Task StudentController_Delete_ReturnsOk()
        {
            //Arrange
            var studentDomain = new Student
            {
                Id = 1,
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new Address
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new Department
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };

            var studentDto = new StudentDto
            {
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new AddressDto
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new DepartmentDto
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };

            studentRepositoryMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(studentDomain);
            mapperMock.Setup(m => m.Map<StudentDto>(studentDomain)).Returns(studentDto);
            //Act
            var result = await studentControllerMock.Delete(1);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<StudentDto>(okResult.Value);
            Assert.Equal("Karthik", resultValue.Name);
        }

        [Fact]
        public async Task StudentController_Update_ReturnOk()
        {
            //Arrange
            var updateStudentDto = new UpdateStudentRequestDto
            {
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new AddressDto
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new DepartmentDto
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };
            var studentDomain = new Student
            {
                Id = 1,
                Name = "Karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new Address
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new Department
                {
                    Name = "CSE",

                }
            };

            var updatedStudentDomain = new Student
            {
                Id = 1,
                Name = "karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new Address
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new Department
                {
                    Name = "CSE",

                }
            };
            var returnStudentDto = new StudentDto
            {
                Name = "karthik",
                RollNo = "21r21a6273",
                Email = "21r21a6273@mlrit.ac.in",
                Address = new AddressDto
                {
                    Country = "India",
                    State = "Telangana",
                    City = "Hyderabad",
                    Zip = 500072
                },
                Department = new DepartmentDto
                {
                    Name = "CSE",
                    Specialisation = "CyberSecurity"
                }
            };

            mapperMock.Setup(m => m.Map<Student>(updateStudentDto)).Returns(studentDomain);
            studentRepositoryMock.Setup(repo => repo.UpdateAsync(1, studentDomain)).ReturnsAsync(updatedStudentDomain);
            mapperMock.Setup(m => m.Map<StudentDto>(updatedStudentDomain)).Returns(returnStudentDto);

            //Act
            var result = await studentControllerMock.Update(1,updateStudentDto);
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<StudentDto>(okResult.Value);
            Assert.Equal(updatedStudentDomain.Name, resultValue.Name);

        }
    }
}
