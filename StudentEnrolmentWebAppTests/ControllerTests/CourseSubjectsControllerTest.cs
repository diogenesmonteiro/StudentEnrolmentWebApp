using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEnrolmentWebApp.Controllers;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.CourseSubjectsServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ControllerTests
{
    public class CourseSubjectsControllerTest
    {
        [Fact]
        public void Get_CourseSubjects_OkResult_With_List()
        {
            var mockRepo = new Mock<ICourseSubjectsService>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(CourseSubjectsData.CourseSubjectsList());

            var controller = new CourseSubjectsController(mockRepo.Object);
            var result = controller.Get().Result;

            Assert.IsType<OkObjectResult>(result);

            var okObject = result as OkObjectResult;
            var courseSubjectsList = okObject.Value as IEnumerable<CourseSubject>;

            Assert.Equal(3, courseSubjectsList.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_CourseSubject_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseSubjectsService>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(CourseSubjectsData.OneCourseSubject());

            var controller = new CourseSubjectsController(mockRepo.Object);
            var result = controller.Get(1).Result;

            Assert.IsType<OkObjectResult>(result);

            var okObject = result as OkObjectResult;
            var courseSubject = okObject.Value as CourseSubject;

            Assert.Equal(1, courseSubject.Id);
            Assert.Equal(2, courseSubject.CourseId);
            Assert.Equal(7, courseSubject.SubjectId);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_CourseSubject_Status201Created_To_List()
        {
            var mockRepo = new Mock<ICourseSubjectsService>();
            mockRepo.Setup(n => n.Add(It.IsAny<CourseSubject>()));

            var controller = new CourseSubjectsController(mockRepo.Object);
            var result = controller.Post(new CourseSubject()
            {
                Id = 1,
                CourseId = 2,
                SubjectId = 7
            }).Result;

            Assert.IsType<StatusCodeResult>(result);

            mockRepo.Verify(m => m.Add(It.IsAny<CourseSubject>()), Times.Once);
        }

        [Fact]
        public void Alter_CourseSubject__OkResultFrom_List()
        {
            var mockRepo = new Mock<ICourseSubjectsService>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<CourseSubject>()));

            var controller = new CourseSubjectsController(mockRepo.Object);
            var result = controller.Put(1, new CourseSubject()
            {
                CourseId = 2,
                SubjectId = 7
            }).Result;

            Assert.IsType<OkObjectResult>(result);

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<CourseSubject>()), Times.Once);
        }

        [Fact]
        public void Delete_CourseSubject_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseSubjectsService>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new CourseSubjectsController(mockRepo.Object);
            var result = controller.Delete(1).Result;

            Assert.IsType<OkObjectResult>(result);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
