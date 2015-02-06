using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationRhapsody.DesignPatterns
{
    public class WebDriverFactory
    {
        public IWebDriver CreateInstance(Browsers browser)
        {
            if (Browsers.Chrome == browser)
            {
                return new ChromeDriver();
            }
            else if (Browsers.IE == browser)
            {
                return new InternetExplorerDriver();
            }
            else
            {
                return new FirefoxDriver();
            }
        }
    }
}
