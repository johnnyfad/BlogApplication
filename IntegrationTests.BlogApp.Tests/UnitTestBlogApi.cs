using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.BlogApp.Tests
{
    internal class UnitTestBlogApi
    {
        [Fact]
        [TestMethod]
        public async Task GetBlog_Returns_The_Correct_Number_of_Categories()
        {
            int count = 6;
            var faceRecipes = A.CollectionOfDummy<BlogWebApi.Model.Blog>(count).AsEnumerable();
            var context = A.Fake<BlogWebApi.Data.SqlServerDbContext>();
            foreach (BlogWebApi.Model.Blog category in faceRecipes)
            {
                A.CallTo(() => context.Blog.Add(category));
            }
            var controller = new BlogWebApi.Controllers.BlogController(context);

            var actionResult = await controller.getRecipes();

            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<BlogWebApi.Model.Blog>;
            Assert.Equals(count, returnCategories.Count());
        }
    }
}
