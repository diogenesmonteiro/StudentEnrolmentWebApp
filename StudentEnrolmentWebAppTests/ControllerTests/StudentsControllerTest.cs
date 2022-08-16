using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEnrolmentWebApp.Controllers;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.StudentServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ControllerTests
{
    public class StudentsControllerTest
    {
        [Fact]
        public void Get_Students_OkResult_With_List()
        {
            var mockRepo = new Mock<IStudentService>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(StudentsData.StudentsList());

            var controller = new StudentsController(mockRepo.Object);
            var result = controller.Get().Result;

            Assert.IsType(typeof(OkObjectResult), result);

            var okObject = result as OkObjectResult;
            var studentsList = okObject.Value as IEnumerable<Student>;

            Assert.Equal(3, studentsList.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Student_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<IStudentService>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(StudentsData.OneStudent());
            
            var controller = new StudentsController(mockRepo.Object);
            var result = controller.Get(1).Result;

            Assert.IsType(typeof(OkObjectResult), result);

            var okObject = result as OkObjectResult;
            var student = okObject.Value as Student;

            Assert.Equal(1, student.Id);
            Assert.Equal("John", student.FirstName);
            Assert.Equal("Smith", student.LastName);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_Student_Status201Created_To_List()
        {
            var mockRepo = new Mock<IStudentService>();
            mockRepo.Setup(n => n.Add(It.IsAny<Student>()));

            var controller = new StudentsController(mockRepo.Object);
            var result = controller.Post(new Student()
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last"
            }).Result;

            Assert.IsType(typeof(StatusCodeResult), result);

            mockRepo.Verify(m => m.Add(It.IsAny<Student>()), Times.Once);
        }

        [Fact]
        public void Alter_Student__OkResultFrom_List()
        {
            var mockRepo = new Mock<IStudentService>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<Student>()));

            var controller = new StudentsController(mockRepo.Object);
            var result = controller.Put(1, new Student()
            {
                FirstName = "First",
                LastName = "Last"
            }).Result;

            Assert.IsType(typeof(OkObjectResult), result);

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<Student>()), Times.Once);
        }

        [Fact]
        public void Delete_Student_OkResult_From_List()
        {
            var mockRepo = new Mock<IStudentService>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new StudentsController(mockRepo.Object);
            var result = controller.Delete(1).Result;

            Assert.IsType(typeof(OkObjectResult), result);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
