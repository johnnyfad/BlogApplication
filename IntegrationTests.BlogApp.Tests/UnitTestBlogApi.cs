using BlogApp.ClassLib.Model;
using BlogWebApi.Controllers;
using BlogWebApi.Data;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.BlogApp.Tests
{
    [TestClass]
    public class UnitTestBlogApi
    {
        [Fact]
        [TestMethod]
        public async Task GetBlog_Returns_The_Correct_Number_of_Categories()
        {
            int count = 6;
            var faceRecipes = A.CollectionOfDummy<Blog>(count).AsEnumerable();
            var context = A.Fake<BlogWebApi.Data.SqlServerDbContext>();
            foreach (Blog category in faceRecipes)
            {
                A.CallTo(() => context.Blog.Add(category));
            }
            var controller = new BlogWebApi.Controllers.BlogController(context);

            var actionResult = await controller.getRecipes();

            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<Blog>;
            Assert.Equals(count, returnCategories.Count());
        }
        [Fact]
        [TestMethod]
        public async Task blogCreateAndControlCheck()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                    options.UseSqlServer("Data Source=(local); Initial Catalog=Blog; trusted_connection=yes; TrustServerCertificate=True"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();


                var controller = new BlogController(dbContext); // Instantiate your controller
                Blog user = new Blog(0, "https://miro.medium.com/v2/resize:fit:720/0*_82itPxsjjcCsFb4", "Test Blog", "Blog exp.", 2);
                // Act
                var result = controller.Create(user);

                // Assert
                Assert.IsNotNull(result);


            }
        }
        [Fact]
        [TestMethod]
        public async Task addUser()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                    options.UseSqlServer("Data Source=(local); Initial Catalog=Blog; trusted_connection=yes; TrustServerCertificate=True"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();


                var controller = new UserController(dbContext); // Instantiate your controller
                User user = new User(0, "John", "Olay", "john@gmail.com", "1234");
                // Act
                var result = controller.Create(user);

                // Assert
                Assert.IsNotNull(result);


            }
        }

    }
}
