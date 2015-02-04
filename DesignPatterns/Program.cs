using OpenQA.Selenium;
using System;

namespace AutomationRhapsody.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string browser = "Chrome";
            WebDriverFacade webDriver = new WebDriverFacade(browser);
            webDriver.Start("http://automationrhapsody.com/examples/utf8icons.html");


            /* Example for Null Object patterns */
            // Location of elements is inside tests logic which is confusing
            // One element can be needed in several tests this will require locating it several times
            IWebElement element = webDriver.FindElement(By.CssSelector("notExisting"));
            element.Click();

            // Because we use singleton it is possible to compare for the Null Object
            if (element == NullWebElement.NULL)
            {
                Console.WriteLine("Element not found!");
            }


            /* Example for Page Objects pattern */
            HomePageObject homePage = new HomePageObject(webDriver);
            // One element is defined on only one place - we do not repeat ourselves
            Console.WriteLine("Search label is: " + homePage.GetSearchLabel());
            homePage.ClearSearch();
            homePage.SearchFor("automation");

            webDriver.Stop();
        }
    }
}
