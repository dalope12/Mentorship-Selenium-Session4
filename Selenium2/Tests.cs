using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Selenium2
{
    public class Tests
    {
        IWebDriver webdriver;

        [SetUp]
        public void Setup()
        {
            webdriver = new ChromeDriver("C:\\Drivers\\mentor\\");
        }

        [Test, Category("Regression"), Category("Production"), Category("Stage"), Category("Test")]
        [Author("Daniel Lopez")]
        public void FirstTest()
        {
            // URL
            webdriver.Url = "https://www.google.com";

            // Tittle
            string urlTittle = webdriver.Title;
            Console.WriteLine(urlTittle);

            // Refresh
            webdriver.Navigate().Refresh();

            By locatorSearchInput = By.Name("q");
            By locatorGoogleSearchButton = By.ClassName("gNO89b");

            webdriver.FindElement(locatorSearchInput).SendKeys("Query");
            webdriver.FindElements(locatorGoogleSearchButton)[1].Click();

            // webdriver.FindElement(locatorSearchInput).SendKeys(Keys.Enter);

            // Close
            webdriver.Close();

            // Quit
            webdriver.Quit();
            Assert.Pass();
        }

        [Test, Category("E2E"), Category("Production")]
        // Specifies that a test method should be rerun on failure a number of times.
        [Retry(2)]
        public void Test2()
        {
            // Go to the URL.
            webdriver.Url = "https://www.google.com";

            // Return true/false if the page title contains "hola".
            var tittleBool = webdriver.Title.Contains("hola");

            // Close the driver instance.
            webdriver.Close();
            webdriver.Quit();

            // Assert that the title of the page contains "hola" text.
            Assert.True(tittleBool, "The page title is not 'hola'.");
        }

        [Test, Category("E2E"), Category("Production")]
        [Retry(2)]
        public void Test3()
        {
            // Go to the URL.
            webdriver.Url = "https://www.google.com";

            // Get the page title text.
            var titleText = webdriver.Title;

            // Close the driver instance.
            webdriver.Close();
            webdriver.Quit();

            // Assert that the title of the page contains "hola" text.
            Assert.That(titleText.Contains("hola"), $"The page title is not 'hola', is: {titleText}");
        }

        // Types of Locators

        //By.Id("");
        //By.Name("");
        //By.ClassName("");
        //By.TagName("");
        //By.LinkText("");
        //By.PartialLinkText("");
        //By.CssSelector("");
        //By.XPath("");
    }
}