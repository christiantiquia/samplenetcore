using Microsoft.AspNetCore.Mvc;
using Snp.Sample.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Snp.Sample.Web.Tests.Controllers
{
    public class ValuesControllerTest
    {
        public ValuesControllerTest()
        {

        }

        [Fact]
        public void Get_ReturnsValues_WithAListOfString()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.Equal(2, result.Value.Count());
        }


        [Fact]
        public void Get_ReturnsValues_WithAStringValue()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.Equal("value1", result.Value.FirstOrDefault());
        }


        [Fact]
        public void GetById_ReturnsSingleValue_WithAStringValue()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get(1);

            // Assert
            Assert.Equal("value", result.Value);
        }


        [Fact]
        public void Post_ValidString_ReturnsOk()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Post("test");
            var okResult = result as OkResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("   ")]
        public void Post_EmptyNullWhiteSpaceString_ReturnsBadRequest(string value)
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Post(value);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
