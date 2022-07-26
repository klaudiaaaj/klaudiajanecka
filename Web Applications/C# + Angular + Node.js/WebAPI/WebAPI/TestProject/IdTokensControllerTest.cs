using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;
using WebAPI.Dto;

namespace TestProject
{
    public class  IdTokensControllerTest
    {
        //TESTS
        //FACTS

        [Fact]
        public async Task GetIdTokens_List_True()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new IdTokensController(classTest.getContext());

            // Act
            var result = await controller.GetIdTokens();

            // Assert
            Assert.Equal(result.Value.Count(), 3); 
        }
        [Fact]
        public async Task GetIdToken_IdToken_True()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new IdTokensController(classTest.getContext());

            // Act
            var result = await controller.GetIdToken(1);

            // Assert
            Assert.Equal("Nickname3", result.Value.Nickname);
        }
        [Fact]
        public async Task GetIdToken_IdToken_NotFoundResult()
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new IdTokensController(classTest.getContext());

            // Act
            var result = await controller.GetIdToken(2);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }
        
        //THEORY

        [Theory]
        [MemberData(nameof(TestPostUser_Data_Correct))]
        public async Task PostUser_CorrectData_True(  int? UserId,int PlatformId,string Nickname,string PlatformUserId,int? Exp,int? Iat)
        {
            //Arrange
            var classTest = new TestHelper();
            var controller = new IdTokensController(classTest.getContext());
            PostIdTokenDto idTokenDto = new PostIdTokenDto
            {
                Exp = Exp,
                Iat = Iat,
                Nickname = Nickname,
                PlatformId = PlatformId,
                PlatformUserId = PlatformUserId,
                UserId = UserId,
            };

            //Arrange 
            var result = await controller.PostIdToken(idTokenDto);

            //Assert
            var okResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;

            var idTokenCreated = okResult.Value.Should().BeAssignableTo<PostIdTokenDto>().Subject;
            idTokenCreated.PlatformUserId.Should().Be(PlatformUserId);
        }

        //TEST DATA
        public static IEnumerable<Object[]> TestPostUser_Data_Correct =>
          new List<Object[]>
          {

                    new object[] { 34243, 1, "test1", "123234",2313,231312},
                    new object[] { 34243, 1, "test2", "123234",2313,231312},
                    new object[] { 34243, 1, "test3", "123234",2313,231312},
                    new object[] { 34243, 1, "test4", "123234",2313,231312},
          };
    }
}
