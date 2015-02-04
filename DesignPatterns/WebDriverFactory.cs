using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationRhapsody.DesignPatterns
{
    class WebDriverFactory
    {
        public IWebDriver CreateInstance(string browser)
        {
            if ("Chrome".ToLower() == browser.ToLower())
            {
                return new ChromeDriver();
            }
            else
            {
                return new FirefoxDriver();
            }
        }
    }
}
