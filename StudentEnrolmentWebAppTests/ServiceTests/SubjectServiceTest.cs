using System.Collections.Generic;
using System.Linq;
using Moq;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.SubjectRep;
using StudentEnrolmentWebApp.Services.SubjectServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ServiceTests
{
    public class SubjectServiceTest
    {
        [Fact]
        public void Get_Subjects_OkResult_With_List()
        {
            var mockRepo = new Mock<ISubjectRepository>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(SubjectsData.SubjectsList());

            var service = new SubjectService(mockRepo.Object);
            var result = service.GetAll().Result;

            Assert.IsType(typeof(List<Subject>), result);
            Assert.Equal(3, result.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Subject_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ISubjectRepository>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(SubjectsData.OneSubject());

            var service = new SubjectService(mockRepo.Object);
            var result = service.GetById(1).Result;

            Assert.IsType(typeof(Subject), result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Law and Resistance", result.Name);
            Assert.Equal("This course will explore...", result.Description);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_Subject_Execute()
        {
            var mockRepo = new Mock<ISubjectRepository>();
            mockRepo.Setup(n => n.Add(It.IsAny<Subject>()));

            var service = new SubjectService(mockRepo.Object);
            var result = service.Add(new Subject()
            {
                Id = 1,
                Name = "Name of the course subject",
                Description = "Description of the Subject"
            });

            mockRepo.Verify(m => m.Add(It.IsAny<Subject>()), Times.Once);
        }

        [Fact]
        public void Alter_Course__Execute()
        {
            var mockRepo = new Mock<ISubjectRepository>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<Subject>()));

            var controller = new SubjectService(mockRepo.Object);
            var result = controller.Update(1, new Subject()
            {
                Name = "Name of the subject",
                Description = "Description of the subject"
            });

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<Subject>()), Times.Once);
        }

        [Fact]
        public void Delete_Subject_Execute()
        {
            var mockRepo = new Mock<ISubjectRepository>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new SubjectService(mockRepo.Object);
            var result = controller.Remove(1);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
