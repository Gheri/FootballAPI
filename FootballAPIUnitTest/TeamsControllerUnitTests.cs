using FootballAPI.Controllers;
using FootballAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FootballAPIUnitTest
{
    public class TeamsControllerUnitTests
    {
        [Fact]
        public async void VerifyPostReturnsBadRequestIfModelHasError()
        {
            // Arrange
            var mockTeamDataSource = new Mock<ITeamDataSource>();
            var teamsController = new TeamsController(mockTeamDataSource.Object);
            var teamModel = new TeamModel() { Name = "ABC", Img = "123.png" };
            teamsController.ModelState.AddModelError("error", "error");

            // Act 
            var result = await teamsController.PostTeam(teamModel);

            //Assert
            var actionResult = Assert.IsType<ActionResult<TeamModel>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void VerifyPostReturnsUnprocessableEntityResponseIfTeamNameIsEmpty()
        {
            // Arrange
            var mockTeamDataSource = new Mock<ITeamDataSource>();
            var teamsController = new TeamsController(mockTeamDataSource.Object);
            var teamModel = new TeamModel() { Name = "", Img = "123.png" };
            
            // Act 
            var result = await teamsController.PostTeam(teamModel);

            //Assert
            var actionResult = Assert.IsType<ActionResult<TeamModel>>(result);
            Assert.IsType<UnprocessableEntityObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void VerifyPostReturnsUnprocessableEntityResponseIfTeamNameIsAlreadyPresent()
        {
            // Arrange
            var mockTeamDataSource = new Mock<ITeamDataSource>();
            var teamsController = new TeamsController(mockTeamDataSource.Object);
            var teamModel = new TeamModel() { Name = "ABC", Img = "123.png" };
            mockTeamDataSource.Setup(x => x.GetTeam("ABC")).Returns(teamModel);

            // Act 
            var result = await teamsController.PostTeam(teamModel);

            //Assert
            var actionResult = Assert.IsType<ActionResult<TeamModel>>(result);
            Assert.IsType<UnprocessableEntityObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void VerifyPostReturnsCreatedAtIfSucceed()
        {
            // Arrange
            var mockTeamDataSource = new Mock<ITeamDataSource>();
            var teamsController = new TeamsController(mockTeamDataSource.Object);
            var teamModel = new TeamModel() { Name = "ABC", Img = "123.png" };
            mockTeamDataSource.Setup(x => x.GetTeam("ABC")).Returns((TeamModel)null).Verifiable();
            mockTeamDataSource.Setup(x => x.AddTeam(teamModel)).Verifiable();
            // Act 
            var result = await teamsController.PostTeam(teamModel);

            //Assert
            mockTeamDataSource.Verify();
            var actionResult = Assert.IsType<ActionResult<TeamModel>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<TeamModel>(createdAtActionResult.Value);
            Assert.Equal("ABC", returnValue.Name);

        }
    }
}
