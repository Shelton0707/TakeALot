using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;


new DriverManager().SetUpDriver(new EdgeConfig());

IWebDriver driver = new EdgeDriver();

driver.Navigate().GoToUrl("https://github.com");
driver.Manage().Window.Maximize();


IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
searchInput.SendKeys("selenium");
searchInput.SendKeys(Keys.Enter);


driver.Quit();
IList<string> repositories = driver.FindElements(By.CssSelector(".repo-list-item"))
    .Select(item => item.Text.ToLower())
    .ToList();

IList<string> containingSearch = repositories.Where(item => item.Contains("selenium"))
    .ToList();

Assert.AreEqual(containingSearch, repositories);



