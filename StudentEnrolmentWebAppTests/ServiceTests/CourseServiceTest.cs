using System.Collections.Generic;
using System.Linq;
using Moq;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.CourseRep;
using StudentEnrolmentWebApp.Services.CourseServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ServiceTests
{
    public class CourseServiceTest
    {
        [Fact]
        public void Get_Courses_OkResult_With_List()
        {
            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(CoursesData.CoursesList());

            var service = new CourseService(mockRepo.Object);
            var result = service.GetAll().Result;

            Assert.IsType(typeof(List<Course>), result);
            Assert.Equal(3, result.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Course_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(CoursesData.OneCourse());

            var service = new CourseService(mockRepo.Object);
            var result = service.GetById(1).Result;

            Assert.IsType(typeof(Course), result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Computer Science Degree", result.Name);
            Assert.Equal("A computer science degree is...", result.Description);
            Assert.Equal(true, result.IsPartFunded);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_Course_Execute()
        {
            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(n => n.Add(It.IsAny<Course>()));

            var service = new CourseService(mockRepo.Object);
            var result = service.Add(new Course()
            {
                Id = 1,
                Name = "Name of the course",
                Description = "Description of the course",
                IsPartFunded = true
            });

            mockRepo.Verify(m => m.Add(It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public void Alter_Course__Execute()
        {
            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<Course>()));

            var controller = new CourseService(mockRepo.Object);
            var result = controller.Update(1, new Course()
            {
                Name = "Name of the course",
                Description = "Description of the course",
                IsPartFunded = true
            });

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public void Delete_Course_Execute()
        {
            var mockRepo = new Mock<ICourseRepository>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new CourseService(mockRepo.Object);
            var result = controller.Remove(1);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
