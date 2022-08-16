using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEnrolmentWebApp.Controllers;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Services.CourseMembershipsServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ControllerTests
{
    public class CourseMembershipsControllerTest
    {
        [Fact]
        public void Get_CourseMemberships_OkResult_With_List()
        {
            var mockRepo = new Mock<ICourseMembershipsService>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(CourseMembershipsData.CourseMembershipsList());

            var controller = new CourseMembershipsController(mockRepo.Object);
            var result = controller.Get().Result;

            Assert.IsType<OkObjectResult>(result);

            var okObject = result as OkObjectResult;
            var courseMembershipsList = okObject.Value as IEnumerable<CourseMembership>;

            Assert.Equal(3, courseMembershipsList.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_CourseMembership_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseMembershipsService>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(CourseMembershipsData.OneCourseMembership());

            var controller = new CourseMembershipsController(mockRepo.Object);
            var result = controller.Get(1).Result;

            Assert.IsType<OkObjectResult>(result);

            var okObject = result as OkObjectResult;
            var courseMembership = okObject.Value as CourseMembership;

            Assert.Equal(1, courseMembership.Id);
            Assert.Equal(5, courseMembership.StudentId);
            Assert.Equal(2, courseMembership.CourseId);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_CourseMembership_Status201Created_To_List()
        {
            var mockRepo = new Mock<ICourseMembershipsService>();
            mockRepo.Setup(n => n.Add(It.IsAny<CourseMembership>()));

            var controller = new CourseMembershipsController(mockRepo.Object);
            var result = controller.Post(new CourseMembership()
            {
                Id = 1,
                StudentId = 5,
                CourseId = 2
            }).Result;

            Assert.IsType<StatusCodeResult>(result);

            mockRepo.Verify(m => m.Add(It.IsAny<CourseMembership>()), Times.Once);
        }

        [Fact]
        public void Alter_Student__OkResultFrom_List()
        {
            var mockRepo = new Mock<ICourseMembershipsService>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<CourseMembership>()));

            var controller = new CourseMembershipsController(mockRepo.Object);
            var result = controller.Put(1, new CourseMembership()
            {
                StudentId = 5,
                CourseId = 2
            }).Result;

            Assert.IsType<OkObjectResult>(result);

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<CourseMembership>()), Times.Once);
        }

        [Fact]
        public void Delete_CourseMembership_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseMembershipsService>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new CourseMembershipsController(mockRepo.Object);
            var result = controller.Delete(1).Result;

            Assert.IsType<OkObjectResult>(result);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
