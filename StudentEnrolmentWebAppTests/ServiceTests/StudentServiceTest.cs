using System.Collections.Generic;
using System.Linq;
using Moq;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.StudentRep;
using StudentEnrolmentWebApp.Services.StudentServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ServiceTests
{
    public class StudentServiceTest
    {
        [Fact]
        public void Get_Students_OkResult_With_List()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(StudentsData.StudentsList());

            var service = new StudentService(mockRepo.Object);
            var result = service.GetAll().Result;

            Assert.IsType<List<Student>>(result);
            Assert.Equal(3, result.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Student_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(StudentsData.OneStudent());

            var service = new StudentService(mockRepo.Object);
            var result = service.GetById(1).Result;

            Assert.IsType<Student>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Smith", result.LastName);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_Student_Execute()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(n => n.Add(It.IsAny<Student>()));

            var service = new StudentService(mockRepo.Object);
            var result = service.Add(new Student()
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last"
            });

            mockRepo.Verify(m => m.Add(It.IsAny<Student>()), Times.Once);
        }

        [Fact]
        public void Alter_Student__Execute()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<Student>()));

            var controller = new StudentService(mockRepo.Object);
            var result = controller.Update(1, new Student()
            {
                FirstName = "First",
                LastName = "Last"
            });

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<Student>()), Times.Once);
        }

        [Fact]
        public void Delete_Student_Execute()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new StudentService(mockRepo.Object);
            var result = controller.Remove(1);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
