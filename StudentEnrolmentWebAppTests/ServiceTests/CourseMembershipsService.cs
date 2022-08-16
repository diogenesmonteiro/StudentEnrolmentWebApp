using System.Collections.Generic;
using System.Linq;
using Moq;
using StudentEnrolmentWebApp.Domain.Models;
using StudentEnrolmentWebApp.Infrastructure.CourseMembershipRep;
using StudentEnrolmentWebApp.Services.CourseMembershipsServices;
using StudentEnrolmentWebApp.Tests.MockData;
using Xunit;

namespace StudentEnrolmentWebApp.Tests.ServiceTests
{
    public class CourseMembershipsServiceTest
    {
        [Fact]
        public void Get_CourseMemberships_OkResult_With_List()
        {
            var mockRepo = new Mock<ICourseMembershipRepository>();
            mockRepo.Setup(n => n.GetAll()).ReturnsAsync(CourseMembershipsData.CourseMembershipsList());

            var service = new CourseMembershipsService(mockRepo.Object);
            var result = service.GetAll().Result;

            Assert.IsType<List<CourseMembership>>(result);
            Assert.Equal(3, result.Count());

            mockRepo.Verify(m => m.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_CourseMembership_By_Id_OkResult_From_List()
        {
            var mockRepo = new Mock<ICourseMembershipRepository>();
            mockRepo.Setup(n => n.GetById(It.IsAny<int>())).ReturnsAsync(CourseMembershipsData.OneCourseMembership());

            var service = new CourseMembershipsService(mockRepo.Object);
            var result = service.GetById(1).Result;

            Assert.IsType<CourseMembership>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(5, result.StudentId);
            Assert.Equal(2, result.CourseId);

            mockRepo.Verify(m => m.GetById(1), Times.Once);
        }

        [Fact]
        public void Add_CourseMembership_Execute()
        {
            var mockRepo = new Mock<ICourseMembershipRepository>();
            mockRepo.Setup(n => n.Add(It.IsAny<CourseMembership>()));

            var service = new CourseMembershipsService(mockRepo.Object);
            var result = service.Add(new CourseMembership()
            {
                Id = 1,
                StudentId = 5,
                CourseId = 7
            });

            mockRepo.Verify(m => m.Add(It.IsAny<CourseMembership>()), Times.Once);
        }

        [Fact]
        public void Alter_CourseMembership__Execute()
        {
            var mockRepo = new Mock<ICourseMembershipRepository>();
            mockRepo.Setup(n => n.Update(It.IsAny<int>(), It.IsAny<CourseMembership>()));

            var controller = new CourseMembershipsService(mockRepo.Object);
            var result = controller.Update(1, new CourseMembership()
            {
                StudentId = 5,
                CourseId = 7
            });

            mockRepo.Verify(m => m.Update(It.IsAny<int>(), It.IsAny<CourseMembership>()), Times.Once);
        }

        [Fact]
        public void Delete_CourseMembership_Execute()
        {
            var mockRepo = new Mock<ICourseMembershipRepository>();
            mockRepo.Setup(n => n.Remove(It.IsAny<int>()));

            var controller = new CourseMembershipsService(mockRepo.Object);
            var result = controller.Remove(1);

            mockRepo.Verify(m => m.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
