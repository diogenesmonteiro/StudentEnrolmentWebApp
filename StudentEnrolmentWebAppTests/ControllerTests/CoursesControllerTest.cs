using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEnrolmentWebApp.Controllers;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.CourseServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ControllerTests
{
    public class CoursesControllerTest
    {
        [Fact]
        public void Get_Courses_OkResult_With_List()
        {
            var mockRepo = new Mock<ICourseService>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(CoursesData.CoursesList);

            var controller = new CoursesController(mockRepo.Object);
            var result = controller.Get().Result;

            Assert.IsType<OkObjectResult>(result);

            var okObject = result as OkObjectResult;
            var coursesList = okObject.Value as IEnumerable<Course>;

            Assert.Equal(3, coursesList.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Course_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseService>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(CoursesData.OneCourse());

            var controller = new CoursesController(mockRepo.Object);
            var result = controller.Get(1).Result;

            Assert.IsType<OkObjectResult>(result);

            var okObject = result as OkObjectResult;
            var course = okObject.Value as Course;

            Assert.Equal(1, course.Id);
            Assert.Equal("Computer Science Degree", course.Name);
            Assert.Equal("A computer science degree is...", course.Description);
            Assert.True(course.IsPartFunded);
            
            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_Course_Status201Created_To_List()
        {
            var mockRepo = new Mock<ICourseService>();
            mockRepo.Setup(n => n.Add(It.IsAny<Course>()));

            var controller = new CoursesController(mockRepo.Object);
            var result = controller.Post(new Course()
            {
                Id = 1,
                Name = "Name of the course",
                Description = "Description of the course",
                IsPartFunded = true
            }).Result;

            Assert.IsType<StatusCodeResult>(result);

            mockRepo.Verify(m => m.Add(It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public void Alter_Course__OkResultFrom_List()
        {
            var mockRepo = new Mock<ICourseService>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<Course>()));

            var controller = new CoursesController(mockRepo.Object);
            var result = controller.Put(1, new Course()
            {
                Name = "Name of the course",
                Description = "Description of the course",
                IsPartFunded = true
            }).Result;

            Assert.IsType<OkObjectResult>(result);

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<Course>()), Times.Once);
        }

        [Fact]
        public void Delete_Course_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseService>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new CoursesController(mockRepo.Object);
            var result = controller.Delete(1).Result;

            Assert.IsType<OkObjectResult>(result);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
