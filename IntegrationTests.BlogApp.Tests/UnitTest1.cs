using BlogApp.ClassLib.Model;
using BlogWebApi.Controllers;
using BlogWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace IntegrationTests.BlogApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver? _webDriver;

        [TestInitialize]
        public void setup()
        {
            //Setup
           new DriverManager().SetUpDriver(new ChromeConfig());
           _webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void TestHomeLoginTitle()
        {
            _webDriver?.Navigate().GoToUrl("https://localhost:7104/login");
            Assert.IsTrue(_webDriver?.Title.Contains("Login"));
        }
       

        [TestCleanup]
        public void TearDown()
        {
            // Teaar down
           _webDriver?.Quit();
        }
    }
}