using System;
using Xunit;
using WebAPI.Models;
using WebAPI.Controllers;
using System.Collections.Generic;
using WebAPI.Interfaces;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using FluentAssertions;
using System.Linq;

namespace TestProject
{
    public class UsersControllerTest 
    {

        public UsersControllerTest()
        {
        }
        [Fact]
        public async Task GetuUsers_List_True()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.GetUsers();

            // Assert
            Assert.Equal(result.Value.Count(), 3);
        }

        [Fact]
        public async Task GetUserById_ExistingOne_True()
        {

            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.GetUserById(4);

            // Assert
            Assert.Equal("test2", result.Value.AppNickname);
        }

        [Fact]
        public async Task GetUserById_NoExistignOne_NotFound()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.GetUserById(100);

            //Assert
            Assert.IsAssignableFrom<NotFoundResult>(result.Result);

        }
        [Fact]
        public async Task GetUserByNickname_NoExistignOne_NotFound()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.GetUserByNickname("EmptyUser");

            //Assert
            Assert.IsAssignableFrom<NotFoundResult>(result.Result);

        }
        [Fact]
        public async Task GetUserByNickname_ExistingOne_True()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.GetUserByNickname("test3");

            // Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(2, model.Count());

            Assert.Equal("test3", result.Value.AppNickname);
        }
    

        [Fact]
        public async Task CreateNewUserByNickname_ExistingNickname_CreatedAtAction()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.CreateNewUserByNickname("test2");

            // Assert
            var okResult = result.Result.Should().BeOfType<ObjectResult>().Subject;

        }
        [Fact]
        public async Task ValidateUserGithub_ExistingOne_True()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.ValidateUserGithub(5);

            // Assert
            Assert.True(result.Value);
        }
        [Fact]
        public async Task ValidateUserGithub_NoIdToken_False()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.ValidateUserGithub(7);

            // Assert

            Assert.False(result.Value);
        }
        [Fact]
        public async Task ValidateUserGithub_WrongUserId_NotFound()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.ValidateUserGithub(12);

            // Assert

            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task ValidateUserDiscord_ExistingOne_True()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.ValidateUserDiscord(4);

            // Assert
        

            Assert.True(result.Value);
        }
        [Fact]
        public async Task ValidateUserDiscord_NoIdToken_False()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.ValidateUserDiscord(5);

            // Assert

            Assert.False(result.Value);
        }
        [Fact]
        public async Task ValidateUserDiscord_WrongUserId_NotFound()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.ValidateUserDiscord(12);

            // Assert

            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task UpdateUserToken_WrongUserId_False()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

  
            // Act &&Assert
            Assert.ThrowsAnyAsync<DbUpdateConcurrencyException>(async ()=> await controller.UpdateUserToken(55, 1, 12));
        }
        [Fact]
        public async Task UpdateUserToken_CorrectUserId_NoContent()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());

            // Act
            var result = await controller.UpdateUserToken(4, 1, 12);

            // Assert
            Assert.IsAssignableFrom<NoContentResult>(result);
        }


        //Theory
        [Theory]
        [MemberData(nameof(TestPostUser_Data_Correct))]
        public async Task PostUser_CorrectData_True(int DiscordTokenId, int GithubTokenId, string AppNickname, string Password)
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());
            PostUserDto user = new PostUserDto
            {
                DiscordTokenId = DiscordTokenId,
                GithubTokenId = GithubTokenId,
                AppNickname = AppNickname,
                Password = Password,
            };

            //Arrange 
            var result = await controller.PostUser(user);


            //Assert
            var okResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;

            var userCreated = okResult.Value.Should().BeAssignableTo<PostUserDto>().Subject;
            userCreated.AppNickname.Should().Be(AppNickname);
        }

        [Theory]
        [MemberData(nameof(TestPostUser_Data_Wrong))]
        public async Task PostUser_CorrectData_StatusCode400(int DiscordTokenId, int GithubTokenId, string AppNickname, string Password)
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new UsersController(classTest.getContext());
            PostUserDto user = new PostUserDto
            {
                DiscordTokenId = DiscordTokenId,
                GithubTokenId = GithubTokenId,
                AppNickname = AppNickname,
                Password = Password,
            };

            //Arrange 
            var result = await controller.PostUser(user);


            //Assert
            var okResult = result.Result.Should().BeOfType<ObjectResult>().Subject;
            Assert.Equal(okResult.StatusCode, 400);
        }

        public static IEnumerable<Object[]> TestPostUser_Data_Correct =>
            new List<Object[]>
            {

                    new object[] { 3, 3, "test5", "1234"},
                    new object[] { 45, 10,"nana", "1234" },
                    new object[] { 2, 0, "", "1234"},
                    new object[] { null, null,  "test10", "1234" },

            };
        public static IEnumerable<Object[]> TestPostUser_Data_Wrong =>
          new List<Object[]>
          {

                    new object[] { 3, 3, "test1", "1234"},
                    new object[] { 45, 10,"test2", "1234" },
                    new object[] { 2, 0, "test3", ""},
          };
    }


}


public class MyDbSetupCode : IDisposable
{
    public MyDbSetupCode()
    {
        // setup code
    }

    public void Dispose()
    {
        // clean-up code
    }
}


