using System.Collections.Generic;
using System.Linq;
using Moq;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.CourseSubjectsRep;
using StudentEnrolmentWebApp.Services.CourseSubjectsServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ServiceTests
{
    public class CourseSubjectsServiceTest
    {
        [Fact]
        public void Get_CourseSubjects_OkResult_With_List()
        {
            var mockRepo = new Mock<ICourseSubjectsRepository>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(CourseSubjectsData.CourseSubjectsList());

            var service = new CourseSubjectsService(mockRepo.Object);
            var result = service.GetAll().Result;

            Assert.IsType(typeof(List<CourseSubject>), result);
            Assert.Equal(3, result.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_CourseSubject_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseSubjectsRepository>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(CourseSubjectsData.OneCourseSubject());

            var service = new CourseSubjectsService(mockRepo.Object);
            var result = service.GetById(1).Result;

            Assert.IsType(typeof(CourseSubject), result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.CourseId);
            Assert.Equal(7, result.SubjectId);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_CourseSubject_Execute()
        {
            var mockRepo = new Mock<ICourseSubjectsRepository>();
            mockRepo.Setup(n => n.Add(It.IsAny<CourseSubject>()));

            var service = new CourseSubjectsService(mockRepo.Object);
            var result = service.Add(new CourseSubject()
            {
                Id = 1,
                CourseId = 2,
                SubjectId = 7
            });

            mockRepo.Verify(m => m.Add(It.IsAny<CourseSubject>()), Times.Once);
        }

        [Fact]
        public void Alter_CourseSubject__Execute()
        {
            var mockRepo = new Mock<ICourseSubjectsRepository>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<CourseSubject>()));

            var controller = new CourseSubjectsService(mockRepo.Object);
            var result = controller.Update(1, new CourseSubject()
            {
                CourseId = 2,
                SubjectId = 7
            });

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<CourseSubject>()), Times.Once);
        }

        [Fact]
        public void Delete_CourseSubject_Execute()
        {
            var mockRepo = new Mock<ICourseSubjectsRepository>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new CourseSubjectsService(mockRepo.Object);
            var result = controller.Remove(1);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
