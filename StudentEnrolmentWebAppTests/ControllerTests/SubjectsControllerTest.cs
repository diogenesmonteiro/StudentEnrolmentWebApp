using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEnrolmentWebApp.Controllers;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.SubjectServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ControllerTests
{
    public class SubjectsControllerTest
    {
        [Fact]
        public void Get_Subjects_OkResult_With_List()
        {
            var mockRepo = new Mock<ISubjectService>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(SubjectsData.SubjectsList());

            var controller = new SubjectsController(mockRepo.Object);
            var result = controller.Get().Result;

            Assert.IsType(typeof(OkObjectResult), result);

            var okObject = result as OkObjectResult;
            var subjectsList = okObject.Value as IEnumerable<Subject>;

            Assert.Equal(3, subjectsList.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_Subject_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ISubjectService>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(SubjectsData.OneSubject());

            var controller = new SubjectsController(mockRepo.Object);
            var result = controller.Get(1).Result;

            Assert.IsType(typeof(OkObjectResult), result);

            var okObject = result as OkObjectResult;
            var subject = okObject.Value as Subject;

            Assert.Equal(1, subject.Id);
            Assert.Equal("Law and Resistance", subject.Name);
            Assert.Equal("This course will explore...", subject.Description);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_Subject_Status201Created_To_List()
        {
            var mockRepo = new Mock<ISubjectService>();
            mockRepo.Setup(n => n.Add(It.IsAny<Subject>()));

            var controller = new SubjectsController(mockRepo.Object);
            var result = controller.Post(new Subject()
            {
                Id = 1,
                Name = "Name of the subject",
                Description = "Description of the subject"
            }).Result;

            Assert.IsType(typeof(StatusCodeResult), result);

            mockRepo.Verify(m => m.Add(It.IsAny<Subject>()), Times.Once);
        }

        [Fact]
        public void Alter_Subject__OkResultFrom_List()
        {
            var mockRepo = new Mock<ISubjectService>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<Subject>()));

            var controller = new SubjectsController(mockRepo.Object);
            var result = controller.Put(1, new Subject()
            {
                Name = "Name of the subject",
                Description = "Description of the subject"
            }).Result;

            Assert.IsType(typeof(OkObjectResult), result);

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<Subject>()), Times.Once);
        }

        [Fact]
        public void Delete_Subject_OkResult_From_List()
        {
            var mockRepo = new Mock<ISubjectService>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new SubjectsController(mockRepo.Object);
            var result = controller.Delete(1).Result;

            Assert.IsType(typeof(OkObjectResult), result);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
